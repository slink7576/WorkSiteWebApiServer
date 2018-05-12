using BusinessLogicLayer.SubSystems;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer;
using UnitOfWorkLayer.Repository;
using Entities.Entities.DAL;

namespace CustomNinjectModule
{
    public class NinjectConfigurationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<DbContext>().To<DataBase>();
            Bind<IEditSubSystem>().To<EditSubSystem>();
            Bind<IVerificationSubSystem>().To<VerificationSubSystem>();
            Bind<IPresentSubSystem>().To<PresentSubSystem>();
            Bind<IInteractionSubSystem>().To<InteractionSubSystem>();
            Bind<IGenericRepository<User>>().To<IGenericRepository<User>>();
            Bind<IGenericRepository<Admin>>().To<IGenericRepository<Admin>>();
            Bind<IGenericRepository<Admin>>().To<IGenericRepository<Admin>>();
            Bind<IGenericRepository<Summary>>().To<IGenericRepository<Summary>>();
            Bind<IGenericRepository<Vacansy>>().To<IGenericRepository<Vacansy>>();
            Bind<IGenericRepository<Recrutier>>().To<IGenericRepository<Recrutier>>();
        }
    }
}
