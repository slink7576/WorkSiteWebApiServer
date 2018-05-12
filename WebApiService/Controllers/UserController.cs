
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.SubSystems;
using CustomNinjectModule;
using Entities;
using Entities.Entities.BLL;
using Entities.Entities.DAL;
using JsonParser;
using Newtonsoft.Json.Linq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApiService.Controllers
{
    public class UserController : ApiController
    {
        IKernel kernel;
        SystemFacade database;
      
        public UserController()
        {
            kernel = new StandardKernel(new NinjectConfigurationModule());
            database = new SystemFacade(kernel.Get<IEditSubSystem>(), kernel.Get<IInteractionSubSystem>(), kernel.Get<IPresentSubSystem>(), kernel.Get<IVerificationSubSystem>());

        }
        // Verification of user.
        [Route("api/user/{login}/{password}")]
        public Object Get(string login, string password)
        {
            return database.checkUser(login, password);
        }
        // Applying user to vacansy.
        [HttpPost]
        [Route("api/user/put/")]
        public void Post(SummaryBLL summ, Vacansy vac)
        {
            database.onApply(CustomMapper.getVacansyBLL(vac), summ);
        }

        // Applying user to vacansy (json).
        [HttpPost]
        public void Post(JObject data)
        {
            database.onApply(MyParser.ApplyVacansyVac(data), MyParser.ApplyVacansySum(data));

        }

    }
}
