using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class VerTarefasPage : PageBase
    {
        Random rand = new Random();

        #region Mapping
        By pesquisaTarefaGlobal = By.Name("bug_id");
        By contadorDeTarefas = By.ClassName("badge");
        By boxDeErro = By.XPath("//div[@class='alert alert-danger']//p[2]");
        By idBug = By.XPath("(//td[@class='bug-id'])");
        By capturaTexto = By.XPath("//*[@id='bug_action']//h4");
        By botaoSalvarFiltro = By.LinkText("Salvar");
        By campoNomeFiltro = By.Name("query_name");
        By botaoSalvarNovoFiltro = By.XPath("//input[@value='Salvar Filtro Atual']");
        By listaDeTarefas = By.XPath("(//*[@class='column-id']//a[contains(@href,'/view')])");
        By botaoEditarTarefa = By.XPath("(//*[@class='column-edit']//i[@title='Atualizar'])");
        By checkboxMarcarTarefa = By.ClassName("ace");
        By checkboxMarcarTarefa_ = By.XPath(" (//span[@class='lbl'])");
        By botaoAtualizarInformacao = By.XPath("//input[@type='submit']");
        By botaoConfirmarDeletarTarefa = By.XPath("//input[@value='Apagar Tarefas']");
        By botaoAtribuirTarefa = By.XPath("//input[@value='Atribuir Tarefas']");
        By botaoOkParaTarefaSelecionada = By.XPath("//input[@value='OK']");
        By dropdownAcoes = By.XPath("//select[@name='action']");
        By dropdownAtribuir = By.ClassName("input-sm");
        By campoEstado = By.LinkText("administrator");

        By dropdownPrioridade = By.Id("priority");
        By optionsPrioridade = By.XPath("//*[@id='priority']//option");
        By prioridadeSelecionanda = By.XPath("(//*[@id='priority']//option[@selected])");
        #endregion

        //Controller Global
        public string VerificarPrioridadeAtual;
        public string VerificarPrioridadeAnterior;
        public string MarcadorAnterior;
        public string MarcadorAtual;

        public string VerificarCampoEstado()
        {
            return GetText(campoEstado);
        }

        #region Acction
        public void PesquisarGlobalTarefas(string pesquisaTarefa)
        {
            ClearAndSendKeys(this.pesquisaTarefaGlobal, pesquisaTarefa);
            EnterKeyBoardInput(pesquisaTarefaGlobal);
        }

        public string CapturarMensagemRetornada()
        {
            return GetText(boxDeErro);
        }

        public string CapturarIdDoBug()
        {
            return GetText(idBug);
        }

        public string VerificarTextoNaTela()
        {
            return GetText(capturaTexto);
        }

        public string VerificarPrioridade()
        {
            return GetText(prioridadeSelecionanda);
        }

        public string VerificarMarcador()
        {
            return GetText(contadorDeTarefas);
        }

        public void UpdateMarcador()
        {
            MarcadorAtual = VerificarMarcador();
        }

        public void ClicarEmNovoFiltro()
        {
            Click(botaoSalvarFiltro);
        }

        public void PreencherNovoFiltro()
        {
            SendKeys(this.campoNomeFiltro, "Filtro" + GeneralHelpers.ReturnStringWithRandomCharacters(2));
        }

        public void ConfirmarCriacaoFiltro()
        {
            Click(botaoSalvarNovoFiltro);
        }

        public void ClicarEmAtualizarTarefa()
        {
            Click(botaoAtualizarInformacao);
        }

        public bool VerificarTarefaNaLista()
        {
            return ReturnIfElementExists(listaDeTarefas);
        }


        public void ClicarEmTarefaAleatoria()
        {

            IList<IWebElement> options = driver.FindElements(this.listaDeTarefas);

            int tarefasRandom = rand.Next(1, options.Count);

            string temp = tarefasRandom.ToString();

            Click(By.XPath("(//*[@class='column-id']//a[contains(text(),'" + temp + "')])"));

        }

        public void ClicarEmEditarTarefaAleatoria()
        {

            IList<IWebElement> options = driver.FindElements(this.botaoEditarTarefa);

            int tarefasRandom = rand.Next(1, options.Count);

            string temp = tarefasRandom.ToString();

            Click(By.XPath("(//*[@class='column-edit']//i[@title='Atualizar'])['" + temp + "']"));

        }

        public void ClicarEmMarcarTarefaAleatoria()
        {

            IList<IWebElement> quantidadeDeMarcadoresNaTela = driver.FindElements(checkboxMarcarTarefa);

            int numeroDoMarcadoSelecionado = rand.Next(1, quantidadeDeMarcadoresNaTela.Count);

            string valorTemporario = numeroDoMarcadoSelecionado.ToString();

            Click(By.XPath("(//span[@class='lbl'])[" + valorTemporario + "]"));

        }

        public void clicarEmCampoPrioridade()
        {
            Click(dropdownPrioridade);
            VerificarPrioridadeAnterior = VerificarPrioridade();
        }

        public void SelecionarPrioridadeAleatoria()
        {
            /* Option 1 : Post as information wend exist in drop 
            Random rand = new Random();

            //string[] itemsInDropdown = new string[] { GetText(optionsPrioridade) };

            string[] itemsInDropdown = new string[] {"nenhuma", "baixa", "normal", "alta", "urgente", "imediato" };

            ComboBoxSelectByVisibleText(this.dropdownPrioridade, (itemsInDropdown[rand.Next(itemsInDropdown.Length)]));
            */

            // Option 2 : Get Information exist in drop int put in string list

            IList<IWebElement> allOptionsDropdown = driver.FindElements(this.optionsPrioridade);

            IList<string> optionsListDropdown = new List<string>();

            foreach (var element in allOptionsDropdown)
            {
                if (element.Text == VerificarPrioridadeAnterior)
                {
                    optionsListDropdown.Remove(element.Text);
                }
                else
                {
                    optionsListDropdown.Add(element.Text);
                }

            }

            //Random rand = new Random();

            VerificarPrioridadeAtual = optionsListDropdown[rand.Next(0, optionsListDropdown.Count)];

            ComboBoxSelectByVisibleText(this.dropdownPrioridade, VerificarPrioridadeAtual);

        }

        public void AtribuirTarefaA(string atribuirA)
        {
            ComboBoxSelectByVisibleText(dropdownAtribuir, atribuirA);
        }

        public void ClicarEmAtribuirTarefa()
        {
            Click(botaoAtribuirTarefa);
        }

        public void SelecionarApagarTarefa()
        {
            string itemDelete = "Apagar";

            ComboBoxSelectByVisibleText(dropdownAcoes, itemDelete);

        }

        public void SelecionarAtribuirTarefa()
        {
            string itemAtribuir = "Atribuir";

            ComboBoxSelectByVisibleText(dropdownAcoes, itemAtribuir);
        }

        public void ClicarEmBotaoOK()
        {
            MarcadorAnterior = VerificarMarcador();
            Click(botaoOkParaTarefaSelecionada);
        }

        public void ClicarEmConfirmarApagarTarefa()
        {
            Click(botaoConfirmarDeletarTarefa);
        }

        #endregion
    }
}
