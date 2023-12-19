namespace AutomacaoHiper
{using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

public class AutomacaoFormulario
{
    private IWebDriver driver;

    public AutomacaoFormulario()
    {
        // Informar o caminho do navegador
        string caminhonavegador = "C:\\Program Files (x86)\\Google\\Chrome\\Application";

        
        var config = new ChromeOptions();
        config.AddArgument("--start-maximized"); // Deixar janela do navegador em tela cheia

        // Abrir o navegador
        driver = new ChromeDriver(caminhonavegador, config);
    }

    public void ExecutarAutomacao()
    {
        // Passo 1: Abre o navegador e acessa o site
        AbrirPagina("XXXXXXXX");

        // Passo 2: Preenche os campos para cadastro nome e email
        PreencherFormulario("Teste", "teste@gmail.com");

        // Passo 3: Salvar
        ClicarSalvar();

        // Passo 4: Validar os campos nome e email na pagina
        ValidarCampos("Teste", "teste@gmail.com");

        // Passo 5: Fechar o navegador
        FecharBrowser();
    }

    private void AbrirPagina(string url)
    {
        driver.Navigate().GoToUrl(url); // Metodo para abrir o navegador 
    }

    private void PreencherFormulario(string nome, string email)
    {
        // Metodo para achar os campos de cadastro nome e email e preenche-los
        IWebElement campoNome = EsperaElemento(By.Id("id-do-campo-nome"));
        campoNome.SendKeys(nome);

        IWebElement campoEmail = EsperaElemento(By.Id("id-do-campo-email"));
        campoEmail.SendKeys(email);
    }

    private void ClicarSalvar()
    {
        // Achar o botão "Salvar" e clicar nele
        IWebElement botaoSalvar = EsperaElemento(By.Id("id-do-botao-salvar"));
        botaoSalvar.Click();
    }

    private void ValidarCampos(string nome, string email)
    {
        // Metodo que verifica se os campos foram preenchidos
        IWebElement campoNome = EsperaElemento(By.Id("id-do-campo-nome"));
        IWebElement campoEmail = EsperaElemento(By.Id("id-do-campo-email"));

        // Metodo que compara os valores dos campos com os valores informado
        if (campoNome.Text != nome || campoEmail.Text != email)
        {
            throw new Exception("Os campos não foram inseridos corretamente na página.");
        }
    }
        
        private IWebElement EsperaElemento(By by, int timeoutSegundos = 15)
    {
        var espera = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSegundos));
        return espera.Until(drv => drv.FindElement(by));
        }

        private void FecharBrowser()
    {
        // Fechar o navegador
        driver.Quit();
    }
}

}
