using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities.DAL
{

    [DataContract]
    [KnownType(typeof(User))]
    public class User 
    {
        [DataMember]
        public Summary UserSummary { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int Id { get ; set; }
       
       
    }
}