using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Data
{
    public class UnitOfWork
    {
        private KoiOrderingSystemInJapanContext context;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        private FarmRepository farmRepository;
        private TripRepository tripRepository;
        private KoiFishRepository koifishRepository;
        private OrderHistoryRepository orderHistoryRepository;
        private OrderKoiFishRepository orderKoiFishRepository;
        private OrderTripRepository orderTripRepository;
        private TripScheduleRepository tripScheduleRepository;

        public UnitOfWork()
        {
            context ??= new KoiOrderingSystemInJapanContext();
        }

        public UserRepository UserRepository
        {
            get
            {
                return userRepository ??= new UserRepository(context);
            }
        }

        public RoleRepository RoleRepository
        {
            get
            {
                return roleRepository ??= new RoleRepository(context);
            }
        }

        public FarmRepository FarmRepository
        {
            get
            {
                return farmRepository ??= new FarmRepository(context);
            }
        }

        public TripRepository TripRepository
        {
            get
            {
                return tripRepository ??= new TripRepository(context);
            }
        }

        public KoiFishRepository KoiFishRepository
        {
            get
            {
                return koifishRepository ??= new KoiFishRepository(context);
            }
        }
        public OrderHistoryRepository OrderHistoryRepository
        {
            get
            {
                return orderHistoryRepository ??= new OrderHistoryRepository(context);
            }
        }
        public OrderKoiFishRepository OrderKoiFishRepository
        {
            get
            {
                return orderKoiFishRepository ??= new OrderKoiFishRepository(context);
            }
        }
        public OrderTripRepository OrderTripRepository
        {
            get
            {
                return orderTripRepository ??= new OrderTripRepository(context);
            }
        }
        public TripScheduleRepository TripScheduleRepository
        {
            get
            {
                return tripScheduleRepository ??= new TripScheduleRepository(context);
            }
        }
    }
}
