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

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Street Address is required")]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public List<Country> Countries { get; set; }

        public string CountryCode { get; set; }

        [Display(Name = "PickUp Day")]        
        public DayOfWeek PickUpDay { get; set; }

        [Display(Name = "Extra PickUp Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExtraPickUpDay { get; set; }

        [Display(Name = "Account Status")]
        public string AccountStatus { get; set; }

        [Display(Name = "Amount Due")]
        public double AmountDue { get; set; }

        [Display(Name = "Start Service")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ServiceStart { get; set; }

        [Display(Name = "Stop Service")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ServiceStop { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }

    public class Country
    {
        #region Properties  
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string MapReference { get; set; }
        public string CountryCode { get; set; }
        public string CountryCodeLong { get; set; }
        #endregion
    }
}