# Sistema de Gestión de Pedidos y Movimientos de Stock

Proyecto desarrollado para la materia **Programación 3**  
Carrera: Analista Programador / Analista en Tecnologías de la Información  
Facultad de Ingeniería – ORT Uruguay  

---

## Descripción

Sistema integral para la gestión de pedidos y control de movimientos de stock de una empresa de venta de insumos de papelería.

El sistema fue desarrollado en **.NET 8** aplicando:

- Arquitectura Limpia (Clean Architecture)
- Domain Driven Design (DDD)
- Entity Framework Core 8
- LINQ
- JWT para autenticación
- Web API + MVC (HttpClient)

El sistema está dividido en dos soluciones independientes:

1.  Web API (Dominio + Aplicación + Infraestructura)
2.  Cliente MVC que consume la API mediante HttpClient

---

## Arquitectura

El proyecto sigue los principios de Clean Architecture:

- **Dominio** → Entidades, Value Objects, reglas de negocio
- **Aplicación** → Casos de uso, DTOs, servicios
- **Infraestructura** → EF Core, acceso a datos
- **Web API** → Endpoints REST
- **MVC Cliente** → Interfaz de usuario consumiendo la API vía HttpClient

---

## Funcionalidades Implementadas



- Login / Logout
- Gestión de Usuarios
- Gestión de Clientes
- Gestión de Artículos
- Gestión de Pedidos (Común y Express)
- Anulación de pedidos
- Listados vía Web API
- CRUD de Tipos de Movimiento (Web API)
- Autenticación con JWT
- Registro de Movimientos de Stock
- Consultas avanzadas:
  - Movimientos por artículo y tipo
  - Artículos con movimientos en rango de fechas
  - Resumen anual agrupado por tipo
- Paginado en consultas
- Control de autorización por rol

---

## Tecnologías Utilizadas

- .NET 8
- C#
- Entity Framework Core 8
- SQL Server
- LINQ
- JWT
- Swagger
- Postman
- MVC
- HttpClient

