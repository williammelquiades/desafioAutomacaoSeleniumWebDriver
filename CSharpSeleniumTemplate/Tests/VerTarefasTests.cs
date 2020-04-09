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
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class VerTarefasTests : TestBase
    {

        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows logarNoSistema;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] VerTarefasPage verTarefas;
        #endregion

        [Test]
        [Category("Ver Tarefas")]
        public void ValidarAcessoATela()
        {
            #region Parameters
            string nomeNaTela = "Visualizando Tarefas";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            Assert.IsTrue(verTarefas.VerificarTextoNaTela().Contains(nomeNaTela));

        }

        [Test]
        [Category("Ver Tarefas")]
        public void PesquisarTaredaPorString()
        {
            #region Parameters
            string tarefa = "Pokemo 20" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string mensagemErroEsperada = "Um número era esperado para bug_id.";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.PesquisarGlobalTarefas(tarefa);

            Assert.That(verTarefas.CapturarMensagemRetornada().Contains(mensagemErroEsperada));
        }

        [Test]
        [Category("Ver Tarefas")]
        public void PesquisarTarefaIdInexistente()
        {
            #region Parameters
            string tarefa = GeneralHelpers.ReturnStringWithRandomNumbers(4);
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.PesquisarGlobalTarefas(tarefa);

            Assert.That(verTarefas.CapturarMensagemRetornada().Contains("A tarefa " + tarefa + " não encontrada."));
        }

        [Test]
        [Category("Ver Tarefas")]
        public void SalvarUmNovoFiltro()
        {
            #region Parameters
            string descricaoNovoFiltro = "Filtro";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmNovoFiltro();

            verTarefas.PreencherNovoFiltro();

            verTarefas.ConfirmarCriacaoFiltro();

            //Assert.That(verTarefas.CapturarMensagemRetornada().Contains("Sucesso"));
        }

        [Test]
        [Category("Ver Tarefas")]
        public void AcessarTarefaAleatoria()
        {
            #region Parameters
            string numeroPadrao = "00";
            #endregion
            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.VerificarTarefaNaLista();

            verTarefas.ClicarEmTarefaAleatoria();

            Assert.That(verTarefas.CapturarIdDoBug().Contains(numeroPadrao));

        }

        [Test]
        [Category ("Ver Tarefas")]
        public void AlterarPriodidadeTarefa()
        {
            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmEditarTarefaAleatoria();

            verTarefas.clicarEmCampoPrioridade();

            verTarefas.SelecionarPrioridadeAleatoria();

            verTarefas.ClicarEmAtualizarTarefa();

            Assert.AreNotEqual(verTarefas.VerificarPrioridadeAtual, verTarefas.VerificarPrioridadeAnterior );

        }

        
        [Test]
        [Category ("Ver Tarefas")]
        public void ApagarUmaTarefa()
        {
            // a fazer
        }

        /*
        [Test]
        [Category ("Ver Tarefas")]
        public void AtribuirTaredas()
        {
            // a fazer
        }

        [Test]
        [Category ("Ver Tarefas")]
        public void ResolverTarefa()
        {
            // a fazer
        }*/
    }
}
