using System;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using RssLibrary;

namespace RssLibrary{
    public class RssFeader
    {
        #region variables
        #endregion

        #region Constructor
        public RssFeader()
        {
        }

        public RssFeader(string urlRss)
        {
            UrlRs = urlRss;
        }
        #endregion 

        #region properties
        public string UrlRs { get; set; }
        #endregion

        #region methods
        public Channel GetWholeChannel()
        {
            var feed = SyndicationFeed.Load(XmlReader.Create(UrlRs));
            
            try
            {
                Channel feedData = null;
                if (feed != null)
                {
                    feedData = new Channel
                    {
                        Title = feed.Title.Text,
                        Description = feed.Description.Text,
                        PubDate = feed.LastUpdatedTime
                    };

                    foreach (var item in feed.Items)
                    {
                        var newFeed = new FeedItem();
                        newFeed.Title = item.Title.Text;
                        newFeed.PubDate = item.PublishDate.DateTime.ToString("G");
                        if (item.Authors.Any())
                        {
                            newFeed.Author = item.Authors[0].Name;
                        }
                        newFeed.Content = item.Summary.Text;
                        if (item.Links.Any())
                        {
                            newFeed.Link = item.Links[0].Uri;    
                        }                        
                        feedData.Items.Add(newFeed);
                    }
                }

                return feedData;
            }
            catch (Exception ex)
            {
                return null;
            } 
        }

        public Channel GetWholeChannelAsync()
        {
            return null;
        }


        #endregion
    }
}
