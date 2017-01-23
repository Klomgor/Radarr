﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NzbDrone.Core.NetImport.StevenLu
{
    public class StevenLuResponse
    {
        public Movie[] Movie { get; set; }
    }

    public class Movie
    {
        public string title { get; set; }
        public string imdb_id { get; set; }
        public string poster_url { get; set; }
    }
}
