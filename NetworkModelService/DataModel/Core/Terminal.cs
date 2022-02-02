using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject
    {
        private List<long> regulatingControl = new List<long>();

        public Terminal(long globalId) : base(globalId)
        {

        }

        public List<long> RegulatingControl { get => regulatingControl; set => regulatingControl = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return (CompareHelper.CompareLists(x.regulatingControl, this.regulatingControl, true));
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
                case ModelCode.TERMINAL_REGULATINGCTRL:

                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TERMINAL_REGULATINGCTRL:
                    prop.SetValue(regulatingControl);
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
                return regulatingControl.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regulatingControl != null && regulatingControl.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_REGULATINGCTRL] = regulatingControl.GetRange(0, regulatingControl.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.REGULATINGCTRL_TERMINAL:
                    regulatingControl.Add(globalId);
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
                case ModelCode.REGULATINGCTRL_TERMINAL:

                    if (regulatingControl.Contains(globalId))
                    {
                        regulatingControl.Remove(globalId);
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
