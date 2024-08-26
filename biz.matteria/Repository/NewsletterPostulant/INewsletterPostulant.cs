using biz.matteria.Models.NewsletterPostulant;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.NewsletterPostulant
{
    public interface INewsletterPostulant: IGenericRepository<biz.matteria.Entities.NewsletterPostulant>
    {
        NewsletterPostulantService addNewsletterPostulant(biz.matteria.Entities.NewsletterPostulant request);

        biz.matteria.Entities.NewsletterPostulantFrontConfiguration GetNewsletterPostulantConfiguration(int languajeId);
    }
}
