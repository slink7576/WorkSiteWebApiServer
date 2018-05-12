using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IVerificationSubSystem
    {
        object CheckUser(string login, string password);
        string DecryptPassword(string pass);
    }
}
