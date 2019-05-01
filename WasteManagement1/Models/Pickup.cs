﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WasteManagement1.Models
{
    public class Pickup
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool PickupCompleted { get; set; }

        public string Lat { get; set; }

        public string Long { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}