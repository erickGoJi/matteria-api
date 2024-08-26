using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManagerBlog
{
    public interface IFrontContentManagerBlog: IGenericRepository<biz.matteria.Entities.FrontContentManagerBlog>
    {

        List<biz.matteria.Entities.FrontContentManagerBlog> GetFrontManagerBlog(int languageId, int type);

        biz.matteria.Entities.FrontContentManagerBlog GetFrontManagerBlogById(int languageId,int blogId);


    }
}
