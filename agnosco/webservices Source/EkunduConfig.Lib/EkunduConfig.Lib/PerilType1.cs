using System.Xml.Serialization;
using System.Collections.Generic;
namespace EkunduConfig
{
    [XmlRoot(ElementName = "SubCommissionBand", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class SubCommissionBand
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "PerilTypeAnalysisId", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class PerilTypeAnalysisId
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "GLReference", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class GLReference
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "RateTypeId", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class RateTypeId
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "AccumulatedTreatmentType", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class AccumulatedTreatmentType
    {
        [XmlAttribute(AttributeName = "nil", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string Nil { get; set; }
    }

    [XmlRoot(ElementName = "SectionTypes", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class SectionTypes
    {
        [XmlElement(ElementName = "int", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string Int { get; set; }
        [XmlAttribute(AttributeName = "a", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string A { get; set; }
    }

    [XmlRoot(ElementName = "ReserveTypeAssociation", Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/")]
    public class ReserveTypeAssociation
    {
        [XmlElement(ElementName = "Code", Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/")]
        public string Code { get; set; }
        [XmlElement(ElementName = "IsMainReserve", Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/")]
        public string IsMainReserve { get; set; }
    }

    [XmlRoot(ElementName = "ReserveTypes", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class ReserveTypes
    {
        [XmlElement(ElementName = "ReserveTypeAssociation", Namespace = "http://schemas.etana.co.za/ReserveTypeAssociation/")]
        public List<ReserveTypeAssociation> ReserveTypeAssociation { get; set; }
        [XmlAttribute(AttributeName = "a", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string A { get; set; }
    }

    [XmlRoot(ElementName = "PerilType", Namespace = "http://schemas.etana.co.za/PerilType/")]
    public class PerilType1
    {
        [XmlElement(ElementName = "PerilCode", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string PerilCode { get; set; }
        [XmlElement(ElementName = "CaptionDescription", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string CaptionDescription { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string Description { get; set; }
        [XmlElement(ElementName = "IsSumInsured", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsSumInsured { get; set; }
        [XmlElement(ElementName = "ClassOfBusinessCode", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string ClassOfBusinessCode { get; set; }
        [XmlElement(ElementName = "LeadCommissionBand", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string LeadCommissionBand { get; set; }
        [XmlElement(ElementName = "LossScheduleTypeId", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string LossScheduleTypeId { get; set; }
        [XmlElement(ElementName = "SubCommissionBand", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public SubCommissionBand SubCommissionBand { get; set; }
        [XmlElement(ElementName = "TaxGroup", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string TaxGroup { get; set; }
        [XmlElement(ElementName = "IsCompulsoryCoi", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsCompulsoryCoi { get; set; }
        [XmlElement(ElementName = "PerilTypeAnalysisId", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public PerilTypeAnalysisId PerilTypeAnalysisId { get; set; }
        [XmlElement(ElementName = "GLReference", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public GLReference GLReference { get; set; }
        [XmlElement(ElementName = "EffectiveDate", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string EffectiveDate { get; set; }
        [XmlElement(ElementName = "IsDeleted", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsDeleted { get; set; }
        [XmlElement(ElementName = "RateTypeId", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public RateTypeId RateTypeId { get; set; }
        [XmlElement(ElementName = "IsPremium", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsPremium { get; set; }
        [XmlElement(ElementName = "RIBandCode", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string RIBandCode { get; set; }
        [XmlElement(ElementName = "XLBand", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string XLBand { get; set; }
        [XmlElement(ElementName = "AccumulatedTreatmentType", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public AccumulatedTreatmentType AccumulatedTreatmentType { get; set; }
        [XmlElement(ElementName = "GisScreenCode", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string GisScreenCode { get; set; }
        [XmlElement(ElementName = "IsLevyTax", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsLevyTax { get; set; }
        [XmlElement(ElementName = "IsTaxed", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsTaxed { get; set; }
        [XmlElement(ElementName = "IsAutoCancel", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsAutoCancel { get; set; }
        [XmlElement(ElementName = "IsStampDutyInsurer", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsStampDutyInsurer { get; set; }
        [XmlElement(ElementName = "IsStampDutyInsured", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public string IsStampDutyInsured { get; set; }
        [XmlElement(ElementName = "SectionTypes", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public SectionTypes SectionTypes { get; set; }
        [XmlElement(ElementName = "ReserveTypes", Namespace = "http://schemas.etana.co.za/PerilType/")]
        public ReserveTypes ReserveTypes { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
        [XmlAttribute(AttributeName = "i", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string I { get; set; }
    }

}
