using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{

    class CriarTarefasPage : PageBase
    {

        #region Mapping
        By listaDeProjetos = By.Id("select-project-id");
        By botaoSelecionarProjeto = By.XPath("//div[2]/input");
        By listaDeCategoria = By.Id("category_id");
        By listaDeFraquencia = By.Id("reproducibility");
        By listaDeGravidade = By.Id("severity");
        By listaDePrioridade = By.Id("priority");
        By listaDePerfil = By.Id("profile_id");
        By listaDeAtribuicao = By.Id("handler_id");
        By listaDemarcadores = By.Id("tag_select");
        By campoMarcador = By.Id("tag_select");
        By campoCargaIMG = By.Id("dropzone-previews-box");
        By campoCargarImg = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[12]/td/div[2]");
        By campoResumo = By.Name("summary");
        By campoDescricao = By.Name("description");
        By campoPassoReproducao = By.Name("steps_to_reproduce");
        By campoInfoAdicionais = By.Name("additional_info");
        By msgErroCategoria = By.XPath("//p[contains(text(),'APPLICATION ERROR #11')]");
        By msgDeRetornoTarefa = By.XPath("//p");
        #endregion

        #region Actions
        public void ClicarEmSelecionarProjeto()
        {
            //Click(botaoSelecionarProjeto);
        }

        public void SalvarNovoProjeto()
        {
            Click(botaoSelecionarProjeto);
        }

        public void SelecionarProjeto(string listaDeProjetos)
        {
            ComboBoxSelectByVisibleText(this.listaDeProjetos, listaDeProjetos);
        }

        public void SelecionarCategoria(string listaDeCategoria)
        {
            ComboBoxSelectByVisibleText(this.listaDeCategoria, listaDeCategoria);
        }

        public void SelecionarFrequencia(string listaDeFraquencia)
        {
            ComboBoxSelectByVisibleText(this.listaDeFraquencia, listaDeFraquencia);
        }

        public void SelecionarGravidade(string listaDeGravidade)
        {
            ComboBoxSelectByVisibleText(this.listaDeGravidade, listaDeGravidade);
        }

        public void SelecionarPrioridade(string listaDePrioridade)
        {
            ComboBoxSelectByVisibleText(this.listaDePrioridade, listaDePrioridade);
        }

        public void SelecionarPerfil(string listaDePerfil)
        {
            ComboBoxSelectByVisibleText(this.listaDePerfil, listaDePerfil);
        }

        public void SelecionaAtribuicao(string listaDeAtribuicao)
        {
            ComboBoxSelectByVisibleText(this.listaDeAtribuicao, listaDeAtribuicao);
        }

        public void PreencherResumo(string campoResumo)
        {
            SendKeys(this.campoResumo, campoResumo);
        }

        public void PreencherDescricao(string campoDescricao)
        {
            SendKeys(this.campoDescricao, campoDescricao);
        }

        public void PreencherPassoAPasso(string campoPassoReproducao)
        {
            SendKeys(this.campoPassoReproducao, campoPassoReproducao);
        }

        public void PreencherInfoAdicionais(string campoInfoAdicionais)
        {
            SendKeys(this.campoInfoAdicionais, campoInfoAdicionais);
        }

        public string MensagemValidacaoResumo(string textoCampoResumo)
        {
            return GetAttribute(this.campoResumo, textoCampoResumo);
        }

        public string MensagemValidacaoDescricao(string testeCampoDescricao)
        {
            return GetAttribute(this.campoDescricao, testeCampoDescricao);
        }

        public string ValidarCriarTarefa()
        {
            return GetText(msgDeRetornoTarefa);
        }

        public string RetornaMensagemDeErro()
        {
            return GetText(msgErroCategoria);
        }
        #endregion
    }
}