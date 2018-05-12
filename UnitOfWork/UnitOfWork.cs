using DataAccessLayer;
using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Repository;

namespace UnitOfWorkLayer
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext context;
        private IGenericRepository<User> usersRepository;
        private IGenericRepository<Recrutier> recruitersRepository;
        private IGenericRepository<Vacansy> vacansyRepository;
        private IGenericRepository<Summary> summaryRepository;
        private IGenericRepository<Admin> adminsRepository;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
            
            usersRepository = new GenericRepository<User>(context);
            recruitersRepository = new GenericRepository<Recrutier>(context);
            vacansyRepository = new GenericRepository<Vacansy>(context);
            summaryRepository = new GenericRepository<Summary>(context);
        }
        public IGenericRepository<Admin> AdminsRepository
        {
            get
            {

                if (this.adminsRepository == null)
                {
                    this.adminsRepository = new GenericRepository<Admin>(context);
                }
               

                return adminsRepository;
            }
        }

        public IGenericRepository<Summary> SummaryRepository
        {
            get
            {

                if (this.summaryRepository == null)
                {
                    this.summaryRepository = new GenericRepository<Summary>(context);
                }
                var loadActivity = vacansyRepository.Get();
                var loadActivity2 = summaryRepository.Get();
                var loadActivity3 = recruitersRepository.Get();
              
                return summaryRepository;
            }
        }
        public IGenericRepository<Vacansy> VacansyRepository
        {
            get
            {

                if (this.vacansyRepository == null)
                {
                    this.vacansyRepository = new GenericRepository<Vacansy>(context);
                }

                var loadActivity = vacansyRepository.Get();
                var loadActivity2 = summaryRepository.Get();
                return vacansyRepository;
            }
        }

        public IGenericRepository<User> UsersRepository
        {
            get
            {

                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<User>(context);
                }
               
                var loadActivity = vacansyRepository.Get();
                var loadActivity2 = summaryRepository.Get();
                return usersRepository;
            }
        }
        public IGenericRepository<Recrutier> RecruitersRepository
        {
            get
            {

                if (this.recruitersRepository == null)
                {
                    this.recruitersRepository = new GenericRepository<Recrutier>(context);
                }
                 var loadActivity = vacansyRepository.Get();
                 var loadActivity2 = summaryRepository.Get();
                return recruitersRepository;
            }
        }

      

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
