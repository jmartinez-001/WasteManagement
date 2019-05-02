using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
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

    public class CountryModel
    {
        #region DatabaseMethod  
        public List<T> ConvertTo<T>(DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString();
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }
        #endregion

        SqlConnection con;
        SqlDataAdapter adap;
        DataTable dt;
        SqlCommand cmd;
        public CountryModel()
        {
            string conn = ConfigurationManager.ConnectionStrings["CountryConnectionString"].ConnectionString;
            con = new SqlConnection(conn);
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            try
            {
                con.Open();
                adap = new SqlDataAdapter();
                dt = new DataTable();
                cmd = new SqlCommand("GetCountries", con);
                cmd.CommandType = CommandType.StoredProcedure;

                adap.SelectCommand = cmd;
                adap.Fill(dt);
                countries = ConvertTo<Country>(dt);
            }
            catch (Exception x)
            {

            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
            return countries;
        }
    }
}