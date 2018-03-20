using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Transaction.SavingTransaction;

namespace DataObjects.Interfaces.Finance
{
    public interface IGenerateChequeSequenceDao
    {
        object Get();

        object Save(GenerateChequeSequence generateChequeSequence);

        object Search(GenerateChequeSequence generateChequeSequence);

        object GenerateChequeSequence(GenerateChequeSequence generateChequeSequence);

    }
}
