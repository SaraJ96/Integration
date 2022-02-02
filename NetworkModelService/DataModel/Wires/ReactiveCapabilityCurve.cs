using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class ReactiveCapabilityCurve : Curve
    {
        private List<long> synchronousMachine = new List<long>();

        public ReactiveCapabilityCurve(long globalId) : base(globalId)
        {

        }

        public List<long> SynchronousMachine { get => synchronousMachine; set => synchronousMachine = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ReactiveCapabilityCurve x = (ReactiveCapabilityCurve)obj;
                return (CompareHelper.CompareLists(x.synchronousMachine, this.synchronousMachine, true));
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

        public override bool HasProperty(ModelCode t)
        {

            switch (t)
            {
                case ModelCode.REACTIVECAPABILITYCURVE_SYNCMACH:
                
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.REACTIVECAPABILITYCURVE_SYNCMACH:
                    prop.SetValue(synchronousMachine);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }



        public override bool IsReferenced
        {
            get
            {
                return synchronousMachine.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (synchronousMachine != null && synchronousMachine.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.REACTIVECAPABILITYCURVE_SYNCMACH] = synchronousMachine.GetRange(0, synchronousMachine.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE:
                    synchronousMachine.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.SYNCHRONOUSMACHINE_REACTIVECAPABILITYCURVE:

                    if (synchronousMachine.Contains(globalId))
                    {
                        synchronousMachine.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

    }
}
