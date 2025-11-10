
🧩 MarketHub – Proyecto de práctica integral .NET + React
🎯 Objetivo

Desarrollar una aplicación web modular que permita la interacción entre distintos tipos de usuarios (Administrador, Vendedor y Usuario Comprador) con manejo seguro de autenticación, autorización por roles, publicación y compra de productos.
El proyecto implementará una arquitectura moderna basada en .NET 9, Clean Architecture, Entity Framework Core, JWT, React, y Docker Compose para su despliegue y orquestación.
🧱 Requerimientos funcionales
👥 Roles de usuario
🧑‍💼 Administrador

    Puede ver todos los usuarios, incluyendo los perfiles configurados como privados.
    Puede aprobar o rechazar la creación de nuevos administradores.
    Puede eliminar cualquier usuario o publicación.
    Tiene acceso total al sistema (modo superuser).

🧑‍🔧 Vendedor

    Puede crear, editar, eliminar y listar sus propios productos.
    Cada producto incluye:
        Nombre
        Descripción
        Categoría (ej: fitness, videojuegos, ropa, etc.)
        Precio sin IVA
        Precio total con IVA (calculado automáticamente)
    Puede gestionar sus publicaciones y decidir si son públicas o privadas.
    Solo el propio vendedor o el administrador pueden modificar/eliminar sus productos o publicaciones.

🧑‍🛍️ Usuario Comprador

    Puede buscar y visualizar publicaciones públicas.
    Puede realizar compras de productos a través de una pasarela de pago integrada (API externa).
    Puede añadir productos a un carrito antes de proceder al pago.

🔐 Requerimientos no funcionales
🔑 Autenticación y autorización

    Implementar JWT (JSON Web Token) para el control de sesiones.
    Middleware que restrinja el acceso a rutas según el rol del usuario.

🧩 Arquitectura

Seguir el patrón Clean Architecture, con separación clara en capas:
💾 Persistencia

    Usar Entity Framework Core con MySQL como base de datos principal.
    Configurar migraciones automáticas y semillas de datos iniciales.

💳 Integración de pasarela de pago

    Simular o integrar una API real (por ejemplo, Stripe o PayPal Sandbox).
    Implementar flujos de pago seguros (creación de órdenes, confirmación, callback).

🖥️ Front-end

    Desarrollar una SPA (Single Page Application) en React.
    Implementar páginas y componentes principales:
        Registro / Inicio de sesión
        Listado y detalle de productos
        Panel de vendedor
        Panel de administrador
        Carrito de compras
        Flujo de pago
    Estilizar con CSS Modules, Tailwind o Styled Components.

🐳 Dockerización

    Crear contenedores separados para:
        backend (.NET API)
        frontend (React)
        db (MySQL)
    Orquestar con Docker Compose, exponiendo los servicios de forma accesible.

☁️ Despliegue

    Preparar el proyecto para despliegue en un entorno remoto (por ejemplo, Render, Azure, o Railway).
    Configurar variables de entorno para conexión a base de datos, claves JWT y credenciales de la pasarela de pago.

🧪 Testing

    Implementar pruebas unitarias y de integración básicas en la capa de aplicación y dominio.

🧭 Flujo de uso resumido

    Un visitante puede registrarse como usuario o vendedor.
    El admin inicial se crea mediante semilla.
    Los usuarios autenticados pueden buscar otros usuarios o publicaciones:
        Búsqueda parcial ('%pie%' debe coincidir con “piedra”, “pierna”, “pie”).
    Un vendedor publica productos y los expone al público.
    Un usuario puede añadir productos al carrito y pagar mediante la pasarela.
    El admin puede moderar usuarios y contenido.

🧰 Tecnologías clave
Categoría 	Tecnología
Backend 	.NET 9 (Web API)
ORM 	Entity Framework Core (MySQL)
Autenticación 	JWT Bearer
Frontend 	React + Vite
Infraestructura 	Docker & Docker Compose
Testing 	xUnit / NUnit
Documentación API 	Swagger + Postman Collection
CI/CD (opcional) 	GitHub Actions
🌍 Extensiones opcionales

    Integrar SignalR o WebSockets para notificaciones en tiempo real (por ejemplo, nuevas compras o mensajes).
    Añadir un sistema de logs centralizado con Serilog.
    Implementar multilenguaje (ES/EN) en el front.
    Incluir un modo oscuro en la interfaz React.

🚀 Próximos pasos sugeridos

    Crear la estructura base del proyecto siguiendo el patrón Clean Architecture.
    Configurar la base de datos y EF Core con migraciones iniciales.
    Implementar JWT y registro/login.
    Desarrollar controladores RESTful para usuarios, productos y compras.
    Integrar React y construir el front.
    Dockerizar el entorno con docker-compose up.
    Exponer los endpoints en Swagger y probarlos en Postman.
    Preparar despliegue remoto (Render, Railway, Azure).

📦 Repositorio de ejemplo (opcional)

    Si deseas practicar, puedes crear un repositorio con la estructura anterior.
    Ejemplo de estructura inicial:

    MarketHub/
    ├── src/
    │   ├── MarketHub.Domain/
    │   ├── MarketHub.Application/
    │   ├── MarketHub.Infrastructure/
    │   └── MarketHub.API/
    ├── client/
    │   └── markethub-react/
    ├── docker-compose.yml
    ├── README.md
    └── .gitignore

    ✨ Objetivo final: Consolidar tus habilidades prácticas en desarrollo full stack con .NET y React, aplicando principios de arquitectura limpia, seguridad con JWT, persistencia con EF, despliegue con Docker, y exposición profesional de servicios para consumo desde Postman y un frontend moderno.

