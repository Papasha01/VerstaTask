# Запуск проекта

## Требования

Для работы проекта необходимо установить:

- .NET 9
- Node.js
- SQLite

## Установка и запуск

### 1. Клонирование репозитория

Склонируйте репозиторий с исходным кодом:

```sh
git clone https://github.com/Papasha01/VerstaTask
cd VerstaTask
```

### 2. Настройка backend

Перейдите в папку backend и установите зависимости:

```sh
cd .\backend\VerstaTask\
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet tool install --global dotnet-ef
dotnet ef database update -s .\API\ -p .\DataAccess\
dotnet run --project .\src\API\API.csproj
dotnet build .\VerstaTask.sln
http://localhost:5056/swagger/index.html
https://localhost:7127
npm install
npm run dev
```

Создайте и примените миграции базы данных:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Запустите сервер:

```sh
dotnet run
```

### 3. Настройка frontend

Перейдите в папку frontend и установите зависимости:

```sh
cd ../frontend
npm install
```

Запустите React-приложение:

```sh
npm start
```

После запуска backend и frontend приложение будет доступно по адресу:

```
http://localhost:3000
```

