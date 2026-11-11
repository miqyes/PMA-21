# Lab-10 — REST API студентів з PostgreSQL

API працює з PostgreSQL у Docker. Таблиця `Students` створюється автоматично при запуску API, якщо її ще немає.

## Запуск

1. Запусти Docker Desktop.
2. У терміналі з цієї папки підніми базу даних:

   ```bash
   docker compose up -d
   ```

3. Дочекайся, поки база стане healthy, і запусти API:

   ```bash
   dotnet run
   ```

Сервер виведе адресу, наприклад `http://localhost:5000`. Зупинити базу можна командою `docker compose down`. Дані залишаться у Docker volume `postgres_data`.

## Структура таблиці

`Students`: `Id` (UUID, первинний ключ), `FirstName` (текст), `LastName` (текст), `BirthDate` (дата), `Grades` (масив цілих чисел PostgreSQL).

## Маршрути

- `POST /students` — додати студента. Body запиту — JSON; відповідь — XML.
- `GET /students` — отримати всіх студентів у XML.
- `GET /students/{id}` — отримати студента за ID у XML.
- `PATCH /students/{id}` — змінити передані поля. Body — JSON; відповідь — XML.
- `DELETE /students/{id}` — видалити студента.

Приклад body для POST:

```json
{
  "firstName": "Олена",
  "lastName": "Петренко",
  "birthDate": "2005-04-12T00:00:00",
  "grades": [85, 92, 78]
}
```
