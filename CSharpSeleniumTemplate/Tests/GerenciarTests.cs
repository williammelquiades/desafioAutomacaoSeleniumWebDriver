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
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] FormularioGerenciarProjetosPage formularioGerenciarProjeto;
        [AutoInstance] FormularioCategoriaGlobais formularioCategoriasGlobais;
        string MSGESPERADA = "Operação realizada com sucesso.";
        #endregion

        /*
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

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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
        public void AcessarAbaGerenciarUsuario()
        {
            #region Parameters
            string nameEsperado = "Gerenciar Contas";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmGerenciarUsuario();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarProjetos()
        {
            #region Parameters
            string nameEsperado = "Projetos";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarMarcadores();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarCamposPersonalizados()
        {
            #region Parameters
            string nameEsperado = "Campos Personalizados";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarCamposPersonalizados();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarPadraoNomeDoFormulario());
        }

        [Test]
        [Category("Acessar Abas")]
        public void AcessarAbaGerenciarPerfisGlobais()
        {
            #region Parameters
            string nameEsperado = "Adicionar Perfil";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarConfiguracao();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDuploDoFormulario());
        }

        [Test]
        [Category("Campos Obrigatorios")]
        public void ValidaCampoObrigatorioEmGerenciarProjetos()
        {
            #region  Parameters
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgIE = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioGerenciarProjeto.ClicarEmNovoProjeto();

            formularioGerenciarProjeto.ClicarEmAdicionarProjeto();

            CollectionAssert.Contains(new[] { msgEN, msgPT, msgIE }, formularioGerenciarProjeto.ValidarCampoNomeProjeto(msgJavaScripit));
        }

        [Test]
        [Category("Gerenciar Projetos Sucesso")]
        public void CriarNovoProjetoComSucesso()
        {

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();

            formularioGerenciarProjeto.ClicarEmNovoProjeto();
            formularioGerenciarProjeto.PreencherNomeProjeto();
            formularioGerenciarProjeto.PreencherDescricao();
            formularioGerenciarProjeto.ClicarEmAdicionarProjeto();

            Assert.AreEqual(MSGESPERADA, formularioGerenciarProjeto.RetornaMensagem());

        }

        [Test]
        [Category("Gerenciar Projetos BD")]
        public void CriarNovoProjetoComSucessoConsultandoBD()
        {
            #region Parameters
            int quantidadeProjetosAoIniciar = 0;
            int quantidadeProjetosAoFinalizar;
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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
        [Category("Gerenciar Projetos BD")]
        public void DeletarProjetoBD()
        {
            #region Parameters
            int quantidadeProjetosAoIniciar = 0, quantidadeProjetosAoFinalizar;
            #endregion

            quantidadeProjetosAoIniciar = GerenciarProjetosDBSteps.RetornaQuantidadeDeProjetosCriadosDB();

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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


            loginInSystem.EfetuarLogin(USUARIO, SENHA);

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

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();


            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            Assert.True(formularioCategoriasGlobais.MenssagemDeErro().Contains(msgError));
        }

        [Test]
        [Category("Gerenciar Categoria Global")]
        public void CriarCategoriaComSucesso()
        {
            #region Parameters          
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaGerenciarProjetos();          

            formularioCategoriasGlobais.PreencherNomeCategoria();

            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            Assert.AreEqual(MSGESPERADA, formularioGerenciarProjeto.RetornaMensagem());
        }*/

        public void CriarCategoriaRepetida()
        {
            #region Parameters
            string msgError = "Uma categoria com este nome já existe.";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();
            gerenciarPage.ClicarEmAbaGerenciarProjetos();
            Assume.That(formularioCategoriasGlobais.ProcurarProjetosNaLista());
            formularioCategoriasGlobais.PreencherNomeCategoria();
            formularioCategoriasGlobais.ClicarEmAdicionarCategoria();

            Assert.AreEqual(msgError, formularioCategoriasGlobais.MenssagemDeErro());


        }
    }
}
