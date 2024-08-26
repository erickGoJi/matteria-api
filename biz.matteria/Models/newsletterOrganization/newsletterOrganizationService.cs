using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Models.newsletterOrganization
{
    public class newsletterOrganizationService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Business { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
