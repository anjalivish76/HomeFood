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
    public class AreaBusinessLayer
    {
        public AreaDetails AreaCoordinates(string areaname,string cityname,string statename,string countryname)
        {
            //get
            //{
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                AreaDetails areaDetails = new AreaDetails();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAreaCoordinates", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param;

                    param = cmd.Parameters.Add("@AreaName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Size = 100;
                    param.Value = areaname;

                    param = cmd.Parameters.Add("@CityName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Size = 100;
                    param.Value = cityname;

                    param = cmd.Parameters.Add("@StateName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Size = 100;
                    param.Value = statename;

                    param = cmd.Parameters.Add("@CountryName", SqlDbType.VarChar);
                    param.Direction = ParameterDirection.Input;
                    param.Size = 100;
                    param.Value = countryname;

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        areaDetails.Latitude = Convert.ToDecimal(rdr["Latitude"]);
                        areaDetails.Longitude = Convert.ToDecimal(rdr["Longitude"]);
                    }
                }

                return areaDetails;
            //}

        }

        public List<AreaDetails> GetAreasList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<AreaDetails> lstAreas = new List<AreaDetails>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllAreas", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        AreaDetails area = new AreaDetails();
                        area.AreaId = Convert.ToInt16(rdr["AreaId"]);
                        area.AreaName = rdr["AreaName"].ToString();
                        area.CityId = Convert.ToInt16(rdr["CityId"]);
                        area.StateId = Convert.ToInt16(rdr["StateId"]);
                        area.CountryId = Convert.ToInt16(rdr["CountryId"]);
                        area.Latitude = Convert.ToDecimal(rdr["Latitude"]);
                        area.Longitude = Convert.ToDecimal(rdr["Longitude"]);

                        lstAreas.Add(area);
                    }
                }
                return lstAreas;
        }

        
    }
}
