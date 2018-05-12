
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entities.Entities.DAL
{
    [DataContract]
    [KnownType(typeof(Admin))]
    public class Admin : GlobalUser
    {
        
    }
}