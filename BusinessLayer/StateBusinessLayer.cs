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
    public class StateBusinessLayer
    {
        public List<State> GetStates()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<State> lstStates = new List<State>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetStates", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param;

                //param = cmd.Parameters.Add("@CountryId", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = CountryId;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    State state = new State();
                    state.StateId = Convert.ToInt16(rdr["StateId"]);
                    state.StateName = rdr["StateName"].ToString();
                    state.CountryId = Convert.ToInt16(rdr["CountryId"]);
                    
                    lstStates.Add(state);
                }
            }
            return lstStates;
        }
    }
}
