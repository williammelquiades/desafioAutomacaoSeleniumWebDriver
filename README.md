## Desenvolvimento de uma TAS para desafio Base 2 

- Tecnologias utilizadas no Projeto

	- Linguagem		- [CSharp](https://docs.microsoft.com/pt-br/dotnet/csharp/ "CSharp")
	- Framework de desenvolvimento: .NET Full Framework 4.6.1
	- Execução dos testes - [SeleniumGrid](https://github.com/SeleniumHQ/selenium/wiki/Grid2)
	- Framework de Testes
	- Orquestrador de testes - [NUnit 3.11](https://github.com/nunit/nunit "NUnit 3.11")
	- Relatório de testes automatizados - [ExtentReports 3.1.0](http://extentreports.com/docs/versions/3/net/ "ExtentReports 3.1.0")
	- Framework interação com elementos web - [Selenium.WebDriver 3.141](https://www.seleniumhq.org/download/ "Selenium.WebDriver") 
	- Docker Toolbox - [Docker](https://docs.docker.com/toolbox/toolbox_install_windows/)
	- Jenkins - [Jenkins lts 2.204.2](https://hub.docker.com/r/jenkins/jenkins)


## Arquitetura

O desafio foi realizado sob a GTAA da Base 2 tecnologia, o desenvolvimento foi baseado no fluxograma da arquitetura conforme imagem abaixo:

![alt text](https://i.imgur.com/wexOWJF.png)

## Desafio Automacao Selenium WebDriver : Regras

[x] 1) Implementar 50 scripts de testes que manipulem uma aplicação web
[X] 2) Alguns scripts devem ler dados de uma planilha Excel para implementar Data-Driven.
[x] 3) Dos 50 scripts a classe de teste CriarTarefasTests no cénario CriarNovasTarefasEmMassa é responsavel por criar novas tarefas usando o arquivos .csv e uma classe de login usar dados fake do arquivo .csv para tenta logar no sistema.
[x] 4) Os casos de testes precisam ser executados em no mínimo três navegadores. Utilizando o Selenium Grid.
       - Os navegadores selecionados para execução foram Chrome, Firefox e Ie "Sim, tentei sofrer com energúmeno para execução de tests"
       - Não é necessário executar em paralelo! "Sigo tentando aprofundar a execução via Docker"
[x] 5) Screenshots dos casos de testes na pasta bin\Debug\Reports após execução.
[x] 6) Relatório de testes automaticamente com screenshots dos casos de testes na pasta bin\Debug\Reports após execução com  ExtentReport.
[x] 7) Massa de testes geradas ao executar scripts e restore de banco de dados ao finalizar.
[x] 8) Scripts injetando Javascript para executar operação na telas.
[ ] 9) Testes agendados pelo Jenkins, CI, OK - CD [em estudos]



