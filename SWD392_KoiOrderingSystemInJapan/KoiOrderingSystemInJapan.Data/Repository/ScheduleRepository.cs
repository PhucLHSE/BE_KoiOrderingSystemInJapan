using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repository
{
    public class ScheduleRepository : GenericRepository<Schedule>
    {
        public ScheduleRepository() { }
        public ScheduleRepository(KoiOrderingSystemInJapanContext context) => _context = context;
    }
}
