using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CMSExceptionLayer;
using EntitiesLayer;
using System.Data.Common;

/// <summary>
/// Data Access Layer of the CMS
/// </summary>

namespace CMSDataAccessLayer
{
    public class CMSDAL
    {
        //To handle all the customers
        static List<Customer> customerList = new List<Customer>();

        //File to save the list of customers
        public static string fileName = "Customers.txt";

        //Data Access Logic to Add a new customer

        public bool CreateCustomerDAL(Customer newCustomer)
        {
            bool customerCreated = false;
            try
            {
                customerList.Add(newCustomer);
                Serialization();
                customerCreated = true;
            }
            catch (SystemException cex)
            {
                throw new CMSExceptions(cex.Message);
            }
            return customerCreated;
        }

        //Data Access Logic to Modify existing customer

        public bool ModifyCustomerDAL(Customer modifyCustomer)
        {
            bool customerModified = false;
            try
            {
                for (int i = 0; i < customerList.Count; i++)
                {
                    if (customerList[i].CustomerId == modifyCustomer.CustomerId)
                    {
                        modifyCustomer.CustomerId = customerList[i].CustomerId;
                        modifyCustomer.CustomerName = customerList[i].CustomerName;
                        modifyCustomer.City = customerList[i].City;
                        modifyCustomer.Age = customerList[i].Age;
                        modifyCustomer.PhoneNo = customerList[i].PhoneNo;
                        modifyCustomer.Pincode = customerList[i].Pincode;
                        customerModified = true;
                        Serialization();
                    }
                }
            }
            catch (SystemException cex)
            {
                throw new CMSExceptions(cex.Message);
            }
            return customerModified;
        }

        //Data Access Logic to Delete existing customer

        public bool RemoveCustomerDAL(int deleteCustomerId)
        {
            bool customerRemoved = false;
            try
            {
                customerList.Clear();
                Deserialization();
                Customer removeCustomer = customerList.Find(cust => cust.CustomerId == deleteCustomerId);
                if (removeCustomer != null)
                {
                    customerList.Remove(removeCustomer);
                    customerRemoved = true;
                    Serialization();
                }
            }
            catch (SystemException ex)
            {
                throw new CMSExceptions(ex.Message);
            }
            return customerRemoved;
        }

        //Data Access Logic to Show all the existing customers

        public List<Customer> CustomerSummaryDAL()
        {
            Deserialization();
            return customerList;
        }

        //Data Access Logic to Search existing customer

        public Customer SearchCustomerDAL(string searchCustomer, string type)
        {
            Deserialization();
            Customer customerSearched = null;
            try
            {
                if (type == "id")
                    customerSearched = customerList.Find(cust => cust.CustomerId == Convert.ToInt32(searchCustomer));
                else if (type == "name")
                    customerSearched = customerList.Find(cust => cust.CustomerName == searchCustomer);
                else if (type == "phno")
                    customerSearched = customerList.Find(cust => cust.PhoneNo == searchCustomer);
            }
            catch (SystemException cex)
            {
                throw new CMSExceptions(cex.Message);
            }
            return customerSearched;
        }

        //To store the existing customers into the file

        public void Serialization()
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, customerList);
                fileStream.Close();
                customerList.Clear();
            }
            catch (DbException cex)
            {
                throw new CMSExceptions(cex.Message);
            }
        }

        //To read the customers data from the file

        public void Deserialization()
        {
            try
            {
                FileStream fileStream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                customerList.Clear();
                customerList = binaryFormatter.Deserialize(fileStream) as List<Customer>;
                fileStream.Close();
            }
            catch (DbException cex)
            {
                throw new CMSExceptions(cex.Message);
            }
        }
    }
}