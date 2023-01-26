# Take Challenge
Esse projeto é um desafio técnico da empresa [Take BLiP](https://www.take.net/blip/). 
O propósito geral foi a criação de um chatbot que apresente os principais pilares da Take e através de uma integração com o Github, trazer os repositórios mais antigos da empresa na linguagem **C#**.

# Arquitetura
## Chatbot
O chatbot foi desenvolvido na plataforma da Take BLiP, utilizando o *Builder* para criação do fluxo conversacional e *Javascript* para processamento das informações.
Foi utilizado o serviço https://imgbb.com/ para hospedagem das imagens.

## API
A API foi desenvolvida em *C#* no framework *.Net Core*. Foi utilizado um template de projeto que utiliza o padrão *Onion* de desenvolvimento para abstração do código. 
A API foi publicada no Serviço de Aplicado da Azure e está documentada no *Swagger* e disponível através da URL: [https://githubintegration20230125124833.azurewebsites.net/](https://githubintegration20230125124833.azurewebsites.net/)

| **Parâmetros** | **Tipo** |**Valores** | **Descrição** |
|--|--|--|--|
| user | string | any |Usuário do github  |
| quantity | integer | any | Quantidade de Repositórios |
| sort | string | created, updated, pushed, full_name |Campo de ordenação |
| direction | string | asc, desc|A ordem da ordenação |


## Pastas e Arquivos
```
Take.Challenge
|── Api
|── Flow
|    └─ mybotflow.json
```
