# LinkConverter
  LinkConverter is a rest api using .Net Core and PostgreSQL with Docker support.
  Both the rest api and the Postgres DB runs in container.
  Added Swagger support to interact with API's resources.'
  
## Prerequisites
1. [Docker](https://www.docker.com/)

## Steps
1. `git clone https://github.com/DevelopmentHiring/TrendyolCase-MuhammetYasinArli.git`

2. `cd TrendyolCase-MuhammetYasinArli\src\LinkConverter`

3. `docker-compose build`

4. `docker-compose up`

5.  Navigate to http://localhost:5000/swagger/index.html

## API Details


```sh 

POST /api/v1/weburl-to-deeplink          # Converts web url to deep link
POST /api/v1/deeplink-to-weburl          # Converts deep link to web url
GET  /api/v1/link-conversions            # Returns all stored link conversions

```

- Postman collection : postman\LinkConverter.postman_collection.json

- View error logs at Seq Dashboard : http://localhost:5341 
