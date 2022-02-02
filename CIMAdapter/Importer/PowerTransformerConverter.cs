namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;
    using System;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				
			}
		}

        //ima samo listu referenci
		public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimTerminal != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);
				
			}
		}

        public static void PopulateReactiveCapabilityCurveProperties(FTN.ReactiveCapabilityCurve cimReactiveCapabilityCurve, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimReactiveCapabilityCurve != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateCurveProperties(cimReactiveCapabilityCurve, rd, importHelper, report);

            }
        }
        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimPowerSystemResource != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);

			}
		}

        public static void PopulateCurveProperties(FTN.Curve cimCurve, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimCurve != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimCurve, rd);

            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd, importHelper, report);

                if (cimEquipment.AggregateHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_AGGREGATE, cimEquipment.Aggregate));
                }
                if (cimEquipment.NormallyInServiceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMALLYINSERVICE, cimEquipment.NormallyInService));
                }
            }
        }
      

        public static void PopulateRegulatingCondEqProperties(FTN.RegulatingCondEq cimRegulatingCondEq, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRegulatingCondEq != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimRegulatingCondEq, rd, importHelper, report);

            }
        }

        public static void PopulateRotatingMachineProperties(FTN.RotatingMachine cimRotatingMachineResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRotatingMachineResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateRegulatingCondEqProperties(cimRotatingMachineResource, rd, importHelper, report);

            }
        }

        public static void PopulateShuntCompensatorProperties(FTN.ShuntCompensator cimShuntCompensatorResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimShuntCompensatorResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateRegulatingCondEqProperties(cimShuntCompensatorResource, rd, importHelper, report);

            }
        }

        public static void PopulateStaticVarCompensatorProperties(FTN.StaticVarCompensator cimStaticVarCompensatorResource, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimStaticVarCompensatorResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateRegulatingCondEqProperties(cimStaticVarCompensatorResource, rd, importHelper, report);

            }
        }

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd, importHelper, report);

            }
        }
      
        public static void PopulateSynchronousMachineProperties(FTN.SynchronousMachine cimSynchronousMachine, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSynchronousMachine != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateRotatingMachineProperties(cimSynchronousMachine, rd, importHelper, report);

          
                if (cimSynchronousMachine.ReactiveCapabilityCurvesHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSynchronousMachine.ReactiveCapabilityCurves.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSynchronousMachine.GetType().ToString()).Append(" rdfID = \"").Append(cimSynchronousMachine.ID);
                        report.Report.Append("\" - Failed to set reference to RotatingMachine: rdfID \"").Append(cimSynchronousMachine.ReactiveCapabilityCurves.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE, gid));
                }
            }
        }

        public static void PopulateControlProperties(FTN.Control cimControl, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimControl != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimControl, rd);


                if (cimControl.RegulatingCondEqHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimControl.RegulatingCondEq.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimControl.GetType().ToString()).Append(" rdfID = \"").Append(cimControl.ID);
                        report.Report.Append("\" - Failed to set reference to IdentifiedObject: rdfID \"").Append(cimControl.RegulatingCondEq.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.CONTROL_REGULATINGCONDEQ, gid));
                }
            }
        }

       
        public static void PopulateRegulatingControlProperties(FTN.RegulatingControl cimRegulatingCtrl, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRegulatingCtrl != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimRegulatingCtrl, rd, importHelper, report);

                if (cimRegulatingCtrl.DiscreteHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_DISCRETE, cimRegulatingCtrl.Discrete));
                }
                if (cimRegulatingCtrl.ModeHasValue)
                {                                                               //enum
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_MODE, (short)GetDMSRegulatingControlModeKind(cimRegulatingCtrl.Mode)));
                }
                if (cimRegulatingCtrl.MonitoredPhaseHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_MONITOREDPHASE, (short)GetDMSPhaseCode(cimRegulatingCtrl.MonitoredPhase)));
                }
                if (cimRegulatingCtrl.TargetRangeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_TARGETRANGE, cimRegulatingCtrl.TargetRange));
                }
                if (cimRegulatingCtrl.TargetValueHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_TARGETVALUE, cimRegulatingCtrl.TargetValue));
                }

                if (cimRegulatingCtrl.TerminalHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimRegulatingCtrl.Terminal.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimRegulatingCtrl.GetType().ToString()).Append(" rdfID = \"").Append(cimRegulatingCtrl.ID);
                        report.Report.Append("\" - Failed to set reference to PowerSystemResource: rdfID \"").Append(cimRegulatingCtrl.Terminal.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.REGULATINGCTRL_TERMINAL, gid));
                }

            }
  
    }
    #endregion Populate ResourceDescription

    #region Enums convert
    public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		{
			switch (phases)
			{
				case FTN.PhaseCode.A:
					return PhaseCode.A;
				case FTN.PhaseCode.AB:
					return PhaseCode.AB;
				case FTN.PhaseCode.ABC:
					return PhaseCode.ABC;
				case FTN.PhaseCode.ABCN:
					return PhaseCode.ABCN;
				case FTN.PhaseCode.ABN:
					return PhaseCode.ABN;
				case FTN.PhaseCode.AC:
					return PhaseCode.AC;
				case FTN.PhaseCode.ACN:
					return PhaseCode.ACN;
				case FTN.PhaseCode.AN:
					return PhaseCode.AN;
				case FTN.PhaseCode.B:
					return PhaseCode.B;
				case FTN.PhaseCode.BC:
					return PhaseCode.BC;
				case FTN.PhaseCode.BCN:
					return PhaseCode.BCN;
				case FTN.PhaseCode.BN:
					return PhaseCode.BN;
				case FTN.PhaseCode.C:
					return PhaseCode.C;
				case FTN.PhaseCode.CN:
					return PhaseCode.CN;
				case FTN.PhaseCode.N:
					return PhaseCode.N;
				case FTN.PhaseCode.s12N:
					return PhaseCode.ABN;
				case FTN.PhaseCode.s1N:
					return PhaseCode.AN;
				case FTN.PhaseCode.s2N:
					return PhaseCode.BN;
				default: return PhaseCode.Unknown;
			}
		}

        public static RegulatingControlModeKind GetDMSRegulatingControlModeKind(FTN.RegulatingControlModeKind regulatingControlModeKind)
        {
            switch (regulatingControlModeKind)
            {
                case FTN.RegulatingControlModeKind.voltage: //
                    return RegulatingControlModeKind.Voltage; //
                case FTN.RegulatingControlModeKind.activePower:
                    return RegulatingControlModeKind.ActivePower;
                case FTN.RegulatingControlModeKind.reactivePower:
                    return RegulatingControlModeKind.ReactivePower;
                case FTN.RegulatingControlModeKind.currentFlow:
                    return RegulatingControlModeKind.CurrentFlow;
                case FTN.RegulatingControlModeKind.@fixed:
                    return RegulatingControlModeKind.Fixed;
                case FTN.RegulatingControlModeKind.admittance:
                    return RegulatingControlModeKind.Admittance;
                case FTN.RegulatingControlModeKind.timeScheduled:
                    return RegulatingControlModeKind.TimeScheduled;
                case FTN.RegulatingControlModeKind.temperature:
                    return RegulatingControlModeKind.Temperature;
                case FTN.RegulatingControlModeKind.powerFactor:
                    return RegulatingControlModeKind.PowerFactor;
              
                default: return RegulatingControlModeKind.Voltage;
            }
        }




        #endregion Enums convert
    }
}
