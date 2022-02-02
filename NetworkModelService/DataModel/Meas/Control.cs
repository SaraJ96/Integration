using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Meas
{
    public class Control : IdentifiedObject
    {
        private long regulatingCondEq = 0;

        public Control (long globalId) : base(globalId)
        {
        }

        public long RegulatingCondEq { get => regulatingCondEq; set => regulatingCondEq = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Control x = (Control)obj;
                return (x.regulatingCondEq == this.regulatingCondEq);
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



        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.CONTROL_REGULATINGCONDEQ:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.CONTROL_REGULATINGCONDEQ:
                    property.SetValue(regulatingCondEq);
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
           
                case ModelCode.CONTROL_REGULATINGCONDEQ:
                    regulatingCondEq = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        //public override bool IsReferenced
        //{
        //    get
        //    {
        //        return regulatingCondEq > 0 || base.IsReferenced;
        //    }
        //}

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (regulatingCondEq != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.REGULATINGCONDEQ_CTRL] = new List<long>();
                references[ModelCode.REGULATINGCONDEQ_CTRL].Add(regulatingCondEq);
            }

            base.GetReferences(references, refType);
        }


    }
}
