using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.DAO;
using MarconnetDotFr.DataAccess.Mappers;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.Repositories
{
    public class XmlFilesResumeRepository : IResumeRepository
    {
        private readonly string ResumeFile = "//xml//resume.xml";
        private readonly string PersonalWorkFile = "//xml//work.xml";

        private readonly IHostingEnvironment _hostingEnvironment;
        private bool _isInitialized = false;
        private XDocument _resumeDoc = null;
        private XDocument _personalWorkDoc = null;

        public XmlFilesResumeRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            LoadDocuments();
        }

        private void LoadDocuments()
        {
            try
            {
                _resumeDoc = XDocument.Load($"{_hostingEnvironment.WebRootPath}{ResumeFile}");
                _personalWorkDoc = XDocument.Load($"{_hostingEnvironment.WebRootPath}{PersonalWorkFile}");
                _isInitialized = true;
            }
            catch (DirectoryNotFoundException)
            {
#if DEBUG
                throw;
#endif
            }
        }

        public IEnumerable<WorkItemModel> GetSideProjects()
        {
            IEnumerable<WorkItemModel> items = new List<WorkItemModel>();
            if (_isInitialized)
            {
                items = _personalWorkDoc.Descendants("work")
                    .Select(item => ResumeMapper.ToWorkItemModel(new WorkItemModelXmlDao(item)));
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetUniversityDiplomas()
        {
            IEnumerable<ResumeItemModel> items = new List<ResumeItemModel>();
            if (_isInitialized)
            {
                items = _resumeDoc.Descendants("education").Descendants("edu")
                    .Select(item => ResumeMapper.ToResumeItemModel(new ResumeItemModelXmlDao(item)));
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetWorkExperiences()
        {
            IEnumerable<ResumeItemModel> items = new List<ResumeItemModel>();
            if (_isInitialized)
            {
                items = _resumeDoc.Descendants("experiences").Descendants("exp")
                    .Select(item => ResumeMapper.ToResumeItemModel(new ResumeItemModelXmlDao(item)));
            }

            return items;
        }
    }
}