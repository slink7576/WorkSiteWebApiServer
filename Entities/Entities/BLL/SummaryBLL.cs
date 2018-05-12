using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Entities.BLL
{
    public class SummaryBLL
    {
       
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
                if (Name == (obj as SummaryBLL).Name && Position == (obj as SummaryBLL).Position && Info == (obj as SummaryBLL).Info && Salary == (obj as SummaryBLL).Salary)
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