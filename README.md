## DADOS PARA INSTALAÇÃO ##

	1 - Realizar o download e instalar o .NET Framework 4.7 (https://www.microsoft.com/en-us/download/details.aspx?id=55170);
	2 - Realizar o download e instalar o Visual Studio 2017 (https://www.visualstudio.com/pt-br/thank-you-downloading-visual-studio/?sku=Community&rel=15);
	3 - Abrir a solução TaskList.sln e realizar um "Build Solution";
	4 - Caso execute o projeto pelo Visual Studio a aplicação encontra-se apontada para o seguinte endereço (http://localhost:58573/),
		senão caso contrário poderá realizar um "Publish" no projeto "Vidalink.Tasklist.Application" e instalar no IIS(Internet Information Services);
	5 - O Banco de dados está junto ao projeto embarcado na pasta "...\TaskList\Vidalink.Tasklist.Application\App_Data";
	
## SOBRE O PROJETO ##	

	1 - O projeto possui quatro camadas, sendo serparado pelas suas responsabilidades, sendo assim conseguimos garantir um software mais testável, 
		confiável e reutilizavél. Abaixo segue uma breve descrição da arquitetura:
		
		|--Application (Autentica/Autoriza, fornece as visões do sistema)
		|
		|-- Model (Interface para manter a compatibilidade de modelo entre as camadas)
		|
		|-- Services (Camada responsável por servir a camada de aplicação, concentrando regras de negócio)
		|
		|--Repository (Camada responsável por obter os dados do banco e transeferir para a camada de serviços)
		
	2 - Dentre as tecnologias utilizadas estão (Asp.Net Identity, Linq, Lambda, Repository, DDD, DTO, MVC, Generics, CRUD, HTML-Helpers, Razor, etc)

	
## DADOS DE ACESSO NA APLICAÇÃO##

Url: 	http://localhost:58573/
Email: 	usuario@vidalink.com
Senha:	123456

by Roger Messina.
