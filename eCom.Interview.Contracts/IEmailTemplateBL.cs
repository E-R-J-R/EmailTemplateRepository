using eCom.Interview.DTO;
using System.Collections.Generic;
using System.Linq;

namespace eCom.Interview.Contracts
{
    public interface IEmailTemplateBL
    {      
        List<EmailTemplate> GetEmailTemplateList();
        EmailResponse GetPagedEmailTemplateList(SearchParam param);

    }
}
