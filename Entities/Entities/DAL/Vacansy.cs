using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.DAL
{

    public class Vacansy
    {
        public int Id { get; set; }
        public string Purpose { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
        public bool Remote { get; set; }
    
        public List<Summary> OfferedSummarys{ get; set; }
       
        public Vacansy()
        {
            OfferedSummarys = new List<Summary>();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                throw new ArgumentException();
            }
            else
            {
                if (Purpose == (obj as Vacansy).Purpose &&  Id == (obj as Vacansy).Id && Salary == (obj as Vacansy).Salary && Description == (obj as Vacansy).Description && Remote == (obj as Vacansy).Remote && OfferedSummarys.Capacity == (obj as Vacansy).OfferedSummarys.Capacity)
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
