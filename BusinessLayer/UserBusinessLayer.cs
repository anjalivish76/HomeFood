using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class UserBusinessLayer
    {
        public User GetUserDetails(string username,string userpwd)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            User currentUser = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = username;

                param = cmd.Parameters.Add("@UserPwd", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = userpwd;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    currentUser.UserId = Convert.ToInt16(rdr["UserId"]);
                    if (rdr["RestId"] != System.DBNull.Value)
                    {
                        currentUser.RestId = Convert.ToInt16(rdr["RestId"]);
                    }
                    currentUser.Mobile = rdr["Mobile"].ToString();
                    currentUser.UserEmail = rdr["UserEmail"].ToString();
                    currentUser.UserDisplayName = rdr["UserDisplayName"].ToString();
                }
            }

            return currentUser;
        }

        public User RegisterUser(string username, string userpwd,string displayname)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            User currentUser = new User();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = username;

                param = cmd.Parameters.Add("@UserPwd", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = userpwd;

                param = cmd.Parameters.Add("@DisplayName", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = displayname;

                con.Open();

                cmd.ExecuteNonQuery();
            }

            return currentUser;
        }
    }
}
