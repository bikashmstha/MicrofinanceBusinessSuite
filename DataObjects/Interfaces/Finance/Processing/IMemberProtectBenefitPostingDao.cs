﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.Finance.Processing;

namespace DataObjects.Interfaces.Finance
{
    public interface IMemberProtectBenefitPostingDao
    {


        object SaveMemberProtectBenefitPosting(List<MemberProtectBenefitPosting> memberProtectBenefitPosting);

        object SearchMemberProtectBenefitPosting(MemberProtectBenefitPosting memberProtectBenefitPosting);



    }
}