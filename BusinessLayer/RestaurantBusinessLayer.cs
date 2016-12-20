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
    public class RestaurantBusinessLayer
    {
        public List<Restaurant> AllRestaurants()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<Restaurant> allrestaurants = new List<Restaurant>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllRestaurants", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Restaurant rest = new Restaurant();
                    rest.RestId = Convert.ToInt16(rdr["RestId"]);
                    rest.RestName = rdr["RestName"].ToString();
                    rest.Address = rdr["Address"].ToString();
                    rest.CityName = rdr["CityName"].ToString();
                    rest.StateName = rdr["StateName"].ToString();
                    rest.CountryName = rdr["CountryName"].ToString();
                    rest.Latitude = Convert.ToDecimal(rdr["Latitude"]);
                    rest.Longitude = Convert.ToDecimal(rdr["Longitude"]);
                    rest.AreaId = Convert.ToInt16(rdr["AreaId"]);
                    rest.AreaName = rdr["AreaName"].ToString();
                    rest.Phone1 = rdr["Phone1"].ToString();
                    rest.Phone2 = rdr["Phone2"].ToString();
                    rest.Phone3 = rdr["Phone3"].ToString();
                    rest.Cuisines = rdr["Cuisines"].ToString();
                    rest.Hours = rdr["Hours"].ToString();
                    rest.Discount = rdr["Discount"].ToString();
                    rest.MainImagePath = rdr["MainImagePath"].ToString();

                    allrestaurants.Add(rest);
                }
            }

            return allrestaurants;
        }

        public Restaurant GetRestaurantDetails(string idRest)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Restaurant rest = new Restaurant();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetRestaurantDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@RestId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = idRest;

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    
                    rest.RestId = Convert.ToInt16(rdr["RestId"]);
                    rest.RestName = rdr["RestName"].ToString();
                    rest.Address = rdr["Address"].ToString();
                    rest.Phone1 = rdr["Phone1"].ToString();
                    rest.CostDesc = rdr["CostDesc"].ToString();
                    rest.Highlights = rdr["Highlights"].ToString();
                    rest.FamousFor = rdr["FamousFor"].ToString();
                    rest.MenuPath = rdr["MenuPath"].ToString();
                    rest.CoverImagePath = rdr["CoverImagePath"].ToString();
                    rest.Image1 = rdr["Image1"].ToString();
                    rest.Image2 = rdr["Image2"].ToString();
                    rest.Image3 = rdr["Image3"].ToString();
                    rest.Image4 = rdr["Image4"].ToString();
                    rest.Image5 = rdr["Image5"].ToString();
                    rest.Image6 = rdr["Image6"].ToString();
                                        
                }

                return rest;
            }
        }

        public void AddRestaurantImages(Restaurant newRestImages)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddRestaurantImages", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@RestId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = newRestImages.RestId;

                param = cmd.Parameters.Add("@MainImagePath", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.MainImagePath;

                param = cmd.Parameters.Add("@CoverImagePath", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.CoverImagePath;

                param = cmd.Parameters.Add("@Image1", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image1;

                param = cmd.Parameters.Add("@Image2", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image2;

                param = cmd.Parameters.Add("@Image3", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image3;

                param = cmd.Parameters.Add("@Image4", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image4;

                param = cmd.Parameters.Add("@Image5", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image5;

                param = cmd.Parameters.Add("@Image6", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRestImages.Image6;

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        
        public int AddRestaurant(Restaurant newRest)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //Restaurant rest = new Restaurant();
            int result = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddRestaurant", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = cmd.Parameters.Add("@RestName", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.RestName;

                param = cmd.Parameters.Add("@Address", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 200;
                param.Value = newRest.Address;

                param = cmd.Parameters.Add("@CityId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.CityId;

                param = cmd.Parameters.Add("@StateId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.StateId;

                param = cmd.Parameters.Add("@CountryId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.CountryId;

                param = cmd.Parameters.Add("@AreaId", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = newRest.AreaId;

                param = cmd.Parameters.Add("@Phone1", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.Phone1;

                param = cmd.Parameters.Add("@Phone2", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.Phone2;

                param = cmd.Parameters.Add("@Phone3", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.Phone3;

                param = cmd.Parameters.Add("@Cuisines", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 500;
                param.Value = newRest.Cuisines;

                param = cmd.Parameters.Add("@Hours", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 50;
                param.Value = newRest.Hours;

                //param = cmd.Parameters.Add("@Discount", SqlDbType.Int);
                //param.Direction = ParameterDirection.Input;
                //param.Value = newRest.Discount;

                //param = cmd.Parameters.Add("@CostDesc", SqlDbType.VarChar);
                //param.Direction = ParameterDirection.Input;
                //param.Size = 500;
                //param.Value = newRest.CostDesc;

                //param = cmd.Parameters.Add("@Highlights", SqlDbType.VarChar);
                //param.Direction = ParameterDirection.Input;
                //param.Size = 1000;
                //param.Value = newRest.Highlights;

                param = cmd.Parameters.Add("@FamousFor", SqlDbType.VarChar);
                param.Direction = ParameterDirection.Input;
                param.Size = 1000;
                param.Value = newRest.FamousFor;

                param = cmd.Parameters.Add("@HomeDelivery", SqlDbType.Bit);
                param.Direction = ParameterDirection.Input;
                param.Value = newRest.HomeDelivery;

                param = cmd.Parameters.Add("@HomeDeliveryCost", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.Value = newRest.DeliveryCost;

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();

                cmd.ExecuteNonQuery();
                result = Convert.ToInt16(returnParameter.Value);
            }
            return result;
        }
    }
}
