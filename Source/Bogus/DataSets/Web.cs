using System.Linq;

namespace Bogus.DataSets
{
    /// <summary>
    /// Uses Fakers to generate a url
    /// </summary>
    public class Web : DataSet
    { 

        public Web(string locale = "en")
        { 
        }
          

        public string FullUrl()
        { 
            var imdb = new Imdb(this.Locale);
            var inet = new Internet(this.Locale);
            var Protocol = inet.Protocol();
            var Domain = inet.DomainName();
            var Path = "/" + Utils.Slashify(imdb.Words().Select(Utils.Slugify), "/");

            return $"{Protocol}, {Domain}, {Path}";
        }
    }
}