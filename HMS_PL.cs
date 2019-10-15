using HMS_BusinessLogicLayer;
using HMS_EntityLayer;
using HMS_ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSConsoleApp
{
    class HMS_PL
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice :");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        ListAllPatients();
                        break;
                    case 3:
                        SearchPatientByPatientId();
                        break;
                    case 4:
                        UpdatePatient();
                        break;
                    case 5:
                        DeletePatient();
                        break;
                    case 6:
                        AddLab();
                        break;
                    case 7:
                        ListAllLabs();
                        break;
                    case 8:
                        SearchLabByLabId();
                        break;
                    case 9:
                        UpdateLab();
                        break;
                    case 10:
                        DeleteLab();
                        break;
                    case 11:
                        AddBill();
                        break;
                    case 12:
                        ListAllBills();
                        break;
                    case 13:
                        SearchBillByBillId();
                        break;
                    case 14:
                        UpdateBill();
                        break;
                    case 15:
                        DeleteBill();
                        break;
                    case 16:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice, please try again");
                        break;
                }
            } while (choice >0 && choice <17);
        }
        private static void PrintMenu()
        {
            Console.WriteLine("\n************* [HOSPITAL MANAGEMENT SYSTEM] ***********");
            Console.WriteLine("Patient CRUD Operations");
            Console.WriteLine("********************************************************");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. List All Patients");
            Console.WriteLine("3. Search Patient by Patient Id");
            Console.WriteLine("4. Update Patient");
            Console.WriteLine("5. Delete Patient");
            Console.WriteLine(" *******************************************************");
            Console.WriteLine("Lab CRUD Operations");
            Console.WriteLine("********************************************************");
            Console.WriteLine("6. Add Lab Details");
            Console.WriteLine("7. List All Lab Details");
            Console.WriteLine("8. Search Lab Details by LabId");
            Console.WriteLine("9. Update Lab Details");
            Console.WriteLine("10. Delete Lab Details");
            Console.WriteLine("********************************************************");
            Console.WriteLine("Bill CRUD Operations");
            Console.WriteLine("********************************************************");
            Console.WriteLine("11. Add Bill");
            Console.WriteLine("12. List All Bills");
            Console.WriteLine("13. Search Bill by BillId");
            Console.WriteLine("14. Update Bill");
            Console.WriteLine("15. Delete Bill");
            Console.WriteLine("********************************************************");
            Console.WriteLine("16. Quit");
            Console.WriteLine("********************************************************");
        }

        private static void AddPatient()
        {
            try
            {
                Patient newPatient = new Patient();
                Console.WriteLine("Enter PatientID :");
                newPatient.PatientId = Console.ReadLine();
                Console.WriteLine("Enter Patient Name:");
                newPatient.PatientName = Console.ReadLine();
                Console.WriteLine("Enter Date Of Birth :");
                newPatient.DOB = Convert.ToDateTime(Console.ReadLine()).Date;
                Console.WriteLine("Enter Patient Weight :");
                newPatient.Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Patient Height :");
                newPatient.Height = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Patient Gender:");
                newPatient.Gender = Console.ReadLine();
                Console.WriteLine("Enter Patient Address:");
                newPatient.Address = Console.ReadLine();
                Console.WriteLine("Enter Patient Phoneno :");
                newPatient.PhoneNo = Convert.ToDouble(Console.ReadLine());

                bool patientAdded = HMS_BLL.AddPatientBLL(newPatient);
                if (patientAdded)
                    Console.WriteLine("Patient Added");
                else
                    Console.WriteLine("Patient not Added");
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListAllPatients()
        {
            try
            {
                List<Patient> patientList = HMS_BLL.GetAllPatientsBLL();
                if (patientList != null)
                {
                    Console.WriteLine("***************************************************************************************");
                    Console.WriteLine("Patient Id\tPatient Name\tDate Of Birth\t\tWeight\tHeight\tGender\tAddress\tPhoneNo");
                    Console.WriteLine("***************************************************************************************");
                    foreach (Patient patient in patientList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}", patient.PatientId, patient.PatientName, patient.DOB, patient.Weight, patient.Height, patient.Gender, patient.Address, patient.PhoneNo);
                    }
                    Console.WriteLine("***************************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Patients Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SearchPatientByPatientId()
        {
            try
            {
                Console.WriteLine("Enter Patient ID to Search:");
                string searchPatientId = Console.ReadLine();
                Patient searchPatient = HMS_BLL.SearchPatientBLL(searchPatientId);
                if (searchPatient != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Patient Name\tDate Of Birth\t\tWeight\tHeight\tGender\tAddress\tPhoneNo");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", searchPatient.PatientName, searchPatient.DOB, searchPatient.Weight, searchPatient.Height, searchPatient.Gender, searchPatient.Address, searchPatient.PhoneNo);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdatePatient()
        {
            try
            {
                Console.WriteLine("Enter Patient ID to Update Details:");
                string updatePatientId = Console.ReadLine();
                Patient updatedPatient = HMS_BLL.SearchPatientBLL(updatePatientId);
                if (updatedPatient != null)
                {
                    Console.WriteLine("Update Name :");
                    updatedPatient.PatientName = Console.ReadLine();
                    Console.WriteLine("Update Date Of Birth:");
                    updatedPatient.DOB = Convert.ToDateTime(Console.ReadLine()).Date;
                    Console.WriteLine("Update Weight:");
                    updatedPatient.Weight = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Height:");
                    updatedPatient.Height = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Gender :");
                    updatedPatient.Gender = Console.ReadLine();
                    Console.WriteLine("Update Address :");
                    updatedPatient.Address = Console.ReadLine();
                    Console.WriteLine("Update Phone Number:");
                    updatedPatient.PhoneNo = Convert.ToDouble(Console.ReadLine());

                    bool patientUpdated = HMS_BLL.UpdatePatientBLL(updatedPatient);
                    if (patientUpdated)
                        Console.WriteLine("Patient Details Updated");
                    else
                        Console.WriteLine("Patient Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DeletePatient()
        {
            try
            {
                Console.WriteLine("Enter Patient Id to Delete:");
                string deletePatientId = Console.ReadLine();
                Patient deletePatient = HMS_BLL.SearchPatientBLL(deletePatientId);
                if (deletePatientId != null)
                {
                    bool patientdeleted = HMS_BLL.DeletePatientBLL(deletePatientId);
                    if (patientdeleted)
                        Console.WriteLine("patient deleted");
                    else
                        Console.WriteLine("patient not deleted ");
                }
                else
                {
                    Console.WriteLine("No Patient Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddLab()
        {
            try
            {
                Lab newLab = new Lab();
                Console.WriteLine("Enter Lab Id :");
                newLab.LabId = Console.ReadLine();
                Console.WriteLine("Enter Patient Id :");
                newLab.PatientId = Console.ReadLine();
                Console.WriteLine("Enter Test Date :");
                newLab.TestDate = Convert.ToDateTime(Console.ReadLine()).Date;
                Console.WriteLine("Enter Test Type :");
                newLab.TestType = Console.ReadLine();

                bool labAdded = HMS_BLL.AddLabBLL(newLab);
                if (labAdded)
                    Console.WriteLine("Lab Details Added");
                else
                    Console.WriteLine("Lab Details Not Added");
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListAllLabs()
        {
            try
            {
                List<Lab> LabList = HMS_BLL.GetAllLabsBLL();
                if (LabList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Lab Id\t\tPatient Id\t\tTestDate\t\tTestType");
                    Console.WriteLine("******************************************************************************");
                    foreach (Lab lab in LabList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", lab.LabId, lab.PatientId, lab.TestDate, lab.TestType);
                    }
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Lab Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SearchLabByLabId()
        {
            try
            {
                Console.WriteLine("Enter Lab Id to Search: ");
                string searchLabId = Console.ReadLine();
                Lab searchLab = HMS_BLL.SearchLabBLL(searchLabId);
                if (searchLab != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Lab Id\t\tPatient Id\t\tTestDate\t\tTestType");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", searchLab.LabId, searchLab.PatientId, searchLab.TestDate, searchLab.TestType);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Lab Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdateLab()
        {
            try
            {
                Console.WriteLine("Enter Lab Id to Update Details:");
                string updateLabId = Console.ReadLine();
                Lab updatedLab = HMS_BLL.SearchLabBLL(updateLabId);
                if (updatedLab != null)
                {
                    Console.WriteLine("Update Patient Id :");
                    updatedLab.PatientId = Console.ReadLine();
                    Console.WriteLine("Update Test Date :");
                    updatedLab.TestDate = Convert.ToDateTime(Console.ReadLine()).Date;
                    Console.WriteLine("Update Test Type :");
                    updatedLab.TestType = Console.ReadLine();

                    bool labUpdated = HMS_BLL.UpdateLabBLL(updatedLab);
                    if (labUpdated)
                        Console.WriteLine("Lab Details Updated");
                    else
                        Console.WriteLine("Lab Details Not Updated ");
                }
                else
                {
                    Console.WriteLine("No Lab Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DeleteLab()
        {
            try
            {
                Console.WriteLine("Enter Lab Id to Delete:");
                string deleteLabId = Console.ReadLine();
                Lab deleteLab = HMS_BLL.SearchLabBLL(deleteLabId);
                if (deleteLabId != null)
                {
                    bool labdeleted = HMS_BLL.DeleteLabBLL(deleteLabId);
                    if (labdeleted)
                        Console.WriteLine("Lab Deleted");
                    else
                        Console.WriteLine("Lab Not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Lab Details Available");
                }

            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddBill()
        {
            try
            {
                Bill newBill = new Bill();
                Console.WriteLine("Enter Bill Id :");
                newBill.BillId = Console.ReadLine();
                Console.WriteLine("Enter Patient Id:");
                newBill.PatientId = Console.ReadLine();
                Console.WriteLine("Enter Doctor Fees:");
                newBill.DoctorFees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Room Charge:");
                newBill.RoomCharge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Operation Charge :");
                newBill.OperationCharge = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Medicine Fees:");
                newBill.MedicineFees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Total Days:");
                newBill.TotalDays = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Lab Fees:");
                newBill.LabFees = Convert.ToInt32(Console.ReadLine());

                bool billAdded = HMS_BLL.AddBillBLL(newBill);
                if (billAdded)
                    Console.WriteLine("Bill Added");
                else
                    Console.WriteLine("Bill Not Added");
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListAllBills()
        {
            try
            {
                List<Bill> billList = HMS_BLL.GetAllBillsBLL();
                if (billList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Biil Id\t\tPatient Id\tDoctorFees\tRoomCharge\tOperationCharge\tMedicineFees\tTotalDays\tLabFees\tTotalAmount");
                    Console.WriteLine("******************************************************************************");
                    foreach (Bill bill in billList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}\t\t{8}", bill.BillId, bill.PatientId, bill.DoctorFees, bill.RoomCharge, bill.OperationCharge, bill.MedicineFees, bill.TotalDays, bill.LabFees, bill.TotalAmount);
                    }
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Bill Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void SearchBillByBillId()
        {
            try
            {
                Console.WriteLine("Enter Bill ID to Search:");
                string searchBillId = Console.ReadLine();
                Bill searchBill = HMS_BLL.SearchBillBLL(searchBillId);
                if (searchBill != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Bill Id\t\tPatient Id\t\tDoctorFees\t\tRoomCharge\t\tOperationCharge\t\tMedicineFees\t\tTotalDays\t\tLabFees\t\tTotalAmount");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}\t\t{6}\t\t{7}", searchBill.BillId, searchBill.PatientId, searchBill.DoctorFees, searchBill.RoomCharge, searchBill.OperationCharge, searchBill.MedicineFees, searchBill.TotalDays, searchBill.TotalAmount);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Bill Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdateBill()
        {
            try
            {
                Console.WriteLine("Enter Bill ID to Update Details:");
                string updateBillId = Console.ReadLine();
                Bill updatedBill = HMS_BLL.SearchBillBLL(updateBillId);
                if (updatedBill != null)
                {
                    Console.WriteLine("Update Patient Id :");
                    updatedBill.PatientId = Console.ReadLine();
                    Console.WriteLine("Update Doctor Fees :");
                    updatedBill.DoctorFees = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update  Room Charge:");
                    updatedBill.RoomCharge = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Operation Charge:");
                    updatedBill.OperationCharge = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Medicine Fees :");
                    updatedBill.MedicineFees = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Total Days :");
                    updatedBill.TotalDays = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Update Lab Fees :");
                    updatedBill.LabFees = Convert.ToInt32(Console.ReadLine());

                    bool billUpdated = HMS_BLL.UpdateBillBLL(updatedBill);
                    if (billUpdated)
                        Console.WriteLine("Bill Details Updated");
                    else
                        Console.WriteLine("Bill Details Not Updated ");
                }
                else
                {
                    Console.WriteLine("No Bill Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DeleteBill()
        {
            try
            {
                Console.WriteLine("Enter Bill Id To Delete:");
                string deleteBillId = Console.ReadLine();
                Bill deleteBill = HMS_BLL.SearchBillBLL(deleteBillId);
                if (deleteBillId != null)
                {
                    bool billdeleted = HMS_BLL.DeleteBillBLL(deleteBillId);
                    if (billdeleted)
                        Console.WriteLine("Bill Deleted");
                    else
                        Console.WriteLine("Bill Not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Bill Details Available");
                }
            }
            catch (HMS_Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
