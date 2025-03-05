# Проект: Тестовое задание Versta

## Описание
Этот проект представляет собой веб-приложение, для приемки заказа на доставку.


## Технологии
- **Backend:** ASP.NET 9
- **Frontend:** React.js
- **ORM:** Entity Framework
- **База данных:** SQLite

## Требования
Перед началом работы убедитесь, что у вас установлены:
- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Node.js (LTS)](https://nodejs.org/)
- [SQLite](https://www.sqlite.org/download.html)

## Установка и запуск

### 1. Клонирование репозитория
```sh
git clone https://github.com/Papasha01/VerstaTask
cd VerstaTask
```

### 2. Запуск backend-а
```sh
cd backend\VerstaTask

# Установка зависимостей
dotnet restore

# Применение миграций
dotnet ef migrations add Init -s .\API\ -p .\DataAccess\
dotnet ef database update -s .\API\ -p .\DataAccess\

# Запуск
dotnet run --project .\src\API\API.csproj

```

Backend запустится на `http://localhost:5056/swagger`.

### 3. Запуск frontend-а
```sh
cd frontend\versta-react-app

# Установка зависимостей
npm i

# Запуск
npm run dev
```

Ссылка на Frontend часть будет выведена в консоль.
### 4. Пример работы 
![chrome_GzhnhwPmFs](https://github.com/user-attachments/assets/b50a8395-a213-4088-8800-ac1b1b09e6e9)

![chrome_jIPYmExWMl](https://github.com/user-attachments/assets/5e1961e7-5162-4a73-9b1b-1a7b40c54639)

### Если ты лид, и читаешь это, и возникли сложности воспроизведения инструкции запуска, можешь писать [@Levykinx](https://t.me/Levykinx)
