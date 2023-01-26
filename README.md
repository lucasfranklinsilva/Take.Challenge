# [PT]Take Challenge 
Esse projeto é um desafio técnico da empresa [Take BLiP](https://www.take.net/blip/). 
O propósito geral foi a criação de um chatbot que apresente os principais pilares da Take e através de uma integração com o Github, trazer os repositórios mais antigos da empresa na linguagem **C#**.

# Arquitetura
## Chatbot
O chatbot foi desenvolvido na plataforma da Take BLiP, utilizando o *Builder* para criação do fluxo conversacional e *Javascript* para processamento das informações. O chatbot pode ser acessado através do link: 
Foi utilizado o serviço https://imgbb.com/ para hospedagem das imagens.

## API
A API foi desenvolvida em *C#* no framework *.Net Core*. Foi utilizado um template de projeto que utiliza o padrão *Onion* de desenvolvimento para abstração do código. 
A API foi publicada no Serviço de Aplicado da Azure e está documentada no *Swagger* e disponível através da URL: [Github Integration](https://githubintegration20230125124833.azurewebsites.net/)

| **Parâmetros** | **Tipo** |**Valores** | **Descrição** |
|--|--|--|--|
| user | string | any |Usuário do github  |
| quantity | integer | any | Quantidade de repositórios |
| sort | string | created, updated, pushed, full_name |Campo de ordenação |
| direction | string | asc, desc|A ordem da ordenação |


## Pastas e Arquivos
```
Take.Challenge
|── Api
|── Flow
|    └─ mybotflow.json
```

# [EN]Take Challenge 
This project is a technical challenge from the company [Take BLiP](https://www.take.net/blip/).
The general purpose was to create a chatbot that presents the main pillars of Take and, through an integration with Github, bring the company's oldest repositories in the **C#** language.

# Architecture
## Chatbot
The chatbot was developed on the Take BLiP platform, using the *Builder* to create the conversational flow and *Javascript* to process the information.
The service https://imgbb.com/ was used to host the images.

## API
The API was developed in *C#* in the *.Net Core* framework. A project template that uses the *Onion* development pattern for code abstraction was used.
The API has been published on Azure Applied Service and is documented in *Swagger* and available through the URL: [Github Integration](https://githubintegration20230125124833.azurewebsites.net/)

| **Parameters** | **Type** |**Values** | **Description** |
|--|--|--|--|
| user | string | any | Github user |
| quantity | integer | any | Number of repositories |
| sort | string | created, updated, pushed, full_name | Sort field |
| direction | string | asc, desc| The sort order |


## Folders and Files
```
Take.Challenge
|── API
|── Flow
|    └─ mybotflow.json
```
