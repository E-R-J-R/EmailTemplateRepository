﻿using System.Collections.Generic;
using System.Web.Http;
using eCom.Interview.Contracts;
using eCom.Interview.DTO;
using System.Web.Http.Cors;

namespace eCom.Interview.Web.Controllers
{
    public class EmailTemplateController : ApiController
    {
        private readonly IEmailTemplateBL _emailTemplateBl;

        public EmailTemplateController(IEmailTemplateBL emailTemplateBl)
        {
            _emailTemplateBl = emailTemplateBl;
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/emailtemplate/get")]
        [HttpGet]
        public List<EmailTemplate> GetEmailTemplateList()    
        {
            return _emailTemplateBl.GetEmailTemplateList();
        }

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/emailtemplate/getpaged")]
        [HttpPost]
        public EmailResponse GetPagedEmailTemplateList([FromBody]SearchParam param)
        {
            return _emailTemplateBl.GetPagedEmailTemplateList(param);
        }
    }
}
