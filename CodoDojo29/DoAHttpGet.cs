using System.Net;

namespace CodoDojo29
{
    public class DoAHttpGet : IDoAHttpGet
    {
        public string GetUrl(string url)
        {
            return new WebClient().DownloadString(url);
        }
    }
}