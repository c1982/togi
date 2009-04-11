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

            return ConvertToTweetItem(list);
        }


        public IList<TweetItem> CheckReplies()
        {
            string SinceId = Regedit.GetKey_("since_reply");
            IList<Tweet> list = TwitterApi.RepliesTimeLine(SinceId);

            return ConvertToTweetItem(list);
        }

        public IList<TweetItem> CheckMessages()
        {
            string SinceId = Regedit.GetKey_("since_message");
            IList<Tweet> list = TwitterApi.MessageTimeLine(SinceId);

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
