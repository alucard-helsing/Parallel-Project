using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_EntityLayer
{
    [Serializable]
    public class Patient
    {
        private string patientId;
        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        private string patientName;
        public string PatientName
        {
            get { return patientName; }
            set { patientName = value; }
        }
        private DateTime dOB;
        public DateTime DOB
        {
            get { return dOB; }
            set { dOB = value; }
        }
        private int weight;
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private double phoneNo;
        public double PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }
    }
    [Serializable]
    public class Lab
    {
        private string labId;
        public string LabId
        {
            get { return labId; }
            set { labId = value; }
        }
        private string patientId;
        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        private string testType;
        public string TestType
        {
            get { return testType; }
            set { testType = value; }
        }
        private DateTime testDate;
        public DateTime TestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }
       
    }
    [Serializable]
    public class Bill   
    {
        private string billId;
        public string BillId
        {
            get { return billId; }
            set { billId = value; }
        }
        private string patientId;
        public string PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }
        private double doctorFees;
        public double DoctorFees
        {
            get { return doctorFees; }
            set { doctorFees = value; }
        }
        private double roomCharge;
        public double RoomCharge
        {
            get { return roomCharge; }
            set { roomCharge = value; }
        }
        private double operationCharge;
        public double OperationCharge
        {
            get { return operationCharge; }
            set { operationCharge = value; }
        }
        private double medicineFees;
        public double MedicineFees
        {
            get { return medicineFees; }
            set { medicineFees = value; }
        }
        private int totalDays;
        public int TotalDays
        {
            get { return totalDays; }
            set { totalDays = value; }
        }
        private double labFees;
        public double LabFees
        {
            get { return labFees; }
            set { labFees = value; }
        }
        private double totalAmount;
        public double TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
    }
}
