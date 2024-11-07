﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Common.Enum
{
    public enum OrderTripStatus
    {
        //Pending, 
        //Confirmed,
        //Cancelled
        PendingApproval,
        Approved,
        NotApproved,
        AwaitingConfirmation,
        Confirmed,
        Declined
    }
}
