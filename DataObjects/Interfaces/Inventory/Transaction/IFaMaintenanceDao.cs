﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IFaMaintenanceDao
    {


        object SaveFaMaintenance(FaMaintenance famaintenance);

        object SearchFaMaintenance(FaMaintenance famaintenance);



    }
}
