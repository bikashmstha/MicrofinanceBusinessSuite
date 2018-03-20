using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;
namespace DataObjects.Interfaces.Maintenance
{
    public interface IInstallmentPeriodDao
    {
        List<InstallmentPeriod> GetInstallmentPeriod();
        OutMessage SaveInstallmentPeriod(InstallmentPeriod installmentPeriod);
    }
}
