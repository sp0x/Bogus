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
          

        public string FullUrl(string domain = null, string protocol = null)
        { 
            var imdb = new Imdb(this.Locale);
            var inet = new Internet(this.Locale);
            if(string.IsNullOrEmpty(protocol)) protocol = inet.Protocol();
            if(string.IsNullOrEmpty(domain)) domain = inet.DomainName();
            var Path = "/" + Utils.Slashify(imdb.Words().Select(Utils.Slugify), "/");

            return $"{protocol}://{domain}{Path}";
        }
    }
}