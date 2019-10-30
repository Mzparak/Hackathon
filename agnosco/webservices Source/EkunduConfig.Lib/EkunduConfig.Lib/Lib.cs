using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace EkunduConfig
{
    public class Lib
    {
        #region Global Varibles
        public SQLHelper dao = null;
        public  static ArrayList rst_perilTypeCodes = new ArrayList();
        public static string rst_perilGroupCode;
        #endregion

        #region Data Structures
        #region PerilType
        struct perilTypeData
        {
            public string PerilCode;
            public string CaptionDescription;
            public string Description;
            public string IsSumInsured;
            public string ClassOfBusinessCode;
            public string LeadCommissionBand;
            public string LossScheduleTypeId;
            public string SubCommissionBand;
            public string TaxGroup;
            public string IsCompulsoryCoi;
            public string PerilTypeAnalysisId;
            public string GLReference;
            public string EffectiveDate;
            public string IsDeleted;
            public string RateTypeId;
            public string IsPremium;
            public string RIBandCode;
            public string XLBand;
            public string AccumulatedTreatmentType;
            public string GisScreenCode;
            public string IsLevyTax;
            public string IsTaxed;
            public string IsAutoCancel;
            public string IsStampDutyInsurer;
            public string IsStampDutyInsured;
        }

        struct reserveTypeAssociation
        {
            public string Code;
            public string IsMainReserve;
            
        }
        #endregion

        #region PerilGroupAndUsage
        struct perilGroupData
        {
            public string Code;
            public string Description;
            public string IsDeleted;
            public string EffectiveDate;
            public string CaptionDescription;
        }
        struct perilTypeUsage
        {
            public string Id;
            public string PerilTypeCode;
            public string PerilTypeAllocation;
        }
        #endregion

        #region Rating Section Type
        struct ratingSectionTypeData
        {
            public string Caption;
            public string CaptionId;
            public string Code;
            public string CountryId;
            public string CurrencyId;
            public string Description;
            public string EffectiveDate;
            public string IsDeleted;
            public string Rate;
            public string rate_type_id;
            public string StateId;
            public string PerilGroupCode;
            public string PerilTypeCode;
        }
        #endregion

        #region Rating Section Earning Type Patterns
        struct ratingSectionTypeEarningPatternData
        {
            public string EarningPatternCode;
            public string Caption;
            public string CaptionId;
            public string Code;
            public string Description;
            public string EffectiveDate;

        }
        #endregion
        #region Section Type
        struct sectionType
        {
            public string @int;
        }
        #endregion


        #endregion

        public string GetRisk(string code, string filter)
        {
            string result = null;
            Risk risk = new Risk();
            switch (filter)
            {
                case "RS":
                    risk = GetRSTOrchestrator(code, filter);
                    result = JsonConvert.SerializeObject(risk);
                    break;
                case "PG":
                    PerilGroup pg = new PerilGroup();
                    pg = getPerilGroupConfig(code);
                    risk = generateResponceObj(null, pg, null);
                    result = JsonConvert.SerializeObject(risk);
                    break;
                case "PT":
                    ArrayList codes = new ArrayList();
                    codes.Add(code);
                    List<PerilType> ptList = new List<PerilType>();
                    ptList = getPerilTypeConfig(codes);
                    risk = generateResponceObj(ptList, null, null);
                    result = JsonConvert.SerializeObject(risk);
                    break;
                default: break;
            }
            return result;

        }

        public void GenerateXml(string json)
        {
            string perilTypeDir = ConfigurationManager.AppSettings["PerilTypeDir"];
            string perilGroupDir = ConfigurationManager.AppSettings["PerilGroupDir"];
            string ratingSectionDir = ConfigurationManager.AppSettings["RatingSectionTypeDir"];

            if (!Directory.Exists(perilTypeDir))
            {
                Directory.CreateDirectory(perilTypeDir);
            }
            if (!Directory.Exists(perilGroupDir))
            {
                Directory.CreateDirectory(perilGroupDir);
            }
            if (!Directory.Exists(ratingSectionDir))
            {
                Directory.CreateDirectory(ratingSectionDir);
            }

            EkunduConfig.GenXML xmlObj = new GenXML();
            xmlObj = JsonConvert.DeserializeObject<GenXML>(json);
            if (xmlObj.perilTypes != null)
            {
                foreach (PerilType pt in xmlObj.perilTypes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc = customSerializeToXml(pt);
                    if (pt.SectionTypes == null)
                    {
                        XmlNode root1 = doc.DocumentElement;
                        XmlElement sectionElem = doc.CreateElement("SectionTypes");
                        root1.InsertAfter(sectionElem, root1.LastChild);
                    }
                    if (pt.ReserveTypes == null)
                    {
                        XmlNode root1 = doc.DocumentElement;
                        XmlElement reserveElem = doc.CreateElement("ReserveTypes");
                        root1.InsertAfter(reserveElem, root1.LastChild);
                    }
                   
                    doc = blankNameSpaceRemover(doc);

                    doc.Save(perilTypeDir + pt.PerilCode + ".xml");
                }
            }

            if (xmlObj.perilGroups != null)
            {
                foreach (PerilGroup pg in xmlObj.perilGroups)
                {
                    XmlDocument doc = new XmlDocument();
                    doc = customSerializeToXml(pg);
                    doc.Save(perilGroupDir + pg.Code + ".xml");
                }
            }

            if (xmlObj.ratingSectionTypes != null)
            {
                foreach (RatingSectionType rt in xmlObj.ratingSectionTypes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc = customSerializeToXml(rt);
                    doc.Save(ratingSectionDir + rt.Code + ".xml");
                }
            }
        }

        #region Helpers

        #region Peril Type
        private List<PerilType> getPerilTypeConfig(ArrayList perilCodes)
        {
            List<PerilType> perilTypes = new List<PerilType>();
            foreach (var perilCode in perilCodes)
            {
                PerilType result = null;
                DataSet dsResult = null;
                string spName = "EKUNDU_LIB_PERILTYPES";
                SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
                SqlParameter param_PerilTypes = new SqlParameter("PerilCode", perilCode);
                dsResult = SQLHelper.GetDataSet(conn, spName, param_PerilTypes);

                if (dsResult != null)
                {
                    //Generate Peril Type Data Object
                    result = createPerilTypeObj(dsResult.Tables[0]);
                }
                perilTypes.Add(result);
            }
            return perilTypes;
        }
        private PerilType createPerilTypeObj(DataTable dt)
        {
            List<perilTypeData> list = new List<perilTypeData>();
            FieldInfo[] fields = typeof(perilTypeData).GetFields();
            perilTypeData t = Activator.CreateInstance<perilTypeData>();
            PerilType perilType = new PerilType();

            //peril type reserve Type association fields
            FieldInfo[] rtfields = typeof(reserveTypeAssociation).GetFields();
            reserveTypeAssociation rta = Activator.CreateInstance<reserveTypeAssociation>();
            List<ReserveTypeAssociation> list_ptRTA = new List<ReserveTypeAssociation>();

            //peril type section Type association fields
            FieldInfo[] stfields = typeof(sectionType).GetFields();
            sectionType sta = Activator.CreateInstance<sectionType>();
            
            foreach (DataRow dr in dt.Rows)
            {
                if (perilType.PerilCode == null)
                {
                    foreach (FieldInfo fi in fields)
                    {
                        var value = dr[fi.Name].ToString().Trim();
                        if (value != String.Empty)
                        {
                            fi.SetValueDirect(__makeref(t), value);
                            Type type = typeof(PerilType);
                            PropertyInfo[] properties = type.GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                PropertyInfo propertyInfo = type.GetProperty(property.Name);
                                if (property.Name == fi.Name)
                                {
                                    propertyInfo.SetValue(perilType, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                    break;
                                }
                            }
                        }
                    }
                }
                // Reserve types
                ReserveTypeAssociation ptRTA = new ReserveTypeAssociation();
                foreach (FieldInfo fi in rtfields)
                {
                    var value = dr[fi.Name].ToString().Trim();
                    if (value != String.Empty)
                    {
                        fi.SetValueDirect(__makeref(rta), value);
                        Type type = typeof(ReserveTypeAssociation);
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            PropertyInfo propertyInfo = type.GetProperty(property.Name);
                            if (property.Name == fi.Name)
                            {
                                propertyInfo.SetValue(ptRTA, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                list_ptRTA.Add(ptRTA);
                
                //Section Types
                PerilTypeSectionTypes perilTypeSectionTypes = new PerilTypeSectionTypes();
                //Not populating the section types as the S4i Deployment tool does not cater for it.
                //foreach (FieldInfo fi in stfields)
                //{
                //    var value = dr[fi.Name].ToString().Trim();
                //    if (value != String.Empty)
                //    {
                //        fi.SetValueDirect(__makeref(sta), value);
                //        Type type = typeof(PerilTypeSectionTypes);
                //        PropertyInfo[] properties = type.GetProperties();
                //        foreach (PropertyInfo property in properties)
                //        {
                //            PropertyInfo propertyInfo = type.GetProperty(property.Name);
                //            if (property.Name == fi.Name)
                //            {
                //                propertyInfo.SetValue(perilTypeSectionTypes, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                //                break;
                //            }
                //        }
                //    }
                //}
                perilType.SectionTypes = perilTypeSectionTypes;
            }
            perilType.ReserveTypes = list_ptRTA.ToArray();
            return perilType;
        }
        #endregion

        #region Peril Group
        private PerilGroup getPerilGroupConfig(string perilGroupCode)
        {
            PerilGroup result = null;
            DataSet dsResult = null;
            string spName = "EKUNDU_LIB_PERILGROUP";
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            SqlParameter param_PerilGroupCode = new SqlParameter("PerilGroupCode", perilGroupCode);
            dsResult = SQLHelper.GetDataSet(conn, spName, param_PerilGroupCode);

            if (dsResult != null)
            {
                //Generate Peril Group Data Object
                result = createPerilGroupObj(dsResult.Tables[0]);
            }
            return result;
        }

        private  PerilGroup createPerilGroupObj(DataTable dt)
        {
            //peril group fileds
            FieldInfo[] gfields = typeof(perilGroupData).GetFields();
            perilGroupData gd = Activator.CreateInstance<perilGroupData>();

            //peril type usage fields
            FieldInfo[] tufields = typeof(perilTypeUsage).GetFields();
            perilTypeUsage tu = Activator.CreateInstance<perilTypeUsage>();

            PerilGroup perilGroup = new PerilGroup();
            List<PerilTypeUsage> ptu = new List<PerilTypeUsage>();

            foreach (DataRow dr in dt.Rows)
            {
                if (perilGroup.Code == null)
                {
                    foreach (FieldInfo fi in gfields)
                    {
                        var value = dr[fi.Name].ToString().Trim();
                        if (value != String.Empty)
                        {
                            fi.SetValueDirect(__makeref(gd), value);
                            Type type = typeof(PerilGroup);
                            PropertyInfo[] properties = type.GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                PropertyInfo propertyInfo = type.GetProperty(property.Name);
                                if (property.Name == fi.Name)
                                {
                                    propertyInfo.SetValue(perilGroup, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                    break;
                                }
                            }
                        }
                    }
                }
                PerilTypeUsage ptUsage = new PerilTypeUsage();
                foreach (FieldInfo fi in tufields)
                {
                    var value = dr[fi.Name].ToString().Trim();
                    if (value != String.Empty)
                    {
                        fi.SetValueDirect(__makeref(tu), value);
                        Type type = typeof(PerilTypeUsage);
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            PropertyInfo propertyInfo = type.GetProperty(property.Name);
                            if (property.Name == fi.Name)
                            {
                                propertyInfo.SetValue(ptUsage, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                ptu.Add(ptUsage);
            }
            perilGroup.PerilTypeUsageAllocation = ptu.ToArray();
            return perilGroup;
        }
        #endregion

        #region Rating Section Type
        private RatingSectionType getRatingSectionTypeConfig(string ratingSectionTypeCode)
        {
            RatingSectionType result = null;
            DataSet dsResult = null;
            string spName = "EKUNDU_LIB_RatingSectionType";
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            SqlParameter param_ratingSectionTypes = new SqlParameter("RatingSectionTypeCode", ratingSectionTypeCode);
            dsResult = SQLHelper.GetDataSet(conn, spName, param_ratingSectionTypes);

            if (dsResult != null)
            {
                //Generate Rating Section Type Data Object
                result = createRatingSectionTypeObj(dsResult.Tables[0]);
            }
            return result;
        }
        private static RatingSectionType createRatingSectionTypeObj(DataTable dt)
        {
            FieldInfo[] fields = typeof(ratingSectionTypeData).GetFields();
            ratingSectionTypeData t = Activator.CreateInstance<ratingSectionTypeData>();
            RatingSectionType ratingSectionType = new RatingSectionType();

            foreach (DataRow dr in dt.Rows)
            {
                rst_perilTypeCodes.Add(dr["PerilTypeCode"].ToString().Trim());
                if (ratingSectionType.Code == null)
                {
                    rst_perilGroupCode = dr["PerilGroupCode"].ToString().Trim();
                    foreach (FieldInfo fi in fields)
                    {
                        var value = dr[fi.Name].ToString().Trim();
                        if (value != String.Empty)
                        {
                            fi.SetValueDirect(__makeref(t), value);
                            Type type = typeof(RatingSectionType);
                            PropertyInfo[] properties = type.GetProperties();
                            foreach (PropertyInfo property in properties)
                            {
                                PropertyInfo propertyInfo = type.GetProperty(property.Name);
                                if (property.Name == fi.Name)
                                {
                                    propertyInfo.SetValue(ratingSectionType, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return ratingSectionType;
        }
        #endregion

        #region Rating Section Type Earning Patterns
        private List<EarningPatternUsageModel> getRatingSectionTypeEarningPatternConfig(string ratingSectionTypeCode)
        {
            List<EarningPatternUsageModel> result = new List<EarningPatternUsageModel>();
            DataSet dsResult = null;
            string spName = "EKUNDU_LIB_RatingSectionTypeEarningPattern";
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            SqlParameter param_RatingSectionTypeCode = new SqlParameter("RatingSectionTypeCode", ratingSectionTypeCode);
            dsResult = SQLHelper.GetDataSet(conn, spName, param_RatingSectionTypeCode);

            if (dsResult != null)
            {
                //Generate Peril Group Data Object
                result = createRSTEarningPatternObj(dsResult.Tables[0]);

                #region xml gen old code
                //Gnerate XML Doc And Store to Disk
                //XmlDocument doc = new XmlDocument();
                //doc = customSerializeToXml(result);
                //doc.Save(@"C:\Users\mohamedp\Desktop\Test\blah.xml");
                #endregion

            }
            return result;
        }

        private List<EarningPatternUsageModel> createRSTEarningPatternObj(DataTable dt)
        {   
            //RSTEarningPattern fileds
            FieldInfo[]  rsepfields = typeof(ratingSectionTypeEarningPatternData).GetFields();
            ratingSectionTypeEarningPatternData rstepd = Activator.CreateInstance<ratingSectionTypeEarningPatternData>();
            List<EarningPatternUsageModel> result = new List<EarningPatternUsageModel>();

            foreach (DataRow dr in dt.Rows)
            {
                EarningPatternUsageModel epum = new EarningPatternUsageModel();
                foreach (FieldInfo fi in rsepfields)
                {
                    var value = dr[fi.Name].ToString().Trim();
                    if (value != String.Empty)
                    {
                        fi.SetValueDirect(__makeref(rstepd), value);
                        Type type = typeof(EarningPatternUsageModel);
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            PropertyInfo propertyInfo = type.GetProperty(property.Name);
                            if (property.Name == fi.Name)
                            {
                                propertyInfo.SetValue(epum, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                EarningPatternUsageModelEarningPatternModel epumepm = new EarningPatternUsageModelEarningPatternModel();
                foreach (FieldInfo fi in rsepfields)
                {
                    var value = dr[fi.Name].ToString().Trim();
                    if (value != String.Empty)
                    {
                        fi.SetValueDirect(__makeref(rstepd), value);
                        Type type = typeof(EarningPatternUsageModelEarningPatternModel);
                        PropertyInfo[] properties = type.GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            PropertyInfo propertyInfo = type.GetProperty(property.Name);
                            if (property.Name == fi.Name)
                            {
                                propertyInfo.SetValue(epumepm, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                break;
                            }
                        }
                    }
                }
                epum.EarningPatternModel = epumepm;
                result.Add(epum);
            }
          
            return result;
        }
        #endregion

        #region Get Rating Section Orchestrator
        private Risk GetRSTOrchestrator(string code, string filter)
        {
            rst_perilTypeCodes.Clear();
            rst_perilGroupCode = null;
            Risk risk = new Risk();

            //Get Rating Section Type Config
            RatingSectionType rst = new RatingSectionType();
            rst = getRatingSectionTypeConfig(code);
            List<EarningPatternUsageModel> epum = new List<EarningPatternUsageModel>();
            epum = getRatingSectionTypeEarningPatternConfig(code);
            rst.EarningPatternUsage = epum.ToArray();

            // Get Peril Group Config
            PerilGroup pg = new PerilGroup();
            pg = getPerilGroupConfig(rst_perilGroupCode);
            // Get Peril Type Config
            List<PerilType> ptList = new List<PerilType>();
            ptList = getPerilTypeConfig(rst_perilTypeCodes);

            RiskAttributes riskAtt = new RiskAttributes();
            riskAtt.ratingSectionType = rst;
            riskAtt.perilGroup = pg;
            riskAtt.perilTypes = ptList;
            risk.riskAttributes = riskAtt;
            return risk; 
        }
        #endregion
        
        #region Risk Object Generation
        private Risk generateResponceObj(List<PerilType> perilTypes, PerilGroup perilGroup, RatingSectionType ratingSectionType)
        {
            Risk risk = new Risk();
            RiskAttributes riskAtts = new RiskAttributes();
            if (perilTypes != null)
            {
                riskAtts.perilTypes = perilTypes;
            }

            if (perilGroup != null)
            {
                //need to make peril types a list and add foreach loop here 
                riskAtts.perilGroup = perilGroup;
            }

            if (ratingSectionType != null)
            {
                riskAtts.ratingSectionType = ratingSectionType;
            }

            risk.riskAttributes = riskAtts;

            return risk;
        }
        #endregion

        #region XML DOCUMENT GENERATION
        private static XmlDocument customSerializeToXml(object input)
        {
            var document = new XmlDocument();

            XmlSerializer ser = new XmlSerializer(input.GetType());
            string result = string.Empty;

            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, input);

                memStm.Position = 0;
                result = new StreamReader(memStm).ReadToEnd();
                result = result.Replace("<?xml version=\"1.0\"?>", "");
            }
            document.LoadXml(result);
            return document;

        }
        #endregion

        #region XML DOCUMENT Name Space Cleanner
        private XmlDocument blankNameSpaceRemover(XmlDocument dirtyDoc)
        {
            XmlDocument cleanDoc = new XmlDocument();
            XDocument doc = XDocument.Parse(dirtyDoc.OuterXml);
            // All elements with an empty namespace...
            foreach (var node in doc.Root.Descendants()
                                    .Where(n => n.Name.NamespaceName == ""))
            {
               
                node.Attributes("xmlns").Remove();
                node.Name = node.Parent.Name.Namespace + node.Name.LocalName;

                using (var xmlReader = doc.CreateReader())
                {
                    cleanDoc.Load(xmlReader);
                }
            }
           return cleanDoc;
        }
        #endregion
        #endregion

    }
}
