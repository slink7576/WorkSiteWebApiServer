using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Entities.Entities.BLL;

namespace JsonParser
{
    public static class MyParser
    {
        public static VacansyBLL ApplyVacansyVac(JObject data)
        {
            bool check = true;
            var parametr = data.GetValue("summary").ToArray();
            var vacansy = data.GetValue("vacansy").ToArray();
            var offered = vacansy[4].ToArray();
            var offeredSummary = new List<Summary>();
            foreach (var c in offered)
            {
                foreach (var j in c.ToArray())
                {

                    offeredSummary.Add(new Summary() { Info = j.ToArray()[3].Last.ToString(), Name = j.ToArray()[0].Last.ToString(), Position = j.ToArray()[1].Last.ToString(), Salary = Int32.Parse(j.ToArray()[3].Last.ToString()) });
                }

            }

            if (vacansy[3].Last.ToString() == "False")
            {
                check = false;
            }
            return new VacansyBLL() { Description = vacansy[0].Last.ToString(), Salary = Int32.Parse(vacansy[1].Last.ToString()), Remote = check, Purpose = vacansy[2].Last.ToString() };
        }
        public static SummaryBLL ApplyVacansySum(JObject data)
        {
            bool check = true;
            var parametr = data.GetValue("summary").ToArray();
            var vacansy = data.GetValue("vacansy").ToArray();
            var offered = vacansy[4].ToArray();
            var offeredSummary = new List<Summary>();
            foreach (var c in offered)
            {
                foreach (var j in c.ToArray())
                {

                    offeredSummary.Add(new Summary() { Info = j.ToArray()[3].Last.ToString(), Name = j.ToArray()[0].Last.ToString(), Position = j.ToArray()[1].Last.ToString(), Salary = Int32.Parse(j.ToArray()[3].Last.ToString()) });
                }

            }

            if (vacansy[3].Last.ToString() == "False")
            {
                check = false;
            }
            return new SummaryBLL() { Info = parametr[2].Last.ToString(), Name = parametr[0].Last.ToString(), Position = parametr[1].Last.ToString(), Salary = Int32.Parse(parametr[3].Last.ToString()) };
        }
        public static SummaryBLL ParseSummary(JObject data)
        {
            var parametr = data.GetValue("summary").ToArray();
            return new SummaryBLL() { Info = parametr[2].Last.ToString(), Name = parametr[0].Last.ToString(), Position = parametr[1].Last.ToString(), Salary = Int32.Parse(parametr[3].Last.ToString()) };
        }
        public static VacansyBLL ParseVacansy(JObject data)
        {
            var parametr = data.GetValue("vacansy").ToArray();
            bool check = false;
            if (parametr[3].Last.ToString() == "True")
            {
                check = true;
            }
            return new VacansyBLL() { Description = parametr[0].Last.ToString(), Purpose = parametr[2].Last.ToString(), Remote = check, Salary = Int32.Parse(parametr[1].Last.ToString()) };
        }
    }
}
