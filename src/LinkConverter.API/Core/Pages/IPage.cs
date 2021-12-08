namespace LinkConverter.API.Core.Pages
{
    public interface IPage
    {
        public int Priority { get; }
        public bool IsMatchWithDeeplinkPattern(string link);

        public bool IsMatchWithWebUrlPattern(string link);

        public string BuildDeeplink(string webUrl);

        public string BuildWebUrl(string deeplink);
    }
}
