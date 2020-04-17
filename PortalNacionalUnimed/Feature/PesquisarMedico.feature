#language: pt-br

Funcionalidade: Pesquisar Médico
	Eu como usuário
	Quero realizar buscas de Médicos
	Assim posso encontrar um Médico mais próximo a mim
	
@PesquisaMedico @SmokeTest
Cenário: CT01 - Realizar busca de um médico da cidade do Rio de Janeiro
	Dado o usuário não logado acessa o Guia Médico
	Quando preencher o campo de busca com a especialidade "Cardiologista"
		E clicar em Pesquisar
	Então serão exibidos os campos de Estado e Cidade
	Quando selecionar o estado "Rio de Janeiro" e a cidade "Rio de Janeiro"
		E clicar em Continuar
	Então o resultado da busca apresenta a especialidade "Cardiologia" para a cidade "Rio de Janeiro"
	
@PesquisaMedico 
Cenário: CT02 - Realizar busca de médicos da cidade do Rio de Janeiro e que não exiba médicos da cidade de São Paulo
	Dado o usuário não logado acessa o Guia Médico
	Quando preencher o campo de busca com a especialidade "Cardiologista"
		E clicar em Pesquisar
	Então serão exibidos os campos de Estado e Cidade
	Quando selecionar o estado "Rio de Janeiro" e a cidade "Rio de Janeiro"
		E clicar em Continuar
	Então o resultado da busca lista médicos do "Rio de Janeiro" e não exibe médicos de "São Paulo" nas 3 primeiras páginas