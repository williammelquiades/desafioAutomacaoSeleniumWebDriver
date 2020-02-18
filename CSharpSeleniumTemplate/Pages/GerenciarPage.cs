using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarPage : PageBase
    {
        //Abas de acesso em tela Gerenciar
        #region Mapping
        By abaInformacaoSite = By.XPath("(//ul[@class='nav nav-tabs padding-18']//li//a)[1]");
        By textoNomeFormulario = By.XPath("//h4[@class='widget-title lighter']");
        By abaGerenciarUsuarios = By.LinkText("Gerenciar Usuários");
        By abaGerenciarProjetos = By.LinkText("Gerenciar Projetos");
        By abaGerenciarMarcadores = By.LinkText("Gerenciar Marcadores");
        By linkAllMarkers = By.LinkText("TODAS");
        By abaGerenciarCamposPersonalizados = By.LinkText("Gerenciar Campos Personalizados");
        By abaGerenciarPerfisGlobais = By.LinkText("Gerenciar Perfís Globais");
        By abaGerenciarPlugins = By.LinkText("Gerenciar Plugins");
        By abaGerenciarConfiguracoes = By.LinkText("Gerenciar Configuração");
        /*
           Aba interna de gerenciamento de configurações 
           (//div[@class='btn-group']//a)[1 a 6 ]
         */
        By linkReportSetting = By.LinkText("Relatório de Configuração");
        By linkFlowWork = By.LinkText("Limiares do Fluxo de Trabalho");
        By linkTransitionsFlowWord = By.LinkText("Transições de Fluxo de Trabalho");
        By linkNotificationEmail = By.LinkText("Notificações por E-Mail");
        By linkManageColumns = By.LinkText("Gerenciar Colunas");
        #endregion

        #region Actions
        public void ClicarEmAbaInformacaoSite()
        {
            Click(abaInformacaoSite);
        }
        public string CapturarNomeDoFormulario()
        {
            return GetText(textoNomeFormulario);
        }

        public void ClicarEmGerenciarUsuario()
        {
            Click(abaGerenciarUsuarios);
        }

        public void ClicarEmAbaGerenciarProjetos()
        {
            Click(abaGerenciarProjetos);
        }

        public void ClicarEmAbaGerenciarMarcadores()
        {
            Click(abaGerenciarMarcadores);
        }

        public void ClicarEmAbaGerenciarCamposPersonalizados()
        {
            Click(abaGerenciarCamposPersonalizados);
        }

        public void ClicarEmAbaGerenciarPerfilGlobal()
        {
            Click(abaGerenciarPerfisGlobais);
        }


        public void ClicarEmAbaGerenciarPlugins()
        {
            Click();
        }
        public void ClicarEmAbaGerenciarConfiguracao()
        {
            Click();
        }

        #endregion
    }
}
