
namespace ServiceNoticias
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class NewsArticle
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string TimePublished { get; set; }
        public List<string> Authors { get; set; }
        public string Summary { get; set; }
        public string Banner_Image { get; set; }
        public string Source { get; set; }
        public string CategoryWithinSource { get; set; }
        public string SourceDomain { get; set; }
        public List<Topic> Topics { get; set; }
        public double OverallSentimentScore { get; set; }
        public string OverallSentimentLabel { get; set; }
        public List<TickerSentiment> TickerSentiment { get; set; }
    }

    public class Topic
    {
        public string TopicName { get; set; }
        public double RelevanceScore { get; set; }
    }

    public class TickerSentiment
    {
        public string Ticker { get; set; }
        public double RelevanceScore { get; set; }
        public double TickerSentimentScore { get; set; }
        public string TickerSentimentLabel { get; set; }
    }

    public class FeedResponse
    {
        [JsonProperty("feed")]
        public List<NewsArticle> Feed { get; set; }
    }


}
