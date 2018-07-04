using System;

namespace PopularSeriesApp.Models
{
    public class PopularSeries
    {
        public string original_name { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public decimal popularity { get; set; }
        public int vote_count { get; set; }
        public decimal vote_average { get; set; }
        public DateTime? first_air_date { get; set; }
        public string poster_path { get; set; }
        public int[] genre_ids { get; set; }
        public string original_language { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }
        public string[] origin_country { get; set; }

        public int NumberPage { get; set; }
        public string NamePage { get; set; }
        public string TitlePage { get; set; }

        public string Thumb
        {
            get { return $"{AppSettings.ApiImageBaseUrl}w200{poster_path}"; }
        }

        public string ScreenshotMed
        {
            get { return $"{AppSettings.ApiImageBaseUrl}w300{poster_path}"; }
        }

        public string LogoMed
        {
            get { return $"{AppSettings.ApiImageBaseUrl}original{poster_path}"; }
        }

        public string ScreenshotBig
        {
            get { return $"{AppSettings.ApiImageBaseUrl}w500{poster_path}"; }
        }
    }
}
