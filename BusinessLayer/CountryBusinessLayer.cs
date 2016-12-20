using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class CountryBusinessLayer
    {
        public List<Country> GetCountryList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Country> lstCountries = new List<Country>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Country country = new Country();
                    country.CountryId = Convert.ToInt16(rdr["CountryId"]);
                    country.CountryName = rdr["CountryName"].ToString();

                    lstCountries.Add(country);
                }
            }
            return lstCountries;
        }
    }
}
