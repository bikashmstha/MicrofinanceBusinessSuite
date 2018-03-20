using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessObjects.HumanResource;
using DataObjects;
using DataObjects.Interfaces.HumanResource;

namespace MicrofinanceBusinessSuite.Controllers.HumanResource.Maintenance
{
    public class PostController : ControllerBase
    {

        private static IPostDao postDao = DataAccess.PostDao;

        public object Get()
        {
            return postDao.Get();
        }

        public object Save(Post post)
        {
            return postDao.Save(post);
        }
        public object Search(Post post)
        {
            return postDao.Search(post);
        }
        public object GetPostShort()
        {
            return postDao.GetPostShort();
        }

        public object GetEmpPost(string PostDesc)
        {
            return postDao.GetEmpPost(PostDesc);
        }
    }
}
