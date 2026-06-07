using System;
using System.Collections.Generic;
using System.Text;

namespace RiderSharingApp.Interfaces
{
    public interface INotification
    {
        void Send(string message);
    }
}
