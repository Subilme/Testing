using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace LinkChecker
{
    public class LinkChecker
    {
        private string _url;
        private Dictionary<string, HttpResponseMessage> _responses;
        private readonly HashSet<string> _visitedLinks;

        public LinkChecker()
        {
            _url = string.Empty;
            _responses = new Dictionary<string, HttpResponseMessage>();
            _visitedLinks = new HashSet<string>();
        }

        public async Task CheckLinks(string url)
        {
            if (!IsValidUrl(url))
            {
                throw new Exception("Url is not valid");
            }
            _url = url;

            HtmlWeb web = new HtmlWeb();
            HttpClient client = new HttpClient();
            HashSet<string> links = GetAllLinksOnPage(web, _url).ToHashSet();

            while (links.Any())
            {
                HashSet<string> newLinks = new HashSet<string>();

                foreach (var link in links)
                {
                    string absoluteUrl = string.Empty;

                    try
                    {
                        absoluteUrl = GetAbsoluteUrl(link);
                    }
                    catch (UriFormatException)
                    {
                        continue;
                    }

                    if (!absoluteUrl.StartsWith(_url) || _visitedLinks.Contains(absoluteUrl))
                    {
                        continue;
                    }

                    _visitedLinks.Add(absoluteUrl);
                    HttpResponseMessage response = await client.GetAsync(absoluteUrl);

                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine(absoluteUrl);
                    }
                    _responses[absoluteUrl] = response;
                    newLinks.UnionWith(GetAllLinksOnPage(web, absoluteUrl));

                    //Console.WriteLine($"{absoluteUrl} {response.StatusCode}");
                }

                links = newLinks.ToHashSet();
            }
        }

        private string GetAbsoluteUrl(string url)
        {
            string href = AbsolutizeUrl(url);
            var uri = new Uri(href, UriKind.RelativeOrAbsolute);

            if (!uri.IsAbsoluteUri)
            {
                uri = new Uri(new Uri(_url), uri);
            }

            return uri.ToString();
        }

        private string AbsolutizeUrl(string url)
        {
            int index = url.IndexOf('#');
            url = (index > -1) ? url.Remove(index) : url;

            index = url.IndexOf('?');
            url = (index > -1) ? url.Remove(index) : url;

            return url;
        }

        private IEnumerable<string> GetAllLinksOnPage(HtmlWeb web, string url)
        {
            HtmlDocument htmlDoc = web.Load(url);
            HtmlNodeCollection nodes = htmlDoc.DocumentNode.SelectNodes("//a[@href]");

            return nodes != null
                ? nodes.Select(x => x.Attributes["href"].Value)
                : new List<string>();
        }

        private static readonly Regex _urlRegex = new("^https?:\\/\\/(?:www\\.)" +
        "?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b" +
        "(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");

        private static bool IsValidUrl(string url)
        {
            return _urlRegex.IsMatch(url);
        }

        public void PrintLinks(string valid, string invalid)
        {
            using StreamWriter validLinks = new StreamWriter(valid);
            using StreamWriter invalidLinks = new StreamWriter(invalid);

            int validCount = 0, invalidCount = 0;

            foreach (var item in _responses)
            {
                if (item.Value.IsSuccessStatusCode)
                {
                    validLinks.WriteLine($"{item.Key} {item.Value.StatusCode}");
                    validCount++;
                }
                else
                {
                    invalidLinks.WriteLine($"{item.Key} {item.Value.StatusCode}");
                    invalidCount++;
                }
            }

            validLinks.WriteLine($"Links total: {validCount}");
            validLinks.WriteLine($"Date: {DateTime.Now}");

            invalidLinks.WriteLine($"Links total: {invalidCount}");
            invalidLinks.WriteLine($"Date: {DateTime.Now}");
        }
    }
}
