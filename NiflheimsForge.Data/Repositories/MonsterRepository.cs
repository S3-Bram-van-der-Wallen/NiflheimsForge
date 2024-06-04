using NiflheimsForge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly NiflheimsForgeDBContext _context;

        public MonsterRepository(NiflheimsForgeDBContext context)
        {
            _context = context;
        }
    }
}
