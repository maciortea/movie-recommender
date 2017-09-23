# movie-recommender
A movie recommendation system built in ASP.NET Core

This project demonstrates with an interesting example on machine learning how to use clean architecture and unit of work pattern in ASP.NET Core.

References:
  - recommendation system is based on <a href="https://github.com/nreco/recommender">NReco Recommender</a> library
  - dataset csv files were downloaded from <a href="https://grouplens.org/datasets/movielens/">MovieLens</a> and imported to a SQL local database file
Dataset 

Before running:
  - modify connection string from appsettings.json file to point correctly to the local database file from "\MovieRecommender.Infrastructure\Database\MovieRecommenderDb.mdf" relative path.
