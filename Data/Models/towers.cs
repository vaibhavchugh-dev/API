using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rwaAPI.Data.Models
{
    public class towers
    {


        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string towerno { get; set; }
        public int phone { get; set; }
        public int noflats { get; set; }
        public int nofloors { get; set; }

    }
}
