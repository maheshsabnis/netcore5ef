using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace EfCore_Net5.Models
{
    public abstract class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }
    }

    public class Movie : Production
    {
        public int DurationInMinutes { get; set; }
        public double WorldwideBoxOfficeGross { get; set; }
    }

    public class Series : Production
    {
        public int NumberOfEpisodes { get; set; }
    }
}
