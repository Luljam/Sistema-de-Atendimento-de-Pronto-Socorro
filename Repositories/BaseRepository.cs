using AtendimentoProntoSocorro.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtendimentoProntoSocorro.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}
