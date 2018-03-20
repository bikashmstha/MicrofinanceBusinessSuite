using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IDesignationDao
    {
        object Get();

        object Save(Designation designation);

        object Search(Designation designation);

        object GetDesignationShort();

        object GetEmpDesignation(string DesignationDesc);

    }
}
