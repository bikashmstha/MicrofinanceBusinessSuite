﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IInfFaAssetDao
    {


        object SaveInfFaAsset(InfFaAsset infFaAsset);

        object SearchInfFaAsset(InfFaAsset infFaAsset);


    }
}