using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities.BLL
{
    [DataContract]
    [KnownType(typeof(RecrutierBLL))]
    public class RecrutierBLL : GlobalUserBLL
    {
        [DataMember]
        public List<VacansyBLL> vacansies { get; set; }
    }
}