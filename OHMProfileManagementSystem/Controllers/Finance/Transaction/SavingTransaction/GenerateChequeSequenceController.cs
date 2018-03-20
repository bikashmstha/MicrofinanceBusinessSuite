using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.Finance.Transaction.SavingTransaction;
using DataObjects;
using DataObjects.Interfaces.Finance;


namespace MicrofinanceBusinessSuite.Controllers.Finance.Transaction.SavingTransaction
{
    public class GenerateChequeSequenceController : ControllerBase
    {
        private static IGenerateChequeSequenceDao generateChequeSequenceDao = DataAccess.GenerateChequeSequenceDao;

        public object Get()
        {
            return generateChequeSequenceDao.Get();
        }

        public object Save(GenerateChequeSequence generateChequeSequence)
        {
            return generateChequeSequenceDao.Save(generateChequeSequence);
        }
        public object Search(GenerateChequeSequence generateChequeSequence)
        {
            return generateChequeSequenceDao.Search(generateChequeSequence);
        }
        public object GenerateChequeSequence(GenerateChequeSequence generateChequeSequence)
        {
            return generateChequeSequenceDao.GenerateChequeSequence(generateChequeSequence);
        }
    }
}