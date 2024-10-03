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
    }
}
