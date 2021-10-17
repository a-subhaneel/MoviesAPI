Api endpoints to fetch list of movies, create and edit movies where each movie can have multiple actors and one producer.

(Asp.net core api project)

In this application I have used docker timescale database.

Fot installing the database follow the below commands:
1. docker pull timescale/timescaledb:latest-pg12
2. docker run -d --name timescaledb -p 5432:5432 -e POSTGRES_PASSWORD=password timescale/timescaledb:latest-pg12

The above commands will create a docker database container in you machine given that you already have docker desktop installed in your system.
The docker timescaledb container is hosted at ip address 'localhost' and port is '5432' with username as 'postgres' and password as 'password'.
To view the database, you can use 'azure data studio' or 'pg admin' (potgresql management studios) and use the above connection details.

If you wish to use your own database connection, then update the connection string at ../MoviesAPI\DataContext\DataBaseContext.cs and ../MoviesAPI\appsettings.Development.json.

Migration files are already added, so just run the application with 'dotnet run' or by using 'iis express'. It will automatically update the database in your system.
Also seed data command has been given to auto populate dummy data in the database for movies, actors and producers.

1. FETCH ALL MOVIES: HttpGet method, On app load it will auto call the list of all movies at url 'http://localhost:5812/api/Movies/GetAllMovies'
the O/P is in Json format as '[
    {
        "id": 1,
        "movieName": "The Shawshank Redemption",
        "releaseDate": "1994-09-22",
        "movieBio": "In 1947 Portland, Maine, banker Andy Dufresne is convicted of murdering his wife and her lover and is sentenced to two consecutive life sentences at the Shawshank State Prison.",
        "actorList": [
            {
                "id": 3,
                "actorName": "Morgan Freeman"
            },
            {
                "id": 4,
                "actorName": "Clancy Brown"
            }
        ],
        "producerList": [
            {
                "id": 3,
                "producerName": "Niki Marvin"
            }
        ]
    },
]'

2. CREATE MOVIES. Httppost method expecting json body.
    the expected I/P is as follows:
    ![image](https://user-images.githubusercontent.com/59724085/137632079-2bc527a9-c8ae-4bf9-a213-dbc0a679592d.png)
    given actors and producer are selected from a list and id and name is passed together from ui
 
3. EDIT MOVIES. Httppost method expecting json body.
    the expected I/P is as follows:
    ![image](https://user-images.githubusercontent.com/59724085/137632168-45c961bc-5b60-4a95-b300-f91b372b47de.png)
    id has to be sent from ui to make the update in existing record, also given actors and producer are selected from a list and id and name is passed together from ui.

