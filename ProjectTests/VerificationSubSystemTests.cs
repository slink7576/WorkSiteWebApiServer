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
    public class VerificationSubSystemTests
    {
        IVerificationSubSystem verificationSubSys;
        IUnitOfWork mockUnitOfWork;
        IKernel kernel = new NSubstituteMockingKernel();

        [Test]
        public void TestCheckUser()
        {
            User user1 = new User() { Login = "user1", Password = "1" };
            User user2 = new User() { Login = "user2", Password = "2" };
            List<User> users = new List<User>() { user1, user2 };

            Recrutier recrutier1 = new Recrutier() { Login = "recrutier1", Password = "3" };
            Recrutier recrutier2 = new Recrutier() { Login = "recrutier2", Password = "4" };
            List<Recrutier> recrutiers = new List<Recrutier>() { recrutier1, recrutier2 };

            Admin admin1 = new Admin() { Login = "admin1", Password = "5" };
            Admin admin2 = new Admin() { Login = "admin2", Password = "6" };
            List<Admin> admins = new List<Admin>() { admin1, admin2 };

            mockUnitOfWork = kernel.Get<IUnitOfWork>();

            IGenericRepository<User> mockUserRepository = kernel.Get<IGenericRepository<User>>();
            mockUserRepository.Get().Returns(users);
            mockUnitOfWork.UsersRepository.Returns(mockUserRepository);

            IGenericRepository<Recrutier> mockRecrutierRepository = kernel.Get<IGenericRepository<Recrutier>>();
            mockRecrutierRepository.Get().Returns(recrutiers);
            mockUnitOfWork.RecruitersRepository.Returns(mockRecrutierRepository);

            IGenericRepository<Admin> mockAdminRepository = kernel.Get<IGenericRepository<Admin>>();
            mockAdminRepository.Get().Returns(admins);
            mockUnitOfWork.AdminsRepository.Returns(mockAdminRepository);

            verificationSubSys = new VerificationSubSystem(mockUnitOfWork);

            AdminBLL expected = CustomMapper.getAdminBLL(admin1);
            AdminBLL real = (AdminBLL)verificationSubSys.CheckUser("admin1", ":");
            Assert.AreEqual(expected.Login, real.Login);
        }
    }
}
