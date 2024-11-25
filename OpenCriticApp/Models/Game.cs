namespace OpenCriticApp.Models {
    public class Images {
        public BoxImage Box { get; set; } // game boxart
        public BannerImage Banner { get; set; } // game banner
    }

    public class BoxImage {
        public string Og { get; set; } // original size of image
        public string Sm { get; set; } // compressed size for image
    }

    public class BannerImage {
        public string Og { get; set; } // original size of banner
        public string Sm { get; set; } // compressed size for banner
    }

    public class Platform {
        public string Name { get; set; } // name of console
    }

    public class Game {
        public string Name { get; set; } // name of game
        public DateTime FirstReleaseDate { get; set; } // release date
        public float TopCriticScore { get; set; } // overall OpenCritic score
        public Images Images { get; set; } // API uses box and banner
        public List<Platform> Platforms { get; set; } // what console the game is on
    }
}
