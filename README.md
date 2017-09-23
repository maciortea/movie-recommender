# movie-recommender

This project demonstrates with an interesting example on machine learning how to use clean architecture and Unit of Work pattern in ASP.NET Core.

References:
  - Recommendation system is using <a href="https://github.com/nreco/recommender">NReco Recommender</a> library
  - Dataset csv files were downloaded from <a href="https://grouplens.org/datasets/movielens/">MovieLens</a> and imported to a SQL local database file

Before running:
  - Modify connection string from appsettings.json file to point correctly to the local database file from "\MovieRecommender.Infrastructure\Database\MovieRecommenderDb.mdf" relative path
