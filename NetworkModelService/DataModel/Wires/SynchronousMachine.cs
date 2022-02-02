using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;


namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class SynchronousMachine : RotatingMachine
    {
        private long reactiveCapabilityCurve = 0;

        public SynchronousMachine(long globalId) : base(globalId)
        {

        }

        public long ReactiveCapabilityCurve { get => reactiveCapabilityCurve; set => reactiveCapabilityCurve = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SynchronousMachine x = (SynchronousMachine)obj;
                return (x.reactiveCapabilityCurve == this.reactiveCapabilityCurve);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE:
                    property.SetValue(reactiveCapabilityCurve);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE:
                    reactiveCapabilityCurve = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

       /* public override bool IsReferenced
        {
            get
            {
                return reactiveCapabilityCurve > 0 || base.IsReferenced;
            }
        }*/

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (reactiveCapabilityCurve != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE] = new List<long>();
                references[ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE].Add(reactiveCapabilityCurve);
            }

            base.GetReferences(references, refType);
        }

    }
}
