# Reviews

## О проекте
Микросервис отзывов разработан на ASP.NET Core Web API и интегрируется с основным приложением <a href="https://github.com/MaratKarsanov/OnlineShop">интернет-магазина</a> для управления отзывами о продуктах и получения рейтинга продуктов.

## Функциональные возможности
<ul>
  <li>API для управления отзывами: CRUD операции для отзывов пользователей о продуктах.</li>
  <li>API для получения рейтинга продукта</li>
</ul>
  
## Использованные технологии
<ul>
  <li>ASP.NET Core Web API</li>
  <li>Entity Framework Core</li>
  <li>MSSQL</li>
  <li>AutoMapper</li>
  <li>Swagger</li>
</ul>

## Установка и запуск
<h3>Предварительные требования</h3>
<ul>
  <li><a href="https://dotnet.microsoft.com/ru-ru/download">.NET Core SDK</a></li>
  <li><a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">MSSQL</a></li>
</ul>

## Шаги установки
<ol>
<li>Клонируйте репозиторий:</li>


<code>git clone https://github.com/PavelKozaev/review_service.git
cd review_service</code>
  
<li>Настройте строки подключения к базе данных MSSQL в файле конфигурации appsettings.json.</li>

<li>Примените миграции базы данных:</li>

<code>dotnet ef database update</code>
<li>Запустите микросервис:</li>

<code>dotnet run</code>
</ol>

## Контрибьютинг
Если вы хотите внести свой вклад в разработку микросервиса, пожалуйста, создайте форк репозитория, создайте новую ветку, внесите свои изменения и отправьте pull request.

## Автор
<a href="https://github.com/MaratKarsanov">Marat Karsanov</a>
