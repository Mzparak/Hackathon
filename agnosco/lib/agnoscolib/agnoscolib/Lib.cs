using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
namespace agnoscolib
{
    public class Lib
    {

        #region User Related Methods

        #region GetUsers
        public string GetUsers()
        {
            string result = null;
            Users users = new Users();
            DataSet dsResult = null;
            string spName = "Agnosco_GetUsers";
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            dsResult = SQLHelper.GetDataSet(conn, spName);

            if (dsResult != null)
            {
                List<User> userList = new List<User>();
                userList = genUsersObj(dsResult.Tables[0]);
                result = JsonConvert.SerializeObject(userList);
            }

            return result;
        }

        #endregion

        #region ValidateUser
        public string ValidateUser(string UserName)
        {
            string result = null;
            DataSet dsResult = null;
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            string spName = "Agnosco_ValidateUser";
            dsResult = SQLHelper.GetDataSet(
                    conn,
                    spName,
                    SQLHelper.NewVarcharParam("@param_userName", 100, UserName
                ));
            conn.Close();
            if (dsResult != null)
            {
                User user = new User();
                user = genUserObj(dsResult.Tables[0]);
                result = JsonConvert.SerializeObject(user);
            }

            return result;
        }
        #endregion
        #endregion

        #region Nomination Related Methods
        #region Add Nomination
        public void AddNomination(Nomination nomination)
        {
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            string spName = "Agnosco_AddNomination";
            SQLHelper.ExecuteQuery(
                conn,
                spName,
                SQLHelper.NewIntParam("@param_nominator", nomination.Nominator),
                SQLHelper.NewIntParam("@param_nominee", nomination.Nominee),
                SQLHelper.NewVarcharParam("@param_nominationInfo", 4000, nomination.NominationInfo),
                SQLHelper.NewIntParam("@param_points", nomination.Points));

            conn.Close();
        }
        //testmethod genNominationJson
        public string genNominationJson()
        {
            Nomination nom = new Nomination
            {
                Nominator = 2,
                Nominee = 3,
                NominationInfo = "",
                Points = 100
            };
            string result = JsonConvert.SerializeObject(nom);
            return result;
        }
        #endregion
        #endregion



        #region HelperMethods
        private List<User> genUsersObj(DataTable dt)
        {
            List<User> result = new List<User>();
            foreach (DataRow dr in dt.Rows)
            {
                User user = new User();
                user = genUserObjWorker(dr);
                result.Add(user);
            }
            return result;
        }

        private User genUserObj(DataTable dt)
        {
            User user = new User();
            foreach (DataRow dr in dt.Rows)
            {
                user = genUserObjWorker(dr);
            }
            return user;
        }
        private User genUserObjWorker(DataRow dr)
        {
                User user = new User();
                user.Id = Convert.ToInt32(dr["id"]);
                user.UserName = dr["userName"].ToString().Trim();
                user.FirstName = dr["firstName"].ToString().Trim();
                user.Surname = dr["surname"].ToString().Trim();
                user.Province = dr["province"].ToString().Trim();
                user.City = dr["city"].ToString().Trim();
                user.Branch = dr["branch"].ToString().Trim();
                user.Department = dr["department"].ToString().Trim();
                user.EmployeeCode = dr["employeeCode"].ToString().Trim();
                user.JobTitle = dr["jobTitle"].ToString().Trim();
                user.EmailAdd = dr["emailAdd"].ToString().Trim();
                user.PhoneNo = dr["phoneNo"].ToString().Trim();
                user.Manager = dr["manager"].ToString().Trim();
                user.Roles = dr["roles"].ToString().Trim();
                user.Active = dr["active"].ToString().Trim();
            return user;
        }





        #endregion

    }
}




