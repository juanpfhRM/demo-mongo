# DemoMongo API

Este proyecto es un ejemplo de **API en .NET 8** que se conecta a **MongoDB**, expone endpoints para probar la conexión y listar productos de ejemplo.

---

## 🛠️ Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community) en local o remoto
- (Opcional) Postman o navegador con Swagger para probar los endpoints

---

## 📥 Clonar el repositorio

```bash
git clone https://github.com/juanpfhRM/demo-mongo
cd demo-mongo
```
---

## ⚡ Configuración de MongoDB
Puedes usar un archivo `.env` en la raíz del proyecto con tus credenciales de MongoDB:
```bash
MONGO_CONNECTION_STRING=mongodb://localhost:<Puerto>
MONGO_DATABASE_NAME=<NombreDB>
```
Si no usas .env, puedes poner tus valores directamente en appsettings.json, aunque no se recomienda.

---

## 📦 Restaurar dependencias
Antes de compilar, asegúrate de restaurar los paquetes NuGet:
```bash
dotnet restore
```

---

## 🏗️ Compilar el proyecto
```bash
dotnet build
```

---

## ▶️ Ejecutar la API
```bash
dotnet run
```
En la consola se mostrará la URL exacta.

---

## 🌐 Probar endpoint
La API tiene el siguiente endpoint principal:
- **GET**: `/api/mongo/test` — Prueba la conexión a MongoDB

---

## 🔹 Usando Swagger
Abre en tu navegador:
```bash
https://localhost:<Puerto>/swagger
```
Ahí puedes ejecutar el endpoint de manera interactiva.

## 🔹 Usando Postman
- Selecciona método (GET o POST)
- URL: https://localhost:<Puerto>/api/mongo/test
- Enviar y ver el resultado JSON

---

## 📄 Notas
- Si deseas cambiar la base de datos o la cadena de conexión, actualiza tu archivo `.env` o las variables de entorno.