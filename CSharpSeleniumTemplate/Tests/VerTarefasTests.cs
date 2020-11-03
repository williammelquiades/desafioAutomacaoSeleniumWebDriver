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
        //[Parallelizable]
        public void ValidarAcessoATela()
        {
            #region Parameters
            string nomeNaTela = "Visualizando Tarefas";
            #endregion

           // MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            Assert.IsTrue(verTarefas.VerificarTextoNaTela().Contains(nomeNaTela));

        }

        [Test]
        //[Parallelizable]
        [Category("Ver Tarefas")]
        public void PesquisarTarefaPorString()
        {
            #region Parameters
            string tarefa = "Pokemo 20" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string mensagemErroEsperada = "Um número era esperado para bug_id.";
            #endregion

           //MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.PesquisarGlobalTarefas(tarefa);

            Assert.That(verTarefas.CapturarMensagemRetornada().Contains(mensagemErroEsperada));
        }

        [Test]
        //[Parallelizable]
        [Category("Ver Tarefas")]
        public void PesquisarTarefaIdInexistente()
        {
            #region Parameters
            string tarefa = GeneralHelpers.ReturnStringWithRandomNumbers(4);
            #endregion

           // MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.PesquisarGlobalTarefas(tarefa);

            Assert.That(verTarefas.CapturarMensagemRetornada().Contains("A tarefa " + tarefa + " não encontrada."));
        }

        [Test]
        //[Parallelizable]
        [Category("Ver Tarefas")]
        public void SalvarUmNovoFiltro()
        {
            #region Parameters
            string descricaoNovoFiltro = "Filtro";
            #endregion

           // MassaStartDBSteps.CriaMassaDeTestesDB();

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

          //  MassaStartDBSteps.CriaMassaDeTestesDB();

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
            //MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmEditarTarefaAleatoria();

            verTarefas.clicarEmCampoPrioridade();

            verTarefas.SelecionarPrioridadeAleatoria();

            verTarefas.ClicarEmAtualizarTarefa();

            Assert.AreNotEqual(verTarefas.VerificarPrioridadeAtual, verTarefas.VerificarPrioridadeAnterior );

        }


        #region Erro 1100 Mantis
   
        [Test]
        //[Parallelizable]
        [Category ("Ver Tarefas")]
        public void ApagarUmaTarefa()
        {

            //MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmMarcarTarefaAleatoria();

            verTarefas.SelecionarApagarTarefa();

            verTarefas.ClicarEmBotaoOK();

            verTarefas.ClicarEmConfirmarApagarTarefa();

            verTarefas.UpdateMarcador();

            Assert.AreNotEqual(verTarefas.MarcadorAnterior,verTarefas.MarcadorAtual);
        }
        #endregion

        [Test]
        //[Parallelizable]
        [Category ("Ver Tarefas")]
        public void AtribuirUmaTarefa()
        {

            #region Parameters
            string atribuirA = "administrator";
            #endregion

          //  MassaStartDBSteps.CriaMassaDeTestesDB(); 
            
            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmMarcarTarefaAleatoria();

            verTarefas.SelecionarAtribuirTarefa();

            verTarefas.ClicarEmBotaoOK();

            verTarefas.AtribuirTarefaA(atribuirA);

            verTarefas.ClicarEmAtribuirTarefa();

            Assert.That(verTarefas.VerificarCampoUsuario().Contains(atribuirA));
            //Assert.That(verTarefas.VerificarCampoEstado().Contains(atribuirA));

        }

       
        [Test]
        //[Parallelizable]
        [Category ("Ver Tarefas")]
        public void ResolverTarefa()
        {

            //MassaStartDBSteps.CriaMassaDeTestesDB();

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuVerTarefas();

            verTarefas.ClicarEmMarcarTarefaAleatoria();

            verTarefas.SelecionarResolverTarefa();

            verTarefas.ClicarEmBotaoOK();

            verTarefas.SelecionarStatusDaResolutionAleatoria();

            verTarefas.ClicarEmResolverTarefa();

            // melhorar metodo de assert, capturar tarefa selecionada.
            Assert.That(verTarefas.VerificarCampoEstado().Contains("resolvido"));
        }
    }
}
