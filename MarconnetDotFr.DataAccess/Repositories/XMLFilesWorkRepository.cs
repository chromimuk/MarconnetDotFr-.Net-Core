using MarconnetDotFr.Core.Exceptions;
using MarconnetDotFr.Core.Models;
using MarconnetDotFr.DataAccess.DAO;
using MarconnetDotFr.DataAccess.DAO.Interfaces;
using MarconnetDotFr.DataAccess.Mappers;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Xml.Linq;

namespace MarconnetDotFr.DataAccess.Repositories
{
    public class XmlFilesWorkRepository : IWorkRepository
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly Dictionary<string, string> _knownWorks = new Dictionary<string, string>()
        {
            { "castable", "//xml//work_castable.xml" },
            { "cdf", "//xml//work_cdf.xml" },
            { "colisee", "//xml//work_colisee.xml" },
            { "civ5-gamegenerator", "//xml//work_civ5-gamegenerator.xml" },
            { "witcfc", "//xml//work_witcfc.xml" },
            { "lastfmapi", "//xml//work_lastfmapi.xml" },
        };

        public XmlFilesWorkRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public WorkModel GetWorkModel(string workModelName)
        {
            if (_knownWorks.ContainsKey(workModelName))
            {
                string xmlFileName = _knownWorks[workModelName];
                string xmlFilePath = $"{_hostingEnvironment.WebRootPath}{xmlFileName}";
                XDocument xmlFile = XDocument.Load(xmlFilePath);

                IWorkModelDao dao = new WorkModelXmlDao(xmlFile);
                return ResumeMapper.ToWorkModel(dao);
            }
            else
            {
                throw new WorkNotKnownException($"No known work named {workModelName}");
            }
        }
    }
}