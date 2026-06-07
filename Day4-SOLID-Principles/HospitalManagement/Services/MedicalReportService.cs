using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Services
{
    public class MedicalReportService
    {
        public void GenerateReport(string patient,string doctor)
        {
            Console.WriteLine($"Medical Report Generated for {patient} by Dr. {doctor}");
        }
    }
}
