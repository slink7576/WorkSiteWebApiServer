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
    public class InteractionSubSystemTests
    {
        IInteractionSubSystem interactionSubSys;
        IUnitOfWork mockUnitOfWork;
        IKernel kernel = new NSubstituteMockingKernel();

        [Test]
        public void TestOnApply()
        {
            List<Recrutier> recrutiers = new List<Recrutier>();
            List<Vacansy> vac1 = new List<Vacansy>() { new Vacansy() { Salary = 100 }, new Vacansy() { Salary = 200 } };
            List<Vacansy> vac2 = new List<Vacansy>() { new Vacansy() { Salary = 300 }, new Vacansy() { Salary = 100, OfferedSummarys = new List<Summary>() { new Summary() { Name = "Oleg" } } } };
            recrutiers.Add(new Recrutier() { Login = "good man", vacansies = vac1 });
            recrutiers.Add(new Recrutier() { Login = "very good man", vacansies = vac2 });

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<Recrutier> mockRecruitersRepository = kernel.Get<IGenericRepository<Recrutier>>();
            mockRecruitersRepository.Get().Returns(recrutiers);
            mockUnitOfWork.RecruitersRepository.Returns(mockRecruitersRepository);

            interactionSubSys = new InteractionSubSystem(mockUnitOfWork);

            VacansyBLL vac = new VacansyBLL() { Salary = 100 };
            Summary sm = new Summary() { Name = "Ighor" };

            interactionSubSys.OnApply(vac, CustomMapper.getSummaryBLL(sm));

            List<Summary> list1 = recrutiers[0].vacansies[0].OfferedSummarys;
            List<Summary> list2 = recrutiers[1].vacansies[1].OfferedSummarys;
            bool first = list1.Contains(sm);
            bool second = list2.Contains(sm);

            Assert.AreEqual(recrutiers[0].vacansies[0].OfferedSummarys[0], sm);
        }

        [Test]
        public void TestOnSuggested()
        {
            Vacansy vac1 = new Vacansy() { Purpose = "level1", Salary = 2000 };
            Vacansy vac2 = new Vacansy() { Purpose = "level1", Salary = 4000 };
            Vacansy vac3 = new Vacansy() { Purpose = "level2", Salary = 10000 };
            List<Vacansy> vacansies = new List<Vacansy>() { vac1, vac2, vac3 };
             
            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<Vacansy> mockVacansiesRepository = kernel.Get<IGenericRepository<Vacansy>>();
            mockVacansiesRepository.Get().Returns(vacansies);
            mockUnitOfWork.VacansyRepository.Returns(mockVacansiesRepository);

            interactionSubSys = new InteractionSubSystem(mockUnitOfWork);

            List<VacansyBLL> expected = new List<VacansyBLL>() { CustomMapper.getVacansyBLL(vac2) };
            List<VacansyBLL> real = (List<VacansyBLL>)interactionSubSys.OnSuggested(new SummaryBLL() { Position = "level1", Salary = 3000 });

            Assert.AreEqual(expected, real);
        }

        [Test]
        public void TestOnSuggestedSummaries()
        {
            Summary sm1 = new Summary() { Position = "level1" };
            Summary sm2 = new Summary() { Position = "level2" };
            Summary sm3 = new Summary() { Position = "level1" };
            List<Summary> summary = new List<Summary>() { sm1, sm2, sm3 };

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<Summary> mockSummaryRepository = kernel.Get<IGenericRepository<Summary>>();
            mockSummaryRepository.Get().Returns(summary);
            mockUnitOfWork.SummaryRepository.Returns(mockSummaryRepository);

            interactionSubSys = new InteractionSubSystem(mockUnitOfWork);

            List<SummaryBLL> expected = new List<SummaryBLL>() { CustomMapper.getSummaryBLL(sm1), CustomMapper.getSummaryBLL(sm3) };
            List<SummaryBLL> real = (List<SummaryBLL>)interactionSubSys.OnSuggestedSummaries(new VacansyBLL() { Purpose = "level1" });

            Assert.AreEqual(expected,real);
        }

        [Test]
        public void TestOnOffered()
        {
            Vacansy vac1 = new Vacansy() { Purpose = "level1", OfferedSummarys = new List<Summary>() { new Summary() { Name = "Summary1" } } };
            Vacansy vac2 = new Vacansy() { Purpose = "level1", OfferedSummarys = new List<Summary>() { new Summary() { Name = "Summary2" } } };
            Vacansy vac3 = new Vacansy() { Purpose = "level2", OfferedSummarys = new List<Summary>() { new Summary() { Name = "Summary3" } } };
            List<Vacansy> vacansies = new List<Vacansy>() { vac1, vac2, vac3 };

            mockUnitOfWork = kernel.Get<IUnitOfWork>();
            IGenericRepository<Vacansy> mockVacansiesRepository = kernel.Get<IGenericRepository<Vacansy>>();
            mockVacansiesRepository.Get().Returns(vacansies);
            mockUnitOfWork.VacansyRepository.Returns(mockVacansiesRepository);

            interactionSubSys = new InteractionSubSystem(mockUnitOfWork);

            List<SummaryBLL> real = (List<SummaryBLL>)interactionSubSys.OnOffered(new VacansyBLL() { Purpose = "level2" });
            List<SummaryBLL> expected = new List<SummaryBLL>() { CustomMapper.getSummaryBLL(vac3.OfferedSummarys[0]) };

            Assert.AreEqual(expected, real);
        }
    }
}
