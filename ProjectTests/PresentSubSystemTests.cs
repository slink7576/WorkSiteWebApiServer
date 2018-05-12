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
    public class PresentSubSystemTests
    {
        IPresentSubSystem presentSubSys;
        IUnitOfWork mockUnitOfWork;
        IKernel kernel = new NSubstituteMockingKernel();
        IGenericRepository<Recrutier> mockRecruitersRepository;
        IGenericRepository<User> mockUserRepository;

        [Test]
        public void TestGetVacansies()
        {
            List<Recrutier> recrutiers = new List<Recrutier>();
            List<Vacansy> vac1 = new List<Vacansy>() { new Vacansy() { Salary = 100 }, new Vacansy() { Salary = 200 } };
            List<Vacansy> vac2 = new List<Vacansy>() { new Vacansy() { Salary = 300 }, new Vacansy() { Salary = 100 } };
            recrutiers.Add(new Recrutier() { Login = "good man", vacansies = vac1 });
            recrutiers.Add(new Recrutier() { Login = "very good man", vacansies = vac2 });

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            mockRecruitersRepository = kernel.Get<IGenericRepository<Recrutier>>();
            mockRecruitersRepository.Get().Returns(recrutiers);
            mockUnitOfWork.RecruitersRepository.Returns(mockRecruitersRepository);

            presentSubSys = new PresentSubSystem(mockUnitOfWork);

            List<VacansyBLL> expected = new List<VacansyBLL>() { CustomMapper.getVacansyBLL(vac1[0]), CustomMapper.getVacansyBLL(vac1[1]), CustomMapper.getVacansyBLL(vac2[0]), CustomMapper.getVacansyBLL(vac2[1]) };
            List<VacansyBLL> real = (List<VacansyBLL>)presentSubSys.GetVacansies();

            Assert.AreEqual(expected, real);
        }

        [Test]
        public void TestGetSummary()
        {
            User user1 = new User() { UserSummary = new Summary() { Name = "summary1" } };
            User user2 = new User() { UserSummary = new Summary() { Name = "summary2" } };
            User user3 = new User() { UserSummary = new Summary() { Name = "summary3" } };
            List<User> users = new List<User>() { user1, user2, user3 };

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            mockUserRepository = kernel.Get<IGenericRepository<User>>();
            mockUserRepository.Get().Returns(users);
            mockUnitOfWork.UsersRepository.Returns(mockUserRepository);

            presentSubSys = new PresentSubSystem(mockUnitOfWork);

            List<SummaryBLL> expected = new List<SummaryBLL>() { CustomMapper.getSummaryBLL(user1.UserSummary), CustomMapper.getSummaryBLL(user2.UserSummary), CustomMapper.getSummaryBLL(user3.UserSummary) };
            List<SummaryBLL> real = (List<SummaryBLL>)presentSubSys.GetSummary();

            Assert.AreEqual(expected, real);
        }

        [Test]
        public void TestGetFilteredSummaries()
        {
            User user1 = new User() { UserSummary = new Summary() { Name = "summary1", Position = "worker", Salary = 1000 } };
            User user2 = new User() { UserSummary = new Summary() { Name = "summary2", Position = "teacher", Salary = 4000 } };
            User user3 = new User() { UserSummary = new Summary() { Name = "summary3", Position = "worker", Salary = 8000 } };
            List<User> users = new List<User>() { user1, user2, user3 };

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            mockUserRepository = kernel.Get<IGenericRepository<User>>();
            mockUserRepository.Get().Returns(users);
            mockUnitOfWork.UsersRepository.Returns(mockUserRepository);

            presentSubSys = new PresentSubSystem(mockUnitOfWork);

            List<SummaryBLL> expected = new List<SummaryBLL>() { CustomMapper.getSummaryBLL(user1.UserSummary) };
            List<SummaryBLL> real = (List<SummaryBLL>)presentSubSys.GetFilteredSummaries("worker", 6000, "Name");

            Assert.AreEqual(expected, real);
        }

        [Test]
        public void TestGetFilteredVacansies()
        {
            List<Recrutier> recrutiers = new List<Recrutier>();
            List<Vacansy> vac1 = new List<Vacansy>() { new Vacansy() { Purpose = "worker", Remote = true }, new Vacansy() { Purpose = "worker", Remote = false } };
            List<Vacansy> vac2 = new List<Vacansy>() { new Vacansy() { Purpose = "teacher", Remote = true }, new Vacansy() { Purpose = "worker", Remote = true } };
            recrutiers.Add(new Recrutier() { Login = "good man", vacansies = vac1 });
            recrutiers.Add(new Recrutier() { Login = "very good man", vacansies = vac2 });

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            mockRecruitersRepository = kernel.Get<IGenericRepository<Recrutier>>();
            mockRecruitersRepository.Get().Returns(recrutiers);
            mockUnitOfWork.RecruitersRepository.Returns(mockRecruitersRepository);

            presentSubSys = new PresentSubSystem(mockUnitOfWork);

            List<VacansyBLL> expected = new List<VacansyBLL>() { CustomMapper.getVacansyBLL(vac1[0]), CustomMapper.getVacansyBLL(vac2[1])};
            List<VacansyBLL> real = (List<VacansyBLL>)presentSubSys.GetFilteredVacansies("worker", "Title", true);

            Assert.AreEqual(expected, real);
        }

    }
}
