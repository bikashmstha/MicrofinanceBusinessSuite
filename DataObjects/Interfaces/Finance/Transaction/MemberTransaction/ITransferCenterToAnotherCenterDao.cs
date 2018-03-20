using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction;

namespace DataObjects.Interfaces.Finance
{
    public interface ITransferCenterToAnotherCenterDao
    {
        object Get();

        object Save(TransferCenterToAnotherCenter TransferCenterToAnotherCenter);

        object Search(TransferCenterToAnotherCenter TransferCenterToAnotherCenter);

    }
}
