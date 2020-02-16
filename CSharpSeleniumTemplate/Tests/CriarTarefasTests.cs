using CSharpSeleniumTemplate.Bases;
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
    [TestFixture]
    public class CriarTarefasTests : TestBase
    {

        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        MenuMantis menuMantis;
        CriarTarefasPage criarTarefas;
        #endregion

        [Test]
        public void ValidarCamposObrigatorioResumo()
        {
            menuMantis = new MenuMantis();

            #region Parameters
            string projetoPadrao = "Automacao";
            string resumo = "Teste Resumo";
            string descricao = "";
            string msgPT = "Preencha este campo.";
            string msgEN = "Please fill out this field.";
            string msgExplorer = "Este é um campo obrigatório";
            string msgJavaScripit = "validationMessage";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);
            menuMantis.ClicarItemMenuCriarTarefas();
            criarTarefas.SelecionarProjeto(projetoPadrao);
            criarTarefas.ClicarEmSelecionarProjeto();

            //CollectionAssert.Contains(new[] { msgEN, msgPT, msgExplorer }, createTaskPage.RetornarMsgDescricao(msgJavaScripit));

        }
        /*
        [Test, Category("ValidarCampoObrigatorioDescricao")]
        public void ValidarCampoObrigatorioDescricao() { 
        
        }

        [Test, Category("VerificarErroDoCampoCategoria")]
        public void VerificarErroDeCampoCategoria() { 
        
        }

        [Test, Category("CriarTarefas")]
        public void CriarNovaTarefaComSucesso() {

            // Relatorio.iniciarTeste("Criar tarefa");

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            //home.verificaAcessoTelaHome();


            menuMantis.ClicarItemMenuCriarTarefas();
            criarTarefas.SelecionarProjeto("Automacao");

            criarTarefas.SelecionarCategoria("TESTE");
            criarTarefas.SelecionarFrequencia("TESTE");
            criarTarefas.SelecionarGravidade("TESTE");
            criarTarefas.SelecionarPrioridade("TESTE");
            criarTarefas.SelecionarPerfil("TESTE");
            criarTarefas.SelecionaAtribuicao("TESTE");
            criarTarefas.PreencherResumo("TESTE");
            criarTarefas.PreencherDescricao("TESTE");



            //criarTarefas.criarNovaTarefaAleatoria();

            //Assert.AreEqual("Operação realizada com sucesso.", criar.MensagemOperacao.Text);
        }//fim void

        [Test, Category("CriarNovasTarefasEmMassaComDataDriver")]
        public void CriarNovasTarefasEmMassa() {

        }
        */
    }
}
