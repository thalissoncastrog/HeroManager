# HeroManager

<h4 align="center">A project .NET + Angular to provide informations about heroes and his powers.</h4>

<p align="center">
  <a href="#how-to-use">How To Use</a> •
  <a href="#license">License</a>
</p>

## How To Use

To clone and run this application, you'll need [Git](https://git-scm.com) and [.NET](https://learn.microsoft.com/en-us/dotnet/core/install/) installed on your computer. From your command line:

```bash
# Clone this repository
$ git clone https://github.com/thalissoncastrog/HeroManager.git

# Go into the repository
$ cd HeroManager

# Go into the solution folder
$ cd HeroManagerAPI

# Install dependencies
$ dotnet restore

# Run the app
$ dotnet run
```

> **Note**
> After run each command above, go to a web browser and access this url: http://localhost:[port]/swagger.

<h4>- For a better experience, use Docker:</h4>

> **Note**:
> Install docker according your operating system [Docker Instalation](https://docs.docker.com/engine/install/).

```bash
# Clone this repository
$ git clone https://github.com/thalissoncastrog/HeroManager.git

# Go into the repository
$ cd HeroManager

# For Linux user: Do the next commands as root user
$ sudo su

# For Windows user: Just open docker desktop and follow the next instruction

#Run the services: .NET API
$ docker-compose up -d --build
```

> **Note**
> After run each command above, go to a web browser and access this url: http://localhost:8080/swagger.

```json
// POST REQUEST BODY TEMPLATE

{
  "name": "thalisson",
  "heroName": "invencible",
  "birthDate": "2025-02-28T13:30:08.545Z",
  "height": 1.73,
  "weight": 71,
  "heroSuperPowers": [
    {
      "superPowerId": 2
    }
  ]
}
```

## Future Improvements

- Apply DTO to improve the json body and the response from API
- Apply a relational database.
- Import frontend to a docker container.
- Implement a API Gateway.
- Docker secrets or secrets manager in cloud, to manage credentials needed in each service.
- Integrate centralized logging and monitoring like prometheus.

## License

MIT

---

> Instagram [@thalissoncastrog](https://www.instagram.com/thalissoncastrog/) &nbsp;&middot;&nbsp;
> GitHub [@thalissoncastrog](https://github.com/thalissoncastrog) &nbsp;&middot;&nbsp;
> Email [thalisson.adao@gmail.com](mailto:thalisson.adao@gmail.com)
