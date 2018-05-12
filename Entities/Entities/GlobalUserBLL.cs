
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entities.Entities.BLL
{
    [DataContract]
    [KnownType(typeof(GlobalUserBLL))]
    public class GlobalUserBLL
    {
        [DataMember]
        public string Login { get; set; }
    }
}