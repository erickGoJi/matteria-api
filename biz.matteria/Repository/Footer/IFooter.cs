using biz.matteria.Models.Footer;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.Footer
{
    public interface IFooter: IGenericRepository<biz.matteria.Entities.Footer>
    {

        List<footerResponse> GetFooter(int languaje);

    }
}
