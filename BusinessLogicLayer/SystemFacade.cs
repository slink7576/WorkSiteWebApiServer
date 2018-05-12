using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.SubSystems;
using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    

    public class SystemFacade
    {
        IEditSubSystem editSystem;
        IInteractionSubSystem interactionSystem;
        IPresentSubSystem presentSystem;
        IVerificationSubSystem verificationSystem;
        public SystemFacade(IEditSubSystem editSystem, IInteractionSubSystem interactionSystem, IPresentSubSystem presentSystem, IVerificationSubSystem verificationSystem)
        {
            this.editSystem = editSystem;
            this.interactionSystem = interactionSystem;
            this.presentSystem = presentSystem;
            this.verificationSystem = verificationSystem;
        }
        public object checkUser(string login, string password)
        {
            return verificationSystem.CheckUser(login, password);
        }
        public ICollection<VacansyBLL> getVacansies()
        {
            return presentSystem.GetVacansies();
        }
        public ICollection<SummaryBLL> getSummaries()
        {
           
            return presentSystem.GetSummary();
        }
        public ICollection<SummaryBLL> getFilteredSummaries(string position, int salary, string sortType)
        {
            return presentSystem.GetFilteredSummaries( position,  salary,  sortType);
        }
        public ICollection<VacansyBLL> getFilteredVacansies(string position, string sortType, bool isRemote)
        {
            return presentSystem.GetFilteredVacansies(position, sortType, isRemote);
        }
        public void onApply(VacansyBLL vacnsy, SummaryBLL summary)
        {
            interactionSystem.OnApply(vacnsy, summary);
        }
        public void updSummary(string user, SummaryBLL summ)
        {
            editSystem.UpdSummary(user, summ);
        }
        public void updVacansy(string user, VacansyBLL vacansy)
        {
            editSystem.UpdVacansy(user, vacansy);
        }
        public ICollection<SummaryBLL> onOffered(VacansyBLL vacansy)
        {
            return interactionSystem.OnOffered(vacansy);
        }
        public ICollection<VacansyBLL> onSuggested(SummaryBLL summary)
        {
            return interactionSystem.OnSuggested(summary);
        }
        public ICollection<SummaryBLL> onSuggestedSummaries(VacansyBLL vacansy)
        {
            return interactionSystem.OnSuggestedSummaries(vacansy);
        }
    }
}