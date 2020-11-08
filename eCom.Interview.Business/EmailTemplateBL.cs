using eCom.Interview.Contracts;
using eCom.Interview.DTO;
using eCom.Interview.Web;
using eCom.Interview.Core;
using eComEngine.Interview.Data;
using LinqKit;
using System.Collections.Generic;
using System.Linq;
using System;

namespace eCom.Interview.Business
{
    public class EmailTemplateBL : IEmailTemplateBL
    {
        private readonly IRepository<EmailTemplate> _repository;

        public EmailTemplateBL (IRepository<EmailTemplate> repository)
        {
            _repository = repository;
        }

        public List<EmailTemplate> GetEmailTemplateList()
        {
            return _repository.Templates().Result.ToList();
        }

        public EmailResponse GetPagedEmailTemplateList(SearchParam param)
        {
            var rows = param.PageSize ?? ApplicationSettings.DefaultPageSize;
            var skipRows = (param.Page - 1) * rows;
            var totalRows = 0;

            var condition = BuildWhere(param.SearchField, param.SearchText);

            var templateList = _repository.Templates().Result
                                          .Where(condition)
                                          .OrderBy(x => x.Id)
                                          .ToList();

            templateList = GetOrderedList(templateList, param.OrderBy, param.desc);

            totalRows = templateList.Count();
            templateList = templateList.Skip(skipRows).Take(rows).ToList();

            return new EmailResponse { EmailTemplates = templateList, TotalRecordCount = totalRows };

        }

        //Set to Public for Unit Testing
        public ExpressionStarter<EmailTemplate> BuildWhere(string searchField, string searchText)
        {
            var pred = PredicateBuilder.New<EmailTemplate>();

            if (searchField == EmailTemplateField.EmailLabel.ToString())
            {
                return pred.And(s => s.EmailLabel.Contains(searchText));
            }
            else if (searchField == EmailTemplateField.FromAddress.ToString())
            {
                return pred.And(s => s.FromAddress.Contains(searchText));  
            }
            else
            {
                return pred.And(s => s.Id != Guid.Empty);
            }
        }

        //Set to public for Unit Testing
        public List<EmailTemplate> GetOrderedList(List<EmailTemplate> result, string orderBy, bool desc)
        {

            if (orderBy == EmailTemplateField.FromAddress.ToString())
            {
                return desc ? result.OrderByDescending(c => c.FromAddress).ToList() : result.OrderBy(c => c.FromAddress).ToList();
            }
            else if (orderBy == EmailTemplateField.DateUpdated.ToString())
            {
                return desc ? result.OrderByDescending(c => c.DateUpdated).ToList() : result.OrderBy(c => c.DateUpdated).ToList();
            }
            else
            {
                return desc ? result.OrderByDescending(c => c.EmailLabel).ThenBy(c => c.EmailLabel.Length).ToList() : 
                              result.OrderBy(c => c.EmailLabel.Length).ThenBy(c => c.EmailLabel).ToList();
            }

        }
    }
}
