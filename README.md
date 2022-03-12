# AllowMe challenge - Thiago Aranha

Implementação de desafio Allowme.

### Principais tecnologias utilizadas:

- .Net Core 5.0
- Entity Framework Core
- Postgres 12.5
- Visual Studio 2019
- Docker (Linux containers)

### Requisitos para teste:

- Microsoft Windows
- Visual Studio 2019 ou superior
- Microsoft .Net framework SDK 5.0
- Docker (https://docs.docker.com/install/)

### Como efetuar os testes:

- Abrir o projeto no Visual Studio.
- Marcar o projeto 'docker-compose' como projeto de inicialização (botão direito no nome projeto na aba de Gerenciador de soluções e clicar na opção 'Definir como projeto de inicialização').
- Iniciar o debug clicando no botão de 'play' com o perfil de inicialização 'Docker Compose' na barra superior.
- O processo deve criar as imagens, containers e rede necessários no Docker para rodar o projeto.
- Em seguida, uma aba no navegador padrão deverá ser aberta na página de documentação da api (Swagger).
- Antes de testar os endpoints é necessário autenticar clicando no botão na parte superior direita da tela e informar o username 'allowme' / password 'password' e logar.
- Após autenticar é possivel fazer uma requisição no endpoint ServerRequests. O mesmo mostra o resultado das requisições que estão sendo feitas para a *API de Weather e Geolocation* por meio do job que executa tarefas recorrentes.
- Para efetuar o teste no endpoint de *Billing* é necessário informar a data de inicio e de fim no formato padrão 'AAAA-MM-DDThh:mm:ss'. Ex: 2022-03-10T00:00:00 ou 2022-03-10
- Para rodar os testes do projeto basta clicar com o botão direito no projeto 'AllowmeChallenge.Test.Unit' e selecionar 'Executar testes'

### Considerações:

- A arquitetura do projeto foi desenvolvida com base no padrão DDD (Domain Driven Development).
- A estrutura do banco de dados é criada automaticamente através das migrations que são aplicadas na inicialização do projeto da WebApi.
- O projeto 'AllowmeChallenge.Recurring' roda em um container separado e é responsável por fazer as requisições nas 'Apis de Weather e Geolocation' e registrar as tentativas no banco Postgres a cada 60 segundos.
- O endpoint 'ServiceRequests' não foi desenvolvido apenas para facilitar a visualização dos dados que estão sendo registrados pelo job que roda em background.
