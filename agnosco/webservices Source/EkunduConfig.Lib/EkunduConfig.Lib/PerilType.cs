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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/PerilType/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/PerilType/", IsNullable = false)]
    public partial class PerilType
    {

        private string perilCodeField;

        private string captionDescriptionField;

        private string descriptionField;

        private byte isSumInsuredField;

        private string classOfBusinessCodeField;

        private string leadCommissionBandField;

        private byte lossScheduleTypeIdField;

        private object subCommissionBandField;

        private string taxGroupField;

        private byte isCompulsoryCoiField;

        private object perilTypeAnalysisIdField;

        private object gLReferenceField;

        private System.DateTime effectiveDateField;

        private byte isDeletedField;

        private object rateTypeIdField;

        private byte isPremiumField;

        private string rIBandCodeField;

        private byte xLBandField;

        private object accumulatedTreatmentTypeField;

        private string gisScreenCodeField;

        private byte isLevyTaxField;

        private byte isTaxedField;

        private byte isAutoCancelField;

        private byte isStampDutyInsurerField;

        private byte isStampDutyInsuredField;

        private PerilTypeSectionTypes sectionTypesField;

        private ReserveTypeAssociation[] reserveTypesField;

        /// <remarks/>
        public string PerilCode
        {
            get
            {
                return this.perilCodeField;
            }
            set
            {
                this.perilCodeField = value;
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
        public byte IsSumInsured
        {
            get
            {
                return this.isSumInsuredField;
            }
            set
            {
                this.isSumInsuredField = value;
            }
        }

        /// <remarks/>
        public string ClassOfBusinessCode
        {
            get
            {
                return this.classOfBusinessCodeField;
            }
            set
            {
                this.classOfBusinessCodeField = value;
            }
        }

        /// <remarks/>
        public string LeadCommissionBand
        {
            get
            {
                return this.leadCommissionBandField;
            }
            set
            {
                this.leadCommissionBandField = value;
            }
        }

        /// <remarks/>
        public byte LossScheduleTypeId
        {
            get
            {
                return this.lossScheduleTypeIdField;
            }
            set
            {
                this.lossScheduleTypeIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object SubCommissionBand
        {
            get
            {
                return this.subCommissionBandField;
            }
            set
            {
                this.subCommissionBandField = value;
            }
        }

        /// <remarks/>
        public string TaxGroup
        {
            get
            {
                return this.taxGroupField;
            }
            set
            {
                this.taxGroupField = value;
            }
        }

        /// <remarks/>
        public byte IsCompulsoryCoi
        {
            get
            {
                return this.isCompulsoryCoiField;
            }
            set
            {
                this.isCompulsoryCoiField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object PerilTypeAnalysisId
        {
            get
            {
                return this.perilTypeAnalysisIdField;
            }
            set
            {
                this.perilTypeAnalysisIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object GLReference
        {
            get
            {
                return this.gLReferenceField;
            }
            set
            {
                this.gLReferenceField = value;
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
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object RateTypeId
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
        public byte IsPremium
        {
            get
            {
                return this.isPremiumField;
            }
            set
            {
                this.isPremiumField = value;
            }
        }

        /// <remarks/>
        public string RIBandCode
        {
            get
            {
                return this.rIBandCodeField;
            }
            set
            {
                this.rIBandCodeField = value;
            }
        }

        /// <remarks/>
        public byte XLBand
        {
            get
            {
                return this.xLBandField;
            }
            set
            {
                this.xLBandField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public object AccumulatedTreatmentType
        {
            get
            {
                return this.accumulatedTreatmentTypeField;
            }
            set
            {
                this.accumulatedTreatmentTypeField = value;
            }
        }

        /// <remarks/>
        public string GisScreenCode
        {
            get
            {
                return this.gisScreenCodeField;
            }
            set
            {
                this.gisScreenCodeField = value;
            }
        }

        /// <remarks/>
        public byte IsLevyTax
        {
            get
            {
                return this.isLevyTaxField;
            }
            set
            {
                this.isLevyTaxField = value;
            }
        }

        /// <remarks/>
        public byte IsTaxed
        {
            get
            {
                return this.isTaxedField;
            }
            set
            {
                this.isTaxedField = value;
            }
        }

        /// <remarks/>
        public byte IsAutoCancel
        {
            get
            {
                return this.isAutoCancelField;
            }
            set
            {
                this.isAutoCancelField = value;
            }
        }

        /// <remarks/>
        public byte IsStampDutyInsurer
        {
            get
            {
                return this.isStampDutyInsurerField;
            }
            set
            {
                this.isStampDutyInsurerField = value;
            }
        }

        /// <remarks/>
        public byte IsStampDutyInsured
        {
            get
            {
                return this.isStampDutyInsuredField;
            }
            set
            {
                this.isStampDutyInsuredField = value;
            }
        }

        /// <remarks/>
        public PerilTypeSectionTypes SectionTypes
        {
            get
            {
                return this.sectionTypesField;
            }
            set
            {
                this.sectionTypesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReserveTypeAssociation", Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/", IsNullable = false)]
        public ReserveTypeAssociation[] ReserveTypes
        {
            get
            {
                return this.reserveTypesField;
            }
            set
            {
                this.reserveTypesField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/", IsNullable = true)]
    public partial class ReserveTypeAssociation
    {

        private string codeField;

        private byte isMainReserveField;

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
        public byte IsMainReserve
        {
            get
            {
                return this.isMainReserveField;
            }
            set
            {
                this.isMainReserveField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.etana.co.za/PerilType/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.etana.co.za/PerilType/", IsNullable = true)]
    public partial class PerilTypeSectionTypes
    {

        private byte intField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        
        public byte @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }
    }


}
