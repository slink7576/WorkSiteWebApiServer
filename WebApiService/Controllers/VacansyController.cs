using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.SubSystems;
using CustomNinjectModule;
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
    public class VacansyController : ApiController
    {
        IKernel kernel;
        SystemFacade database;
       
        public VacansyController()
        {
            kernel = new StandardKernel(new NinjectConfigurationModule());
            database = new SystemFacade(kernel.Get<IEditSubSystem>(), kernel.Get<IInteractionSubSystem>(), kernel.Get<IPresentSubSystem>(), kernel.Get<IVerificationSubSystem>());

        }

        // Get all vacansies.
        [HttpGet]
        public IEnumerable<VacansyBLL> Get()
        {
            return database.getVacansies();
        }
        // Get filtered vacansies.
        [HttpGet]
        public ICollection<VacansyBLL> Get(string position, string sortType, bool isRemote)
        {
            return database.getFilteredVacansies(position, sortType, isRemote);

        }
        // Get offered summaries to vacansy.
        [HttpGet]
        [Route("api/user/offered")]
        public ICollection<SummaryBLL> Get(VacansyBLL summary)
        {
            return database.onOffered(summary);

        }
        // Update vacansy to user.
        [HttpPost]
        [Route("api/vacansy/put/")]
        public void Post(string user, VacansyBLL vacansy)
        {
             database.updVacansy(user, vacansy);

        }
        // Suggested summaries.
        [HttpGet]
        [Route("api/vacansy/suggested")]
        public ICollection<SummaryBLL> Get(string position)
        {

            return database.onSuggestedSummaries(new VacansyBLL() { Purpose = position});

        }
        // Update vacansy to user (json parametr).
        [HttpPost]
        public void Post(JObject data)
        {

            database.updVacansy(data.GetValue("name").ToString(), MyParser.ParseVacansy(data));

        }
        

    }
}
