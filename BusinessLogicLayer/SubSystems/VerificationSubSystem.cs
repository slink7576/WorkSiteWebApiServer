
using BusinessLogicLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer;

namespace BusinessLogicLayer.SubSystems
{
    public class VerificationSubSystem : IVerificationSubSystem
    {
        IUnitOfWork uow;
        public VerificationSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public object CheckUser(string login, string password)
        {
            password = DecryptPassword(password);
            if (uow.UsersRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password) != null)
            {
                return CustomMapper.getUserBLL(uow.UsersRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password));
            }
            if (uow.RecruitersRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password) != null)
            {
                return CustomMapper.getRecruiterBLL(uow.RecruitersRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password));
            }
            if (uow.AdminsRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password) != null)
            {
                return CustomMapper.getAdminBLL(uow.AdminsRepository.Get().FirstOrDefault(c => c.Login == login && c.Password == password));
            }
            else
            {
                return null;
            }
        }
        public string DecryptPassword(string pass)
        {
            var tmp = "";
            foreach (var c in pass)
            {
                tmp += (char)(((int)c) - 5);
            }
            return tmp;
        }
    }
   
}