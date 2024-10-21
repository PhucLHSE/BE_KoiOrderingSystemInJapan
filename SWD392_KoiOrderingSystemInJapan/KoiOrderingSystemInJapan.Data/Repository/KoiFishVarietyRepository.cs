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
    public class KoiFishVarietyRepository:GenericRepository<KoiFishVariety>
    {
        public KoiFishVarietyRepository() { }
        public KoiFishVarietyRepository(KoiOrderingSystemInJapanContext context) => _context = context;
    }
}
