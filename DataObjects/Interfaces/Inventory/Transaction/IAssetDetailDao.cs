﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Inventory.Transaction;

namespace DataObjects.Interfaces.Inventory
{
    public interface IAssetDetailDao
    {


        object SaveAssetDetail(AssetDetail assetDetail);

        object SearchAssetDetail(AssetDetail assetDetail);



        object GetAssetDetail(AssetDetail assetDetail);

    }
}