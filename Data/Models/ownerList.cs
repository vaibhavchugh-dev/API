using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace rwaAPI.Data.Models
{
    public class ownerList
    {
        [Key]
        public int ownerid { get; set; }
        public string ownername { get; set; }
        public int towerid { get; set; }
        public int flatno { get; set; }
        public string adderess { get; set; }
        public string phone { get; set; }
        public int noofmembers { get; set; }
        public string profession { get; set; }
        public string officeaddress { get; set; }
        public int noofvechicles { get; set; }
        public int isparkingspace { get; set; }
        public string ownertowername { get; set; }
    }



}
