using System;
using System.Collections.Generic;
using System.Text;

namespace biz.matteria.Services.Email
{
    public interface IEmailService
    {
        void SendEmail(biz.matteria.Models.Email email);
    }
}
