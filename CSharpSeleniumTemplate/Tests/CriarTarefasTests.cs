using CSharpSeleniumTemplate.Bases;
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
            string projetoPadrao = "Automacao";
            string resumo = "Teste Resumo";
            string descricao = "";
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
            //string projetoPadrao = "Automacao";
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
            string categoria = "[All Projects] General"; // [Todos os Projetos] General
            string frequencia = "always"; // always | sempre
            string gravidade = "feature"; // feature | pequeno
            string prioridade = "urgent";
            string perfil = "Linux gnome 0238";
            string atribuido = "administrator";
            string textoDeTeste = "Texto de Tests";
            string msgEsperada = "Operation successful."; // Operation successful. | Operação realizada com sucesso.

            //string
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);
            menuMantis.ClicarItemMenuCriarTarefas();
            //criarTarefas.SelecionarProjeto("Automacao");
            criarTarefas.ClicarEmSelecionarProjeto();

            criarTarefas.SelecionarCategoria(categoria);
            criarTarefas.SelecionarFrequencia(frequencia);
            criarTarefas.SelecionarGravidade(gravidade);
            criarTarefas.SelecionarPrioridade(prioridade);
            criarTarefas.SelecionarPerfil(perfil);
            criarTarefas.SelecionaAtribuicao(atribuido);
            criarTarefas.PreencherResumo(textoDeTeste);
            criarTarefas.PreencherDescricao(textoDeTeste);
            criarTarefas.SalvarNovoProjeto();

            Assert.That(criarTarefas.ValidarCriarTarefa().Contains(msgEsperada));
        }

        /*
        [Test, Category("CriarNovasTarefasEmMassaComDataDriver")]
        public void CriarNovasTarefasEmMassa() {

        }
       */
    }
}
