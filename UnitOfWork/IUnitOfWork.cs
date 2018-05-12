using Entities.Entities.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnitOfWorkLayer.Repository;

namespace UnitOfWorkLayer
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> UsersRepository { get; }
        IGenericRepository<Recrutier> RecruitersRepository { get; }
        IGenericRepository<Vacansy> VacansyRepository { get; }
        IGenericRepository<Summary> SummaryRepository { get; }
        IGenericRepository<Admin> AdminsRepository { get; }
        void Save();
        void Dispose();
    }
}