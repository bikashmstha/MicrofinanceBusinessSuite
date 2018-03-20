using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects;
using BusinessObjects.Maintenance;
using BusinessObjects.Security;

namespace DataObjects.Interfaces.Maintenance
{
    public interface IGLVoucherTypeDao
    {
        List<GLVoucherType> GetGLVoucherType(string officeCode, string fiscalYear);
        OutMessage SaveGLVoucherType(GLVoucherType glVoucherType);
    }
}
