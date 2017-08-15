using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Metrocare.Common;
using MySql.Data.MySqlClient;

namespace Metrocare.WebUI.Controllers
{
    public class Base : Controller
    {
        public Boolean enableSearch { get; set; }

        public void LoadMenu()
        {
            var menuGrupoCollection = new List<MenuGrupoDto>();

            menuGrupoCollection.Add(this.ItemGerenciamento());
            menuGrupoCollection.Add(this.ItemAgendamento());
            menuGrupoCollection.Add(this.ItemCredenciamento());
            menuGrupoCollection.Add(this.ItemAcesso());
            menuGrupoCollection.Add(this.ItemFaturamento());
            menuGrupoCollection.Add(this.ItemPlanos());
            menuGrupoCollection.Add(this.ItemDuvidas());

            var SessionMenu = new Metrocare.Security.Session();
            SessionMenu.Start(menuGrupoCollection, "UserMenu");
        }

        private MenuGrupoDto ItemGerenciamento()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "ger";
            menuGrupo.Descricao = "Gerenciamento";
            menuGrupo.Icon = "icon-users";
            menuGrupo.Open = true;
            menuGrupo.Active = true;
            menuGrupo.Color = "#F96251";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-bar-chart", Descricao = "Dashboard", Status = "A", Url = "~/Dashboard/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 002, Icon = "icon-graph", Descricao = "Logs de Acesso", Status = "A", Url = "~/Log/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 003, Icon = "icon-users", Descricao = "Usuários", Status = "A", Url = "~/Usuario/List" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemCredenciamento()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "crd";
            menuGrupo.Descricao = "Credenciamento";
            menuGrupo.Icon = "icon-badge";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#F04D86";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-user-following", Descricao = "Beneficiário", Status = "A", Url = "~/Beneficiario/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 002, Icon = "icon-users", Descricao = "Dependente", Status = "A", Url = "~/Dependente/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 003, Icon = "icon-eyeglasses", Descricao = "Credenciado", Status = "A", Url = "~/Credenciado/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 004, Icon = "icon-home", Descricao = "Prestador", Status = "A", Url = "~/Prestador/List" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemAgendamento()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "ate";
            menuGrupo.Descricao = "Atendimento";
            menuGrupo.Icon = "icon-call-in";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#C83FE0";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-calendar", Descricao = "Agendamento", Status = "A", Url = "~/Agendamento/Agenda" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 003, Icon = "icon-calculator", Descricao = "Geração de Guia", Status = "A", Url = "~/Agendamento/GeraGuia" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemAcesso()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "per";
            menuGrupo.Descricao = "Permissões";
            menuGrupo.Icon = "icon-eye";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#8659D0";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-users", Descricao = "Usuários", Status = "A", Url = "~/Usuario/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 002, Icon = "icon-list", Descricao = "Menus", Status = "A", Url = "~/Menu/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 003, Icon = "icon-key", Descricao = "Permis. de Acesso", Status = "A", Url = "~/Menu/Permissoes" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemFaturamento()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "fat";
            menuGrupo.Descricao = "Faturamento";
            menuGrupo.Icon = "icon-drawer";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#6471CA";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-layers", Descricao = "Faturas", Status = "A", Url = "~/Faturamento/Fatura" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 002, Icon = "icon-docs", Descricao = "Lotes de Faturas", Status = "A", Url = "~/Faturamento/Lote" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 003, Icon = "icon-share-alt", Descricao = "Pagamento Médico", Status = "A", Url = "~/Faturamento/PagamentoMedico" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemPlanos()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "pln";
            menuGrupo.Descricao = "Planos";
            menuGrupo.Icon = "icon-drawer";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#3FA9F8";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-book-open", Descricao = "Planos", Status = "A", Url = "~/Plano/List" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 002, Icon = "icon-folder-alt", Descricao = "Tabelas de Proced.", Status = "A", Url = "~/Plano/Tabela" });
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 004, Icon = "icon-notebook", Descricao = "Tabela Tuss", Status = "A", Url = "~/Plano/Tuss" });

            return (menuGrupo);
        }

        private MenuGrupoDto ItemDuvidas()
        {
            var menuGrupo = new MenuGrupoDto();

            menuGrupo.Prefixo = "duv";
            menuGrupo.Descricao = "Dúvidas";
            menuGrupo.Icon = "icon-question";
            menuGrupo.Open = false;
            menuGrupo.Active = true;
            menuGrupo.Color = "#28B9FF";
            menuGrupo.MenuCollection.Add(new MenuDto() { Id = 001, Icon = "icon-book-open", Descricao = "Criação de Acesso", Status = "A", Url = "~/Duvidas/List" });

            return (menuGrupo);
        }
        

    }
}
