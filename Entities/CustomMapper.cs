using AutoMapper;
using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entities
{
    public static class CustomMapper
    {
        static IMapper iMapper;
        static CustomMapper()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserBLL>();
                cfg.CreateMap<Vacansy, VacansyBLL>();
                cfg.CreateMap<Summary, SummaryBLL>();
                cfg.CreateMap<Recrutier, RecrutierBLL>();
                cfg.CreateMap<Admin, AdminBLL>();
                cfg.CreateMap<VacansyBLL, Vacansy>();
                cfg.CreateMap<SummaryBLL, Summary>();
            });
            iMapper = config.CreateMapper();
           

        }
        public static IEnumerable<VacansyBLL> getVacansies(IEnumerable<Vacansy> vacansies)
        {

            return vacansies.Select(c => new VacansyBLL {
                Description = c.Description,
                OfferedSummarys = getSummaries(c.OfferedSummarys.Where(g => g != null)).ToList(),
                Purpose = c.Purpose,
                Remote = c.Remote, 
                Salary = c.Salary
            });
       
        }
        public static IEnumerable<SummaryBLL> getSummaries(IEnumerable<Summary> summaries)
        {
            return summaries.Select(c => new SummaryBLL
            {
                Info = c.Info,
                Position = c.Position,
                Salary = c.Salary,
                Name = c.Name

            }).Where(v=> v!= null);

        }
        public static Summary getSummary(SummaryBLL sc)
        {
            return iMapper.Map<Summary>(sc);
        }

        public static Vacansy getVacansy(VacansyBLL sc)
        {
            return iMapper.Map<Vacansy>(sc);
        }

        public static SummaryBLL getSummaryBLL(Summary sc)
        {
           
            return iMapper.Map<SummaryBLL>(sc);
        }
        public static VacansyBLL getVacansyBLL(Vacansy sc)
        {
            return iMapper.Map<VacansyBLL>(sc);
        }
        public static UserBLL getUserBLL(User sc)
        {
            return iMapper.Map<UserBLL>(sc);
        }
        public static RecrutierBLL getRecruiterBLL(Recrutier sc)
        {
            return iMapper.Map<RecrutierBLL>(sc);
        }
        public static AdminBLL getAdminBLL(Admin sc)
        {
            return iMapper.Map<AdminBLL>(sc);
        }

    }
}