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
    public class EditSubSystem : IEditSubSystem
    {
        IUnitOfWork uow;
        public EditSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void UpdSummary(string user, SummaryBLL summ)
        {
            if(summ == null)
            {
                throw new NullSummaryException();
            }
            var currUser = uow.UsersRepository.Get().FirstOrDefault(c => c.Login == user);
            if (currUser == null)
            {
                throw new NoSuchUserException();
            }
            if (currUser != null)
            {

                currUser.UserSummary = CustomMapper.getSummary(summ);

     
            }
            uow.Save();
        }
        public void UpdVacansy(string user, VacansyBLL vacansy)
        {
            if (vacansy == null)
            {
                throw new NullVacansyException();
            }
            var currUser = uow.RecruitersRepository.Get().FirstOrDefault(c => c.Login == user);
            if(currUser == null)
            {
                throw new NoSuchUserException();
            }
            if (currUser != null && currUser.vacansies != null)
            {
                var vacan = currUser.vacansies.FirstOrDefault(c=> c.Purpose == vacansy.Purpose);

                if (vacan != null)
                {
                    currUser.vacansies.Remove(vacan);
                    currUser.vacansies.Add(CustomMapper.getVacansy(vacansy));
                }
                else
                {
                    currUser.vacansies.Add(CustomMapper.getVacansy(vacansy));
                }
                
            }
            else
            {
                currUser.vacansies.Add(CustomMapper.getVacansy(vacansy));
            }
            uow.Save();
                
        }
    }
}