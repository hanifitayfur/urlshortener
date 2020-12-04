# urlshortener
urlshortener with mongoDB

project use dotnet core and mongodb.

docker pull mongo

docker image ls --all

docker run --name mongoDB -p 27017:27017 mongo:latest
--

docker pull mongoclient/mongoclient

docker run --name mongoDBClient  -d -p 3000:3000 mongoclient/mongoclient
