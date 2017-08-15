using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metrocare.Common
{
    [Serializable]
    public partial class MenuGrupoDto : Base
    {
        public MenuGrupoDto()
        {
            this.Prefixo   = String.Empty;
            this.Descricao = String.Empty;
            this.Icon      = String.Empty;
            this.Status    = String.Empty;
            this.Color     = String.Empty;
            this.Open      = false;
            this.Active    = false;
            this.MenuCollection = new List<MenuDto>();
        }
        public String Prefixo   { get; set; }
        public String Descricao { get; set; }
        public String Icon      { get; set; } 
        public Boolean Open     { get; set; }
        public Boolean Active   { get; set; }
        public String Status    { get; set; }
        public String Color     { get; set; }
        public List<MenuDto> MenuCollection { get; set; }   
    }

    [Serializable]
    public partial class MenuDto : Base
    {
        public MenuDto()
        {
            this.Url = String.Empty;
            this.Descricao = String.Empty;
            this.Icon = String.Empty;
            this.Status = String.Empty;
            this.Color = String.Empty;
        }
        public String Url { get; set; }
        public String Descricao { get; set; }
        public String Icon {get; set;}
        public String Status { get; set; }
        public String Color { get; set; }
    }
}
