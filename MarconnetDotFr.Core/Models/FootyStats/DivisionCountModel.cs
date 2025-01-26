using System;
using System.Collections.Generic;
using System.Text;

namespace MarconnetDotFr.Core.Models.FootyStats
{
    public class DivisionCountModel
    {
        public Division division { get; set; }

        public int count { get; set; }

        public string strDivision => division.ToString();
    }
}
