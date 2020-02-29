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
        public void PesquisarTaredaPorString()
        {
            #region Parameters
            string tarefa = "Pokemo 20" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string mensagemErroEsperada = "Um número era esperado para bug_id.";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

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

            verTarefas.PesquisarGlobalTarefas(tarefa);

            Assert.That(verTarefas.CapturarMensagemRetornada().Contains("A tarefa " + tarefa + " não encontrada."));
        }

    }
}
