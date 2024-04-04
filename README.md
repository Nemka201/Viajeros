# Viajeros API
<p>Proyecto final para la Universidad Tecnologica Nacional (FRT)</p>
<p>Este API es una de las partes del proyecto de la práctica profesional supervisada.</p>

<h2>Requisitos</h2>
.NET Core SDK (versión 8.0)
SQL Server (u otro proveedor de base de datos compatible)
<h2>Configuración</h2>
<p>Clona este repositorio en tu máquina local.</p>
<p>Abre el archivo appsettings.json y configura la cadena de conexión a tu base de datos.</p>
<p>Ejecuta las migraciones para crear la base de datos:</p>
<p>dotnet ef database update</p>

Compila y ejecuta la aplicación:
dotnet run

<h2>Estructura del Proyecto</h2>
<p>Controllers: Contiene los controladores de la API.</p>
<p>Models: Define las entidades, modelos de datos y data transfer objects.</p>
<p>Data: Contiene el contexto de la base de datos y las configuraciones de las entidades.</p>
<p>Repositories: Implementa el patrón Unit of Work y los repositorios para acceder a los datos.</p>
<p>Services: Lógica de negocio y operaciones relacionadas con los datos.</p>
<p>Migrations: Migraciones de la base de datos generadas por Entity Framework.</p>
<h2>Uso</h2>
<p>Accede a la API a través de la URL: http://localhost:5000/api/nombre-del-controlador.</p>
<p>Consulta la documentación de la API para obtener detalles sobre los endpoints disponibles.</p>
<h2>Contribución</h2>

<p>Si deseas contribuir, sigue estos pasos:</p>

<p>Crea una rama con un nombre descriptivo:</p>
<p>git checkout -b feature/nueva-funcionalidad</p>

<p>Realiza tus cambios y crea un commit:</p>
<p>git commit -m "Agrega nueva funcionalidad"</p>

<p>Envía tus cambios al repositorio:</p>
git push origin feature/nueva-funcionalidad</p>

Abre una solicitud de extracción en GitHub.
Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para obtener más detalles.
