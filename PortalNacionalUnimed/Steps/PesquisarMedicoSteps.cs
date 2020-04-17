using PortalNacionalUnimed.Helper;
using PortalNacionalUnimed.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace PortalNacionalUnimed.Steps
{
    [Binding]
    public class PesquisarMedicoSteps : PesquisarMedicosPage
    {
        WebDriver _driver = new WebDriver();
        UtilHelper _base = new UtilHelper();

        [BeforeScenario]
        public void Init() => _driver.Inicializar();

        [AfterScenario]
        public void CleanUp() => _base.FechaNavegador();

        [Given(@"o usuário não logado acessa o Guia Médico")]
        public void DadoOUsuarioNaoLogadoAcessaOGuiaMedico()
        {
            _driver.AbreUrl();
            AcessarGuiaMedico();
        }

        [When(@"preencher o campo de busca com a especialidade ""(.*)""")]
        public void QuandoPreencherOCampoDeBuscaComAEspecialidade(string p0)
        {
            PreencherBuscaEspecialidade(p0);
        }

        [When(@"clicar em Pesquisar")]
        public void QuandoClicarEmPesquisar()
        {
            ClicarPesquisar();
        }

        [When(@"selecionar o estado ""(.*)"" e a cidade ""(.*)""")]
        public void QuandoSelecionarOEstadoEACidade(string p0, string p1)
        {
            PreencherEstadoCidade(p0, p1);
        }

        [When(@"clicar em Continuar")]
        public void QuandoClicarEmContinuar()
        {
            ClicarContinuar();
        }

        [Then(@"serão exibidos os campos de Estado e Cidade")]
        public void EntaoSeraoExibidosOsCamposDeEstadoECidade()
        {
            ValidarExibicaoEstadoCidade();
        }

        [Then(@"o resultado da busca apresenta a especialidade ""(.*)"" para a cidade ""(.*)""")]
        public void EntaoOResultadoDaBuscaApresentaAEspecialidadeParaACidade(string p0, string p1)
        {
            ValidarEspecialidadeResultado(p0);
            ValidarCidadeResultado(p1);
        }

        [Then(@"o resultado da busca lista médicos do ""(.*)"" e não exibe médicos de ""(.*)"" nas (.*) primeiras páginas")]
        public void EntaoOResultadoDaBuscaListaMedicosDoENaoExibeMedicosDeNasPrimeirasPaginas(string p0, string p1, int p2)
        {
            ValidarExibicaoCorretaCidadeBuscaMedicos(p0, p1, p2);
        }
    }
}
