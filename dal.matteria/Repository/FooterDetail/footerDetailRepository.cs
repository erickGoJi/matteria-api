using biz.matteria.Repository.FooterDetail;
using dal.matteria.db_Context;
using dal.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace dal.matteria.Repository.FooterDetail
{
    public class footerDetailRepository: GenericRepository<biz.matteria.Entities.FooterDetail>, IFooterDetail
    {

        public footerDetailRepository(DbmatteriaContext context) : base(context) { }





    }
}
