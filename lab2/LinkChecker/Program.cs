namespace LinkChecker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //const string URL = "http://links.qatl.ru/";
            //const string VALID_LINKS = "valid_links.txt";
            //const string INVALID_LINKS = "invalid_links.txt";

            const string URL = "https://www.usa.gov/";
            const string VALID_LINKS = "usa_gov_valid_links.txt";
            const string INVALID_LINKS = "usa_gov_invalid_links.txt";

            //const string URL = "https://www.travelline.ru/";
            //const string VALID_LINKS = "travelline_valid_links.txt";
            //const string INVALID_LINKS = "travelline_invalid_links.txt";

            try
            {
                LinkChecker checker = new LinkChecker();
                await checker.CheckLinks(URL);
                checker.
                    PrintLinks(VALID_LINKS, INVALID_LINKS);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}