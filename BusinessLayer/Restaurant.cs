using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class Restaurant
    {
        public int RestId { get; set; }
        [Required(ErrorMessage="Please enter Restaurant Name")]
        //[MinLength(5)]
        public string RestName { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        //[MinLength(10)]
        
        public string Address { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        [Required(ErrorMessage = "Please select Country")]
        public int CountryId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required(ErrorMessage = "Please select Area")]
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        [Required(ErrorMessage = "Please enter Cuisines")]
        //[MinLength(5)]        
        public string Cuisines { get; set; }
        [Required(ErrorMessage = "Please enter Hours")]
        //[MinLength(10)]
        
        public string Hours { get; set; }
        public string Discount { get; set; }
        [Required(ErrorMessage = "Please select State")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please select City")]
        public int CityId { get; set; }
        //Details
        
        public string CostDesc { get; set; }
        public string Highlights { get; set; }
        public string FamousFor { get; set; }
        public string MenuPath { get; set; }
        //[Required(ErrorMessage = "Please upload Cover Image")]
        public string CoverImagePath { get; set; }
        [Required(ErrorMessage = "Please select Home Delivery")]
        public int HomeDelivery { get; set; }
        public int DeliveryCost { get; set; }
        //[Required(ErrorMessage = "Please upload Main Image")]
        public string MainImagePath { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<SelectListItem> HomeDeliveryList { get; set; }

        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string Image6 { get; set; }
    }

    public enum HomeDelivery
    {
        Yes = 1,
        No = 0
    }
}
