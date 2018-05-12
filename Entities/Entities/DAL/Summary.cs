using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities.DAL
{
  
    public class Summary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Info { get; set; }
        public int Salary { get; set; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                throw new ArgumentException();
            }
            else
            {
                if (Name == (obj as Summary).Name && Position == (obj as Summary).Position && Info == (obj as Summary).Info && Salary == (obj as Summary).Salary)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}