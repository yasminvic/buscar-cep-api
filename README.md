<h1 align="center"> Buscar CEP - API </h1>
<p align="center">
<img loading="lazy" src="http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge"/>
</p>


## 📝 Descrição

<p> API desenvolvida na liguagem C# que recebe o CEP como parâmetro e retorna os dados relativos à ele, relizando uma integração com a API ViaCEP.</p>

## 🛠️ Construído com

C# | ASP.NET Core | Entity Framework Core | Web API C# | Refit
:---:|:--------------:|:-----------------------:|:--------:|:------
7.0| 7.0.102      | 7.0.16                 | 7.0  | 7.0.0

<img src="https://img.shields.io/badge/CSharp-8d0579?style=for-the-badge&logo=csharp&logoColor=white"> 	<img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"> <img src="https://img.shields.io/badge/SQLServer-07405E?style=for-the-badge&logo=sqlserver&logoColor=white"> <img src="https://img.shields.io/badge/redis-%23DD0031.svg?style=for-the-badge&logo=redis&logoColor=white">

## ⚙️ Funcionalidades do Projeto

- `Funcionalidade 1`: Consultar CEP
- `Funcionalidade 2`: Cadastrar Usuário
- `Funcionalidade 3`: Listar todos os Usuários
- `Funcionalidade 4`: Realizar autenticação para acessar API via TokenJWT

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

- Você instalou a versão  `.NET C# 7.0`
- Você instalou a versão mais recente do `Redis`
  
## 🚀 Rodando a Aplicação 

Para usar a API, siga estas etapas:


1. Clone este repositório ou baixe o arquivo Zip
    ```
    $ git clone <https://github.com/tgmarinho/nlw1>
    ```
2. Inicie uma instância do Redis localmente, utilizando Docker. Para isso, abra o Terminal da solução e insira
   ```
    docker run -d -p 6379:6379 --name redis redis
    ```
    
4. Para executar o programa
   - Pressione Ctrl+F5 ou
   - Selecione Depurar>Iniciar sem depuração no menu superior ou
   - Selecione o botão verde Iniciar.
  
5. Autentique-se na rota Auth
   
   ![rota_auth](https://github.com/yasminvic/buscar-cep-api/assets/88940787/03d83a69-48d0-4b41-a15d-0d078314afae)

6. Guarde o Token gerado
7. Clique no botão verde Authorize, e em seguida coloque o seu Token dentro da caixinha que abrirá

   ![caixinha](https://github.com/yasminvic/buscar-cep-api/assets/88940787/24767c32-dee6-486d-ae00-88627a539ba6)

8. Clique novamente em Authorize e depois feche a caixinha
9. Pronto! Agora você pode usufruir da API
