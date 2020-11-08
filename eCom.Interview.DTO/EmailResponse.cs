using System.Collections.Generic;

namespace eCom.Interview.DTO
{
    public class EmailResponse
    {
        public List<EmailTemplate> EmailTemplates { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
