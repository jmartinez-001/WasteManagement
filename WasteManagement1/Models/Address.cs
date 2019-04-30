﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WasteManagement1.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string streetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [ForeignKey("PostalCode")]
        public int postalCodeId { get; set; }

        public PostalCode PostalCode { get; set; }


    }
}