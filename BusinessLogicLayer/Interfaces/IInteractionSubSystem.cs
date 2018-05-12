using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IInteractionSubSystem
    {
        void OnApply(VacansyBLL vacnsy, SummaryBLL summary);
        ICollection<VacansyBLL> OnSuggested(SummaryBLL summary);
        ICollection<SummaryBLL> OnOffered(VacansyBLL vacansy);
        ICollection<SummaryBLL> OnSuggestedSummaries(VacansyBLL vacansy);
    }
}
