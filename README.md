# Viajeros API
Proyecto final para la Universidad Tecnologica Nacional (FRT)
Este API es una de las partes del proyecto de la práctica profesional supervisada.

Requisitos
.NET Core SDK (versión 8.0)
SQL Server (u otro proveedor de base de datos compatible)
Configuración
Clona este repositorio en tu máquina local.
Abre el archivo appsettings.json y configura la cadena de conexión a tu base de datos.
Ejecuta las migraciones para crear la base de datos:
dotnet ef database update

Compila y ejecuta la aplicación:
dotnet run

Estructura del Proyecto
Controllers: Contiene los controladores de la API.
Models: Define las entidades, modelos de datos y data transfer objects.
Data: Contiene el contexto de la base de datos y las configuraciones de las entidades.
Repositories: Implementa el patrón Unit of Work y los repositorios para acceder a los datos.
Services: Lógica de negocio y operaciones relacionadas con los datos.
Migrations: Migraciones de la base de datos generadas por Entity Framework.
Uso
Accede a la API a través de la URL: http://localhost:5000/api/nombre-del-controlador.
Consulta la documentación de la API para obtener detalles sobre los endpoints disponibles.
Contribución

Si deseas contribuir, sigue estos pasos:

Crea una rama con un nombre descriptivo:
git checkout -b feature/nueva-funcionalidad

Realiza tus cambios y crea un commit:
git commit -m "Agrega nueva funcionalidad"

Envía tus cambios al repositorio:
git push origin feature/nueva-funcionalidad

Abre una solicitud de extracción en GitHub.
Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para obtener más detalles.
