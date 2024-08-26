using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FrontContentManagerFaq
{
    public interface IFrontContentManagerFaq: IGenericRepository<biz.matteria.Entities.FrontContentManagerFaq>
    {

        List<biz.matteria.Entities.FrontContentManagerFaq> GetFrontContentFaqsAndAnswers(int languageId);

    }
}
