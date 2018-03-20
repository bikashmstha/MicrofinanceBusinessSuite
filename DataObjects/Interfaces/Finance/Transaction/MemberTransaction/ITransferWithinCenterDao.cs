using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ITransferWithinCenterDao
    {
        object Get();

        object Save(TransferWithinCenter transferwithincenter);

        object Search(TransferWithinCenter transferwithincenter);

    }
}
