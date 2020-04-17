using OpenQA.Selenium;
using PortalNacionalUnimed.Helper;
using System;
using System.Threading;
using NUnit.Framework;

namespace PortalNacionalUnimed.PageObjects
{
    public class PesquisarMedicosPage : PesquisarMedicosMap
    {
        readonly UtilHelper _util = new UtilHelper();

        internal void AcessarGuiaMedico() => ButtonGuiaMedico.Click();

        internal void PreencherBuscaEspecialidade(string espec)
        {
            TextProcurar.Click();
            TextProcurar.SendKeys(espec);
        }

        internal void ClicarPesquisar() => ButtonPesquisar.Click();

        internal void ValidarExibicaoEstadoCidade()
        {
            StringAssert.Contains("Estado", AssertComboEstado.Text);
            StringAssert.Contains("Cidade", AssertComboCidade.Text);
        }

        internal void PreencherEstadoCidade(string estado, string cidade)
        {
            TextEstado.SendKeys(estado + Keys.Tab);
            Thread.Sleep(1000);
            TextCidade.SendKeys(cidade + Keys.Tab);
            RadioUnidade.Click();
        }

        internal void ClicarContinuar()
        {
            ButtonContinuar.Click();
        }

        internal void ValidarCidadeResultado(string cidade)
        {
            StringAssert.Contains(cidade, AssertCidadeLista.Text);
        }

        internal void ValidarEspecialidadeResultado(string espec)
        {
            StringAssert.Contains(espec, AssertEspecialidade.Text);
        }

        public void ValidarExibicaoCorretaCidadeBuscaMedicos(string cidadeEsperada, string cidadeNaoEsperada, int qtdPaginas)
        {
            int i;
            int j;

            for (j = 1; j <= qtdPaginas; j++)
            {
                try
                {
                    for (i = 19; i <= 20; i++)
                    {
                        
                        try
                        {
                            string element = driver.FindElement(By.XPath("(//*[@id='txt_endereco'])[" + i + "]")).Text;
                            StringAssert.Contains(cidadeEsperada, element);
                            StringAssert.DoesNotContain(cidadeNaoEsperada, element);
                        }
                        catch (OpenQA.Selenium.NoSuchElementException)
                        {
                            Assert.Fail();
                        }
                    }
                    
                    ButtonProximaPagina.Click();
                    Thread.Sleep(5000);
                }
                
                catch (OpenQA.Selenium.NoSuchElementException)
                {
                    Assert.Fail();
                }                
            }
        }
    }
}
