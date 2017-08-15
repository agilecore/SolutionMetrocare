using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Generator.Models
{
    public sealed class ModelConfig
    {
        public String ClassName { get; set; }
        public String NameSpaceDto { get; set; }
        public String NameSpaceMapper { get; set; }
        public String NameSpaceDomain { get; set; }
        public String NameSpaceService { get; set; }
        public Boolean CreateDomain { get; set; }
        public Boolean CreateController { get; set; }
    }
}
