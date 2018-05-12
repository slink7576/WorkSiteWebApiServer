using Entities.Entities.BLL;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEditSubSystem
    {
        
        void UpdSummary(string user, SummaryBLL summ);
        void UpdVacansy(string user, VacansyBLL vacansy);
    }
}
