
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entities.Entities.BLL
{
    [DataContract]
    [KnownType(typeof(AdminBLL))]
    public class AdminBLL : GlobalUserBLL
    {
    }
}