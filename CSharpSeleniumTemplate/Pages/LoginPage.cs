using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Name("username");
        By passwordField = By.Name("password");
        By loginButton = By.XPath("//input[@type='submit']");
        By mensagemErroTextArea = By.XPath("//*[starts-with(@class,'alert')]//p");
        //path in katolon: xpath=(.//*[normalize-space(text()) and normalize-space(.)='AVISO:'])[1]/preceding::p[1] /html/body/div[2]/font

        #endregion

        #region Actions
        public void PreencherUsuario(string usuario)
        {
            SendKeys(usernameField, usuario);
        }

        // metodos com JavaScript
        public void PreencherUsuarioJS(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }

        public void PreencherSenhaJS(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }
        // end metedo com JS

        public void PreencherSenha(string senha)
        {
            SendKeys(passwordField, senha);
        }

        public void ClicarEmLogin()
        {
            Click(loginButton);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(mensagemErroTextArea);
        }
        #endregion
    }
}
