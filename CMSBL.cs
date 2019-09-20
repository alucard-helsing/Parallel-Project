using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using CMSDataAccessLayer;
using CMSExceptionLayer;
using EntitiesLayer;

/// <summary>
/// Business Layer of CMS
/// </summary>

namespace CMSBusinessLayer
{
    public class CMSBL
    {
        //To get what type of string that user entered like ID or name or phone number using regular expressions
        //Used in Search,Modify,Delete operations on a specific customer

        public static string Types(string str)
        {
            string validate = String.Empty;
            if (Regex.IsMatch(str, @"[0-9]{1,}"))
                validate = "id";
            if (Regex.IsMatch(str, @"[A-Z][a-z]{1,30}"))
                validate = "name";
            if (Regex.IsMatch(str, @"[0-9]{10}"))
                validate = "phno";
            return validate;
        }

        //To validate the customer depending on the regular expressions

        public static bool ValidateCustomer(Customer customer)
        {
            StringBuilder validationErrors = new StringBuilder();
            bool validate = true;

            //To get the ID is already exists or not
            if (SearchCustomerBL(customer.CustomerId.ToString()) != null)
            {
                validate = false;
                validationErrors.Append("Customer Id already exists");
            }

            //To validate customer ID
            if (!Regex.IsMatch(customer.CustomerId.ToString(), @"[0-9]{1,}"))
            {
                validate = false;
                validationErrors.Append("Customer ID should be only 0-9 and 5 characters");
            }

            //To validate customer name
            if (!Regex.IsMatch(customer.CustomerName, @"[A-Za-z]{1,30}"))
            {
                validate = false;
                validationErrors.Append("Customer Name must be in 10 characters long");
            }

            //To validate customer city
            if (!Regex.IsMatch(customer.City, @"^[A-Za-z]{4,20}$"))
            {
                validate = false;
                validationErrors.Append("There should be City Name and its Code");
            }

            //To validate customer phone number
            if (!Regex.IsMatch(customer.PhoneNo, @"[0-9]{10}"))
            {
                validate = false;
                validationErrors.Append("Phone Number should be only 10 digits long");
            }

            //To validate customer pincode
            if (!Regex.IsMatch(customer.Pincode.ToString(), @"[0-9]{6}"))
            {
                validate = false;
                validationErrors.Append("Pincode should be only 6 digits");
            }

            //To raise the exceptions when any of the validation is not success
            if (validate == false)
                throw new CMSExceptions(validationErrors.ToString());
            return validate;
        }


        //Business Login to Add new customer

        public static bool CreateCustomerBL(Customer customer)
        {
            bool customerCreated = false;
            try
            {
                if (ValidateCustomer(customer))
                {
                    CMSDAL customerDAL = new CMSDAL();
                    customerCreated = customerDAL.CreateCustomerDAL(customer);
                }
            }
            catch(CMSExceptions cex)
            {
                throw cex;
            }
            catch(Exception ex)
            {
                throw ex;
            } 
            return customerCreated;
        }

        //Business Login to Modify existing customer

        public static bool ModifyCustomerBL(Customer modifyCustomer)
        {
            bool customerModified = false;
            try
            {
                CMSDAL customerDAL = new CMSDAL();
                customerModified = customerDAL.ModifyCustomerDAL(modifyCustomer);
            }
            catch (CMSExceptions cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerModified;
        }

        //Business Login to Delete existing customer

        public static bool RemoveCustomerBL(int removeCustomerId)
        {
            bool customerRemoved = false;
            try
            {
                if (removeCustomerId> 0)
                {
                    CMSDAL customerDAL = new CMSDAL();
                    customerRemoved = customerDAL.RemoveCustomerDAL(removeCustomerId);
                }
                else
                {
                    throw new CMSExceptions("Invalid Emp ID");
                }
            }
            catch (CMSExceptions cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerRemoved;
        }

        //Business Login to display all the existing customers

        public static List<Customer> CustomerSummaryBL()
        {
            List<Customer> customerList = null;
            try
            {
                CMSDAL customerDAL = new CMSDAL();
                customerList = customerDAL.CustomerSummaryDAL();
            }
            catch (CMSExceptions cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerList;
        }

        //Business Login to Search existing customer

        public static Customer SearchCustomerBL(string searchCustomer)
        {
            string type = String.Empty;
            Customer customerSearched = null;
            try
            {
                //To know what the user has entered like ID or name or phone number
                type = Types(searchCustomer);
                CMSDAL customerDAL = new CMSDAL();
                customerSearched = customerDAL.SearchCustomerDAL(searchCustomer, type);
            }
            catch (CMSExceptions cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerSearched;
        }
    }
}
