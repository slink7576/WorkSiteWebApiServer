using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Interfaces;
using Entities;
using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer;

namespace BusinessLogicLayer.SubSystems
{
   public class InteractionSubSystem : IInteractionSubSystem
    {
        IUnitOfWork uow;
        public InteractionSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
            
            
        public void OnApply(VacansyBLL vacnsy, SummaryBLL summary)
        {
            if(summary == null)
            {
                throw new NullSummaryException();
            }
            if (vacnsy == null)
            {
                throw new NullVacansyException();
            }
            Vacansy tmp = uow.RecruitersRepository.Get().Select(c => c.vacansies
                .FirstOrDefault(g => g.Description == vacnsy.Description && g.Purpose == vacnsy.Purpose && g.Salary == vacnsy.Salary))
                    .FirstOrDefault( p => p != null);
           
            if (tmp.OfferedSummarys == null)
            {
                tmp.OfferedSummarys = new List<Summary>();
                tmp.OfferedSummarys.Add(CustomMapper.getSummary(summary));
            }
            else
            {
                if(tmp.OfferedSummarys.FirstOrDefault(c=> c.Name == summary.Name && c.Salary == summary.Salary && c.Info == summary.Info) != null)
                {
                    throw new SameSummaryException();
                }
                else
                {
                    tmp.OfferedSummarys.Add(CustomMapper.getSummary(summary));
                }
            }

                uow.Save();

        }
        public ICollection<VacansyBLL> OnSuggested(SummaryBLL summary)
        {
            return CustomMapper.getVacansies(uow.VacansyRepository.Get()
                .Where(g => g.Purpose.Contains(summary.Position) && g.Salary >= summary.Salary)).ToList();
        }
        public ICollection<SummaryBLL> OnSuggestedSummaries(VacansyBLL vacansy)
        {
            return CustomMapper.getSummaries(uow.SummaryRepository.Get()
                .Where(c => c.Position == vacansy.Purpose)).ToList();
        }
        public ICollection<SummaryBLL> OnOffered(VacansyBLL vacansy)
        {
            return CustomMapper.getSummaries(uow.VacansyRepository.Get()
                    .FirstOrDefault(c => c.Purpose == vacansy.Purpose && c.Salary == vacansy.Salary && c.Description == vacansy.Description)
                        .OfferedSummarys).ToList(); 
        }
    }
}