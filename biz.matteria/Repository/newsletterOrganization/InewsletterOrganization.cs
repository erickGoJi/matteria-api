using biz.matteria.Models.newsletterOrganization;
using biz.matteria.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Repository.newsletterOrganization
{
    public interface InewsletterOrganization: IGenericRepository<biz.matteria.Entities.NewsletterOrganization>
    {
        newsletterOrganizationService AddNewletterOrganization(biz.matteria.Entities.NewsletterOrganization request);

        biz.matteria.Entities.NewsletterOrganizationFrontConfiguration getFrontConfigurtionNewsLetterOrganizacion(int language);

    }
}
