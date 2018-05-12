using BusinessLogicLayer;
using Entities.Entities.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer.SubSystems;
using Entities.Entities.BLL;
using Ninject;
using CustomNinjectModule;
using BusinessLogicLayer.Interfaces;
using JsonParser;

namespace WebApiService.Controllers
{
    

    public class SummaryController : ApiController
    {
        IKernel kernel;
        SystemFacade database;
    
        public SummaryController()
        {
            kernel = new StandardKernel(new NinjectConfigurationModule());
            database = new SystemFacade(kernel.Get<IEditSubSystem>(), kernel.Get<IInteractionSubSystem>(), kernel.Get<IPresentSubSystem>(), kernel.Get<IVerificationSubSystem>());
        }
        // Get all summaries.
        [HttpGet]
        public ICollection<SummaryBLL> Get()
        {
            return database.getSummaries();

        }
        // Get filtered summaries.
        [HttpGet]
        public ICollection<SummaryBLL> Get(string position, int salary, string sortType)
        {
            return database.getFilteredSummaries(position,salary,sortType);

        }
        // Get suggested vacansies to summary.
        [HttpGet]
        [Route("api/user/suggested")]
        public ICollection<VacansyBLL> Get(string position, int salary)
        {
            
            return database.onSuggested(new SummaryBLL() {  Position = position, Salary = salary});

        }
        // Update summary to user.
        [HttpPost]
        [Route("api/summary/put/")]
        public void Post(string user, SummaryBLL summary)
        {
            database.updSummary(user, summary);

        }
        // Update summary to user (json).
        [HttpPost]
        public void Post(JObject data)
        {
            
            database.updSummary(data.GetValue("name").ToString(), MyParser.ParseSummary(data));
         

        }


    }
}
