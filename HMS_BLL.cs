using HMS_DataAccessLayer;
using HMS_EntityLayer;
using HMS_ExceptionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HMS_BusinessLogicLayer
{
    public class HMS_BLL
    {
        private static bool ValidatePatient(Patient patient)
        {
                           
            StringBuilder sb = new StringBuilder();
            bool validPatient = true;
            if (patient.PatientId == string.Empty)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient Id is required");
            }
            if (!Regex.IsMatch(patient.PatientId, @"[0-9]{4}-[0-9]{4}-[0-9]{4}"))
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Serial Number Is Invalid..");
            }

            if (patient.PatientName == string.Empty)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Patient Name is Required");
            }
            else if (!Regex.IsMatch(patient.PatientName, "^[A-Z][a-z]+"))
            {
                sb.Append("Customer name should start with Capital letter and it should have alphabets only\n");
                validPatient = false;
            }

            if (patient.DOB >= DateTime.Now || patient.DOB == null)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Invalid Date Of Birth");
            }
            

            if (patient.Weight <= 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Invalid Weight");
            }

            if (patient.Height <= 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Invalid Height");
            }
            if (patient.Gender == string.Empty)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Gender is Required");

            }
            if (patient.Address == string.Empty)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Address is Required");

            }
            if (patient.PhoneNo <= 0)
            {
                validPatient = false;
                sb.Append(Environment.NewLine + "Invalid Phone Number");
            }
            

            if (validPatient == false)
                throw new HMS_Exception(sb.ToString());
            return validPatient;
        }
        private static bool ValidateLab(Lab lab)
        {
            StringBuilder sb = new StringBuilder();
            bool validLab = true;
            if (lab.LabId == string.Empty)
            {
                validLab = false;
                sb.Append(Environment.NewLine + "Lab Id is Required");
            }
            if (lab.PatientId == string.Empty)
            {
                validLab = false;
                sb.Append(Environment.NewLine + "Patient Id is Required");
            }
            if (lab.TestDate == null)
            {
                validLab = false;
                sb.Append(Environment.NewLine + "Test Date is Required");
            }
            if (lab.TestType == string.Empty)
            {
                validLab = false;
                sb.Append(Environment.NewLine + "Test Type is Required");
            }
            if (validLab == false)
                throw new HMS_Exception(sb.ToString());
            return validLab;

        }
        private static bool ValidateBill(Bill bill)
        {
            StringBuilder sb = new StringBuilder();
            bool validBill = true;
            if (bill.BillId == string.Empty)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Bill Id is Required");
            }
            if (bill.PatientId == string.Empty)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Patient Id is Required");
            }
            if (bill.DoctorFees <= 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Invalid Doctor Fees");
            }
            if (bill.RoomCharge <= 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Invalid Room Charge");
            }
            if (bill.OperationCharge <= 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Invalid Operation Charge");
            }
            if (bill.MedicineFees <= 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Invalid Medicine Fees");
            }
            if (bill.TotalDays == 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Total Days is Required");
            }
            if (bill.LabFees <= 0)
            {
                validBill = false;
                sb.Append(Environment.NewLine + "Invalid Lab Fees");
            }
            if (validBill == false)
                throw new HMS_Exception(sb.ToString());
            return validBill;
        }

        public static bool AddPatientBLL(Patient newPatient)
        {
            bool patientAdded = false;
            try
            {
                if (ValidatePatient(newPatient))
                {
                    patientAdded = HMS_DAL.AddPatientDAL(newPatient);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientAdded;
        }
        public static List<Patient> GetAllPatientsBLL()
        {
            List<Patient> PatientList = null;
            try
            {
                PatientList = HMS_DAL.GetAllPatientsDAL();
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PatientList;
        }
        public static Patient SearchPatientBLL(string searchPatientId)
        {
            Patient searchPatient = null;
            try
            {
                searchPatient = HMS_DAL.SearchPatientDAL(searchPatientId);
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchPatient;
        }
        public static bool UpdatePatientBLL(Patient updatePatient)
        {
            bool patientUpdated = false;
            try
            {
                if (ValidatePatient(updatePatient))
                {
                    patientUpdated = HMS_DAL.UpdatePatientDAL(updatePatient);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientUpdated;
        }
        public static bool DeletePatientBLL(string deletePatientId)
        {
            bool patientDeleted = false;
            try
            {
                if (deletePatientId != null)
                {
                    patientDeleted = HMS_DAL.DeletePatientDAL(deletePatientId);
                }
                else
                {
                    throw new HMS_Exception("Invalid Patient Id");
                }
            }
            catch (HMS_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return patientDeleted;
        }

        public static bool AddLabBLL(Lab newLab)
        {
            bool labAdded = false;
            try
            {
                if (ValidateLab(newLab))
                {
                    labAdded = HMS_DAL.AddLabDAL(newLab);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return labAdded;
        }
        public static List<Lab> GetAllLabsBLL()
        {
            List<Lab> LabList = null;
            try
            {
                LabList = HMS_DAL.GetAllLabsDAL();
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LabList;
        }
        public static Lab SearchLabBLL(string searchLabId)
        {
            Lab searchLab = null;
            try
            {
                searchLab = HMS_DAL.SearchLabDAL(searchLabId);
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchLab;
        }
        public static bool UpdateLabBLL(Lab lab)
        {
            bool labUpdated = false;
            try
            {
                if (ValidateLab(lab))
                {
                    labUpdated = HMS_DAL.UpdateLabDAL(lab);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return labUpdated;
        }
        public static bool DeleteLabBLL(string deleteLabId)
        {
            bool labDeleted = false;
            try
            {
                if (deleteLabId != null)
                {
                    labDeleted = HMS_DAL.DeleteLabDAL(deleteLabId);
                }
                else
                {
                    throw new HMS_Exception("Invalid Lab Id");
                }
            }
            catch (HMS_Exception)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return labDeleted;
        }

        public static bool AddBillBLL(Bill newBill)
        {
            bool billAdded = false;
            try
            {
                if (ValidateBill(newBill))
                {
                    billAdded = HMS_DAL.AddBillDAL(newBill);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billAdded;
        }
        public static List<Bill> GetAllBillsBLL()
        {
            List<Bill> BillList = null;
            try
            {
                BillList = HMS_DAL.GetAllBillsDAL();
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BillList;
        }
        public static Bill SearchBillBLL(string searchBillId)
        {
            Bill searchBill = null;
            try
            {
                searchBill = HMS_DAL.SearchBillDAL(searchBillId);
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchBill;
        }
        public static bool UpdateBillBLL(Bill bill)
        {
            bool billUpdated = false;
            try
            {
                if (ValidateBill(bill))
                {
                    billUpdated = HMS_DAL.UpdateBillDAL(bill);
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billUpdated;
        }
        public static bool DeleteBillBLL(string deleteBillId)
        {
            bool billDeleted = false;
            try
            {
                if (deleteBillId != null)
                {
                    billDeleted = HMS_DAL.DeleteBillDAL(deleteBillId);
                }
                else
                {
                    throw new HMS_Exception("Invalid Bill Id");
                }
            }
            catch (HMS_Exception ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return billDeleted;
        }
    }
}
