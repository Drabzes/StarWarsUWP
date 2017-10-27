using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StarWars.Domain
{
    public class Movie : INotifyPropertyChanged
    {
        private string title;
        private DateTime releaseDate;
        private string director;
        private string producer;
        private string imagePath;

        public string Title {
            get
            {
                return title;
            }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director
        {
            get
            {
                return director;
            }
            set
            {
                director = value;
                RaisePropertyChanged(nameof(Director));
            }
        }

        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
                RaisePropertyChanged(nameof(Producer));
            }
        }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                releaseDate = value;
                RaisePropertyChanged(nameof(ReleaseDate));
            }
        }

        [JsonIgnore]
        public virtual ICollection<Planet> Planets { get; set; }
        [JsonProperty(PropertyName = "planets")]
        public List<string> PlanetUris { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [JsonIgnore]
        public string ImagePath {
            get
            {
                return imagePath;
            }
            set
            {
                this.imagePath = value;
                RaisePropertyChanged(nameof(ImagePath));
            }
        }
    }
}
