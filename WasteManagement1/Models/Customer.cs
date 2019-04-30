using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WasteManagement1.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }  
        
        [ForeignKey("Address")]
        public int pickupAddress { get; set; }

        public Address Pickup { get; set; }

        [ForeignKey("Address")]
        public int billingAddress { get; set; }

        public Address Billing { get; set; }

        public string pickUpDay { get; set; }

        public string extraPickUpDay { get; set; }

        public string accountStatus { get; set; }

        public string vacationStart { get; set; }

        public string vacationEnd { get; set; }

        

    }
}