using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class CountryModel
    {
        public List<State> StateModel { get; set; }
        public SelectList FilteredCity { get; set; }
    }
}
