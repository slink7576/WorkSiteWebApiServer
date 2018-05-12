using AutoMapper;
using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MyMapper
    {
       /* static IMapper iMapper;
        static MyMapper()
        {
           var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<User, UserBLL>().ForMember("UserSummary", opts => opts.MapFrom(source => source.UserSummary));

            });
            iMapper = config.CreateMapper();
        }
        public static UserBLL GetUser(User user)
        {
            return iMapper.Map<User, UserBLL>(user);
        }*/
    }
}
