using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
   

    public class GerenciarPerfisGlobaisPage : PageBase
    {
        private string VARPLATAFORMA = "";
        private string SO = "";
        private string VERSAOSO = "";

        #region Mapping
        By abaPerfisGlobais = By.XPath("//a[@href='/manage_prof_menu_page.php']");
        By campoPlataforma = By.Id("platform");
        By campoSo = By.Id("os");
        By campoVersaoSo = By.Id("os-version");
        By campoDescricaoAdicional = By.Id("description");
        By botaoNovoPerfil = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Perfil')]");
        By campoSelecaoPerfilCriado = By.XPath("//select[@id='select-profile']//option");

        #endregion

        #region Actions
        public void ClicarEmAba() { 
            Click(abaPerfisGlobais);
        }

        public void PreencherCampoNomePlataforma(string plataforma) {
            this.VARPLATAFORMA = plataforma;
            SendKeys(this.campoPlataforma, plataforma);           
        }

        public void PreencherCampoNomeSO(string so) {
            SendKeys(this.campoSo, so);
        }

        public void PreenhcerCampoVersaoSO(string versaoSO) {
            SendKeys(this.campoVersaoSo, versaoSO);
        }

        public void PreencherCampoDescricao(String descricao) {
            SendKeys(this.campoDescricaoAdicional, descricao);
        }

        public void ClicarEmAdicionarPerfil() {
            Click(botaoNovoPerfil);
        }

        //public string VerificarItemCriado(string VARPLATAFORMA, string SO, string VERSAOSO)
        //{
          //  this.VARPLATAFORMA = VARPLATAFORMA;
          //  this.SO = SO;
          //  this.VERSAOSO = VERSAOSO;
            //System.Console.WriteLine("Captura de campo: "+campoPlataforma);
            //return GetText(campoPlataforma);
        //}

         
        #endregion
    }
}
