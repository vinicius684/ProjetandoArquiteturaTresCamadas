using Business.Interfaces;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UoW
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly MeuDbContext _context;

        public UnitOfWork(MeuDbContext context) 
        {
            _context = context;
        }

        public async Task<bool> Commit() 
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
