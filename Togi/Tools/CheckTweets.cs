using System;
using System.Collections.Generic;
using System.Text;
using TogiApi;
using TimeLineControl;

namespace Togi.Tools
{
    public class CheckTweets: IDisposable
    {
        private User TwetterUser;
        private Twitter TwitterApi;

        public CheckTweets(User t)
        {
            TwetterUser = t;
            TwitterApi = new Twitter(TwetterUser.UserName, TwetterUser.UserPass);
        }

        public IList<TweetItem> CheckTimeLine()
        {
            string SinceId = Regedit.GetKey_("since_recent");
            IList<Tweet> list = TwitterApi.FriendsTimeLine(SinceId);

            // SinceId yazılıyor.
            if (list != null && list.Count > 0)
                TwitterApi.SetSinceId(list[0]);

            return ConvertToTweetItem(list);
        }

        public IList<TweetItem> CheckRepliesFirsTime()
        {
            string SinceId = Regedit.GetKey_("since_reply");
            IList<TweetItem> tmp_list = new List<TweetItem>();

            //Okunmamislar aliniyor. SinceId
            LoadTweetItem(tmp_list, CheckReplies(), false);

            //Okunmuslar aliniyor. MaxId
            if(!String.IsNullOrEmpty(SinceId))
                LoadTweetItem(tmp_list, CheckReplies_Read(), true);

            return tmp_list;
        }

        public IList<TweetItem> CheckMessagesFirsTime()
        {
            string SinceId = Regedit.GetKey_("since_message");
            IList<TweetItem> tmp_list = new List<TweetItem>();

            //Okunmamislar aliniyor. SinceId
            LoadTweetItem(tmp_list, CheckMessages(), false);

            //Okunmuslar aliniyor. MaxId
            if (!String.IsNullOrEmpty(SinceId))
                LoadTweetItem(tmp_list, CheckMessages_Read(), true);

            return tmp_list;
        }

        public IList<TweetItem> CheckReplies()
        {
            string SinceId = Regedit.GetKey_("since_reply");
            IList<Tweet> list = TwitterApi.RepliesTimeLine(SinceId);

            // SinceId yazılıyor.
            if (list != null && list.Count > 0)
                TwitterApi.SetSinceId(list[0]);

            return ConvertToTweetItem(list);
        }

        public IList<TweetItem> CheckReplies_Read()
        {
            string SinceId = Regedit.GetKey_("since_reply");
            IList<Tweet> list = TwitterApi.RepliesTimeLine(SinceId, true);

            return ConvertToTweetItem(list);
        }

        public IList<TweetItem> CheckMessages()
        {
            string SinceId = Regedit.GetKey_("since_message");
            IList<Tweet> list = TwitterApi.MessageTimeLine(SinceId);

            // SinceId yazılıyor.
            if (list != null && list.Count > 0)
                TwitterApi.SetSinceId(list[0]);

            return ConvertToTweetItem(list);
        }

        public IList<TweetItem> CheckMessages_Read()
        {
            string SinceId = Regedit.GetKey_("since_message");
            IList<Tweet> list = TwitterApi.MessageTimeLine(SinceId, true);

            return ConvertToTweetItem(list);
        } 

        private IList<TweetItem> ConvertToTweetItem(IList<Tweet> liste)
        {
            IList<TweetItem> tmp_list = new List<TweetItem>();

            lock (this)
            {
                foreach (Tweet item in liste)
                {
                    tmp_list.Add(new TweetItem(item));
                }
            }

            return tmp_list;
        }

        private void LoadTweetItem(IList<TweetItem> dest_, 
            IList<TweetItem> source_, 
            bool isRead)
        {
            lock (this)
            {
                foreach (TweetItem item in source_)
                {
                    item.ItemTweet.isRead = isRead;
                    dest_.Add(item);
                }
            }
        }

       public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       protected virtual void Dispose(bool disposing) 
       {
          if (disposing) 
          {

          }
       }

       ~CheckTweets()
       {

          Dispose (false);
       }


    }
}
