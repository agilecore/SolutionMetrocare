using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrocare.Generator.Infrastructure;
using Metrocare.Generator.Models;
using Metrocare.Generator.Connections;
using Metrocare.Generator.Enums;

namespace Metrocare.Generator.Infrastructure
{
    public class BuilderController
    {
        private String ProjectName = "Metronic";

        /// <summary>
        /// Cria Controller
        /// </summary>
        public String BuildController(ModelConfig ModelConf)
        {
            var TextClass = new StringBuilder();

            TextClass.AppendLine("using System;");
            TextClass.AppendLine("using System.Linq;");
            TextClass.AppendLine("using System.Web;");
            TextClass.AppendLine("using System.Collections.Generic;");
            TextClass.AppendLine("using System.Web.Mvc;");
            TextClass.AppendLine("using " + ProjectName + ".Common;");
            TextClass.AppendLine("");
            TextClass.AppendLine("namespace " + ProjectName + ".WebUI.Controllers");
            TextClass.AppendLine("{");
            TextClass.AppendLine("    public class " + ModelConf.ClassName + "Controller : Base");
            TextClass.AppendLine("    {");
            TextClass.AppendLine("        public " + ModelConf.ClassName + "Controller() { }");
            TextClass.AppendLine("");
            TextClass.AppendLine("        [Authorize(Roles = \"" + ModelConf.ClassName.ToUpper() + "\")]");
            TextClass.AppendLine("        public ActionResult Index()");
            TextClass.AppendLine("        {");
            TextClass.AppendLine("            return View();");
            TextClass.AppendLine("        }");        
            TextClass.AppendLine("    }");
            TextClass.AppendLine("}");

            return (string.Format("Gerado o classe Controller {0}...", Utils.CreateFile(ModelConf.ClassName + "Controller", "Controllers", TextClass.ToString(), ETier.WebUI)));
        }

    }
}
