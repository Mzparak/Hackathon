using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Agnoscolib
{
    public class Lib
    {

        #region User Related Methods

        #region GetUsers
        public string GetUsers()
        {
            string result = null;
           
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
                SQLHelper.NewIntParam("@param_nominator", nomination.NominatorId),
                SQLHelper.NewIntParam("@param_nominee", nomination.NomineeId),
                SQLHelper.NewVarcharParam("@param_nominationInfo", 4000, nomination.NominationDetails),
                SQLHelper.NewIntParam("@param_points", nomination.Points),
                SQLHelper.NewVarcharParam("@param_status", 100, nomination.Status)
                );
            Email email = new Email();
            email.sendNominationMail(nomination);
            email.SendHRNominationNoticeMail(nomination);
            conn.Close();
        }
        #endregion

        #region Get Nominations
        public string GetNominations(int depId,string Status, int loggedInUserId)
        {
            string result = null;
            Users users = new Users();
            DataSet dsResult = null;
            string spName = "Agnosco_GetNominations";
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            dsResult = SQLHelper.GetDataSet(
                conn,
                spName,
                SQLHelper.NewIntParam("@param_depId", depId),
                SQLHelper.NewVarcharParam("@param_status", 100, Status),
                SQLHelper.NewIntParam("@param_loggedInUserId", loggedInUserId)
                );
            if (dsResult != null)
            {
                List<Nomination> nominationsList = new List<Nomination>();
                nominationsList = genNominationsObj(dsResult.Tables[0]);
                result = JsonConvert.SerializeObject(nominationsList);
            }
            return result;
        }

        public void UpdateNomination(Nomination nomination)
        {
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            string spName = "Agnosco_UpdateNomination";
            SQLHelper.ExecuteQuery(
                conn,
                spName,
                SQLHelper.NewIntParam("@param_nominationId", nomination.NominationId),
                SQLHelper.NewVarcharParam("@param_status", 100, nomination.Status),
                SQLHelper.NewIntParam("@param_points", nomination.Points),
                SQLHelper.NewIntParam("@param_loggedInUserId", nomination.LoggedInUserId)
                );
            conn.Close();
            if (nomination.Status == "Approved")
            {
                Email email = new Email();
                email.sendNominationApprovedGiftMail(nomination);
                email.SendNominationApprovedMail(nomination);
                
            }
        }


        #endregion

        public void GiveThanks(Agnoscolib.Thanks thanksData)
        {
            Email email = new Email();
            email.SendThanksMail(thanksData);
        }
        #region LeaderboardStats
        public string LeaderboardStats()
        {
            string result = null;
            SqlConnection conn = SQLHelper.NewConnection(SQLHelper.ConnectionString);
            DataSet dsResult = null;
            string spName = "Agnosco_GetLeaderBoardStats";
            dsResult = SQLHelper.GetDataSet(
                conn,
                spName);
            conn.Close();
            if (dsResult != null)
            {
                List<Leaderboard> leaderboardList = new List<Leaderboard>();
                leaderboardList = genLeaderboardObj(dsResult.Tables[0]);
                result = JsonConvert.SerializeObject(leaderboardList);
            }
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
                user.AdminConfig = dr["adminConfig"].ToString().Trim();
            return user;
        }

        private List<Nomination> genNominationsObj(DataTable dt)
        {
            List<Nomination> result = new List<Nomination>();
            foreach (DataRow dr in dt.Rows)
            {
                Nomination nomination = new Nomination();
                nomination = genNominationObjWorker(dr);
                result.Add(nomination);
            }
            return result;
        }
        private Nomination genNominationObj(DataTable dt)
        {
            Nomination nomination = new Nomination();
            foreach (DataRow dr in dt.Rows)
            {
                nomination = genNominationObjWorker(dr);
            }
            return nomination;
        }
        private Nomination genNominationObjWorker(DataRow dr)
        {
            Nomination nomination = new Nomination();
            nomination.NominationId = Convert.ToInt32(dr["NominationId"]);
            nomination.NominatorId = Convert.ToInt32(dr["NominatorId"]);
            nomination.NominatorFullName = dr["NominatorFullName"].ToString().Trim();
            nomination.NomineeId = Convert.ToInt32(dr["NomineeId"]);
            nomination.NomineeFullName = dr["NomineeFullName"].ToString().Trim();
            nomination.NominationDetails = dr["NominationDetails"].ToString().Trim();
            nomination.Points = Convert.ToInt32(dr["Points"]);
            nomination.DateAdded = dr["DateAdded"].ToString().Trim();
            nomination.Status = dr["Status"].ToString().Trim();
            return nomination;
        }

        private List<Leaderboard> genLeaderboardObj(DataTable dt)
        {
            List<Leaderboard> result = new List<Leaderboard>();
            foreach (DataRow dr in dt.Rows)
            {
                Leaderboard leaderboard = new Leaderboard();
                leaderboard = genLeaderboardObjWorker(dr);
                result.Add(leaderboard);
            }
            return result;
        }
        
        private Leaderboard genLeaderboardObjWorker(DataRow dr)
        {
            Leaderboard leaderboard = new Leaderboard();
            leaderboard.Id = Convert.ToInt32(dr["Row#"]);
            leaderboard.AnonymousName = dr["Hollardite"].ToString().Trim();
            leaderboard.Branch = dr["Branch"].ToString().Trim();
            leaderboard.Points = Convert.ToInt32(dr["Points"]);
            leaderboard.Department = dr["Department"].ToString().Trim();
            leaderboard.FullName = dr["Full Name"].ToString().Trim();
            return leaderboard;
        }






        #endregion

    }
}




