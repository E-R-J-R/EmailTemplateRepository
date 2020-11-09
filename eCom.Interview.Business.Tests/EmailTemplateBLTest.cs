using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eComEngine.Interview.Data;
using eCom.Interview.DTO;
using eCom.Interview.Core;

namespace eCom.Interview.Business.Tests
{
    [TestFixture]
    public class EmailTemplateBLTest
    {
        private Mock<IRepository<EmailTemplate>> _repository;
        private List<EmailTemplate> _templateList;

        [SetUp]
        public void Setup()
        {
            _templateList = new List<EmailTemplate>() { 
                new EmailTemplate
                {
                    Id = new Guid("2e2c9748-0521-430d-b2a9-effd09d358a2"),
                    EmailLabel = "Email Template 1 - Revision 2",
                    FromAddress = "webmaster@opm.gov",
                    DateUpdated = DateTime.Parse("2010-05-30T05:35:58.1257971-04:00"),
                    Versions = new EmailTemplate[]
                    {
                        new EmailTemplate { 
                            Id = new Guid("2923d40d-75d7-4566-a1e5-6d3a000ece4b"),
                            EmailLabel = "Email Template 1",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-30T01:35:58.1257971-04:00"),
                        },
                        new EmailTemplate {
                            Id = new Guid("56d6c5f3-e492-4243-b8f1-d47592127630"),
                            EmailLabel = "Email Template 1 - Revision 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-30T05:35:58.1257971-04:00"),
                        }
                    }
                },
                new EmailTemplate
                {
                    Id = new Guid("ea58a3df-c321-4462-9c50-16c6544f4661"),
                    EmailLabel = "Email Template 2 - Revision 2",
                    FromAddress = "webmaster@opm.gov",
                    DateUpdated = DateTime.Parse("2010-05-28T06:35:58.1257971-04:00"),
                    Versions = new EmailTemplate[]
                    {
                        new EmailTemplate {
                            Id = new Guid("1fa4b15e-db2b-4fac-9f25-449b1d896c74"),
                            EmailLabel = "Email Template 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-28T02:35:58.1257971-04:00")
                        },
                        new EmailTemplate {
                            Id = new Guid("db928fa2-1da3-44e0-8065-d097ed969689"),
                            EmailLabel = "Email Template 2 - Revision 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-28T06:35:58.1257971-04:00")
                        }
                    }
                },
                new EmailTemplate
                {
                    Id = new Guid("d6cdd8d3-b696-42d5-9d4a-787de700f26f"),
                    EmailLabel = "Email Template 3 - Revision 2",
                    FromAddress = "webmaster@opm.gov",
                    DateUpdated = DateTime.Parse("2010-05-26T07:35:58.1257971-04:00"),
                    Versions = new EmailTemplate[]
                    {
                        new EmailTemplate {
                            Id = new Guid("184e7fc6-8cca-4778-a6f8-2278bae18126"),
                            EmailLabel = "Email Template 3",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-26T03:35:58.1257971-04:00")
                        },
                        new EmailTemplate {
                            Id = new Guid("cd29492f-e819-4936-b381-b27d9320ab8b"),
                            EmailLabel = "Email Template 3 - Revision 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-05-26T07:35:58.1257971-04:00")
                        }
                    }
                },
                new EmailTemplate
                {
                    Id = new Guid("de010f1e-1ec1-44d4-a468-01b8a6122c8e"),
                    EmailLabel = "Email Template 42 - Revision 2",
                    FromAddress = "webmaster@opm.gov",
                    DateUpdated = DateTime.Parse("2010-03-10T22:35:58.1257971-05:00"),
                    Versions = new EmailTemplate[]
                    {
                        new EmailTemplate {
                            Id = new Guid("624e1199-eb9b-47bd-9a5e-38f3af5f5dee"),
                            EmailLabel = "Email Template 42",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-03-10T18:35:58.1257971-05:00")
                        },
                        new EmailTemplate {
                            Id = new Guid("a6f19eb5-e6d2-46c4-9180-594a4e763d97"),
                            EmailLabel = "Email Template 42 - Revision 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-03-10T22:35:58.1257971-05:00")
                        }
                    }
                },
                new EmailTemplate
                {
                    Id = new Guid("f6612832-d405-4d7b-bd4d-c74cd7e75259"),
                    EmailLabel = "Email Template 74 - Revision 2",
                    FromAddress = "webmaster@opm.gov",
                    DateUpdated = DateTime.Parse("2010-01-07T06:35:58.1257971-05:00"),
                    Versions = new EmailTemplate[]
                    {
                        new EmailTemplate {
                            Id = new Guid("dca18c41-3163-4f88-b4af-fef51c94ffcd"),
                            EmailLabel = "Email Template 74",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-01-07T02:35:58.1257971-05:00")
                        },
                        new EmailTemplate {
                            Id = new Guid("c573cba6-7421-4b1f-bd9d-09a355478a97"),
                            EmailLabel = "Email Template 74 - Revision 2",
                            FromAddress = "webmaster@opm.gov",
                            DateUpdated = DateTime.Parse("2010-01-07T06:35:58.1257971-05:00")
                        }
                    }
                }
            };

            _repository = new Mock<IRepository<EmailTemplate>>();
            _repository.Setup(x => x.Templates()).Returns(Task.FromResult(_templateList.AsQueryable()));

        }

        [Test]
        public void GetPagedTemplates_Paging_Positive_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            var param = new SearchParam()
            {
                Page = 1,
                PageSize = 3
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsTrue(result.EmailTemplates.Count == 3);
            Assert.IsTrue(result.TotalRecordCount == 5);
        }

        [Test]
        public void GetPagedTemplates_Paging_Negative_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            //With only 5 items in template list, we shouldn't have any data returned when Page = 2 and PageSize = 10
            var param = new SearchParam()
            {
                Page = 2,
                PageSize = 10
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsFalse(result.EmailTemplates.Count > 0);
            Assert.IsTrue(result.TotalRecordCount == 5);
        }

        [Test]
        public void GetPagedTemplates_OrderAsc_Positive_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            var param = new SearchParam()
            {
                Page = 1,
                PageSize = 10,
                OrderBy = EmailTemplateField.EmailLabel.ToString(),
                desc = false
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsTrue(result.EmailTemplates.First().EmailLabel == "Email Template 1 - Revision 2");
            Assert.IsTrue(result.EmailTemplates.Last().EmailLabel == "Email Template 74 - Revision 2");
        }

        [Test]
        public void GetPagedTemplates_OrderDesc_Positive_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            var param = new SearchParam()
            {
                Page = 1,
                PageSize = 10,
                OrderBy = EmailTemplateField.EmailLabel.ToString(),
                desc = true
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsTrue(result.EmailTemplates.First().EmailLabel == "Email Template 74 - Revision 2");
            Assert.IsTrue(result.EmailTemplates.Last().EmailLabel == "Email Template 1 - Revision 2");
        }

        [Test]
        public void GetPagedTemplates_Search_Positive_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            var searchText = "Template 3";

            var param = new SearchParam()
            {
                Page = 1,
                PageSize = 10,
                SearchField = EmailTemplateField.EmailLabel.ToString(),
                SearchText = searchText
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsTrue(result.EmailTemplates.Count == 1);
            Assert.IsTrue(result.EmailTemplates.First().EmailLabel.Contains(searchText));
        }

        [Test]
        public void GetPagedTemplates_Search_Negative_Test()
        {
            //Arrange
            var _emailTemplateBl = new EmailTemplateBL(_repository.Object);

            var searchText = "Temlpate"; //Misspelled intentionally

            var param = new SearchParam()
            {
                Page = 1,
                PageSize = 10,
                SearchField = EmailTemplateField.EmailLabel.ToString(),
                SearchText = searchText
            };

            //Act
            var result = _emailTemplateBl.GetPagedEmailTemplateList(param);

            //Assert
            Assert.IsFalse(result.EmailTemplates.Count > 1);
            Assert.IsTrue(result.TotalRecordCount <= 0);
        }
    }
}
