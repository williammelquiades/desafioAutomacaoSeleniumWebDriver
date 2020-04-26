using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class CriarTarefasTests : TestBase
    {

        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows logarNoSistema;
        MenuMantis menuMantis;
        CriarTarefasPage criarTarefas;
        #endregion


        [Test, Category("ValidarCampoObrigatorioResumo")]
        public void ValidarCamposObrigatorioResumo()
        {
            menuMantis = new MenuMantis();
            criarTarefas = new CriarTarefasPage();

            #region Parameters
            //string projetoPadrao = "Automacao";
            //string resumo = "Test";
            //string descricao = "";
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgIE = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuCriarTarefas();

            criarTarefas.ClicarEmSelecionarProjeto();

            criarTarefas.SalvarNovoProjeto();

            CollectionAssert.Contains(new[] { msgEN, msgPT, msgIE }, criarTarefas.MensagemValidacaoResumo(msgJavaScripit));

        }

        [Test, Category("ValidarCampoObrigatorioDescricao")]
        public void ValidarCampoObrigatorioDescricao()
        {
            menuMantis = new MenuMantis();
            criarTarefas = new CriarTarefasPage();

            #region Parameters
            string projetoPadrao = "Automacao";
            string resumo = "Teste Resumo";
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgIE = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);
            menuMantis.ClicarItemMenuCriarTarefas();
            criarTarefas.ClicarEmSelecionarProjeto();
            criarTarefas.PreencherResumo(resumo);
            criarTarefas.SalvarNovoProjeto();

            CollectionAssert.Contains(new[] { msgEN, msgPT, msgIE }, criarTarefas.MensagemValidacaoDescricao(msgJavaScripit));
        }


        [Test, Category("Verificar Erro De Campo Categoria Vazio")]
        public void VerificarErroDeCampoCategoria()
        {
            menuMantis = new MenuMantis();
            criarTarefas = new CriarTarefasPage();

            #region Parameters
            
            string texto = "Texto de Tests";
            string mensagemErroEsperada = "APPLICATION ERROR #11";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);
            menuMantis.ClicarItemMenuCriarTarefas();

            criarTarefas.ClicarEmSelecionarProjeto();
            criarTarefas.PreencherResumo(texto);
            criarTarefas.PreencherDescricao(texto);
            criarTarefas.SalvarNovoProjeto();

            Assert.AreEqual(mensagemErroEsperada, criarTarefas.RetornaMensagemDeErro());
        }


        [Test, Category("Criar Nova Tarefas Com Sucesso")]
        public void CriarNovaTarefaComSucesso()
        {
            menuMantis = new MenuMantis();
            criarTarefas = new CriarTarefasPage();

            #region Parameters
            //string nameProjeto = "General"; 
            string descricaoProjeto = "Texto de Tests";
            string msgEsperada = "Operação realizada com sucesso.";
            #endregion


            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuCriarTarefas();

            //criarTarefas.ClicarEmSelecionarProjeto();

            //criarTarefas.SelecionarCategoria(nameProjeto);

            criarTarefas.PreencherResumo(descricaoProjeto);
            criarTarefas.PreencherDescricao(descricaoProjeto);
            
            criarTarefas.SalvarNovoProjeto();

            Assert.That(criarTarefas.ValidarCriarTarefa().Contains(msgEsperada));
        }

        public static class TestData
        {
            public static IEnumerable TarefasExternas()
            {
                return GeneralHelpers.ReturnCSVData(GeneralHelpers.GetProjectPath() +
         "Resources/TestData/Tarefas/CriarTarefasData.csv");
            }
        }

        [TestCaseSource(typeof(TestData), "TarefasExternas")]
        [Category("CriarTarefasPorDataDriver")]
        public void CriarNovasTarefasEmMassa(ArrayList testData)
        {

            menuMantis = new MenuMantis();
            criarTarefas = new CriarTarefasPage();

            #region Parameters
            string resumo = testData[0].ToString();
            string descricaoProjeto = testData[1].ToString();
            string nameProjeto = "[Todos os Projetos] General";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuCriarTarefas();

            criarTarefas.SelecionarCategoria(nameProjeto);

            criarTarefas.PreencherResumo(resumo);

            criarTarefas.PreencherDescricao(descricaoProjeto);
            
            criarTarefas.SalvarNovoProjeto();

            Assert.That(criarTarefas.ValidarCriarTarefa().Contains("sucesso"));
        }

    }
}
