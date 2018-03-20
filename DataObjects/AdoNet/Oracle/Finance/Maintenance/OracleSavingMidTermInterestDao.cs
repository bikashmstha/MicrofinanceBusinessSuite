using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Finance;
using BusinessObjects.Finance.Maintenance;
using DataObjects.Interfaces.Finance;
using Oracle.DataAccess.Client;

namespace DataObjects.AdoNet.Oracle.Finance
{
    public class OracleSavingMidTermInterestDao : ISavingMidTermInterestDao
    {

        public List<SavingMidTermInterest> GetSavingMidTermInterest()
        {
            throw new NotImplementedException();
        }

        public OutMessage SaveSavingMidTermInterest(SavingMidTermInterest savingMidTermInterest)
        {
            throw new NotImplementedException();
        }
    }
}
