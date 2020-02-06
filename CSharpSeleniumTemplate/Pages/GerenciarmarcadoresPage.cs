using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarMarcadoresPage : PageBase
    {
        #region Mapping
        By abaGerenciarMarcadores = By.XPath("//a[@href='/manage_tags_page.php']");
        By nomeMarcador = By.Id("tag-name");
        By campoDescricao = By.Id("tag-description");
        By botaoNovoMarcador = By.XPath("//input[@type='submit' or contains(text(), 'Criar Marcador')]");
        By tagContador = By.ClassName("badge");
        By searcheMarcadorCriado = By.XPath("//*[@class='table-responsive']//tbody//tr//td//a");
        #endregion

        #region Actions
        public void ClicarEmAbaGerenciarMarcadores() {
            Click(abaGerenciarMarcadores);
        }
        

        public void PreencherNomeMarcado(string nomeMarcador) {
            SendKeys(this.nomeMarcador, nomeMarcador);
            ProcurarMarcadorCriado(nomeMarcador);
        }

        public void preencherDescricaoMarcador(string nomeMarcador) { 
            SendKeys(campoDescricao, nomeMarcador); 
        }

        public void ClicarEmCriarMarcador()
        {
            Click(botaoNovoMarcador);
        }

        public void ValidarMarcadorCriado() {
            GetValue(tagContador);
        }

        public void ProcurarMarcadorCriado(string nomeMarcador)
        {

            System.Console.WriteLine("Marcador criado " + nomeMarcador);
            //GetTableValue(searcheMarcadorCriado, nomeMarcador);
            
            //IWebElement element = driver.FindElement(searcheMarcadorCriado);
           //var marcadores = new List<String>(GetText(element));

           // foreach (searcheMarcadorCriado in marcadores)
          //  {
          //      System.Console.WriteLine();
          //  }
        }

            #endregion
        }
}
