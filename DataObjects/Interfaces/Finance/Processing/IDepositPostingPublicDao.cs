using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IDepositPostingPublicDao
    {


        object SaveDepositPostingPublic(DepositPostingPublic depositPostingPublic);

        object SearchDepositPostingPublic(DepositPostingPublic depositPostingPublic);
    }
}
