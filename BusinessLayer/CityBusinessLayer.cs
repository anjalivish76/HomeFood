using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BusinessLayer
{
    public class CityBusinessLayer
    {
        public List<City> GetCities()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<City> lstCities = new List<City>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetCities", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param;

                //param = cmd.Parameters.Add("@CountryId", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = CountryId;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    City city = new City();
                    city.CityId = Convert.ToInt16(rdr["CityId"]);
                    city.CityName = rdr["CityName"].ToString();
                    city.StateId = Convert.ToInt16(rdr["StateId"]);
                    city.CountryId = Convert.ToInt16(rdr["CountryId"]);

                    lstCities.Add(city);
                }
            }
            return lstCities;
        }
    }
}
