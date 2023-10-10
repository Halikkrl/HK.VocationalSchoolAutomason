using HK.VocationalSchoolAutomason.DataAccess.Contexts;
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
    public class Uow : IUow
    {
        private readonly SchoolContext _context;

        public Uow(SchoolContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
