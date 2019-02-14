using System;
using System.Data;
using System.Data.SqlClient;
using MLSData.Common;
namespace MLSData.DAL
{
    public class MLSData
    {

        public string MLSID_City_PostalCode
        {
            get;
            set;
        }
        public string SortPrice
        {
            get;
            set;
        }
        public string MinPrice
        {
            get;
            set;
        }
        public string MaxPrice
        {
            get;
            set;
        }
        public string BedRooms
        {
            get;
            set;
        }
        public string BathRooms
        {
            get;
            set;
        }
        public string SaleLease
        {
            get;
            set;
        }

        public Guid GuidID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
       
        public string PropertyType
        {
            get;
            set;
        }


        public DataTable GetResidentialPropertiesDetail()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetResidentialPropertiesDetail";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));

                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetResidentialProperties()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetResidentialProperties";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType",PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
         
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetResidentialPropertiesWithPriceSort()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetResidentialProperties";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SortPrice", SortPrice));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetResidentialPropertiesTop10()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetResidentialPropertiesTop10";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));

                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetResidentialPropertiesTop3()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetResidentialPropertiesTop3";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));

                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable PropertyData_CommTop3()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyData_CommTop3";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable PropertyData_Comm()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyData_Comm";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetProperties_CondoTop3()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetProperties_CondoTop3";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetProperties_Condo()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetProperties_Condo";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID_City_PostalCode", MLSID_City_PostalCode));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PropertyType", PropertyType));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MinPrice", MinPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MaxPrice", MaxPrice));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BedRooms", BedRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@BathRooms", BathRooms));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@SaleLease", SaleLease));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetPropertyTypes()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyTypes";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetPropertyTypes_Comm()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyTypes_Comm";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetPropertyTypes_Condo()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyTypes_Condo";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetSaleLease_Residential()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetSaleLease_Residential";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetSaleLease_Comm()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetSaleLease_Comm";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetSaleLease_Condo()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetSaleLease_Condo";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetAutoCompleteData(string City_PostalCode)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@City_PostalCode", City_PostalCode));
                DataTable dt = objMSSqlHelper.ExecuteDataSet("GetSearchList_Residential").Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetAutoCompleteData_Comm(string City_PostalCode)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@City_PostalCode", City_PostalCode));
                DataTable dt = objMSSqlHelper.ExecuteDataSet("GetSearchList_Comm").Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetAutoCompleteData_Condo(string City_PostalCode)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@City_PostalCode", City_PostalCode));
                DataTable dt = objMSSqlHelper.ExecuteDataSet("GetSearchList_Condo").Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetPropertyTypeByMLSID(string mlsid)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetPropertyTypeByMLSID";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@mlsid", mlsid));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable FeatureListing(string MlsIDs)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetFeatureListingByMLSIDs";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID",MlsIDs));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable FeatureListingTop3(string MlsIDs)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetFeatureListingByMLSIDsTop3";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID", MlsIDs));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetFeatures()
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "sp_Features";
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteFeature(string MLSIDs)
        {
            int result;
            try
            {
              //  DataTable dt = new DataTable("deleteFeatures");
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Mls", MLSIDs));
                string strQuery = "DeleteFeatures";
                
                int dt = objMSSqlHelper.ExecuteNonQuery(strQuery); 
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetAllVirtualTourImagesData(int startindex,int pagesize)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetAllVirtualTourData";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@StartIndex", startindex));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@PageSize", pagesize));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetVirtualToolDataByMLSID(string mlsid)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetVirtualDataByMLSID";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@mlsid", mlsid));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable GetIsValidMLS(string mlsid)
        {
            DataTable result;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "GetIsValidMLSID";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID", mlsid));
                DataTable dt = objMSSqlHelper.ExecuteDataSet(strQuery).Tables[0];
                result = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int InsertVirtualToolImage(string mlsid,string Vimage)
        {
            int result = 0;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                string strQuery = "Sp_InsertVirtualTour";
                objMSSqlHelper.Parameters.Add(new SqlParameter("@MLSID", mlsid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Image", Vimage));
                result = Convert.ToInt32(objMSSqlHelper.ExecuteNonQuery(strQuery));               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int InsertRegistration(string name,string emailid, string password)
        {
            int result = 0;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Name", name));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@EmailID", emailid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Password", password));
                SqlParameter IdParam = new SqlParameter("@UserID", SqlDbType.Int);
                IdParam.Direction = ParameterDirection.Output;
                objMSSqlHelper.Parameters.Add(IdParam);
                objMSSqlHelper.ExecuteNonQuery("SpRegistration");
                result = Convert.ToInt32(IdParam.Value);               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable LoginCheck(string emailid, string Password)
        {
            DataTable dt = new DataTable();
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@EmailId",emailid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Password", Password));
                dt = objMSSqlHelper.ExecuteDataSet("SpLoginCheck").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable IsExistEmail(string emailID)
        {
            DataTable dt = new DataTable();
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@EmailId", emailID));
                dt = objMSSqlHelper.ExecuteDataSet("IsExistEmail").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public string InsertVertualTourDetails(Guid Gid,string virtualname, int userid, string link)
        {
            string result = "";
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();               
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", Gid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@VirtualName", virtualname));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserId", userid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Link", link));
                SqlParameter IdParam = new SqlParameter("@Msg", SqlDbType.Int);
                IdParam.Direction = ParameterDirection.Output;
                objMSSqlHelper.Parameters.Add(IdParam);
                objMSSqlHelper.ExecuteNonQuery("SpInsertVertualDetails");
                result = IdParam.Value.ToString();
                if (result == "2")
                {
                    result = "2";
                }
                else if(result=="")
                {
                    result = Gid.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int InsertVertualTourImages(string Gid, int userid, string imagepath)
        {
            int result = 0;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", Gid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserId", userid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@ImagePath", imagepath));
                //SqlParameter IdParam = new SqlParameter("@Msg", SqlDbType.Int);
                //IdParam.Direction = ParameterDirection.Output;
                //objMSSqlHelper.Parameters.Add(IdParam);
                result = Convert.ToInt32(objMSSqlHelper.ExecuteNonQuery("SpInsertVertualTourImages"));                    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public DataTable GetAllOrSingleVirtualRecord(string Gid,int userid,int startindex,int endindex)
        {
            DataTable dt = new DataTable();
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", Gid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserID", userid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@StartIndex", startindex));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@EndIndex", endindex));
                dt = objMSSqlHelper.ExecuteDataSet("SpGetAllTourDetails").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetAllVirtualTourImagesByVID(string Gid, int userid)
        {
            DataTable dt = new DataTable();
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", Gid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserID", userid));
                dt = objMSSqlHelper.ExecuteDataSet("GetAllImagesByTourID").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public int DeleteImagesByVID(int ImageID,string vid,int userid)
        {
            int result = 0;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@ImageID", ImageID));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", vid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserId", userid));
                result = Convert.ToInt32(objMSSqlHelper.ExecuteNonQuery("DeleteImagesByTourID"));   
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int DeleteTourByVID(string vid, int userid)
        {
            int result = 0;
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", vid));
                objMSSqlHelper.Parameters.Add(new SqlParameter("@UserId", userid));
                result = Convert.ToInt32(objMSSqlHelper.ExecuteNonQuery("DeleteTourByVid"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        //its for web
        public DataTable GetAllImagesByVID(string Gid)
        {
            DataTable dt = new DataTable();
            try
            {
                MSSqlHelper objMSSqlHelper = new MSSqlHelper();
                objMSSqlHelper.Parameters.Add(new SqlParameter("@Vid", Gid));
                dt = objMSSqlHelper.ExecuteDataSet("GetAllImagesByVID").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
