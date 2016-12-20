using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPwd { get; set; }
        public int RestId { get; set; }
        public string Mobile { get; set; }
        public string UserEmail { get; set; }
        public string UserDisplayName { get; set; }
    }
}
