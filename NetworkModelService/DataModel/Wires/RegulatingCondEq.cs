using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class RegulatingCondEq : ConductingEquipment
    {
        private List<long> controls = new List<long>();
        private long regulatingControl = 0;

        public RegulatingCondEq(long globalId) : base(globalId)
        {

        }

        public List<long> Controls { get => controls; set => controls = value; }
        public long RegulatingControl { get => regulatingControl; set => regulatingControl = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                RegulatingCondEq x = (RegulatingCondEq)obj;
                return (x.regulatingControl == this.regulatingControl && CompareHelper.CompareLists(x.controls, this.controls, true));
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
                case ModelCode.REGULATINGCONDEQ_CTRL:
                case ModelCode.REGULATINGCONDEQ_REGULATINGCTRL:
                
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.REGULATINGCONDEQ_CTRL:
                    prop.SetValue(controls);
                    break;

                case ModelCode.REGULATINGCONDEQ_REGULATINGCTRL:
                    prop.SetValue(regulatingControl);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.REGULATINGCONDEQ_REGULATINGCTRL:
                    regulatingControl = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }
        public override bool IsReferenced
        {
            get
            {
                return controls.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regulatingControl != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.REGULATINGCTRL_REGULATINGCONDEQ] = new List<long>();
                references[ModelCode.REGULATINGCTRL_REGULATINGCONDEQ].Add(regulatingControl);
            }
            if (controls != null && controls.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.REGULATINGCONDEQ_CTRL] = controls.GetRange(0, controls.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.CONTROL_REGULATINGCONDEQ:
                    controls.Add(globalId);
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
                case ModelCode.CONTROL_REGULATINGCONDEQ:

                    if (controls.Contains(globalId))
                    {
                        controls.Remove(globalId);
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
