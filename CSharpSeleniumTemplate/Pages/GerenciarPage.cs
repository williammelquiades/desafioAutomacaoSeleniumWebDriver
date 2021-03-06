﻿using CSharpSeleniumTemplate.Bases;
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
        //*[@id="main-container"]/div[2]/div[2]/div/div[3]/div[2]/div[2]/div/div/table/tbody/tr[1]/td[1]
        By abaGerenciarUsuarios = By.LinkText("Gerenciar Usuários");
        By abaGerenciarProjetos = By.LinkText("Gerenciar Projetos");
        By abaGerenciarMarcadores = By.LinkText("Gerenciar Marcadores");
        By todosOsMarcadoresPaginacao = By.LinkText("TODAS");
        By abaGerenciarCamposPersonalizados = By.LinkText("Gerenciar Campos Personalizados");
        By botaoNovoCampoPersonalizado = By.XPath("//input[@type='submit' or contains(text(), 'Novo Campo Personalizado')]");
        By abaGerenciarPerfisGlobais = By.LinkText("Gerenciar Perfís Globais");
        By abaGerenciarPlugins = By.LinkText("Gerenciar Plugins");
        By abaGerenciarConfiguracoes = By.LinkText("Gerenciar Configuração");

        By subAbaGerenciamentoConfiguracaoRelPermiss = By.XPath("(//div[@class='btn-group']//a)[1]");
        By subAbaGerenciamentoConfiguracaoRelConfig = By.LinkText("Relatório de Configuração");
        By subAbaGerenciamentoConfiguracaoLimearesDoFLuxo = By.LinkText("Limiares do Fluxo de Trabalho");
        By subAbaGerenciamentoConfigTransicaoDeFluxo = By.LinkText("Transições de Fluxo de Trabalho");
        By subAbaGerenciamentoConfigNotificacaoEmail = By.LinkText("Notificações por E-Mail");
        By subAbaGerenciamentoConfigGerenciarColunas = By.LinkText("Gerenciar Colunas");
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

        public bool VerificarBotaoNovoCampo()
        {
            return ReturnIfElementIsDisplayed(botaoNovoCampoPersonalizado);
        }

        public bool VerificarItemNaTela()
        {
            return ReturnIfElementExists(subAbaGerenciamentoConfiguracaoRelConfig);
        }

        #endregion
    }

    public class FormularioGerenciamentoUsuarioPage : PageBase
    {

        #region Mapping
        By botaoCriarNovaConta = By.XPath("//a[@href='/manage_user_create_page.php']");
        By botaoCriarNocaContaName = By.LinkText("Criar nova conta");
        By campoNomeUsuario = By.Id("user-username");
        By campoNomeVerdadeiro = By.Id("user-realname");
        By campoEmail = By.Id("email-field");
        By nivelDeAcesso = By.Id("user-access-level");
        By checkHabilitado = By.Id("user-enabled");
        By checkProtegido = By.Id("user-protected");
        By quantidadeUsuariosCriados = By.ClassName("");
        #endregion

        //Controles
        public string quantidadeUsuario;

        #region action
        public void CriarNovoUsuario()
        {
            Click(botaoCriarNovaConta);
        }

        public void PreencherNovoUsuario(string nomeUsuario)
        {
            SendKeys(this.campoNomeUsuario, nomeUsuario);
        }

        public void PreencherNomeVerdadeiro(string nomeVerdadeiro)
        {
            SendKeys(this.campoNomeVerdadeiro, nomeVerdadeiro);
        }

        public void PreencherEmail(string campoEmail)
        {
            SendKeys(this.campoEmail, campoEmail);
        }

        public void MarcarAcesso()
        {
            Click(nivelDeAcesso);
        }

        public void MarcarHabilidade()
        {
            Click(checkHabilitado);
        }

        public void MarcarProtegido()
        {
            Click(checkProtegido);
        }

        public void CapturarQuantidadeDeMarcadorCriado()
        {
            quantidadeUsuario = GetText(quantidadeUsuariosCriados);
        }

        public bool VerificarBotaoCriarUsuario()
        {
            return ReturnIfElementExists(botaoCriarNocaContaName);
        }
        #endregion
    }

    public class FormularioGerenciarProjetosPage : PageBase
    {
        #region Mapping
        By botaoNovoProjeto = By.XPath("//button[contains(text(),'Criar Novo Projeto') or contains(text(), 'Create New Project')]");
        By botaoDeleteProjeto = By.XPath("//input[@value='Apagar Projeto']");
        By botaoAtualizarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Atualizar Projeto')]");
        By nomeProjeto = By.Id("project-name");
        By campoDescricao = By.Id("project-description");
        By selecionaEstado = By.Id("project-status");
        By selecionarVisibilidade = By.Id("project-view-state");
        By botaoAdicionarProjeto = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar projeto')]");
        By mensagemErroTextArea = By.XPath("//*[@class='page-content']//p"); //*[starts-with(@class,'alert')]//p
        By mensagemDeSucesso = By.XPath("//*[@class='page-content']//p");
        By listaDeProjetosInTable = By.XPath("//td/a");
        //

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

        public void CapturarTextoDoCampos()
        {
            SendKeys(nomeProjeto, " Edit v.01");
        }

        public void ClicarEmAtualizarProjeto()
        {
            Click(botaoAtualizarCategoria);
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
            SendKeys(this.campoDescricao, "Descrição de teste automático " + GeneralHelpers.ReturnStringWithRandomCharacters(10));
        }

        public void ClicarEmAdicionarProjeto()
        {
            Click(botaoAdicionarProjeto);
        }

        public string RetornaMensagem()
        {
            return GetText(mensagemDeSucesso);
        }

        public bool ProcurarProjetosNaLista()
        {
            return ReturnIfElementExists(listaDeProjetosInTable);
        }

        public bool VerificarRetornoDeBotaoATela()
        {
            return ReturnIfElementIsDisplayed(botaoNovoProjeto);
        }

        public void ClicarEmProjetoDaLista()
        {
            Click(listaDeProjetosInTable);
        }

        public void ClicarEmApagarProjeto()
        {
            Click(botaoDeleteProjeto);
        }

        public void ClicarEmEditarProjeto()
        {
            Click(botaoAtualizarCategoria);
        }

        public void ClicarEmConfirmarApagarProjeto()
        {
            Click(botaoDeleteProjeto);
        }

        public string ValidarCampoNomeProjeto(string msgJavaScripit)
        {
            return GetAttribute(this.nomeProjeto, msgJavaScripit);
        }

        #endregion
    }

    public class FormularioCategoriaGlobaisPage : PageBase
    {

        #region Mapping
        By botaoAdicionarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Categoria')]");
        // By campoNovaCategoria = By.ClassName("input-sm");
        //By botãoAdicionarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Categoria')]");
        By msgError = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        By campoNovaCategoria = By.Name("name");
        By categoriaGlobalLista = By.XPath("((//div[@class='table-responsive'])//tbody)[1]/tr/td[1]");
        By listaItemDeCategoriasGlobais = By.XPath("((//div[@class='table-responsive'])//tbody)[2]/tr/td[1]");
        #endregion
        //Controles de execucao local
        public string verificaItemNaLista;

        #region Actions        
        public void PreencherNomeCategoria(/*string novaCategoria*/)
        { // novaCategoria;
            verificaItemNaLista = ("Categoria[" + GeneralHelpers.ReturnStringWithRandomNumbers(2) + "]");
            SendKeys(this.campoNovaCategoria, verificaItemNaLista);//"Categoria[" + GeneralHelpers.ReturnStringWithRandomNumbers(2) + "]");
        }

        public void PreencherNomeCategoriaIgual()
        {
            SendKeys(this.campoNovaCategoria, RetornaItemDalista());
        }

        public void ClicarEmAdicionarCategoria()
        {
            Click(botaoAdicionarCategoria);
        }

        public void RetornoValidacao()
        {
            // Validar criação de nova categoria
        }

        public string MenssagemDeErro()
        {
            return GetText(msgError);
        }

        public bool ProcurarProjetosNaLista()
        {
            return ReturnIfElementExists(listaItemDeCategoriasGlobais);
        }

        public string RetornaItemDalista()
        {
            return GetText(listaItemDeCategoriasGlobais);
        }

        public string VerificarCategoriaGlobalCriada()
        {
            return GetText(By.XPath("//td[contains(text(), '"+verificaItemNaLista+"')]"));
        }

        public void ClicarEmProjetoDaLista()
        {
            Click(listaItemDeCategoriasGlobais);
        }

        #endregion
    }

    public class FormularioGerenciarMarcadoresPage : PageBase
    {
        #region  Mapping
        By nomeMarcador = By.Id("tag-name");
        By campoDescricao = By.Id("tag-description");
        By botaoNovoMarcador = By.XPath("//input[@type='submit' or contains(text(), 'Criar Marcador')]");
        By botaoDeletemarcador = By.XPath("//input[@value='Apagar Marcador']");
        //By tagContador = By.ClassName("badge");
        By tagContador = By.XPath("//span[@class='badge']");
        By paginacaoTodosMarcadores = By.LinkText("TODAS");
        By buscaMarcadorCriadoInTable = By.XPath("//*[@class='table-responsive']//tbody//tr//td//a");

        #endregion

        //Controles de execucao local
        public string verificaItemNaLista;
        public string quantidadeMarcador;

        #region Actions
        public void PreencherNomeMarcado()
        {
            verificaItemNaLista = ("Marcador " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
            SendKeys(this.nomeMarcador, verificaItemNaLista);
        }

        public void PreencherDescricaoMarcador(string nomeMarcador)
        {
            //verificaItemNaLista = ("Marcador " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
            SendKeys(this.nomeMarcador, "Marcador " + GeneralHelpers.ReturnStringWithRandomCharacters(7)); 
        }

        public void PreencherDescricaoMarcador()
        {
            SendKeys(campoDescricao, GeneralHelpers.ReturnStringWithRandomCharacters(5));
        }

        public void ClicarEmCriarMarcador()
        {
            Click(botaoNovoMarcador);
        }


        public void ClicarEmAlgumMarcadorDaLista()
        {
            Click(buscaMarcadorCriadoInTable);
        }

        public void ClicarEmDeletarMarcador()
        {
            Click(botaoDeletemarcador);
        }

        public void ClicarEmPaginacaoTodos()

        {
            Click(paginacaoTodosMarcadores);
        }
        public void CapturarQuantidadeDeMarcadorCriado()
        {
            quantidadeMarcador = GetText(tagContador);
        }

        public string VerificarCriarMarcadores()
        {
            return GetText(By.LinkText(verificaItemNaLista));
        }

        public bool VerificarMarcadorCriado()
        {
            return ReturnIfElementExists(buscaMarcadorCriadoInTable);
        }

        public string ValidarCampoNomeMarcador(string msgJavaScripit)
        {
            return GetAttribute(this.nomeMarcador, msgJavaScripit);
        }

        public bool VerificarBotaoPaginacaoEmTela()
        {
            return ReturnIfElementExists(paginacaoTodosMarcadores);
        }
        #endregion
    }

    public class FormularioGerenciarCamposPersonalizadosPage : PageBase
    {

        #region Mapping
        By campoInputNovoCampoPersonalizado = By.ClassName("input-sm");
        By botaoNovoCampoPersonalizado = By.XPath("//input[@type='submit' or contains(text(), 'Novo Campo Personalizado')]");
        By listItenstabela = By.XPath("//*[@class='table-responsive']//tbody//tr//td//a");
        #endregion

        #region Actions
        public void PreencherNovoCampoPersonalizado(string novoCampoPersonalizado)
        {
            SendKeys(this.campoInputNovoCampoPersonalizado, novoCampoPersonalizado);
        }

        public void ClicarEmNovo()
        {
            Click(botaoNovoCampoPersonalizado);
        }

        public void ValidarItemCriadoEmTabela()
        {
            // Criar validaçao de item em tela 
        }
        #endregion
    }

    public class FormularioGerenciarPerfilGlobaisPage : PageBase
    {
        private string VARPLATAFORMA = "";
        private string SO = "";
        private string VERSAOSO = "";

        #region Mapping
        By campoPlataforma = By.Id("platform");
        By campoSo = By.Id("os");
        By campoVersaoSo = By.Id("os-version");
        By campoDescricaoAdicional = By.Id("description");
        By botaoNovoPerfil = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Perfil')]");
        By campoSelecaoPerfilCriado = By.XPath("//select[@id='select-profile']//option");

        #endregion

        #region Actions
        public void PreencherCampoNomePlataforma(string plataforma)
        {
            this.VARPLATAFORMA = plataforma;
            SendKeys(this.campoPlataforma, plataforma);
        }

        public void PreencherCampoNomeSO(string so)
        {
            SendKeys(this.campoSo, so);
        }

        public void PreenhcerCampoVersaoSO(string versaoSO)
        {
            SendKeys(this.campoVersaoSo, versaoSO);
        }

        public void PreencherCampoDescricao(String descricao)
        {
            SendKeys(this.campoDescricaoAdicional, descricao);
        }

        public void ClicarEmAdicionarPerfil()
        {
            Click(botaoNovoPerfil);
        }

        //public string VerificarItemCriado(string VARPLATAFORMA, string SO, string VERSAOSO)
        //{
        //  this.VARPLATAFORMA = VARPLATAFORMA;
        //  this.SO = SO;
        //  this.VERSAOSO = VERSAOSO;
        //System.Console.WriteLine("Captura de campo: "+campoPlataforma);
        //return GetText(campoPlataforma);
        //}
        #endregion
    }

    public class FormularioGerenciarPluginsPage : PageBase { }

    public class FormularioGerenciarConfiguracaoPage : PageBase { }
}