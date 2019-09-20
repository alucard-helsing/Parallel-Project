using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    /// <summary>
    /// Customer class that handles the details of the customer
    /// </summary>
    [Serializable]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }
        public int Pincode { get; set; }
    }
}
