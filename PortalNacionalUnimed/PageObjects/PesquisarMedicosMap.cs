using OpenQA.Selenium;
using PortalNacionalUnimed.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalNacionalUnimed.PageObjects
{
    public class PesquisarMedicosMap : UtilHelper
    {

        public IWebElement ButtonGuiaMedico => driver.FindElement(By.CssSelector("[href*='r/guia-medico']"));

        public IWebElement TextProcurar
        {
            get
            {
                string element = "campo_pesquisa";
                WaitElement(By.Id(element), 10);
                return driver.FindElement(By.Id(element));
            }
        }

        public IWebElement AssertComboEstado
        {
            get
            {
                string element = "//div[.='Estado']";
                WaitElement(By.XPath(element), 5);
                return driver.FindElement(By.XPath(element));
            }
        }

        public IWebElement AssertComboCidade
        {
            get
            {
                string element = "//div[.='Cidade']";
                WaitElement(By.XPath(element), 5);
                return driver.FindElement(By.XPath(element));
            }
        }

        public IWebElement ButtonContinuar => driver.FindElement(By.CssSelector("[class='btn btn-success']"));

        public IWebElement ButtonPesquisar => driver.FindElement(By.Id("btn_pesquisar"));

        public IWebElement TextEstado => driver.FindElement(By.Id("react-select-2-input"));

        public IWebElement TextCidade => driver.FindElement(By.Id("react-select-3-input"));

        public IWebElement RadioUnidade
        {
            get
            {
                string element = "[type='radio']";
                WaitElement(By.CssSelector(element), 5);
                return driver.FindElement(By.CssSelector(element));
            }
        }

        public IWebElement AssertCidadeLista
        {
            get
            {
                string element = "txt_endereco";
                WaitElement(By.Id(element), 10);
                return driver.FindElement(By.Id(element));
            }
        }

        public IWebElement AssertEspecialidade => driver.FindElement(By.XPath("//span[.='Cardiologia']"));

        public IWebElement ButtonProximaPagina => driver.FindElement(By.XPath("//li[13]//i[@class='icon-chevron-right']"));
    }
}
