using Microsoft.Extensions.Caching.Memory;
using MovieRecommender.Core.Dto;
using MovieRecommender.Core.Interfaces;
using NReco.CF.Taste.Impl.Common;
using NReco.CF.Taste.Impl.Model;
using NReco.CF.Taste.Impl.Neighborhood;
using NReco.CF.Taste.Impl.Recommender;
using NReco.CF.Taste.Impl.Similarity;
using NReco.CF.Taste.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieRecommender.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;

        public MovieService(IUnitOfWork unitOfWork, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
        }

        public List<MovieRecommendationDto> GetRecommendedMovies(int[] preferredMovieIds)
        {
            var dataModel = GetDataModel();

            // recommendation is performed for the user that is missed in the preferences data
            var plusAnonymModel = new PlusAnonymousUserDataModel(dataModel);
            var prefArr = new GenericUserPreferenceArray(preferredMovieIds.Length);
            prefArr.SetUserID(0, PlusAnonymousUserDataModel.TEMP_USER_ID);
            for (int i = 0; i < preferredMovieIds.Length; i++)
            {
                prefArr.SetItemID(i, preferredMovieIds[i]);

                // in this example we have no ratings of movies preferred by the user
                prefArr.SetValue(i, 5); // lets assume max rating
            }
            plusAnonymModel.SetTempPrefs(prefArr);

            var similarity = new LogLikelihoodSimilarity(plusAnonymModel);
            var neighborhood = new NearestNUserNeighborhood(15, similarity, plusAnonymModel);
            var recommender = new GenericUserBasedRecommender(plusAnonymModel, neighborhood, similarity);
            var recommendedItems = recommender.Recommend(PlusAnonymousUserDataModel.TEMP_USER_ID, 5, null);

            var movieIds = recommendedItems.Select(ri => (int)ri.GetItemID()).ToArray();
            var movieIdToTitleDictionary = _unitOfWork.MovieRepository.GetMovieIdToTileDictionary(movieIds);

            var recommendedMovies = new List<MovieRecommendationDto>();
            foreach (var item in recommendedItems)
            {
                var movieId = (int)item.GetItemID();
                var movieTitle = movieIdToTitleDictionary[movieId];

                recommendedMovies.Add(
                    new MovieRecommendationDto
                    {
                        MovieId = movieId,
                        MovieTitle = movieTitle,
                        Rating = item.GetValue()
                    });
            }

            return recommendedMovies;
        }

        private IDataModel GetDataModel()
        {
            var cacheKey = "RecommenderDataModel";
            IDataModel dataModel = _memoryCache.Get<IDataModel>(cacheKey);
            if (dataModel != null)
            {
                return dataModel;
            }

            var movieRatings = _unitOfWork.MovieRatingRepository.GetAll();

            FastByIDMap<IList<IPreference>> data = new FastByIDMap<IList<IPreference>>();
            foreach (var movieRating in movieRatings)
            {
                var userPreferences = data.Get(movieRating.UserId);
                if (userPreferences == null)
                {
                    userPreferences = new List<IPreference>(3);
                    data.Put(movieRating.UserId, userPreferences);
                }

                userPreferences.Add(new BooleanPreference(movieRating.UserId, movieRating.MovieId));
            }

            var newData = new FastByIDMap<IPreferenceArray>(data.Count());
            foreach (var entry in data.EntrySet())
            {
                var prefList = (List<IPreference>)entry.Value;
                newData.Put(entry.Key, (IPreferenceArray)new BooleanUserPreferenceArray(prefList));
            }

            dataModel = new GenericDataModel(newData);

            _memoryCache.Set(cacheKey, dataModel);

            return new GenericDataModel(newData);
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
