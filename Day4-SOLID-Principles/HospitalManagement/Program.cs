using HospitalManagement.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services;

class Program
{
    static void Main(string[] args)
    {
        Patient p = new Patient
        { Name = "Sanga"
        };
        Doctor d = new Doctor
        { Name = "Shobhika Shelvaraj"
        };

        MedicalReportService report = new MedicalReportService();
        report.GenerateReport(p.Name, d.Name);

        IPayment payment = new CreditcardPayment();
        payment.Pay(5000);

        INotification notification = new WhatsAppNotification();
        notification.Send("Appoinment Confirmed");




    }
}

