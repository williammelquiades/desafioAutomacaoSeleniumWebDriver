using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
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
        By infosInformeSite1 = By.XPath("(//*[@id='manage-overview-table']//tbody//tr/td)[1]");
        By infosInformeSite2 = By.XPath("(//*[@id='manage-overview-table']//tbody//tr/td)[2]");
        By infosInformeSite3 = By.XPath("(//*[@id='manage-overview-table']//tbody//tr/td)[4]");
        By infosInformeSite4 = By.XPath("(//*[@id='manage-overview-table']//tbody//tr/td)[5]");
        By textoPadraoFormulario = By.XPath("//h4[@class='widget-title lighter']");
        By textoDubloFormulario = By.XPath("(//h4[@class='widget-title lighter'])[1]");
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
        public string CapturarPadraoNomeDoFormulario()
        {
            return GetText(textoPadraoFormulario);
        }

        public string CapturarNomeDuploDoFormulario()
        {
            return GetText(textoDubloFormulario);
        }

        public string CapturarInfo1()
        {
            return GetText(infosInformeSite1);
        }

        public string CapturarInfo2()
        {
            return GetText(infosInformeSite2);
        }
        public string CapturarInfo3()
        {
            return GetText(infosInformeSite3);
        }
        public string CapturarInfo4()
        {
            return GetText(infosInformeSite4);
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
            Click(abaGerenciarPlugins);
        }
        public void ClicarEmAbaGerenciarConfiguracao()
        {
            Click(abaGerenciarConfiguracoes);
        }

        #endregion
    }

    public class FormularioGerenciarProjetosPage : PageBase
    {
        #region Mapping
        By botaoNovoProjeto = By.XPath("//button[contains(text(),'Criar Novo Projeto') or contains(text(), 'Create New Project')]");
        By nomeProjeto = By.Id("project-name");
        By campoDescricao = By.Id("project-description");
        By selecionaEstado = By.Id("project-status");
        By selecionarVisibilidade = By.Id("project-view-state");
        By botaoAdicionarProjeto = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar projeto')]");
        By mensagemErroTextArea = By.XPath("//*[@class='page-content']//p"); //*[starts-with(@class,'alert')]//p
        By mensagemDeSucesso = By.XPath("//*[@class='page-content']//p");
        //
        By botãoAdicionarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Categoria')]");
        By campoNovaCategoria = By.ClassName("input-sm");
        #endregion

        #region Actions
        //Gerenciamento Projeto: Seção >> Projetos
       

        public void ClicarEmNovoProjeto()
        {
            Click(botaoNovoProjeto);
        }

        public void PreencherNomeProjeto()
        {
            SendKeys(this.nomeProjeto, "Proj Test " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
        }

        public void SelecionarEstado(string selecionaEstado)
        {
            ComboBoxSelectByVisibleText(this.selecionaEstado, selecionaEstado);
        }

        public void HerdarCategoria() { }

        public void SelecionarVisibilidade(string selecionarVisibilidade)
        {
            ComboBoxSelectByVisibleText(this.selecionarVisibilidade, selecionarVisibilidade);
        }

        public void PreencherDescricao()
        {
            SendKeys(this.campoDescricao, "Descrição de teste automático" + GeneralHelpers.ReturnStringWithRandomCharacters(10));
        }

        public void ClicarEmAdicionarProjeto()
        {
            Click(botaoAdicionarProjeto);
        }

        public string RetornaMensagem()
        {
            return GetText(mensagemDeSucesso);
        }

        // Gerenciamento Projetos: Seção >> Categoria Global

        public void PreencherCategoriaGlobal(string nomeCategoria)
        {
            SendKeys(this.campoNovaCategoria, nomeCategoria);
            ;
        }

        public void ClicarAdicionarEmNovaCategoria()
        {
            Click(campoNovaCategoria);
        }

        public string ValidarCampoNomeProjeto(string msgJavaScripit)
        {
            return GetAttribute(this.nomeProjeto, msgJavaScripit);
        }

        #endregion
    }
}
