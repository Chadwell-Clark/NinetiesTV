using System;
using System.Collections.Generic;
using System.Linq;

namespace NinetiesTV
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Show> shows = DataLoader.GetShows();

            Print("All Names", Names(shows));
            Print("Alphabetical Names", NamesAlphabetically(shows));
            Print("Ordered by Popularity", ShowsByPopularity(shows));
            Print("Shows with an '&'", ShowsWithAmpersand(shows));
            Print("Latest year a show aired", MostRecentYear(shows));
            Print("Average Rating", AverageRating(shows));
            Print("Shows only aired in the 90s", OnlyInNineties(shows));
            Print("Top Three Shows", TopThreeByRating(shows));
            Print("Shows starting with 'The'", TheShows(shows));
            Print("All But the Worst", AllButWorst(shows));
            Print("Shows with Few Episodes", FewEpisodes(shows));
            Print("Shows Sorted By Duration", ShowsByDuration(shows));
            Print("Comedies Sorted By Rating", ComediesByRating(shows));
            Print("More Than One Genre, Sorted by Start", WithMultipleGenresByStartYear(shows));
            Print("Most Episodes", MostEpisodes(shows));
            Print("Ended after 2000", EndedFirstAfterTheMillennium(shows));
            Print("Best Drama", BestDrama(shows));
            Print("All But Best Drama", AllButBestDrama(shows));
            Print("Good Crime Shows", GoodCrimeShows(shows));
            Print("Long-running, Top-rated", FirstLongRunningTopRated(shows));
            Print("Most Words in Title", WordieastName(shows));
            Print("All Names", AllNamesWithCommas(shows));
            Print("All Names with And", AllNamesWithCommasPlsAnd(shows));

            //Challenges
            Print("Genres of 80's", EightiesGenres(shows));
            Print("Unique Geners", UniqueGeners(shows));
            Print("Shows Per Year", GetYearCountPairs(shows));
            Print("How Long to Watch Them All", HowLongToWatchAll(shows));
            Print("Best TV Year", GetBestYear(shows));

        }

        /**************************************************************************************************
         The Exercises

         Above each method listed below, you'll find a comment that describes what the method should do.
         Your task is to write the appropriate LINQ code to make each method return the correct result.

        **************************************************************************************************/

        // 1. Return a list of each of show names.
        static List<string> Names(List<Show> shows)
        {
            return shows.Select(s => s.Name).ToList(); // Looks like this one's already done!
        }

        // 2. Return a list of show names ordered alphabetically.
        static List<string> NamesAlphabetically(List<Show> shows)
        {
            return shows.OrderBy(s => s.Name)
                        .Select(s => s.Name)
                        .ToList();
            // return Names(shows).OrderBy(n => n).ToList(); //Andy's solution using code above
        }

        // 3. Return a list of shows ordered by their IMDB Rating with the highest rated show first.
        static List<Show> ShowsByPopularity(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating).ToList();

        }

        // 4. Return a list of shows whose title contains an & character.
        static List<Show> ShowsWithAmpersand(List<Show> shows)
        {
            return shows.Where(s => s.Name.Contains("&")).ToList();
        }

        // 5. Return the most recent year that any of the shows aired.
        static int MostRecentYear(List<Show> shows)
        {
            return shows.OrderBy(s => s.EndYear)
                        .Max(p => p.EndYear);

            //return shows.Max(s => s.EndYear); /// Andy's solution

        }

        // 6. Return the average IMDB rating for all the shows.
        static double AverageRating(List<Show> shows)
        {
            return shows.Average(s => s.ImdbRating);
        }

        // 7. Return the shows that started and ended in the 90s.
        static List<Show> OnlyInNineties(List<Show> shows)
        {
            return shows.Where(s => s.StartYear >= 1990 && s.EndYear < 2000).ToList();
        }

        // 8. Return the top three highest rated shows.
        static List<Show> TopThreeByRating(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating)
                        .Take(3)
                        .ToList();
        }

        // 9. Return the shows whose name starts with the word "The".
        static List<Show> TheShows(List<Show> shows)
        {
            // return shows.Where(s => s.Name.Substring(1, 3).Contains("The")).ToList();
            return shows.Where(s => s.Name.StartsWith("The")).ToList();
        }

        // 10. Return all shows except for the lowest rated show.
        static List<Show> AllButWorst(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating)
            .Take(shows.Count - 1)
            .ToList();
            // return shows.OrderBy(s => s.ImdbRating).Skip(1).ToList();  ///Andy's
        }

        // 11. Return the names of the shows that had fewer than 100 episodes.
        static List<string> FewEpisodes(List<Show> shows)
        {
            return shows.Where(s => s.EpisodeCount < 100)
            .Select(s => s.Name)
            .ToList();
        }

        // 12. Return all shows ordered by the number of years on air.
        //     Assume the number of years between the start and end years is the number of years the show was on.
        static List<Show> ShowsByDuration(List<Show> shows)
        {
            return shows.OrderBy(s => s.EndYear - s.StartYear).ToList();
        }

        // 13. Return the names of the comedy shows sorted by IMDB rating.
        static List<string> ComediesByRating(List<Show> shows)
        {
            return shows.OrderByDescending(s => s.ImdbRating)
                .Where(s => s.Genres.Contains("Comedy"))
                .Select(s => s.Name)
                .ToList();

            //  return shows                 ///  Andy's
            // .Where(s => s.Genres.Contains("Comedy"))
            // .OrderBy(s => s.ImdbRating)
            // .Select(s => s.Name)
            // .ToList();
        }

        // 14. Return the shows with more than one genre ordered by their starting year.
        static List<Show> WithMultipleGenresByStartYear(List<Show> shows)
        {
            return shows.OrderBy(s => s.StartYear)
            .Where(s => s.Genres.Count() > 1)
            .ToList();

            //Andy reversed order of where and orderby
        }

        // 15. Return the show with the most episodes.
        static Show MostEpisodes(List<Show> shows)
        {
            // throw new NotImplementedException();
            return shows.OrderByDescending(s => s.EpisodeCount)
                    .First();

            // int maxEpCount = shows.Max(s => s.EpisodeCount);    /// Andy's
            // return shows.FirstOrDefault(s => s.EpisodeCount == maxEpCount);


        }

        // 16. Order the shows by their ending year then return the first 
        //     show that ended on or after the year 2000.
        static Show EndedFirstAfterTheMillennium(List<Show> shows)
        {
            // throw new NotImplementedException();
            return shows.OrderBy(s => s.EndYear)
                .Where(s => s.EndYear >= 2000)
                .First();
            // return shows    ///Andy's
            //     .OrderBy(s => s.EndYear)
            //     .FirstOrDefault(s => s.EndYear >= 2000);
        }

        // 17. Order the shows by rating (highest first) 
        //     and return the first show with genre of drama.
        static Show BestDrama(List<Show> shows)
        {
            // throw new NotImplementedException();
            return shows.OrderByDescending(s => s.ImdbRating)
                        .Where(s => s.Genres.Contains("Drama"))
                        .First();

            // return shows   ///Andy's
            //     .OrderByDescending(s => s.ImdbRating)
            //     .FirstOrDefault(s => s.Genres.Contains("Drama"));

        }

        // 18. Return all dramas except for the highest rated.
        static List<Show> AllButBestDrama(List<Show> shows)
        {
            // throw new NotImplementedException();
            return shows.OrderBy(s => s.ImdbRating)
            .Where(s => s.Genres.Contains("Drama"))
            .Take(shows.Count - 1)
            .ToList();
            // return shows   Andy's
            //     .OrderByDescending(s => s.ImdbRating)
            //     .Where(s => s.Genres.Contains("Drama"))
            //     .Skip(1)
            //     .ToList();
        }

        // 19. Return the number of crime shows with an IMDB rating greater than 7.0.
        static int GoodCrimeShows(List<Show> shows)
        {
            // throw new NotImplementedException();
            // return shows.ToList().Count(shows.Where(s => s.ImdbRating > 7.0 && ));
            return shows.Where(s => s.Genres.Contains("Crime") && s.ImdbRating > 7.0)
                        .ToList()
                        .Count();

            /// Andy's solution omitted tolist
        }

        // 20. Return the first show that ran for more than 10 years 
        //     with an IMDB rating of less than 8.0 ordered alphabetically.
        static Show FirstLongRunningTopRated(List<Show> shows)
        {
            return shows.OrderBy(s => s.Name)
                        .Where(s => s.ImdbRating < 8.0 && s.EndYear - s.StartYear > 10)
                        .First();
            //  return shows  ///Andy's
            //     .Where(s => s.EndYear - s.StartYear > 10)
            //     .Where(s => s.ImdbRating > 8)
            //     .OrderBy(s => s.Name)
            //     .FirstOrDefault();
        }

        // 21. Return the show with the most words in the name.
        static Show WordieastName(List<Show> shows)
        {

            // List<string> titles = new List<string>();
            // titles = shows.Select(s => s.Name).ToList();
            // int swapCount = 0;
            // string title = "";
            // for (int i = 0; i < titles.Count(); i++)
            // {
            //     int titleCount = titles[i].Split(" ").Count();
            //     if (titleCount > swapCount)
            //     {
            //         title = titles[i];
            //         swapCount = titleCount;
            //     }
            // }
            // return shows.OrderBy(o => o.Name).FirstOrDefault(s => s.Name == title);
            return shows.OrderByDescending(s => s.Name.Split(" ").Count()).First();
            /// Andy used FirstOrDefault rather than First

        }

        // 22. Return the names of all shows as a single string seperated by a comma and a space.
        static string AllNamesWithCommas(List<Show> shows)
        {
            // throw new NotImplementedException();
            // string allNames = "";
            // foreach (var show in shows)
            // {
            //     allNames += show.Name;
            //     allNames += ", ";
            // }

            // return allNames;

            return string.Join(", ", shows.Select(s => s.Name));

        }

        // 23. Do the same as above, but put the word "and" between the second-to-last and last show name.
        static string AllNamesWithCommasPlsAnd(List<Show> shows)
        {
            // throw new NotImplementedException();

            // string first = string.Join(", ", shows.Select(s => s.Name).Take(shows.Count - 1));
            // string last = shows[shows.Count - 1].Name;
            // return $"{first} and {last}";

            return $"{string.Join(", ", shows.Select(s => s.Name).Take(shows.Count - 1))} and {shows[shows.Count - 1].Name}";
            //  List<string> names = shows.Select(s => s.Name).ToList();     // Andy's
            // string str = string.Join(", ", names.Take(names.Count - 1));
            // return str + ", and " + names.Last();
        }


        /**************************************************************************************************
         CHALLENGES

         These challenges are very difficult and may require you to research LINQ methods that we haven't
         talked about. Such as:

            GroupBy()
            SelectMany()
            Count()

        **************************************************************************************************/

        // 1. Return the genres of the shows that started in the 80s.
        static List<string> EightiesGenres(List<Show> shows)
        {
            return shows
                .Where(s => s.StartYear >= 1980 && s.StartYear < 1990)
                .Select(s => string.Join(", ", s.Genres.ToArray()))
                .ToList();

            // return shows    /// Andy's
            //     .Where(s => s.StartYear >= 1990)
            //     .SelectMany(s => s.Genres)
            //     .Distinct()
            //     .OrderBy(genre => genre)
            //     .ToList();

            //     return string.Join(", ", shows
            //     .Where(s => s.StartYear >= 1980 && s.StartYear < 1990).Select(s => s.Genres).ToString());
        }


        // 2. Print a unique list of geners.

        static List<string> UniqueGeners(List<Show> shows)

        {
            List<string> genres = new List<string>();
            var CollectedGenres = shows.Select(s => s.Genres);
            CollectedGenres.ToList().ForEach(g => genres.AddRange(g));
            return genres.Distinct().ToList();

            // return shows   ///   Andy's
            //     .SelectMany(s => s.Genres)
            //     .Distinct()
            //     .OrderBy(genre => genre)
            //     .ToList();


        }


        // 3. Print the years 1987 - 2018 along with the number of shows that started in each year (note many years will have zero shows)
        // static List<int> NumberOfShowsStartingByYear(List<Show> shows)
        // {
        //     List<int> showStartYearCount = new List<int>();
        //     for(int i =1987; i < 2019; i++)
        //     {
        //         showStartYearCount.Add(i);
        //     }
        //     List<string> dataset =new List<string>();
        //     var StartingYear = shows.Select(s => s.StartYear);
        //     StartingYear.ToList().ForEach(s => showStartYearCount)

        // }

        /// Andy's solution below
        static List<YearCountPair> GetYearCountPairs(List<Show> shows)
        {
            return Enumerable.Range(1987, 32)
                .GroupJoin(shows,
                    year => year,
                    show => show.StartYear,
                    (year, shows) => new YearCountPair(year, shows.Count()))
                .ToList();
        }

        // 4. Assume each episode of a comedy is 22 minutes long and each episode of a show that isn't a comedy is 42 minutes. How long would it take to watch every episode of each show?
        /// Andy's solution
        static string HowLongToWatchAll(List<Show> shows)
        {
            int totalMinutes = shows
                .Select(s => s.EpisodeCount * (s.Genres.Contains("Comedy") ? 22 : 42))
                .Sum();

            int days = totalMinutes / (24 * 60);
            int leftoverMinutes = totalMinutes % (24 * 60);
            int hours = leftoverMinutes / 60;
            int minutes = leftoverMinutes % 60;

            string daysText = SimplePluralizer("day", days);
            string hoursText = SimplePluralizer("hour", hours);
            string minutesText = SimplePluralizer("minute", minutes);

            return $"{daysText}, {hoursText} and {minutesText}";
        }

        static string SimplePluralizer(string text, int num)
        {
            return num + $" {text}" + (num == 1 ? "" : "s");
        }
        // 5. Assume each show ran each year between its start and end years (which isn't true), which year had the highest average IMDB rating.
        //  Andy's Solution below
        static int GetBestYear(List<Show> shows)
        {
            IEnumerable<YearRatingPair> yearRatingsPerShow =
                shows.SelectMany(s =>
                {
                    IEnumerable<int> years = Enumerable.Range(s.StartYear, s.EndYear - s.StartYear);

                    return years.Select(year => new YearRatingPair(year, s.ImdbRating));
                });

            IEnumerable<YearRatingPair> yearRatings =
                yearRatingsPerShow
                    .GroupBy(yrp => yrp.Year)
                    .Select(g => new YearRatingPair(g.Key, g.Average(yrp => yrp.Rating)));

            return yearRatings.OrderByDescending(yr => yr.Rating).FirstOrDefault().Year;
        }


        /**************************************************************************************************
         There is no code to write or change below this line, but you might want to read it.
        **************************************************************************************************/

        static void Print(string title, List<Show> shows)
        {
            PrintHeaderText(title);
            foreach (Show show in shows)
            {
                Console.WriteLine(show);
            }

            Console.WriteLine();
        }

        static void Print(string title, List<string> strings)
        {
            PrintHeaderText(title);
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }

        static void Print(string title, Show show)
        {
            PrintHeaderText(title);
            Console.WriteLine(show);
            Console.WriteLine();
        }

        static void Print(string title, string str)
        {
            PrintHeaderText(title);
            Console.WriteLine(str);
            Console.WriteLine();
        }

        static void Print(string title, int number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void Print(string title, double number)
        {
            PrintHeaderText(title);
            Console.WriteLine(number);
            Console.WriteLine();
        }

        static void PrintHeaderText(string title)
        {
            Console.WriteLine("============================================");
            Console.WriteLine(title);
            Console.WriteLine("--------------------------------------------");
        }
    }
}