using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    public class GerenciarTests : TestBase
    {
        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows LogarNoSistema;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] FormularioGerenciarProjetosPage formularioGerenciarProjeto;
        [AutoInstance] FormularioCategoriaGlobaisPage formularioCategoriasGlobais;
        [AutoInstance] FormularioGerenciarMarcadoresPage formularioMarcadores;
        [AutoInstance] FormularioGerenciamentoUsuarioPage formularioUsuario;
        string MSGESPERADA = "Operação realizada com sucesso.";
        #endregion

        
        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarUsuario()
        {
            #region Parameters
            string nameEsperado = "Gerenciar Contas";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmGerenciarUsuario();

            Assert.That(formularioUsuario.VerificarBotaoCriarUsuario);
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaInformacaoSite()
        {
            #region Parameters
            string nameEsperado = "Informação do Site";
            string versao = "2.22.1";
            string schema = "209";
            string versaoPhp = "5.6.40";
            string baseDados = "mysqli";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaInformacaoSite();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(nameEsperado, gerenciarPage.CapturarPadraoNomeDoFormulario());
                Assert.AreEqual(versao, gerenciarPage.CapturarInfo1());
                Assert.AreEqual(schema, gerenciarPage.CapturarInfo2());
                Assert.AreEqual(versaoPhp, gerenciarPage.CapturarInfo3());
                Assert.AreEqual(baseDados, gerenciarPage.CapturarInfo4());
            });
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarProjetos()
        {
            #region Parameters
            string nameEsperado = "Projetos";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarMarcadores()
        {
            #region Parameters
            string nameEsperado = "Gerenciar Marcadores";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            //Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
            Assert.That(formularioMarcadores.VerificarBotaoPaginacaoEmTela);
        }


        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarCamposPersonalizados()
        {
            #region Parameters
            string nameEsperado = "Campos Personalizados";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarCamposPersonalizados();

            //Assert.AreEqual(nameEsperado, gerenciarPage.CapturarPadraoNomeDoFormulario());
            Assert.That(gerenciarPage.VerificarBotaoNovoCampo);
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarPerfisGlobais()
        {
            #region Parameters
            string nameEsperado = "Adicionar Perfil";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarPerfilGlobal();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarPadraoNomeDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarPlugins()
        {
            #region Parameters
            string nameEsperado = "Plugins Instalados";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarPlugins();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarConfiguracao()
        {
            #region Parameters
            string nameEsperado = "ANEXO(S)";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarConfiguracao();

            Assert.That(gerenciarPage.VerificarItemNaTela());
        }

        [Test]
        [Category("Gerenciar Projetos")]
        public void ValidaCampoObrigatorioEmGerenciarProjetos()
        {
            #region  Parameters
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgIE = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioGerenciarProjeto.ClicarEmNovoProjeto();

            formularioGerenciarProjeto.ClicarEmAdicionarProjeto();

            CollectionAssert.Contains(new[] { msgEN, msgPT, msgIE }, formularioGerenciarProjeto.ValidarCampoNomeProjeto(msgJavaScripit));
        }

        [Test]
        [Category("Gerenciar Projetos")]
        public void CriarNovoProjetoComSucesso()
        {

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioGerenciarProjeto.ClicarEmNovoProjeto();
            formularioGerenciarProjeto.PreencherNomeProjeto();
            formularioGerenciarProjeto.PreencherDescricao();
            formularioGerenciarProjeto.ClicarEmAdicionarProjeto();

            Assert.AreEqual(MSGESPERADA, formularioGerenciarProjeto.RetornaMensagem());

        }

        [Test]
        [Category("Gerenciar Projetos")]
        public void CriarNovoProjetoComSucessoConsultandoBD()
        {
            #region Parameters
            int quantidadeProjetosAoIniciar = 0;
            int quantidadeProjetosAoFinalizar;
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioGerenciarProjeto.ClicarEmNovoProjeto();
            quantidadeProjetosAoIniciar = GerenciarProjetosDBSteps.RetornaQuantidadeDeProjetosCriadosDB();
            formularioGerenciarProjeto.PreencherNomeProjeto();
            formularioGerenciarProjeto.PreencherDescricao();
            formularioGerenciarProjeto.ClicarEmAdicionarProjeto();

            quantidadeProjetosAoFinalizar = GerenciarProjetosDBSteps.RetornaQuantidadeDeProjetosCriadosDB();

            Assert.Less(quantidadeProjetosAoIniciar, quantidadeProjetosAoFinalizar);
            Assert.AreEqual(MSGESPERADA, formularioGerenciarProjeto.RetornaMensagem());
        }

        [Test]
        [Category("Gerenciar Projetos")]
        public void DeletarProjetoBD()
        {
            #region Parameters
            int quantidadeProjetosAoIniciar = 0, quantidadeProjetosAoFinalizar;
            #endregion

            quantidadeProjetosAoIniciar = GerenciarProjetosDBSteps.RetornaQuantidadeDeProjetosCriadosDB();

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            Assume.That(formularioGerenciarProjeto.ProcurarProjetosNaLista());

            formularioGerenciarProjeto.ClicarEmProjetoDaLista();

            formularioGerenciarProjeto.ClicarEmApagarProjeto();

            formularioGerenciarProjeto.ClicarEmConfirmarApagarProjeto();

            quantidadeProjetosAoFinalizar = GerenciarProjetosDBSteps.RetornaQuantidadeDeProjetosCriadosDB();

            Assert.Greater(quantidadeProjetosAoIniciar, quantidadeProjetosAoFinalizar);
            //Assert.That(formularioGerenciarProjeto.VerificarRetornoDeBotaoATela());
        }

        [Test]
        [Category("Gerenciar Projetos")]
        public void EditarProjetoDaLista()
        {
            #region Parameters

            #endregion


            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            Assume.That(formularioGerenciarProjeto.ProcurarProjetosNaLista());

            formularioGerenciarProjeto.ClicarEmProjetoDaLista();

            formularioGerenciarProjeto.CapturarTextoDoCampos();

            formularioGerenciarProjeto.ClicarEmAtualizarProjeto();

            Assert.That(formularioGerenciarProjeto.VerificarRetornoDeBotaoATela());
        }

        [Test]
        [Category("Gerenciar Categoria Global")]
        public void CriarCategoriaSemNome()
        {
            #region Parameters         
            string msgError = "Um campo necessário 'Categoria' estava vazio.";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();


            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            Assert.True(formularioCategoriasGlobais.MenssagemDeErro().Contains(msgError));
        }

        [Test]
        [Category("Gerenciar Categoria Global")]
        public void CriarCategoriaComSucesso()
        {

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioCategoriasGlobais.PreencherNomeCategoria();

            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            //Assert.AreEqual(MSGESPERADA, formularioGerenciarProjeto.RetornaMensagem());
            Assert.AreEqual(formularioCategoriasGlobais.verificaItemNaLista, formularioCategoriasGlobais.VerificarCategoriaGlobalCriada());
        }


        [Test]
        [Category("Gerenciar Categoria Global")]
        public void CriarCategoriaRepetida()
        {
            #region Parameters
            string msgError = "Uma categoria com este nome já existe.";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            Assume.That(formularioCategoriasGlobais.ProcurarProjetosNaLista());

            formularioCategoriasGlobais.PreencherNomeCategoriaIgual();

            //formularioCategoriasGlobais.ClicarEmProjetoDaLista();

            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            Assert.AreEqual(msgError, formularioCategoriasGlobais.MenssagemDeErro());

        }

        [Test]
        [Category("Validar fluxo Marcadores")]
        public void CriarMarcadorSemPreencherCampo()
        {
            #region  Parameters
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgIE = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            formularioMarcadores.ClicarEmCriarMarcador();

            CollectionAssert.Contains(new[] { msgEN, msgPT, msgIE }, formularioMarcadores.ValidarCampoNomeMarcador(msgJavaScripit));
        }
      
        [Test]
        [Category("Validar fluxo Marcadores")]
        public void CriarMarcadoresComSucesso()
        {

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            formularioMarcadores.PreencherNomeMarcado();
            formularioMarcadores.PreencherDescricaoMarcador();

            formularioMarcadores.ClicarEmCriarMarcador();

            Assert.AreEqual(formularioMarcadores.verificaItemNaLista, formularioMarcadores.VerificarCriarMarcadores());
        }
        
        [Test]
        [Category("Validar fluxo Marcadores")]
        public void DeletarMarcador()
        {
            #region  Parameters
            string nomeMarcador = "Marcador " + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string textoDescricao = "Descrição " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            #endregion

            GerenciarProjetosDBSteps.CriarMarcadorViaDB(nomeMarcador, textoDescricao);

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            Assume.That(formularioMarcadores.VerificarMarcadorCriado());

            formularioMarcadores.CapturarQuantidadeDeMarcadorCriado();

            formularioMarcadores.ClicarEmAlgumMarcadorDaLista();

            formularioMarcadores.ClicarEmDeletarMarcador();
            formularioMarcadores.ClicarEmDeletarMarcador();

            Assert.AreEqual(0, GerenciarProjetosDBSteps.VerificarMarcadorDeletadoDB(nomeMarcador));
            Assert.Greater(Convert.ToInt32(formularioMarcadores.quantidadeMarcador), Convert.ToInt32(formularioMarcadores.quantidadeMarcador) - 1);
        }


        [Test]
        [Category("Validar fluxo Marcadores")]
        public void PesquisarTodosOsMarcadores()
        {

            LogarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            formularioMarcadores.ClicarEmPaginacaoTodos();     

            formularioMarcadores.CapturarQuantidadeDeMarcadorCriado();

            int quantidadeMarcadoresBD = GerenciarProjetosDBSteps.RetornaQuantidadeTotalDeMarcadoresDB();

            Assert.AreEqual (Convert.ToInt32(formularioMarcadores.quantidadeMarcador), quantidadeMarcadoresBD);  
        }

    }
}
