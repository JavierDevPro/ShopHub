# How to Create a webApi step by step:

## Infrastructure Creation:

1. First you will create a solution or a .sln file who will contain the conection inner projects then you will create the webapi and the classlib projects with the next line codes:

```
    dotnet new sln -n [solution]
    dotnet new webapi -n [ProjectName.Api]
    dotnet new classlib -n [ProjectName.Application]
    dotnet new classlib -n [ProjectName.Domain]
    dotnet new classlib -n [ProjectName.Infrastructure]
    
    #to add the connection
    
    dotnet sln add ShopHub.Api ShopHub.Application ShopHub.Domain ShopHub.Infrastructure
```

2. then you must connect theme with references to have accces to the logic betwen projects:
```
    dotnet add ShopHub.Api reference ShopHub.Application
    dotnet add ShopHub.Application reference ShopHub.Domain
    dotnet add ShopHub.Api reference ShopHub.Infrastructure
    dotnet add ShopHub.Infrastructure reference ShopHub.Application
```
3. now you can open de solution or the current location of it and start to add the pricipal logic of it it must be like this:
```
.
├── MarketHub.drawio
├── README.md
├── ShopHub.Api/               # Presentation Layer (Web API)
│   ├── appsettings.json
│   ├── Controllers/
│   │   └── (Connects & directs requests, handles authorization)
│   ├── Program.cs
│   ├── Properties/
│   └── ShopHub.Api.csproj
├── ShopHub.Application/       # Business Logic Layer
│   ├── Interfaces/
│   │   └── (Service Contracts)
│   ├── Services/
│   │   └── (Core Business Logic + Accesses Repositories via Interfaces)
│   └── ShopHub.Application.csproj
├── ShopHub.Domain/            # Core Business Rules
│   ├── Entities/
│   │   ├── Category.cs
│   │   └── (Other Domain Models)
│   ├── Interfaces/
│   │   ├── ICategoryRepository.cs
│   │   └── (Repository Contracts/Interfaces)
│   └── ShopHub.Domain.csproj
├── ShopHub.Infrastructure/    # Persistence & External Services
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Repositories/
│   │   └── (Implements Domain Repository Interfaces + DB Context)
│   └── ShopHub.Infrastructure.csproj
├── solution.sln
└── WebAPI_StepByStep.md
```
4. Install some dependencies like:
```
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    
    dotnet tool install --global dotnet-ef
    
    packages:
    
        BCrypt.Net-Next
        Microsoft.IdentityModel.Tokens
        System.IdentityModel.Tokens.Jwt
        Microsoft.AspNetCore.Authentication.JwtBearer
        Microsoft.AspNetCore.OpenApi
        Swashbuckle.AspNetCore
```
5. Before keep going create the ignore files to work well on any device:
    1. .gitignore
        ```
            bin/
            obj/

            .vs/
            .vscode/
            .idea/
            *.user
            *.suo

            .env
            .appsettings.json
            appsettings.json
            appsettings.Development.json

            *.log
            logs/
        ```
    2. .DockerIgnore this is for later at the moment you create the DockerFile do not create at starting the project.
        ```
             #Carpetas de build y binarios
             **/bin/
             **/obj/
             **/out/
             **/publish/
                
             # Archivos de Visual Studio / Rider
             .vs/
             .vscode/
             .idea/
             *.user
             *.suo
             *.cache
             *.DotSettings.user
                
             # Git
             .git/
             .gitignore
             .gitattributes
                
             # Docker
             Dockerfile*
             docker-compose*
             .dockerignore
                
             # Node modules (si tienes frontend)
             **/node_modules/
                
             # Archivos de sistema
             **/.DS_Store
             **/Thumbs.db
                
             # Logs
             **/logs/
             *.log
                
             # IMPORTANTE: NO ignoramos appsettings.json
             # Lo manejaremos con variables de entorno
        ```

6. The seccuense to develop the project suggested for projects like this one is:
    1. Create the models (Diagram ER first Recommended) start with the Domain Layer the one who ends at ".Domain" on entities archive create your entities with their relationships implicited for EF (Entity Framework Core) Use Intefaces to create the repositories functions later.
    2. Start the AppDbContext where you will Inheritance the DbContext a Special class of the EF Dependency, there we can over craft the relationships of our entities with :
        ```
             public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

             protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                 base.OnModelCreating(modelBuilder);
             }
        ```
    3. Add the config Database in Program with the appsettings filled with the "ConnectionStrings": {} now Start with the migrations with focusing the Codefirst Params
       ```
            examples: 
       
            dotnet ef migrations add InitialCreate --project management.Infrastructure --startup-project management.Api
            dotnet ef database update --project management.Infrastructure/ --startup-project management.Api/
       ```