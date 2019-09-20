///<summary>
///    Author: BOMMISETTY T V L JAYA SOWRYA
///    Project: Customer Management System (CMS)
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CMSBusinessLayer;
using CMSExceptionLayer;
using EntitiesLayer;

/// <summary>
/// The Presentation Layer of CMS 
/// <para name=Console Application> </para>
/// </summary>

namespace CMSPresentationLayer
{
    class Program
    {
        // The main function of CMS used to select the operations based on the user choice

        static void Main(string[] args)
        {
            int option;
            do
            {
                Menu();
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        CreateCustomer();
                        ReadLine();
                        Clear();
                        break;
                    case 2:
                        ModifyCustomer();
                        ReadLine();
                        Clear();
                        break;
                    case 3:
                        RemoveCustomer();
                        ReadLine();
                        Clear();
                        break;
                    case 4:
                        CustomerSummary();
                        ReadLine();
                        Clear();
                        break;
                    case 5:
                        SearchCustomer();
                        ReadLine();
                        Clear();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (option != -1);
        }

        //To add a new customer 

        private static void CreateCustomer()
        {
            try
            {
                Customer newcustomer = new Customer();
                Write("Enter CustomerID :");
                newcustomer.CustomerId = Convert.ToInt32(ReadLine());
                Write("Enter Customer Name :");
                newcustomer.CustomerName = ReadLine();
                Write("Enter Customer City :");
                newcustomer.City = ReadLine();
                Write("Enter Customer Age :");
                newcustomer.Age = Convert.ToInt32(ReadLine());
                Write("Enter Phone Number :");
                newcustomer.PhoneNo = ReadLine();
                Write("Enter Pincode :");
                newcustomer.Pincode = Convert.ToInt32(ReadLine());
                bool customerAdded = CMSBL.CreateCustomerBL(newcustomer);
                if (customerAdded)
                    Console.WriteLine("New Customer Created");
                else
                    Console.WriteLine("Customer is not Created");
            }
            catch (CMSExceptions cex)
            {
                Console.WriteLine(cex.Message);
            }
        }

        //To modify the customer details by using ID or name 

        private static void ModifyCustomer()
        {
            try
            {
                string customerModify;
                Write("Enter Customer ID/Customer Name/Phone Number to Modify :");
                customerModify =ReadLine();
                Customer modifyCustomer = CMSBL.SearchCustomerBL(customerModify);
                if (modifyCustomer!= null)
                {
                    Write("Enter Customer Name :");
                    modifyCustomer.CustomerName = ReadLine();
                    Write("Enter Customer City :");
                    modifyCustomer.City = ReadLine();
                    Write("Enter Customer Age :");
                    modifyCustomer.Age = Convert.ToInt32(ReadLine());
                    Write("Enter Phone Number :");
                    modifyCustomer.PhoneNo = ReadLine();
                    Write("Enter Pincode :");
                    modifyCustomer.Pincode = Convert.ToInt32(ReadLine());
                    bool customerModified = CMSBL.ModifyCustomerBL(modifyCustomer);
                    if (customerModified)
                        WriteLine("Customer is Modified");
                    else
                        WriteLine("No Customers are Modified");
                }
                else
                {
                    WriteLine("No Customers are Available");
                }
            }
            catch (CMSExceptions cex)
            {
                Console.WriteLine(cex.Message);
            }
        }

        //To delete the existing customer by using customer ID or name

        private static void RemoveCustomer()
        {
            try
            {
                string customerRemove;
                Write("Enter Customer ID/Customer Name/Phone Number to Remove :");
                customerRemove = ReadLine();
                Customer removeCustomer = CMSBL.SearchCustomerBL(customerRemove);
                if (removeCustomer != null)
                {
                    bool customerRemoved = CMSBL.RemoveCustomerBL(removeCustomer.CustomerId);
                    if (customerRemoved)
                        WriteLine("Customer is Removed Successfully");
                    else
                        WriteLine("Customer is not removed");
                }
                else
                {
                    WriteLine("No Customers are Available");
                }

            }
            catch (CMSExceptions cex)
            {
                Console.WriteLine(cex.Message);
            }
        }

        //To display all the existing customers

        private static void CustomerSummary()
        {
            try
            {
                List<Customer> customerList = CMSBL.CustomerSummaryBL();
                if (customerList != null)
                {
                    WriteLine("*********************************************************************************************");
                    WriteLine("Customer ID\tCustomer Name\tCity\tAge\tPhone Number\tPincode");
                    WriteLine("*********************************************************************************************");
                    foreach (Customer customer in customerList)
                    {
                        WriteLine(customer.CustomerId+"\t"+customer.CustomerName + "\t" +customer.City + "\t" +customer.Age
                            + "\t" +customer.PhoneNo + "\t" +customer.Pincode);
                    }
                    WriteLine("*********************************************************************************************");
                }
                else
                {
                    WriteLine("No Customers Available");
                }
            }
            catch (CMSExceptions cex)
            {
                Console.WriteLine(cex.Message);
            }
        }


        //To search the existing customer by using the customer ID or name or phone number

        private static void SearchCustomer()
        {
            try
            {
                string customerSearched;
                WriteLine("Enter Customer ID/Customer Name/Phone Number to Search:");
                customerSearched = ReadLine();
                Customer searchCustomer = CMSBL.SearchCustomerBL(customerSearched);
                if (searchCustomer != null)
                {
                    WriteLine("******************************************************************************");
                    WriteLine("Customer ID :" + searchCustomer.CustomerId);
                    WriteLine("Customer Name :" + searchCustomer.CustomerName);
                    WriteLine("City :" + searchCustomer.City);
                    WriteLine("Age :" + searchCustomer.Age);
                    WriteLine("Phone No :" + searchCustomer.PhoneNo);
                    WriteLine("Pincode :" + searchCustomer.Pincode);
                    WriteLine("******************************************************************************");
                }
                else
                {
                    WriteLine("No Customers Available");
                }
            }
            catch (CMSExceptions cex)
            {
                WriteLine(cex.Message);
            }
        }

        //Displays all the list of Operations 

        public static void Menu()
        {
            WriteLine();
            WriteLine("                         Customer Management System");
            WriteLine("                                     CMS");
            WriteLine();
            WriteLine();
            WriteLine();
            WriteLine("********************************CMS CRUD Operations**************************************");
            WriteLine("1. Add Customer");
            WriteLine("2. Modify Customer");
            WriteLine("3. Remove Customer");
            WriteLine("4. Customer Summary");
            WriteLine("5. Search Customer");
            WriteLine("6. Exit");
            WriteLine("*****************************************************************************************");
            WriteLine("Enter your Choice:");
        }
                
    }
}
