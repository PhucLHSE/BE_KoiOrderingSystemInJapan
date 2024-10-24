﻿using KoiOrderingSystemInJapan.Data.Base;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data.Repository
{
    public class RefundRequestRepository : GenericRepository<RefundRequest>
    {
        public RefundRequestRepository() { }
        public RefundRequestRepository(KoiOrderingSystemInJapanContext context) => _context = context;
    }
}
