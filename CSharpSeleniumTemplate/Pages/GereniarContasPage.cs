using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    class GereniarContasPage : PageBase
    {
        #region Mapping
        By abaGerenciaUsuario = By.XPath("/manage_user_page.php");
        By botaoCriarNovaConta = By.XPath("//a[@href='/manage_user_create_page.php']");
        By campoNomeUsuario = By.Id("user-username");
        By campoNomeVerdadeiro = By.Id("user-realname");
        By campoEmail = By.Id("email-field");
        By nivelDeAcesso = By.Id("user-access-level");
        By checkHabilitado = By.Id("user-enabled");
        By checkProtegido = By.Id("user-protected");
        #endregion

        #region action
        public void ClicarEmGerenciasUsuario() { 
            Click(abaGerenciaUsuario);
        }

        public void CriarNovoUsuario() {
            Click(botaoCriarNovaConta);
        }

        public void PreencherNovoUsuario(string nomeUsuario) {
            SendKeys(this.campoNomeUsuario, nomeUsuario);
        }

        public void PreencherNomeVerdadeiro (string nomeVerdadeiro) { 
            SendKeys(this.campoNomeVerdadeiro, nomeVerdadeiro);
        }

        public void PreencherEmail(string campoEmail) {
            SendKeys(this.campoEmail, campoEmail);
        }

        public void MarcarAcesso() {
            Click(nivelDeAcesso);
        }

        public void MarcarHabilidade() { 
            Click(checkHabilitado); 
        }

        public void MarcarProtegido()
        {
            Click(checkProtegido);
        }

        #endregion
    }
}
