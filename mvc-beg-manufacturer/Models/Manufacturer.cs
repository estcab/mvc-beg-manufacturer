using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_beg_manufacturer.Models
{
    public class Manufacturer
    {
        public int ManufacturerID { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerCountry { get; set; }
        public string ManufacturerEmail { get; set; }
        public string ManufacturerWebsite { get; set; }
    }
}