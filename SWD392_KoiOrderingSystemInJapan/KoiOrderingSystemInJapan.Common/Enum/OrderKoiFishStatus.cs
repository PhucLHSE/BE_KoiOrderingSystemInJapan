using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Common.Enum
{
    public enum OrderKoiFishStatus
    {
        Pending,
        Confirmed,
        Preparing,
        ReadyforPickup,
        OutforDelivery,
        Completed,
        Cancelled
    }
}
