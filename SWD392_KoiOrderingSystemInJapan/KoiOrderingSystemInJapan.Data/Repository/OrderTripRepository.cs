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
    public class OrderTripRepository : GenericRepository<OrderTrip>
    {
        public OrderTripRepository() { }
        public OrderTripRepository(KoiOrderingSystemInJapanContext context) => _context = context;
    }
}
