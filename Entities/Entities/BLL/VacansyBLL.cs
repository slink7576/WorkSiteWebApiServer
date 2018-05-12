using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.BLL
{
    public class VacansyBLL
    {
        public string Purpose { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
        public bool Remote { get; set; }
        public List<SummaryBLL> OfferedSummarys{ get; set; }
        public VacansyBLL()
        {
            OfferedSummarys = new List<SummaryBLL>();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                if (Purpose == (obj as VacansyBLL).Purpose  && Salary == (obj as VacansyBLL).Salary && Description == (obj as VacansyBLL).Description && Remote == (obj as VacansyBLL).Remote && OfferedSummarys.Capacity == (obj as VacansyBLL).OfferedSummarys.Capacity)
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
