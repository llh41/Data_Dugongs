using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GetMoviesAndBooks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LoadJson();
            Console.WriteLine("it works");
        }

        public async static void LoadJson()
        {
            using (StreamReader r =
                new StreamReader(
                    "/Users/stevenbarash/Developer/PDC/Team project/NEW get data/GetMoviesAndBooks/GetMoviesAndBooks/movies.json")
            )
            {
                var settings = new JsonSerializerSettings
                {
                    DateFormatString = "yyyy-MM-ddTH:mm:ss.fffK",
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };
                string json = r.ReadToEnd();
                List<Movie> items = JsonConvert.DeserializeObject<List<Movie>>(json, settings);
                var goodreadsRating = 0.0;

                const string apiKey = "WRHNqrpPZm5NH4Igzky0Mw";
                const string apiSecret = "qz6Dh0f9DBTzMNlNiFywnVRnvGCwHoBfHsl38Udsvk";

//                var goodreadsRatingdsClientent = GoodreadsClient.Create(apiKey, apiSecret);

//                var book = await goodreadsClient.Books.GetByTitle("Food");

//                string testTitle = "To All the Boys I've Loved Before";
//                var client =
//                    new RestClient("https://www.goodreads.com/book/title.xml?key=" + apiKey + "&title=" +
//                                   testTitle.Replace(" ", "+"));
//                var request = new RestRequest(Method.GET);
//                IRestResponse response = client.Execute(request);
//                XmlDocument doc = new XmlDocument();
//                doc.LoadXml(response.Content);
//                string convertedJson = JsonConvert.SerializeXmlNode(doc);
//                Console.WriteLine(convertedJson);


//                var serializer = new XmlSerializer(typeof(Book));
//                using (TextReader reader = new StringReader(response.Content))
//                {
//                    var result = (Book) serializer.Deserialize(reader);
////                    Console.WriteLine(result.Average_rating);
//                }


                items.ForEach(i =>
                    insertIntoDb(i.Overview));
            }
        }


        public static void insertIntoDb(string vote_average)
        {
            Console.WriteLine(vote_average);
//            using (var connection = new NpgsqlConnection(
//                "User ID=stevenbarash;Password=password;Host=localhost;Database=postgres;Port=5432;")
//            )
//            {
//                connection.Open();
//                using (var command = connection.CreateCommand())
//                {
//                    command.CommandText =
//                        "insert into bookmoviedb (title, movie_rating, movie_year,poster_path,genre) values (@title, @vote_average, @year,@poster_path,@genre)";
//                    command.Parameters.AddWithValue("@title", title);
//                    command.Parameters.AddWithValue("@movie_rating", vote_average);
//                    command.Parameters.AddWithValue("@year", year);
//                    command.Parameters.AddWithValue("@poster_path", poster_path);
//                    command.Parameters.AddWithValue("@genre", genre);
//
//                    int numberOfUpdatedRows = command.ExecuteNonQuery();
//                    var newId = (int) command.ExecuteScalar();
//                }
//            }
        }


////            var jsonSerializer = new JsonSerializer();
////            TMDbClient client = new TMDbClient("154a1219c7bb3c98c46f830499af1e9b");
////            IEnumerable<int> list = new List<int> {818};
////
////            var numOfPages = client.GetKeywordMoviesAsync(818).Result.TotalPages;
////
////            for (var i = 1; i <= numOfPages; i++)
////            {
////                if (i % 40 == 0)
////                {
////                    Thread.Sleep(new TimeSpan(0, 0, 10));
////                }
////
////                var tmdbclient = new RestClient("https://api.themoviedb.org/3/discover/movie?with_keywords=818&&page=" +
////                                                i +
////                                                "&include_video=false&include_adult=false&sort_by=popularity.desc&language=en-US&include_video=false&vote_count.gte=1000&with_original_language=en&api_key=154a1219c7bb3c98c46f830499af1e9b");
////                var request = new RestRequest(Method.GET);
////                request.AddParameter("undefined", "{}", ParameterType.RequestBody);
////                IRestResponse response = tmdbclient.Execute(request);
////
////                var content = response.Content;
////
////                string t = "";
////
////                t += (content + ",");
////
////
////                using (StreamWriter file =
////                    new StreamWriter(
////                        @"/Users/stevenbarash/Developer/PDC/Team project/NEW get data/GetMoviesAndBooks/GetMoviesAndBooks/movies.json",
////                        true))
////                {
////                    file.WriteLine(t);
////                }
////            }
//        }

        public class Movie
        {
            public long Vote_Count { get; set; }

            public long Id { get; set; }

            public bool Video { get; set; }

            public float Vote_Average { get; set; }

            public string Title { get; set; }

            public double Popularity { get; set; }

            public string PosterPath { get; set; }

            public string Original_Language { get; set; }

            public string Original_Title { get; set; }

            public List<long> Genre_Ids { get; set; }

            public string Backdrop_Path { get; set; }

            public bool Adult { get; set; }

            public string Overview { get; set; }

            public DateTimeOffset Release_Date { get; set; }

            public double Book_Rating { get; set; }
        }

//        public partial class Welcome
//        {
//            [JsonProperty("results")] public List<Result> Results { get; set; }
//        }

//        public partial class Result
//        {
//            [JsonProperty("vote_count")] public long VoteCount { get; set; }
//
//            [JsonProperty("id")] public long Id { get; set; }
//
//            [JsonProperty("video")] public bool Video { get; set; }
//
//            [JsonProperty("vote_average")] public double VoteAverage { get; set; }
//
//            [JsonProperty("title")] public string Title { get; set; }
//
//            [JsonProperty("popularity")] public double Popularity { get; set; }
//
//            [JsonProperty("poster_path")] public string PosterPath { get; set; }
//
//            [JsonProperty("original_language")] public OriginalLanguage OriginalLanguage { get; set; }
//
//            [JsonProperty("original_title")] public string OriginalTitle { get; set; }
//
//            [JsonProperty("genre_ids")] public List<long> GenreIds { get; set; }
//
//            [JsonProperty("backdrop_path")] public string BackdropPath { get; set; }
//
//            [JsonProperty("adult")] public bool Adult { get; set; }
//
//            [JsonProperty("overview")] public string Overview { get; set; }
//
//            [JsonProperty("release_date")] public DateTimeOffset ReleaseDate { get; set; }
//        }
//
//        public enum OriginalLanguage
//        {
//            En
//        };
//
//        public partial class Welcome
//        {
//            public static Welcome FromJson(string json) =>
//                JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
//        }
//
//        public static class Serialize
//        {
//            public static string ToJson(this Welcome self) =>
//                JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
//        }
//
//        internal static class Converter
//        {
//            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
//            {
//                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
//                DateParseHandling = DateParseHandling.None,
//                Converters =
//                {
//                    OriginalLanguageConverter.Singleton,
//                    new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
//                },
//            };
//        }
//
//        internal class OriginalLanguageConverter : JsonConverter
//        {
//            public override bool CanConvert(Type t) => t == typeof(OriginalLanguage) || t == typeof(OriginalLanguage?);
//
//            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//            {
//                if (reader.TokenType == JsonToken.Null) return null;
//                var value = serializer.Deserialize<string>(reader);
//                if (value == "en")
//                {
//                    return OriginalLanguage.En;
//                }
//
//                throw new Exception("Cannot unmarshal type OriginalLanguage");
//            }
//
//            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//            {
//                if (untypedValue == null)
//                {
//                    serializer.Serialize(writer, null);
//                    return;
//                }
//
//                var value = (OriginalLanguage) untypedValue;
//                if (value == OriginalLanguage.En)
//                {
//                    serializer.Serialize(writer, "en");
//                    return;
//                }
//
//                throw new Exception("Cannot marshal type OriginalLanguage");
//            }
//
//            public static readonly OriginalLanguageConverter Singleton = new OriginalLanguageConverter();
//        }
    }
}