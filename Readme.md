# Bilbayt Homework

Basic Authentication Application, build using .Net Core and ReactJs with Onion Architecture and CQRS pattern.

It's a Homework give by Bilbayt for a recruiting process.

It's my first time taking a test like this, so I was a little nervous. I hope I didn't overdo it.

## Authors

- [@kemsty2](https://www.github.com/kemsty2)

## Functionnalities
- [x] Register with your username, password, fullname
- [x] Receive Welcoming Mail after Registration
- [x] Login after registration
- [x] See your profile after login

## Environment Variables

To run this project, you will need to configure the folliwing configuration,

- ./Bilbayt.Homework.Api/Bilbayt.Homework.Api/appsettings.json

```json
"MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "bilbayt-homework-db"
},
"SendGridSettings": {
    "ApiKey": "Your-Sendgrid Api Key",
    "TemplateId": "Your Sendgrid Welcoming Email Template Id",
    "SenderEmail": "Your Sendgrid Sender Email",
    "SenderName": "Your Sendgrid Sender Email"
}
```

- ./Bilbayt.Homework.Web/ClientApp/public/config.js
```js
/*
* Api Endpoint
* When running using docker-compose, 
* it's http://*localhost:8000, locally it's https://localhost:5003
*/
window.env = { BASE_URL: "https://localhost:5003" };

```

For testing purpose ,i've left my sendgrid api key in the project appsettings

## Deployment

To run this project locally, you can,

- Use Docker with docker-compose

  ```bash
  docker-compose up
  ```

  Access Aplication on http://localhost:8001

- Use dotnet-cli

  ```bash
  dotnet run --project ./Bilbayt.Homework.Api/Bilbayt.Homework.Api/Bilbayt.Homework.Api.csproj
  dotnet run --project ./Bilbayt.Homework.Web/Bilbayt.Homework.Web.csproj
  ```

  Access Aplication on https://localhost:5001

## Running Tests

To run tests, run the following command

```bash
  dotnet test
```

## License

[MIT](https://choosealicense.com/licenses/mit/)
