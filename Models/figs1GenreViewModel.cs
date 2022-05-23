using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace shopmohinh.Models
{
    public class figs1GenreViewModel
    {
        public List<fig>? figs { get; set; }
        public SelectList? Genres { get; set; }
        public string? figsGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
