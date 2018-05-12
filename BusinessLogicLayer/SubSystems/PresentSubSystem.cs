using BusinessLogicLayer.Interfaces;
using Entities;
using Entities.Entities.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer;

namespace BusinessLogicLayer.SubSystems
{
    public class PresentSubSystem : IPresentSubSystem
    {
        IUnitOfWork uow;
        public PresentSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ICollection<VacansyBLL> GetVacansies()
        {
            return uow.RecruitersRepository.Get()
                .SelectMany(c => CustomMapper.getVacansies(c.vacansies)).ToList();
        }
        public ICollection<SummaryBLL> GetSummary()
        {
            return uow.UsersRepository.Get()
                .Select(c => CustomMapper.getSummaryBLL(c.UserSummary)).ToList();
        }
       
        public ICollection<SummaryBLL> GetFilteredSummaries(string position, int salary, string sortType)
        {
           
            if (salary.ToString() == "")
            {
                salary = Int32.MaxValue;
            }
           
            if (sortType == "Salary")
            {
                if (position == null)
                {
                    return GetSummary().Where(c =>  c.Salary < salary)
                        .OrderBy(c => c.Salary).ToList();

                }
                else
                {
                    return GetSummary().Where(c => c.Position.Contains(position) && c.Salary < salary)
                        .OrderBy(c => c.Salary).ToList();

                }

            }
            if (sortType == "Name")
            {
                if (position == null)
                {
                    return GetSummary().Where(c =>  c.Salary < salary)
                        .OrderBy(c => c.Name).ToList();

                }
                else
                {
                    return GetSummary().Where(c => c.Position.Contains(position) && c.Salary < salary)
                        .OrderBy(c => c.Name).ToList();

                }
            }
            else
            {
                return null;
            }

        }
        public ICollection<VacansyBLL> GetFilteredVacansies(string position, string sortType, bool isRemote)
        {
            if (position == null)
            {
                position = "";
            }
            if (sortType == "Salary")
            {
                return GetVacansies().Where(c => c.Purpose.Contains(position) && c.Remote == isRemote)
                    .OrderBy(c => c.Salary).ToList();

            }
            if (sortType == "Title")
            {
                return GetVacansies().Where(c => c.Purpose.Contains(position) && c.Remote == isRemote)
                    .OrderBy(c => c.Purpose).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}