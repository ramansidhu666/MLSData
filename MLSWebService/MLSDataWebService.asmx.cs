using System.Web.Services;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MLSWebService
{
    /// <summary>
    /// Summary description for MLSDataWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MLSDataWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable GetResidentialProperties(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BedRooms, string BathRooms, string SaleLease)
        {
            DataTable dtMLS = new DataTable("MLSDATA");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BedRooms = BedRooms;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            return dtMLS = obj.GetResidentialProperties();
        }
         [WebMethod]
        public DataTable GetResidentialPropertiesTop3(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BedRooms, string BathRooms, string SaleLease)
        {
            DataTable dtMLS = new DataTable("MLSDATA");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BedRooms = BedRooms;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            return dtMLS = obj.GetResidentialPropertiesTop3();
        }
        [WebMethod]
         public DataTable GetResidentialPropertiesTop10(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BedRooms, string BathRooms, string SaleLease)
         {
             DataTable dtMLS = new DataTable("MLSDATA");
             MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
             obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
             obj.PropertyType = propertyType;
             obj.MinPrice = MinPrice;
             obj.MaxPrice = MaxPrice;
             obj.BedRooms = BedRooms;
             obj.BathRooms = BathRooms;
             obj.SaleLease = SaleLease;
             return dtMLS = obj.GetResidentialPropertiesTop10();
         }

        [WebMethod]
        public DataTable GetPropertyTypesResidential()
        {
            DataTable dtMLS = new DataTable("MLSDATA");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetPropertyTypes();
        }

        [WebMethod]
        public DataTable GetPropertyTypesCommercial()
        {
            DataTable dtMLS = new DataTable("MLSDATA_Comm");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetPropertyTypes_Comm();
        }

        [WebMethod]
        public DataTable GetPropertyTypesCondo()
        {
            DataTable dtMLS = new DataTable("MLSDATA_Condo");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetPropertyTypes_Condo();
        }

        [WebMethod]
        public DataTable GetPropertyTypesByMLSID(string mlsid)
        {
            DataTable dtMLS = new DataTable("MLSDATA");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetPropertyTypeByMLSID(mlsid);
        }

        [WebMethod]
        public DataTable GetSaleLeaseResidential()
        {
            DataTable dtMLS = new DataTable("SaleLease_Res");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetSaleLease_Residential();
        }

        [WebMethod]
        public DataTable GetSaleLeaseCommercial()
        {
            DataTable dtMLS = new DataTable("SaleLease_Comm");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetSaleLease_Comm();
        }

        [WebMethod]
        public DataTable GetSaleLeaseCondo()
        {
            DataTable dtMLS = new DataTable("SaleLease_Condo");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetSaleLease_Condo();
        }

        [WebMethod]
        public DataTable GetImageByMLSID(string MLSID_City_PostalCode)
        {
            DataTable dtMLSImage = new DataTable();
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = "";
            obj.MinPrice = "";
            obj.MaxPrice = "";
            obj.BedRooms = "";
            obj.BathRooms = "";
            obj.SaleLease = "";
            dtMLSImage = obj.GetResidentialProperties();

            DataTable dtFiles = new DataTable("Images");
            dtFiles.Columns.Add("MLSID", typeof(System.String));
            dtFiles.Columns.Add("MLSImage", typeof(System.String));

            string sourcePath;

            if (dtMLSImage.Rows[0]["VOX"].ToString().ToLower() == "false")

                sourcePath = Server.MapPath("IDXImagesResidential/");
            else
                sourcePath = Server.MapPath("VoxResidential/");

            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            foreach (DataRow dr in dtMLSImage.Rows)
            {
                foreach (FileInfo files in dir.GetFiles("Photo" + dr["MLS"].ToString() + "*.*"))
                {
                    DataRow d = dtFiles.NewRow();
                    d[0] = dr["MLS"].ToString();
                    d[1] = dr["serverimagepath"].ToString() + files.Name;

                    dtFiles.Rows.Add(d);
                }
            }

            return dtFiles;
        }

        [WebMethod]
        public DataTable GetCommercialPropertiesByMLSID(string MLSID)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Comm");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID;
            obj.PropertyType = "";
            obj.MinPrice = "";
            obj.MaxPrice = "";
            obj.BathRooms = "";
            obj.SaleLease = "";
            dtMLSImage = obj.PropertyData_Comm();

            DataTable dtFiles = new DataTable("MLSDATA_Comm_Images");
            dtFiles.Columns.Add("MLSID", typeof(System.String));
            dtFiles.Columns.Add("MLSImage", typeof(System.String));
            string sourcePath;
            if (dtMLSImage.Rows[0]["VOX"].ToString().ToLower() == "false")

                sourcePath = Server.MapPath("IDXImagesCommercial/");
            else
                sourcePath = Server.MapPath("VoxCommercial/");

            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            foreach (DataRow dr in dtMLSImage.Rows)
            {
                foreach (FileInfo files in dir.GetFiles("Photo" + dr["MLS"].ToString() + "*.*"))
                {
                    DataRow d = dtFiles.NewRow();
                    d[0] = dr["MLS"].ToString();
                    d[1] = dr["serverimagepath"].ToString() + files.Name;

                    dtFiles.Rows.Add(d);
                }
            }

            return dtFiles;
        }

        [WebMethod]
        public DataTable GetAllCommercialProperties(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BathRooms, string SaleLease)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Comm_All");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            dtMLSImage = obj.PropertyData_Comm();

            return dtMLSImage;
        }
        [WebMethod]
        public DataTable GetAllCommercialPropertiesTop3(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BathRooms, string SaleLease)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Comm_All");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            dtMLSImage = obj.PropertyData_CommTop3();

            return dtMLSImage;
        }
        [WebMethod]
        public DataTable FeatureListing(string MLSIDs)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Comm");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            dtMLSImage = obj.FeatureListing(MLSIDs);
            return dtMLSImage;
        }

        public DataTable FeatureListingTop3(string MLSIDs)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Comm");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            dtMLSImage = obj.FeatureListingTop3(MLSIDs);
            return dtMLSImage;
        }

        [WebMethod]
        public DataTable GetProperties_Condo(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BedRooms, string BathRooms, string SaleLease)
        {
            DataTable dtMLS = new DataTable("MLSDATA_Condo");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BedRooms = BedRooms;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            return dtMLS = obj.GetProperties_Condo();
        }

        [WebMethod]
        public DataTable GetProperties_CondoTop3(string MLSID_City_PostalCode, string propertyType, string MinPrice, string MaxPrice, string BedRooms, string BathRooms, string SaleLease, string Top)
        {
            DataTable dtMLS = new DataTable("MLSDATA_Condo");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID_City_PostalCode;
            obj.PropertyType = propertyType;
            obj.MinPrice = MinPrice;
            obj.MaxPrice = MaxPrice;
            obj.BedRooms = BedRooms;
            obj.BathRooms = BathRooms;
            obj.SaleLease = SaleLease;
            return dtMLS = obj.GetProperties_CondoTop3();
        }

        [WebMethod]
        public DataTable GetPropertiesByMLSID_Condo(string MLSID)
        {
            DataTable dtMLSImage = new DataTable("MLSDATA_Condo");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            obj.MLSID_City_PostalCode = MLSID;
            obj.PropertyType = "";
            obj.MinPrice = "";
            obj.MaxPrice = "";
            obj.BathRooms = "";
            obj.BedRooms = "";
            obj.SaleLease = "";
            dtMLSImage = obj.GetProperties_Condo();

            DataTable dtFiles = new DataTable("MLSDATA_Condo_Images");
            dtFiles.Columns.Add("MLSID", typeof(System.String));
            dtFiles.Columns.Add("MLSImage", typeof(System.String));

            string sourcePath;
            if (dtMLSImage.Rows[0]["VOX"].ToString().ToLower() == "false")
                sourcePath = Server.MapPath("IDXImagesCondo/");
            else
                sourcePath = Server.MapPath("VoxCondo/");


            DirectoryInfo dir = new DirectoryInfo(sourcePath);
            foreach (DataRow dr in dtMLSImage.Rows)
            {
                foreach (FileInfo files in dir.GetFiles("Photo" + dr["MLS"].ToString() + "*.*"))
                {
                    DataRow d = dtFiles.NewRow();
                    d[0] = dr["MLS"].ToString();
                    d[1] = "http://mls.amebasoftware.com/IDXImagesCondo/" + files.Name;
                    dtFiles.Rows.Add(d);
                }
            }

            return dtFiles;
        }

        [WebMethod]
        public DataTable GetAutoCompleteData(string prefixText)
        {
            List<String> itemNames = new List<String>();
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dt = obj.GetAutoCompleteData(prefixText);
            return dt;
        }

        [WebMethod]
        public DataTable GetAutoCompleteData_Comm(string prefixText)
        {
            List<String> itemNames = new List<String>();
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dt = obj.GetAutoCompleteData_Comm(prefixText);
            return dt;
        }

        [WebMethod]
        public DataTable GetAutoCompleteData_Condo(string prefixText)
        {
            List<String> itemNames = new List<String>();
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dt = obj.GetAutoCompleteData_Condo(prefixText);
            return dt;
        }

        [WebMethod]
        public DataTable GetAllFeatures()
        {
            DataTable dtMLS = new DataTable("AllData");
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

            return dtMLS = obj.GetFeatures();
        }
        [WebMethod]
        public int DeleteFeatures(string MLSIDs)
        {

            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            //obj.MLSID_City_PostalCode= MLSIDs;
            int dtMLSImage = obj.DeleteFeature(MLSIDs);
            return dtMLSImage;
        }



        //virtual tour services
        [WebMethod]
        public string GetAllVirtualTourData(int startindex, int pagesize)
        {
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("VirtualToolData");
            dtMLS = obj.GetAllVirtualTourImagesData(startindex, pagesize);
            if (dtMLS.Rows.Count > 0)
            {
                return SuccessJsonParameters(dtMLS);
            }
            else
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "no mls found(s)";
                return SimpleCreateJsonParameters(dtErrorMSg);
            }
        }

        [WebMethod]
        public string GetVirtualTourData(String MLSID)
        {
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("VirtualToolData");
            dtMLS = obj.GetVirtualToolDataByMLSID(MLSID);
            if (dtMLS.Rows.Count > 0)
            {
                return SuccessJsonParameters(dtMLS);
            }
            else
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "no mls found(s)";
                return SimpleCreateJsonParameters(dtErrorMSg);
            }
        }

        [WebMethod]
        public string InsertVertualTourImages(String MLSID, String VimageBase64)
        {
            int IsInserted = 0;
            string result = "";
            string path = "";
            string ImageName = "";
            try
            {
                MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

                if (!Directory.Exists(Server.MapPath(@"~\VertualImages\" + MLSID + "")))
                {
                    Directory.CreateDirectory(Server.MapPath(@"~\VertualImages\" + MLSID + ""));
                }

                if (VimageBase64 != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(VimageBase64);

                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    ms.Write(imageBytes, 0, imageBytes.Length);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

                    ImageName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    path = Server.MapPath(@"~\VertualImages\" + MLSID + @"\" + "") + ImageName;

                    image.Save(path);
                }

                string SavePath = "http://mls.amebasoftware.com/VertualImages/" + MLSID + @"/" + ImageName;

                IsInserted = obj.InsertVirtualToolImage(MLSID, SavePath);
                if (IsInserted > 0)
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tblError";
                    dtErrorMSg.Columns.Add("Url", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Url"] = SavePath;
                    result = SimpleCreateJsonParameters(dtErrorMSg);
                }
                else
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tblError";
                    dtErrorMSg.Columns.Add("Message", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "not inserted";
                    result = SimpleCreateJsonParameters(dtErrorMSg);
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        [WebMethod]
        public string IsValidMLSID(String MLSID)
        {
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("VirtualToolData");
            dtMLS = obj.GetIsValidMLS(MLSID);
            if (dtMLS.Rows.Count > 0)
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "Valid";
                return SimpleCreateJsonParameters(dtErrorMSg);
            }
            else
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "Invalid";
                return SimpleCreateJsonParameters(dtErrorMSg);
            }
        }


        //Registration-new mthods
        [WebMethod]
        public string Registration(String name, String emailID, String password)
        {
            //Registraion method for Virtual tour
            string result = "";
            int rtnValue = 0;
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtIsExistEmail = new DataTable("IxEmailExist");
            dtIsExistEmail = obj.IsExistEmail(emailID);
            if (dtIsExistEmail.Rows.Count > 0)
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "Email already exists";
                result = SimpleCreateJsonShowMessage("Email already exists");

            }
            else
            {
                rtnValue = obj.InsertRegistration(name, emailID, password);
                if (rtnValue > 0)
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tbMsg";
                    dtErrorMSg.Columns.Add("UserID", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["UserID"] = rtnValue;
                    result = SimpleCreateJsonShowMessage("Successfull");
                }
                else
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tblError";
                    dtErrorMSg.Columns.Add("Message", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "Unsuccessfull";
                    result = SimpleCreateJsonShowMessage("Unsuccessfull");
                }

            }

            return result;

        }

        [WebMethod]
        public string AuthenticateUser(string emailid, string password)
        {
            string result = "";
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("LoginCheck");
            dtMLS = obj.LoginCheck(emailid, password);
            if (dtMLS.Rows.Count > 0)
            {
                result = SuccessJsonParameters(dtMLS, "Successfull");
            }
            else
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "invalid user/password";
                result = SimpleCreateJsonShowMessage("invalid user/password");
            }
            return result;
        }

        //insert virtual name for create new virtual tour
        [WebMethod]
        public string InsertVertualDetails(String virtualname, int userid)
        {
            string result = "";

            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            Guid gid;
            gid = Guid.NewGuid();
            string TourLink = "http://mls.amebasoftware.com/VirtualTour.aspx?tour=" + gid;

            result = obj.InsertVertualTourDetails(gid, virtualname, userid, TourLink);
            if (result == "2")
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("Message", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "Virtualname already exist";
                // result = SimpleCreateJsonParameters(dtErrorMSg);
                result = SimpleCreateJsonShowMessage("Virtualname already exist");
            }
            else
            {
                DataTable dtErrorMSg = new DataTable();
                dtErrorMSg.TableName = "tblError";
                dtErrorMSg.Columns.Add("TourLink", typeof(string));
                dtErrorMSg.Columns.Add("TourId", typeof(string));
                dtErrorMSg.Rows.Add();
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["TourLink"] = TourLink;
                dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["TourId"] = result;
                result = SuccessJsonParameters(dtErrorMSg);
            }

            return result;

        }

        //insert virtual tour images.
        [WebMethod]
        public string InsertImageByVirtualName(string VirtualID, int userid, String VimageBase64)
        {
            int IsInserted = 0;
            string result = "";
            string path = "";
            string ImageName = "";
            try
            {
                MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();

                if (!Directory.Exists(Server.MapPath(@"~\VTourImages\" + userid + "")))
                {
                    Directory.CreateDirectory(Server.MapPath(@"~\VTourImages\" + userid + ""));
                }

                if (VimageBase64 != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(VimageBase64);

                    MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                    ms.Write(imageBytes, 0, imageBytes.Length);

                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);

                    ImageName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

                    path = Server.MapPath(@"~\VTourImages\" + userid + @"\" + "") + ImageName;

                    image.Save(path);
                }

                //string SavePath = "http://mls.amebasoftware.com/VTourImages/" + userid + @"/" + ImageName;
                string SavePath = "VTourImages/" + userid + @"/" + ImageName;
                IsInserted = obj.InsertVertualTourImages(VirtualID, userid, SavePath);
                if (IsInserted > 0)
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tblError";
                    dtErrorMSg.Columns.Add("Url", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Url"] = SavePath;
                    result = CustomMsgSuccessJsonParameters(dtErrorMSg, "inserted");
                }
                else
                {
                    DataTable dtErrorMSg = new DataTable();
                    dtErrorMSg.TableName = "tblError";
                    dtErrorMSg.Columns.Add("Message", typeof(string));
                    dtErrorMSg.Rows.Add();
                    dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "not inserted";
                    // result = SimpleCreateJsonParameters(dtErrorMSg);
                    result = SimpleCreateJsonShowMessage("not inserted");
                }

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        [WebMethod]
        public string GetAllOrSingleVirtDetailsByVid(int userid,int startindex,int endindex,string VirtualID = "")
        {
            string result = "";
            string gid = "";
            if (VirtualID == "")
            {
                gid = "00000000-0000-0000-0000-000000000000";
            }
            else
            {
                gid = VirtualID;
            }
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("VirtualDetails");
            dtMLS = obj.GetAllOrSingleVirtualRecord(gid, userid, startindex,endindex);
            if (dtMLS.Rows.Count > 0)
            {
                result = SuccessJsonParameters(dtMLS);
            }
            else
            {
                //DataTable dtErrorMSg = new DataTable();
                //dtErrorMSg.TableName = "tblError";
                //dtErrorMSg.Columns.Add("Message", typeof(string));
                //dtErrorMSg.Rows.Add();
                //dtErrorMSg.Rows[dtErrorMSg.Rows.Count - 1]["Message"] = "no records";
                //result = SimpleCreateJsonParameters(dtErrorMSg);
                result = SimpleCreateJsonShowMessage("no records");
            }
            return result;
        }

        [WebMethod]
        public string ForgotPassword(string emailid)
        {           
            string result = "";
            string password = "";

            try
            {
                var r = new Regex(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");

                string IsValidEmailID = r.IsMatch(emailid).ToString();

                if (IsValidEmailID == "False")
                {
                    result = SimpleCreateJsonShowMessage("Enter valid emailid");
                    return result;
                }
                MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
                DataTable dt = new DataTable();
                dt = obj.IsExistEmail(emailid);
                if (dt.Rows.Count > 0)
                {
                    password = dt.Rows[0]["Password"].ToString();
                    MailAddress mailFrom = new MailAddress(ConfigurationManager.AppSettings["FromMailAddress"].ToString(), "Virtual Tour");
                    MailAddress mailToUser = new MailAddress(emailid);
                    MailMessage mailUser = new MailMessage(mailFrom, mailToUser);
                    mailUser.IsBodyHtml = true;
                    mailUser.Subject = "Virtual Tour Credentials!";
                    mailUser.Body = "EmailID : " + emailid + "<br/>" + "Password : " + password + "<br/>Thanks for using Virtual tour!!";
                    SmtpClient client = new SmtpClient();
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromMailAddress"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
                    client.Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();//host server
                    client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());//port number of host server
                    client.EnableSsl = true;   //secured connection
                    client.Send(mailUser);
                    result = SimpleCreateJsonShowMessage("Your credentials sent successfully to your email address");
                }
                else
                {
                    result = SimpleCreateJsonShowMessage("Email Id doesn't exist");
                }
               

            }
            catch (Exception ex)
            {
                
            }
            return result;
        }

        [WebMethod]
        public string GetAllImagesByVid(int userid,string VirtualID)
        {
            string result = "";           
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            DataTable dtMLS = new DataTable("VirtualTourImages");
            dtMLS = obj.GetAllVirtualTourImagesByVID(VirtualID, userid);
            if (dtMLS.Rows.Count > 0)
            {
                result = SuccessJsonParameters(dtMLS);
            }
            else
            {             
                result = SimpleCreateJsonShowMessage("no images");
            }
            return result;
        }

        [WebMethod]
        public string DeleteImagesByID(int ImageID,string ImageName,string virtualID,int userid)
        {
            string result = "";
            int rtnValue = 0;
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            rtnValue = obj.DeleteImagesByVID(ImageID, virtualID, userid);
            if (rtnValue>0)
            {
                //string path=Server.MapPath("VTourImages/"+userid+"/"+ImageName);
                FileInfo file = new FileInfo(Server.MapPath(ImageName));
                if (file.Exists)
                {
                    file.Delete();
                }
                result = SimpleCreateJsonShowMessage("successfull");
            }
            else
            {
                result = SimpleCreateJsonShowMessage("Unsuccessfull");
            }
            return result;
        }


        [WebMethod]
        public string DeleteTourByVID(string virtualID, int userid)
        {
            string result = "";
            int rtnValue = 0;
            MLSData.DAL.MLSData obj = new MLSData.DAL.MLSData();
            rtnValue = obj.DeleteTourByVID(virtualID, userid);
            if (rtnValue > 0)
            {                
                result = SimpleCreateJsonShowMessage("successfull");
            }
            else
            {
                result = SimpleCreateJsonShowMessage("Unsuccessfull");
            }
            return result;
        }

        //json methods

        //[WebMethod]
        //protected string SuccessJsonParameters(DataTable dt, string Message = "Record found(s)")
        //{
        //    StringBuilder JsonString = new StringBuilder();

        //    //Exception Handling
        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        // JsonString.Append("{ ");
        //        // JsonString.Append("\"Head\":[ ");
        //        JsonString.Append("{Head:{");


        //        JsonString.Append("\"Message\":\"" + Message + "\",data:[");


        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            JsonString.Append("{ ");
        //            for (int j = 0; j < dt.Columns.Count; j++)
        //            {
        //                if (j < dt.Columns.Count - 1)
        //                {
        //                    JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
        //                          "\":" + "\"" +
        //                          RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\",");
        //                }
        //                else if (j == dt.Columns.Count - 1)
        //                {
        //                    JsonString.Append("\"" +
        //                       dt.Columns[j].ColumnName.ToString() + "\":" +
        //                       "\"" + RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\"");
        //                }
        //            }

        //            /*end Of String*/
        //            if (i == dt.Rows.Count - 1)
        //            {
        //                JsonString.Append("} ");
        //            }
        //            else
        //            {
        //                JsonString.Append("}, ");
        //            }
        //        }
        //        JsonString.Append("]");
        //        JsonString.Append("}");
        //        JsonString.Append("}");
        //        //JsonString.Append("]]}");
        //        return JsonString.ToString();
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        [WebMethod]
        protected string SuccessJsonParameters(DataTable dt, string Message = "Record found(s)")
        {
            StringBuilder JsonString = new StringBuilder();

            //Exception Handling
            if (dt != null && dt.Rows.Count > 0)
            {

                // JsonString.Append("{ ");//{”Head":{"Message":"Successfull","data":{"UserID":"23"}}}
                // JsonString.Append("\"Head\":[ ");JsonString.Append("\"Message\":\"" + Message + "\",data:[");
                JsonString.Append("{\"Head\":{");
                JsonString.Append("\"Message\":\"" + Message + "\",\"data\""+":[");


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
                                  "\":" + "\"" +
                                  RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" +
                               dt.Columns[j].ColumnName.ToString() + "\":" +
                               "\"" + RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\"");
                        }
                    }

                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
                JsonString.Append("}");
                JsonString.Append("}");
                //JsonString.Append("]]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        protected string CustomMsgSuccessJsonParameters(DataTable dt, string Message)
        {
            StringBuilder JsonString = new StringBuilder();

            //Exception Handling
            if (dt != null && dt.Rows.Count > 0)
            {
                // JsonString.Append("{ ");
                // JsonString.Append("\"Head\":[ ");
                JsonString.Append("{Head:{");
                JsonString.Append("\"Message\":\"" + Message + "\",data:[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
                                  "\":" + "\"" +
                                  RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" +
                               dt.Columns[j].ColumnName.ToString() + "\":" +
                               "\"" + RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\"");
                        }
                    }

                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }
                JsonString.Append("]");
                JsonString.Append("}");
                JsonString.Append("}");
                //JsonString.Append("]]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        protected string SimpleCreateJsonParameters(DataTable dt)
        {

            StringBuilder JsonString = new StringBuilder();

            //Exception Handling
            if (dt != null && dt.Rows.Count > 0)
            {
                JsonString.Append("{ ");
                JsonString.Append("\"Head\":[ ");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    JsonString.Append("{ ");
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j < dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + dt.Columns[j].ColumnName.ToString() +
                                  "\":" + "\"" +
                                  RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\",");
                        }
                        else if (j == dt.Columns.Count - 1)
                        {
                            JsonString.Append("\"" +
                               dt.Columns[j].ColumnName.ToString() + "\":" +
                               "\"" + RemoveSpecialCharacters(dt.Rows[i][j].ToString()) + "\"");
                        }
                    }

                    /*end Of String*/
                    if (i == dt.Rows.Count - 1)
                    {
                        JsonString.Append("} ");
                    }
                    else
                    {
                        JsonString.Append("}, ");
                    }
                }

                JsonString.Append("]}");
                return JsonString.ToString();
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        protected string RemoveSpecialCharacters(string strData)
        {
            string strResult = "";
            try
            {
                //.&lt;br&gt&#39
                // strData = strData.Replace("\"", "");
                // strData = strData.Replace("/", "");
                //// strData = strData.Replace("!", "");
                // strData = strData.Replace("\n", "");
                // strData = strData.Replace("<br>", "");
                // strData = strData.Replace("\t", "");
                // strData = strData.Replace("<br/>", "");
                // strData = strData.Replace("&#038", "");
                // strData = strData.Replace("&#39", "");
                // strData = strData.Replace("&gt", "");
                // strData = strData.Replace("&lt", "");               
                // strData = strData.Replace("<br/>", "");
                // strData = strData.Replace("<p>", "");
                // strData = strData.Replace("</p>", "");
                // strData = strData.Replace("<span>", "");
                // strData = strData.Replace("</span>", "");
                // strData = strData.Replace("\r", "");
                //// strData = strData.Replace(".", "");
                //strData = strData.Replace("..?", "");
                //strResult = strData.Replace("'", "");
                //strData = strData.Replace(":..", "");
                //strData = strData.Replace("&lt;p", "");
                //strData = strData.Replace("&gt;", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strData;
        }

        [WebMethod]
        protected string SimpleCreateJsonShowMessage(string Message)
        {

            StringBuilder JsonString = new StringBuilder();
            JsonString.Append("{");
            JsonString.Append("\"Head\":{");

            JsonString.Append("\"Message\":" + "\"" +
                                  RemoveSpecialCharacters(Message) + "\"");

            JsonString.Append("}}");

            // {"Head":{"Message":"Email already exists"}}
            return JsonString.ToString();

        }
    }


}
