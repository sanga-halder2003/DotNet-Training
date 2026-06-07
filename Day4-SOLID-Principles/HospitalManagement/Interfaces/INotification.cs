// OCP: New notification types can be added
// without modifying existing code.
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
