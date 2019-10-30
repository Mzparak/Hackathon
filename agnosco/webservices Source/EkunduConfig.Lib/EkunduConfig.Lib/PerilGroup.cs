using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkunduConfig
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/PerilGroup/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/PerilGroup/", IsNullable = false)]
    public partial class PerilGroup
    {

        private string codeField;

        private string descriptionField;

        private string isDeletedField;

        private System.DateTime effectiveDateField;

        private string captionDescriptionField;

        private PerilTypeUsage[] perilTypeUsageAllocationField;

        /// <remarks/>
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string IsDeleted
        {
            get
            {
                return this.isDeletedField;
            }
            set
            {
                this.isDeletedField = value;
            }
        }

        /// <remarks/>
        public System.DateTime EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        public string CaptionDescription
        {
            get
            {
                return this.captionDescriptionField;
            }
            set
            {
                this.captionDescriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PerilTypeUsage", Namespace = "http://schemas.datacontract.org/2004/07/Etana.Utilities.S4IDeploy.Models", IsNullable = false)]
        public PerilTypeUsage[] PerilTypeUsageAllocation
        {
            get
            {
                return this.perilTypeUsageAllocationField;
            }
            set
            {
                this.perilTypeUsageAllocationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Etana.Utilities.S4IDeploy.Models")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Etana.Utilities.S4IDeploy.Models", IsNullable = false)]
    public partial class PerilTypeUsage
    {

        private string idField;

        private string perilTypeCodeField;

        private string perilTypeAllocationField;

        private object perilTypeField;

        /// <remarks/>
        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string PerilTypeCode
        {
            get
            {
                return this.perilTypeCodeField;
            }
            set
            {
                this.perilTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string PerilTypeAllocation
        {
            get
            {
                return this.perilTypeAllocationField;
            }
            set
            {
                this.perilTypeAllocationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object PerilType
        {
            get
            {
                return this.perilTypeField;
            }
            set
            {
                this.perilTypeField = value;
            }
        }
    }


}
