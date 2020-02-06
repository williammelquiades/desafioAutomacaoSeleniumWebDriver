using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarProjetosPage : PageBase
    {
        #region Mapping
        By nomeProjeto = By.Id("project-name");
        By abaGerenciarProjetos = By.XPath("//a[@href='/manage_proj_page.php']");
        By botaoNovoProjeto = By.XPath("//button[contains(text(),'Criar Novo Projeto') or contains(text(), 'Create New Project')]");
        By campoDescricao = By.Id("project-description");
        By selecionaEstado = By.Id("project-status");
        By selecionarVisibilidade = By.Id("project-view-state");
        By botaoAdd = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar projeto')]");
        By mensagemErroTextArea = By.XPath("//*[@class='page-content']//p"); //*[starts-with(@class,'alert')]//p
        //
        By botãoAdicionarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Categoria')]");
        By campoNovaCategoria = By.ClassName("input-sm"); 
        #endregion

        #region Actions
        //Gerenciamento Projeto: Seção >> Projetos
        public void ClicarEmAbaGerenciarProjeto() {
            Click(abaGerenciarProjetos);
        }

        public void ClicarEmNovoProjeto() { 
            Click(botaoNovoProjeto); 
        }

        public void PreencherNomeProjeto(string nomeProjeto) {
            SendKeys(this.nomeProjeto, nomeProjeto);
        }

        public void SelecionarEstado(string selecionaEstado) {
            ComboBoxSelectByVisibleText(this.selecionaEstado, selecionaEstado);
        }

        public void HerdarCategoria() { }

        public void SelecionarVisibilidade(string selecionarVisibilidade) { 
            ComboBoxSelectByVisibleText(this.selecionarVisibilidade, selecionarVisibilidade);
        }

        public void SetDescricao(string campoDescricao) {
            SendKeys(this.campoDescricao, campoDescricao);
        }

        public void clicarEmAdicionar() { 
            Click(botaoAdd);
        }

        public string RetornaMensagem()
        {
            return GetText(mensagemErroTextArea);
        }

        // Gerenciamento Projetos: Seção >> Categoria Global

        public void PreencherCategoriaGlobal(string nomeCategoria) {
            SendKeys(this.campoNovaCategoria, nomeCategoria);
;        }

        public void ClicarAdicionarEmNovaCategoria() {
            Click(campoNovaCategoria);
        }

        #endregion
    }

    public class CategoriaGlobalPage : PageBase {

        #region Mapping
        By botaoAdicionarCategoria = By.XPath("//*[@class='input-sm' and @type='text']//following-sibling::input[1]");
        By campoNovaCategoria = By.ClassName("input-sm");
        #endregion


        #region Actions
        public void PreencherCategoriaGlobal(string nomeCategoria)
        {
            SendKeys(this.campoNovaCategoria, nomeCategoria);
            ;
        }

        public void ClicarAdicionarEmNovaCategoria()
        {
            Click(botaoAdicionarCategoria);
        }

        public void ValidaritemCriado() { }
        #endregion
    }
}
