﻿using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class PlanejametoPage : PageBase
    {
        #region
        By msgDeRetornoEmTela = By.XPath("//p[@class='lead']");
        #endregion

        #region Action

        public string CapturaMensagemNaTela()
        {
            return GetText(msgDeRetornoEmTela);
        }
        #endregion
    }
}
