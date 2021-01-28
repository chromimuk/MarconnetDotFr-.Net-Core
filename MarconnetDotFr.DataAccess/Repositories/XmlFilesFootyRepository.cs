using MarconnetDotFr.Core.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using MarconnetDotFr.DataAccess.Mappers;
using MarconnetDotFr.DataAccess.DAO;
using MarconnetDotFr.DataAccess.Repositories.Interfaces;

namespace MarconnetDotFr.DataAccess.Repositories
{
    public class XmlFilesFootyRepository : IFootyRepository
    {
        private readonly string FCSMAttendanceFile = "//xml//fcsm_attendance.xml";
        private readonly IHostingEnvironment _hostingEnvironment;
        private bool _isInitialized = false;
        private XDocument _fcsmAttendanceDoc = null;

        public XmlFilesFootyRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            LoadDocuments();
        }

        private void LoadDocuments()
        {
            try
            {
                _fcsmAttendanceDoc = XDocument.Load($"{_hostingEnvironment.WebRootPath}{FCSMAttendanceFile}");
                _isInitialized = true;
            }
            catch (DirectoryNotFoundException)
            {
#if DEBUG
                throw;
#endif
            }
        }

        public IEnumerable<AttendanceItemModel> GetAttendances(string club)
        {
            IEnumerable<AttendanceItemModel> items = new List<AttendanceItemModel>();
            if (_isInitialized)
            {
                items = _fcsmAttendanceDoc.Descendants("fcsm").Descendants("seasons").Descendants("season")
                    .Select(item => FootyMapper.ToAttendanceItemModel(new AttendanceItemModelXmlDao(item)));
            }

            return items;
        }
    }
}
