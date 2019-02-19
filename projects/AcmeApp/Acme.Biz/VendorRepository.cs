using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    public class VendorRepository
    {
        private List<Vendor> Vendors;
        /// <summary>
        /// Retrieve one vendor.
        /// </summary>
        /// <param name="vendorId">Id of the vendor to retrieve.</param>
        public Vendor Retrieve(int vendorId)
        {
            // Create the instance of the Vendor class
            Vendor vendor = new Vendor();

            // Code that retrieves the defined customer

            // Temporary hard coded values to return 
            if (vendorId == 1)
            {
                vendor.VendorId = 1;
                vendor.CompanyName = "ABC Corp";
                vendor.Email = "abc@abc.com";
            }
            return vendor;
        }

        /// <summary>
        /// Save data for one vendor.
        /// </summary>
        /// <param name="vendor">Instance of the vendor to save.</param>
        /// <returns></returns>
        public bool Save(Vendor vendor)
        {
            var success = true;

            // Code that saves the vendor

            return success;
        }

        public T RetrieveValue<T>(string sql, T defaulValue)
        {
            T value = defaulValue;

            return value;
        }
        public List<Vendor> Retrieve()
        {
            if (Vendors == null)
            {
                Vendors = new List<Vendor>();
                Vendors.Add(new Vendor()
                { VendorId = 1, CompanyName = "Test", Email = "teste@teste.com" });
                Vendors.Add(new Vendor()
                { VendorId = 2, CompanyName = "Test", Email = "teste1@teste.com" });
            }
            return Vendors;
        }

        public Dictionary<string, Vendor> RetrieveWithKeys()
        {
            var vendors = new Dictionary<string, Vendor>()
            {
                {"ABC Corp", new Vendor()
                     { VendorId= 1, CompanyName = "ABC coorp", Email= "abc@coorp.com" }
                },
                {"XYZ Corp", new Vendor()
                     { VendorId= 2, CompanyName = "XYZ coorp", Email= "abc@coorp.com" }
                }
            };

            //if (vendors.ContainsKey("ABC Corp"))
            //{
            //    Console.WriteLine(vendors["ABC Corp"]);
            //}

            //foreach (var vendor in vendors.Values)
            //{
            //    Console.WriteLine(vendor);
            //}

            foreach (var element in vendors)
            {
                var vendor = element.Value;
                var key = element.Key;
                Console.WriteLine($"Key: {key} Value: {vendor}")
            }
            return vendors;
        
          }

    }
}
