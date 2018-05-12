using Entities.Entities.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPresentSubSystem
    {
        ICollection<VacansyBLL> GetVacansies();
        ICollection<SummaryBLL> GetSummary();
        ICollection<SummaryBLL> GetFilteredSummaries(string position, int salary, string sortType);
        ICollection<VacansyBLL> GetFilteredVacansies(string position, string sortType, bool isRemote);
    }
}
