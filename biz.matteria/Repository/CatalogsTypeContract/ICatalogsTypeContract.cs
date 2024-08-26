using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.CatalogsTypeContract
{
    public interface ICatalogsTypeContract: IGenericRepository<biz.matteria.Entities.CatalogsTypeContract>
    {
        List<biz.matteria.Entities.CatalogsTypeContract> GetTypeContract(int languageId);
    }
}
