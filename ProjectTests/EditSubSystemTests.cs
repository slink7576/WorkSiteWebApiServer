using BusinessLogicLayer.SubSystems;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer;
using UnitOfWorkLayer.Repository;
using NUnit.Framework;
using NSubstitute;
using Ninject;
using CustomNinjectModule;
using BusinessLogicLayer.Interfaces;
using Ninject.MockingKernel;
using Ninject.MockingKernel.NSubstitute;
using System.Data.Entity;
using Entities.Entities.BLL;
using Entities;

namespace ProjectTests
{
    [TestFixture]
    public class EditSubSystemTests
    {
        IEditSubSystem editSubSys;
        IUnitOfWork mockUnitOfWork;
      //  IKernel realKernel = new StandardKernel(new NinjectConfigurationModule());
        IKernel kernel = new NSubstituteMockingKernel();
        
       

        [Test]
        public void TestUpdSummary()
        {
            
            List<User> users = new List<User>();
            User user1 = new User() { Login = "user1" };
            Summary sum1 = new Summary() { Info = "Some info" };
            user1.UserSummary = sum1;
            users.Add(user1);



            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<User> mockUserRepository = kernel.Get<IGenericRepository<User>>();
            mockUserRepository.Get().Returns(users);
            mockUnitOfWork.UsersRepository.Returns(mockUserRepository);

            editSubSys = new EditSubSystem(mockUnitOfWork);
            
            SummaryBLL expected = new SummaryBLL() { Info = "Some updated info" };
            editSubSys.UpdSummary("user1", expected);

            SummaryBLL real = CustomMapper.getSummaryBLL(users.ElementAt(0).UserSummary);

            Assert.AreEqual(expected,real);
        }

        [Test]
        public void TestUpdVacansy()
        {
            List<Recrutier> recrutiers = new List<Recrutier>();
            List<Vacansy> vac1 = new List<Vacansy>() { new Vacansy() { Salary = 100 }, new Vacansy() { Salary = 200 } };
            List<Vacansy> vac2 = new List<Vacansy>() { new Vacansy() { Salary = 300 }, new Vacansy() { Salary = 400 } };
            recrutiers.Add(new Recrutier() { Login = "good man", vacansies = vac1 });
            recrutiers.Add(new Recrutier() { Login = "very good man", vacansies = vac2 });

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<Recrutier> mockRecruitersRepository = kernel.Get<IGenericRepository<Recrutier>>();
            mockRecruitersRepository.Get().Returns(recrutiers);
            mockUnitOfWork.RecruitersRepository.Returns(mockRecruitersRepository);

            editSubSys = new EditSubSystem(mockUnitOfWork);

            Vacansy expected = new Vacansy() { Salary = 1000 };
            editSubSys.UpdVacansy("good man", CustomMapper.getVacansyBLL(expected));

            Vacansy real = recrutiers[0].vacansies.ElementAt(1);

            Assert.AreEqual(expected, real);
        }
    }
}