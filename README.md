# Sistema de Gestión de Recursos y Laboratorios de Electronica
Back End created using .Net8, Entity Framework y Somee
### Descripción general
Este proyecto tiene como objetivo desarrollar un sistema de gestión de recursos y laboratorios para el **Centro de Aprendizaje y Desarrollo de Ingeniería (CADI)**, enfocado en la asignatura **Fundamentos de Electrónica Digital**. El sistema permite administrar equipos, laboratorios, reservas, inventarios y permisos de acceso, facilitando la organización y control de los recursos disponibles en el CADI.

### Funcionalidades principales
El sistema cuenta con las siguientes funcionalidades principales:

1. **Gestión de usuarios**:
   - Registro y administración de estudiantes y profesores.
   - Asignación de roles y permisos según el tipo de usuario.
   - Autenticación y control de acceso basado en roles.

2. **Gestión de laboratorios**:
   - Creación y asignación de laboratorios para las prácticas de los estudiantes.
   - Seguimiento de la disponibilidad de laboratorios.

3. **Gestión de inventarios**:
   - Registro de equipos y componentes disponibles.
   - Actualización del inventario conforme se asignan y devuelven equipos.
   - Monitoreo del estado de los equipos y su historial de uso.

4. **Reservas de laboratorio**:
   - Creación y seguimiento de reservas de laboratorios.
   - Asignación de recursos (equipos) para cada reserva.
   - Registro del historial de reservas.

5. **Historial de usuarios y reservas**:
   - Registro del historial de actividad de los usuarios.
   - Seguimiento de reservas anteriores para facilitar la auditoría y gestión de recursos.

### Arquitectura del sistema

El sistema está construido utilizando el framework **ASP.NET Core**. Se implementa una arquitectura de **capas** para mantener la separación de responsabilidades, garantizando la mantenibilidad y escalabilidad del sistema. Las capas principales son:

1. **Capa de Datos**: 
   - Utiliza **Entity Framework Core** para el manejo de la base de datos.
   - Modelos y entidades incluyen tablas como `User`, `Laboratory`, `Equipment`, `Inventory`, `Reservation`, y sus relaciones.

2. **Capa de Repositorios**:
   - Define la lógica de acceso a datos para interactuar con la base de datos mediante interfaces como `IUserRepository`, `IInventoryRepository`, etc.
   - Implementación de los repositorios correspondientes para cada entidad, asegurando la abstracción de la lógica de datos.

3. **Capa de Servicios**:
   - Implementa la lógica de negocio para el manejo de recursos, inventarios, reservas, y permisos.
   - Los servicios utilizan los repositorios para interactuar con la base de datos y ofrecen métodos para ser utilizados en los controladores.

4. **Capa de Controladores**:
   - Controladores que exponen las funcionalidades del sistema mediante APIs REST, facilitando la interacción entre el cliente y el servidor.
   - Gestionan las peticiones HTTP y retornan respuestas según la lógica implementada en los servicios.

### Tecnologías utilizadas

- **ASP.NET Core**: Framework utilizado para desarrollar el backend del sistema.
- **Entity Framework Core**: ORM (Object-Relational Mapping) para el manejo de la base de datos y las entidades.
- **SQL Server**: Base de datos relacional utilizada para almacenar la información del sistema.
- **Swagger**: Herramienta utilizada para documentar las APIs del sistema, facilitando su exploración y prueba.
- **Inyección de dependencias**: Utilizada para la correcta administración de los servicios y repositorios en el ciclo de vida de la aplicación.

### Base de datos

El sistema utiliza un modelo de base de datos relacional, el cual incluye las siguientes tablas principales:

- `User`: Almacena la información de los usuarios registrados (estudiantes, profesores, etc.).
- `Laboratory`: Define los laboratorios disponibles para los estudiantes.
- `Equipment`: Registra los equipos de laboratorio, como multímetros, fuentes de poder, resistencias, entre otros.
- `Inventory`: Lleva un control de los recursos disponibles.
- `Reservation`: Almacena las reservas de laboratorio realizadas por los usuarios.
- `Permission`: Gestiona los permisos de acceso a diferentes funcionalidades del sistema.
- `User_Permission`: Relaciona los usuarios con los permisos específicos otorgados.

### Ejecución del proyecto

1. **Autenticación y autorización**: 
   - Se implementó autenticación básica sin el uso de JWT o paquetes externos, utilizando sesiones para gestionar el acceso de usuarios autenticados.
   - Cada tipo de usuario (estudiante, profesor, administrador) tiene un conjunto de permisos que controla el acceso a diferentes funcionalidades.

2. **Gestión de inventarios y laboratorios**: 
   - Los usuarios pueden consultar el inventario disponible, reservar equipos para sus prácticas, y registrar el uso de laboratorios.
   - Los administradores pueden actualizar el inventario y gestionar los laboratorios asignados.

3. **Reservas**: 
   - Los estudiantes pueden reservar laboratorios y equipos a través del sistema. 
   - Se realiza un seguimiento de las reservas y se permite la consulta de las reservas pasadas.

### Requisitos no funcionales

- **Seguridad**: Se garantizan las restricciones de acceso a usuarios autorizados mediante la autenticación y control de permisos.
- **Compatibilidad**: El sistema es compatible con diversos navegadores y dispositivos.
- **Rendimiento**: El sistema está optimizado para soportar múltiples usuarios simultáneamente y manejar grandes volúmenes de datos de equipos y reservas.

### Conclusión

Este sistema de gestión de recursos y laboratorios proporciona una solución eficiente para administrar los recursos del CADI, ayudando tanto a estudiantes como a profesores a gestionar sus prácticas de laboratorio en la asignatura de **Fundamentos de Electrónica Digital**. La arquitectura modular y la integración de buenas prácticas de desarrollo aseguran la escalabilidad y mantenimiento del sistema en el tiempo.


- **Seguridad**: Se garantizan las restricciones de acceso a usuarios autorizados mediante la autenticación y control de permisos.
- **Compatibilidad**: El sistema es compatible con diversos navegadores y dispositivos.
- **Rendimiento**: El sistema está optimizado para soportar múltiples usuarios simultáneamente y manejar grandes volúmenes de datos de equipos y reservas.

### Conclusión

Este sistema de gestión de recursos y laboratorios proporciona una solución eficiente para administrar los recursos del CADI, ayudando tanto a estudiantes como a profesores a gestionar sus prácticas de laboratorio en la asignatura de **Fundamentos de Electrónica Digital**. La arquitectura modular y la integración de buenas prácticas de desarrollo aseguran la escalabilidad y mantenimiento del sistema en el tiempo.
