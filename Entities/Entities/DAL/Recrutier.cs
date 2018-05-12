using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities.DAL
{ 
    public class Recrutier 
    {
      
        public int Id { get; set; }
     
        public List<Vacansy> vacansies { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       
       
    }
}