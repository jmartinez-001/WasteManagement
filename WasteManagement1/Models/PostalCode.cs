using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WasteManagement1.Models
{
    public class PostalCode
    {
        [Key]
        public int PostalCodeId { get; set; }

        public int postalCode { get; set; }
    }
}