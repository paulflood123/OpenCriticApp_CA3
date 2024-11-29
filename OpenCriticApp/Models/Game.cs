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
        public string ImageSrc { get; set; } // image for platform
    }

    public class Trailer {
        public string Title { get; set; } // name of trailer (will be unused because looks bad)
        public string VideoId { get; set; } // youtube vid
        public string ExternalUrl { get; set; } // unusued i think
    }

    public class Genre {
        public string Name { get; set; } // genre of the game
    }

    public class Game {
        public string Name { get; set; } // name of game
        public DateTime FirstReleaseDate { get; set; } // release date
        public float TopCriticScore { get; set; } // overall OpenCritic score
        public string Description { get; set; } // description of the game
        public Images Images { get; set; } // box and banner images
        public List<Platform> Platforms { get; set; } // platforms the game is on
        public List<Genre> Genres { get; set; } // genres associated with the game
        public List<Trailer> Trailers { get; set; } // trailers for the game
        public int medianScore { get; set; }
        public float percentRecommended { get; set; }
        public int NumReviews { get; set; }
    }
}
