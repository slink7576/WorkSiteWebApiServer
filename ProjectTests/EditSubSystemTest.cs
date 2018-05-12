using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities.Entities.DAL;
using BusinessLogicLayer.Exceptions;
using UnitOfWorkLayer;
using Moq;
using BusinessLogicLayer.Interfaces;
using System.Linq;
using Ninject;
using CustomNinjectModule;
using Ninject.MockingKernel;
using UnitOfWorkLayer.Repository;
using System.Collections.Generic;

namespace ProjectTests
{
    
    [TestClass]
    public class EditSubSystemTest
    {
        private EditSubSystem editSubSys;
        Mock<IUnitOfWork> mockEditSystem;
        Mock<GenericRepository<User>> mockUser;
        [TestMethod]
        public void TestUpdSummary()
        {
            Reset();
            List<User> users = new List<User>();
            User user1 = new User() { Login = "user1" };
            User user2 = new User() { Login = "user2" };
            users.Add(user1);
            users.Add(user2);

            mockEditSystem.Setup(a => a.UsersRepository).Returns(mockUser.Object);
            mockUser.Setup(a => a.Get(null, null, "")).Returns(users);

            editSubSys.UpdSummary("user1", new Summary());
            //var currUser = uow.UsersRepository.Get().FirstOrDefault(c => c.Login == user);
            Assert.AreNotEqual(null, user1.UserSummary);
        }

        public void Reset()
        {
            mockEditSystem = new Mock<IUnitOfWork>();
            editSubSys = new EditSubSystem(mockEditSystem.Object);
        }
    }

    public class EditSubSystem : IEditSubSystem
    {
        IUnitOfWork uow;
        public EditSubSystem(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void UpdSummary(string user, Summary summ)
        {
            if (summ == null)
            {
                throw new NullSummaryException();
            }
            var currUser = uow.UsersRepository.Get().FirstOrDefault(c => c.Login == user);
            if (currUser == null)
            {
                throw new NoSuchUserException();
            }
            if (currUser != null && currUser.UserSummary != null)
            {

                currUser.UserSummary = summ;


            }
            if (currUser != null && currUser.UserSummary == null)
            {
                currUser.UserSummary = summ;
            }
            uow.Save();
        }
        public void UpdVacansy(string user, Vacansy vacansy)
        {
            if (vacansy == null)
            {
                throw new NullVacansyException();
            }
            var currUser = uow.RecruitersRepository.Get().FirstOrDefault(c => c.Login == user);
            if (currUser == null)
            {
                throw new NoSuchUserException();
            }
            if (currUser != null && currUser.vacansies != null)
            {
                var vacan = currUser.vacansies.FirstOrDefault(c => c.Purpose == vacansy.Purpose);

                if (vacan != null)
                {
                    currUser.vacansies.Remove(vacan);
                    currUser.vacansies.Add(vacansy);
                }
                else
                {
                    currUser.vacansies.Add(vacansy);
                }

            }
            else
            {
                currUser.vacansies.Add(vacansy);
            }
            uow.Save();

        }
    }
}
