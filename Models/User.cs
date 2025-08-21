using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_app.Models
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public byte[] profilePicture { get; set; }
    }
}
