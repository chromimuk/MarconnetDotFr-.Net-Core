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
    public class XMLFilesResumeRepository : IResumeRepository
    {
        private readonly string ResumeFile = "//xml//resume.xml";
        private readonly string PersonalWorkFile = "//xml//work.xml";

        private readonly IHostingEnvironment _hostingEnvironment;
        private bool _isInitialized = false;
        private XDocument _resumeDoc = null;
        private XDocument _personalWorkDoc = null;

        public XMLFilesResumeRepository(IHostingEnvironment hostingEnvironment)
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

        public IEnumerable<WorkItemModel> GetPersonalWork()
        {
            IEnumerable<WorkItemModel> items = new List<WorkItemModel>();
            if (_isInitialized)
            {
                items = _personalWorkDoc.Descendants("work")
                    .Select(item => ResumeMapper.ToWorkItemModel(new WorkItemModelXMLDAO(item)));
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetUniversityDiplomas()
        {
            IEnumerable<ResumeItemModel> items = new List<ResumeItemModel>();
            if (_isInitialized)
            {
                items = _resumeDoc.Descendants("education").Descendants("edu")
                    .Select(item => ResumeMapper.ToResumeItemModel(new ResumeItemModelXMLDAO(item)));
            }

            return items;
        }

        public IEnumerable<ResumeItemModel> GetWorkExperiences()
        {
            IEnumerable<ResumeItemModel> items = new List<ResumeItemModel>();
            if (_isInitialized)
            {
                items = _resumeDoc.Descendants("experiences").Descendants("exp")
                    .Select(item => ResumeMapper.ToResumeItemModel(new ResumeItemModelXMLDAO(item)));
            }

            return items;
        }
    }
}