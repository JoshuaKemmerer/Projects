using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plasty.Models
{
    public class DegreeRequirements
    {
        public int Id { get; set; }

        public string Major { get; set; }

        public int CourseId { get; set; }

        public string EffectiveTerm { get; set; }
    }
}