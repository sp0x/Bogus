using System.Linq;
using Bogus.DataSets;

namespace Bogus
{
    /// <summary>
    /// Uses Fakers to generate a url
    /// </summary>
    public class Url
    {
        public string Protocol { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }

        public Url(string locale = "en")
        {
            Initialize(locale);
        }

        protected virtual void Initialize(string locale)
        { 
            var imdb = new Imdb(locale);
            var inet = new Internet(locale);
            Protocol = inet.Protocol();
            Domain = inet.DomainName();
            Path = "/" + Utils.Slashify(imdb.Words().Select(Utils.Slugify), "/");
        }

        public override string ToString()
        {
            return string.Format("{0}://{1}", Protocol, Domain, Path);
        }
    }
}