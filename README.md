Para que tu `README.md` sea realmente completo y profesional, he añadido el detalle de los patrones de diseño que mencionaste (**Repository**, **Unit of Work**) y una lista exhaustiva de los requerimientos técnicos cumplidos según la letra de la entrega.

Aquí tienes la versión final:

---

# Sistema de Gestión de Pedidos y Depósito

[cite_start]Este sistema integral fue desarrollado para una empresa de papelería con el fin de optimizar la gestión de pedidos de clientes corporativos y el control de inventario en depósito[cite: 25, 26]. [cite_start]La aplicación aplica principios de **Clean Architecture** y **Domain Driven Design (DDD)** para garantizar la escalabilidad y mantenibilidad del código[cite: 174, 370].

## 🚀 Funcionalidades Implementadas

### 1. Gestión Comercial (Módulo Administrador)
* [cite_start]**Gestión de Usuarios:** CRUD completo de usuarios con contraseñas encriptadas y políticas de seguridad (mínimo 6 caracteres, mayúsculas, minúsculas, dígitos y puntuación)[cite: 40, 41, 74].
* [cite_start]**Catálogo de Artículos:** Administración de insumos con validaciones de códigos de 13 dígitos, descripciones mínimas y control de stock[cite: 48, 93, 94].
* [cite_start]**Gestión de Clientes:** Búsqueda avanzada de clientes por nombre o por volumen de facturación acumulada[cite: 85, 87, 88].
* [cite_start]**Sistema de Pedidos:** * **Pedidos Comunes:** Cálculo de recargos del 5% si la distancia supera los 100km[cite: 63].
    * [cite_start]**Pedidos Express:** Recargos del 10% general y 15% por entrega en el mismo día (plazo máximo 5 días)[cite: 53, 62].
    * [cite_start]**Anulación:** Proceso de selección y anulación de pedidos no entregados con listado histórico[cite: 117, 120].

### 2. Gestión de Depósito (Módulo Encargado)
* [cite_start]**Movimientos de Stock:** Registro de ingresos y egresos de mercadería realizado exclusivamente por usuarios con rol "Encargado"[cite: 235, 254].
* [cite_start]**Tipos de Movimiento:** CRUD de categorías (Compra, Venta, Devolución) con restricción de eliminación si tienen movimientos asociados[cite: 239, 257].
* [cite_start]**Consultas Paginadas:** * Historial de movimientos por artículo y tipo, ordenados por fecha y cantidad[cite: 294, 295, 306].
    * [cite_start]Reporte de artículos con actividad en rangos de fechas específicos[cite: 296, 306].
    * [cite_start]Resumen anual de cantidades movidas agrupadas por tipo[cite: 297].

---

## 🏗️ Arquitectura y Patrones

[cite_start]El proyecto se basa en una separación estricta de responsabilidades utilizando **Clean Architecture**[cite: 174, 370]:

* [cite_start]**Domain & BusinessLogic:** Contiene las entidades, **Value Objects** para validaciones complejas y la lógica central[cite: 163, 233, 359].
* [cite_start]**Data Access:** Implementación de persistencia mediante **Entity Framework Core 8**[cite: 140, 329]. Se utilizan los patrones **Repository** y **Unit of Work** para desacoplar la lógica de negocio de la base de datos.
* [cite_start]**Web API:** Expone los servicios mediante endpoints REST protegidos por **JWT** y devuelve **Status Codes** adecuados[cite: 167, 259, 363].
* **Client Web (HttpClient):** Aplicación MVC independiente que consume la API. [cite_start]Utiliza **ViewModels** y **DTOs** para la transferencia de datos[cite: 170, 230, 366].

---

## 🔑 Credenciales de Prueba

* **Usuario:** `usuario1@gmail.com`
* **Contraseña:** `User1.`

---

## 🛠️ Instrucciones de Ejecución

Para que el ecosistema funcione correctamente, siga este orden:

1.  [cite_start]**Levantar el Servidor (API):** Abra la solución de lógica de negocio, configure el `appsettings.json` y ejecute el proyecto para habilitar los servicios y Swagger[cite: 142, 331].
2.  [cite_start]**Levantar el Cliente (Web):** Abra la solución del Cliente MVC, asegúrese de que apunte a la URL de la API y ejecute el proyecto para acceder a la interfaz de Encargado[cite: 230, 308].

---

## ⚙️ Stack Tecnológico
* [cite_start]**.NET 8.0** / **C#**[cite: 172, 368].
* [cite_start]**EF Core 8** / **LINQ** (Sintaxis de método)[cite: 169, 173, 365].
* [cite_start]**SQL Server** / **JSON Web Tokens (JWT)**[cite: 261, 291].
* [cite_start]**AutoMapper** para mapeo de DTOs[cite: 366].