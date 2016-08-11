using System;
using System.Collections.Generic;

namespace RssLibrary
{
    public class Channel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PubDate { get; set; }

        private List<FeedItem> _Items = new List<FeedItem>();
        public List<FeedItem> Items
        {
            get
            {
                return _Items;
            }
        }
    }

    public class FeedItem
    {
        private DateTime _pubDate;

        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string PubDate
        {
            get { return _pubDate.ToString("dd-MMM-yyyy HH:mm"); }
            set { _pubDate = Convert.ToDateTime(value); }
        }

        public Uri Link { get; set; }
    }


}
