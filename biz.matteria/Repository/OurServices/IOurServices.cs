using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.OurServices
{
    public interface IOurServices: IGenericRepository<biz.matteria.Entities.FrontContentManagerNuestrosservicio>
    {
        List<biz.matteria.Entities.FrontContentManagerNuestrosservicio> GetOurServices(int languageId);

    }
}
