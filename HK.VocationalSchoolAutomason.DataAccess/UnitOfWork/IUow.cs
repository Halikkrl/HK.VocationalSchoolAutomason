using HK.VocationalSchoolAutomason.DataAccess.Interfaces;
using HK.VocationalSchoolAutomason.DataAccess.Repositories;
using HK.VocationalSchoolAutomason.Entities.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.DataAccess.UnitOfWork
{
    public interface IUow 
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}
