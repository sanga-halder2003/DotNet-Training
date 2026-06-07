using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagement.Interfaces
{
    public interface INotification
    {
        void Send(string message);
    }
}
