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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/RatingSectionType/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/RatingSectionType/", IsNullable = false)]
    public partial class RatingSectionType
    {
        private string captionField;

        private ushort captionIdField;

        private string codeField;

        private object countryIdField;

        private object currencyIdField;

        private string descriptionField;

        private EarningPatternUsageModel[] earningPatternUsageField;

        private System.DateTime effectiveDateField;

        private byte isDeletedField;

        private string perilGroupCodeField;

        private decimal rateField;

        private byte rateTypeIdField;

        private object stateIdField;

        /// <remarks/>
        public string Caption
        {
            get
            {
                return this.captionField;
            }
            set
            {
                this.captionField = value;
            }
        }

        /// <remarks/>
        public ushort CaptionId
        {
            get
            {
                return this.captionIdField;
            }
            set
            {
                this.captionIdField = value;
            }
        }

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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object CountryId
        {
            get
            {
                return this.countryIdField;
            }
            set
            {
                this.countryIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object CurrencyId
        {
            get
            {
                return this.currencyIdField;
            }
            set
            {
                this.currencyIdField = value;
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
        [System.Xml.Serialization.XmlArrayItemAttribute("EarningPatternUsageModel", Namespace = "http://schemas.etana.co.za/EarningPatternUsageModel/", IsNullable = false)]
        public EarningPatternUsageModel[] EarningPatternUsage
        {
            get
            {
                return this.earningPatternUsageField;
            }
            set
            {
                this.earningPatternUsageField = value;
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
        public byte IsDeleted
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
        public string PerilGroupCode
        {
            get
            {
                return this.perilGroupCodeField;
            }
            set
            {
                this.perilGroupCodeField = value;
            }
        }

        /// <remarks/>
        public decimal Rate
        {
            get
            {
                return this.rateField;
            }
            set
            {
                this.rateField = value;
            }
        }

        /// <remarks/>
        public byte RateTypeId
        {
            get
            {
                return this.rateTypeIdField;
            }
            set
            {
                this.rateTypeIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object StateId
        {
            get
            {
                return this.stateIdField;
            }
            set
            {
                this.stateIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/EarningPatternUsageModel/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternUsageModel/", IsNullable = false)]
    public partial class EarningPatternUsageModel
    {

        private string earningPatternCodeField;

        private EarningPatternUsageModelEarningPatternModel earningPatternModelField;

        private System.DateTime effectiveDateField;

        private byte isDeletedField;

        private string ratingSectionCodeField;

        /// <remarks/>
        public string EarningPatternCode
        {
            get
            {
                return this.earningPatternCodeField;
            }
            set
            {
                this.earningPatternCodeField = value;
            }
        }

        /// <remarks/>
        public EarningPatternUsageModelEarningPatternModel EarningPatternModel
        {
            get
            {
                return this.earningPatternModelField;
            }
            set
            {
                this.earningPatternModelField = value;
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
        public byte IsDeleted
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
        public string RatingSectionCode
        {
            get
            {
                return this.ratingSectionCodeField;
            }
            set
            {
                this.ratingSectionCodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/EarningPatternUsageModel/")]
    public partial class EarningPatternUsageModelEarningPatternModel
    {

        private string captionField;

        private ushort captionIdField;

        private string codeField;

        private string descriptionField;

        private System.DateTime effectiveDateField;

        private byte isDeletedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
        public string Caption
        {
            get
            {
                return this.captionField;
            }
            set
            {
                this.captionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
        public ushort CaptionId
        {
            get
            {
                return this.captionIdField;
            }
            set
            {
                this.captionIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
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
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
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
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
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
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.etana.co.za/EarningPatternModel/")]
        public byte IsDeleted
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
    }
}

