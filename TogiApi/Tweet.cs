using System;
using System.Collections.Generic;
using System.Text;

namespace TogiApi
{
    public class Tweet
    {
        // Tweet
        public string Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }

        // Is?
        public bool isFavorite { get; set; }
        public bool isRead { get; set; }
        public TweetTypes TweetType{ get; set; }


        // User
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserScreenName { get; set; }
        public string ProfilImageUrl { get; set; } 

        // Reply
        public string ReplyStatusId { get; set; }
        public string ReplyUserId { get; set; }
        public string ReplyScreenName { get; set; }

        // Message

        public enum TweetTypes
        {
            Normal,
            Reply,
            Message
        }
    }
}
