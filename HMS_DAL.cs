using System;
using System.Collections.Generic;
using HMS_EntityLayer;
using HMS_ExceptionLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HMS_DataAccessLayer
{
    public class HMS_DAL
    {
        public static List<Patient> patientList = new List<Patient>();
        public static string patientFile = "Patients.txt";
        public static List<Lab> labList = new List<Lab>();
        public static string labFile = "Labs.txt";
        public static List<Bill> billList = new List<Bill>();
        public static string billFile = "Bills.txt";

        public static bool AddPatientDAL(Patient newPatient)
        {
            bool patientAdded = false;
            try
            {
                patientList.Add(newPatient);
                SerializePatients();
                patientAdded = true;
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return patientAdded;
        }
        public static Patient SearchPatientDAL(string searchPatientId)
        {
            DeSerializePatients();
            Patient searchPatient = null;
            try
            {
                searchPatient = patientList.Find(p => p.PatientId == searchPatientId);
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return searchPatient;
        }
        public static bool UpdatePatientDAL(Patient updatePatient)
        {
            bool patientUpdated = false;
            try
            {
                for (int i = 0; i < patientList.Count; i++)
                {
                    if (patientList[i].PatientId == updatePatient.PatientId)
                    {
                        patientList[i].PatientName = updatePatient.PatientName;
                        patientList[i].DOB = updatePatient.DOB;
                        patientList[i].Weight = updatePatient.Weight;
                        patientList[i].Height = updatePatient.Height;
                        patientList[i].Gender = updatePatient.Gender;
                        patientList[i].Address = updatePatient.Address;
                        patientList[i].PhoneNo = updatePatient.PhoneNo;
                        patientUpdated = true;
                        SerializePatients();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return patientUpdated;
        }
        public static bool DeletePatientDAL(string deletePatientId)
        {
            bool patientDeleted = false;
            try
            {
                patientList.Clear();
                DeSerializePatients();
                Patient deletePatient = patientList.Find(p => p.PatientId == deletePatientId);
                if (deletePatient != null)
                {
                    patientList.Remove(deletePatient);
                    patientDeleted = true;
                    SerializePatients();
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return patientDeleted;
        }
        public static List<Patient> GetAllPatientsDAL()
        {
            DeSerializePatients();
            return patientList;
        }
        public static void SerializePatients()
        {
            try
            {
                FileStream fileStream = new FileStream(patientFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, patientList);
                fileStream.Close();
                patientList.Clear();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }
        public static void DeSerializePatients()
        {
            try
            {
                FileStream fileStream = new FileStream(patientFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Patient> patientslist = bf.Deserialize(fileStream) as List<Patient>;
                patientList.Clear();
                foreach (Patient patient in patientslist)
                    patientList.Add(patient);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }

        public static bool AddLabDAL(Lab newLab)
        {
            bool labAdded = false;
            try
            {
                labList.Add(newLab);
                SerializeLabs();
                labAdded = true;
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return labAdded;
        }
        public static List<Lab> GetAllLabsDAL()
        {
            DeSerializeLabs();
            return labList;
        }
        public static Lab SearchLabDAL(string labId)
        {
            DeSerializeLabs();
            Lab searchLab = null;
            try
            {
                searchLab = labList.Find(lab => lab.LabId == labId);
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return searchLab;
        }
        public static bool UpdateLabDAL(Lab updateLab)
        {
            bool labUpdated = false;
            try
            {
                for (int i = 0; i < labList.Count; i++)
                {
                    if (labList[i].LabId == updateLab.LabId)
                    {
                        labList[i].PatientId = updateLab.PatientId;
                        labList[i].TestDate = updateLab.TestDate;
                        labList[i].TestType= updateLab.TestType;
                        labUpdated = true;
                        SerializeLabs();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return labUpdated;
        }
        public static bool DeleteLabDAL(string labId)
        {
            bool labDeleted = false;
            try
            {
                labList.Clear();
                DeSerializeLabs();
                Lab deleteLab = labList.Find(lab => lab.LabId == labId);
                if (deleteLab != null)
                {
                    labList.Remove(deleteLab);
                    labDeleted = true;
                    SerializeLabs();
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return labDeleted;
        }
        public static void SerializeLabs()
        {
            try
            {
                FileStream fileStream = new FileStream(labFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, labList);
                fileStream.Close();
                labList.Clear();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }
        public static void DeSerializeLabs()
        {
            try
            {
                FileStream fileStream = new FileStream(labFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Lab> lablist = bf.Deserialize(fileStream) as List<Lab>;
                labList.Clear();
                foreach (Lab lab in lablist)
                    labList.Add(lab);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }

        public static bool AddBillDAL(Bill newBill)
        {
            bool billAdded = false;
            try
            {
                newBill.TotalAmount = newBill.DoctorFees + newBill.MedicineFees + newBill.RoomCharge + newBill.OperationCharge + newBill.LabFees;
                billList.Add(newBill);
                SerializeBills();
                billAdded = true;
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return billAdded;
        }
        public static List<Bill> GetAllBillsDAL()
        {
            DeSerializeBills();
            return billList;
        }
        public static Bill SearchBillDAL(string searchBillId)
        {
            DeSerializeBills();
            Bill searchBill = null;
            try
            {
                searchBill = billList.Find(p => p.BillId == searchBillId);
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return searchBill;
        }
        public static bool UpdateBillDAL(Bill bill)
        {
            bool billUpdated = false;
            try
            {
                for (int i = 0; i < billList.Count; i++)
                {
                    if (billList[i].BillId == bill.BillId)
                    {
                        billList[i].DoctorFees = bill.DoctorFees;
                        billList[i].LabFees = bill.LabFees;
                        billList[i].RoomCharge = bill.RoomCharge;
                        billList[i].OperationCharge = bill.OperationCharge;
                        billList[i].TotalDays = bill.TotalDays;
                        billList[i].PatientId= bill.PatientId;
                        billList[i].MedicineFees= bill.MedicineFees;
                        billList[i].TotalAmount= bill.DoctorFees+bill.MedicineFees+bill.RoomCharge+bill.OperationCharge+bill.LabFees;
                        billUpdated = true;
                        SerializeBills();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return billUpdated;
        }
        public static bool DeleteBillDAL(string deleteBillId)
        {
            bool billDeleted = false;
            try
            {
                billList.Clear();
                DeSerializeBills();
                Bill deleteBill = billList.Find(b => b.BillId == deleteBillId);
                if (deleteBill != null)
                {
                    billList.Remove(deleteBill);
                    billDeleted = true;
                    SerializeBills();
                }
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
            return billDeleted;
        }
        public static void SerializeBills()
        {
            try
            {
                FileStream fileStream = new FileStream(billFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStream, billList);
                fileStream.Close();
                billList.Clear();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }
        public static void DeSerializeBills()
        {
            try
            {
                FileStream fileStream = new FileStream(billFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                List<Bill> billlist = bf.Deserialize(fileStream) as List<Bill>;
                billList.Clear();
                foreach (Bill bill in billlist)
                    billList.Add(bill);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw new HMS_Exception(ex.Message);
            }
        }
    }
}
