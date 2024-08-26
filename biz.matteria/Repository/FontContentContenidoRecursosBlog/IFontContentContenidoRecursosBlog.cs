using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.FontContentContenidoRecursosBlog
{
    public interface IFontContentContenidoRecursosBlog: IGenericRepository<biz.matteria.Entities.FontContentContenidoRecursosBlog>
    {
        biz.matteria.Entities.FontContentContenidoRecursosBlog getFontContenidoRecursosBlog(int languageId);

    }
}
