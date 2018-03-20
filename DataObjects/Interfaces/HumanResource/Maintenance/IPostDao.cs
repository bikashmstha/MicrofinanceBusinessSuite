using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObjects.HumanResource;

namespace DataObjects.Interfaces.HumanResource
{
    public interface IPostDao
    {
        object Get();

        object Save(Post post);

        object Search(Post post);

        object GetPostShort();

        object GetEmpPost(string PostDesc);

    }
}
