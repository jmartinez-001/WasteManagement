using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WasteManagement1.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        [ForeignKey("Address")]
        public int PhysicalAddress { get; set; }

        public Address Address { get; set; }

        

    }
}