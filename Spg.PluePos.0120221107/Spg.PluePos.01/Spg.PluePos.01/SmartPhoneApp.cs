using Spg.PluePos._01.Model;
using System;
using System.Collections.Generic;

namespace Spg.PluePos._01
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; } = string.Empty;

        public SmartPhoneApp(string id)
        {
            SmartPhoneId = id;
        }

        /// <summary>
        /// Add-Methode von SmartPhoneApp-Klasse
        /// </summary>
        /// <param name="post"></param>
        public new void Add(Post post)
        {
            if (post is not null)
            {
                post.SmartPhone = this;
                base.Add(post);
            }
        }

        public int CalcRating()
        {
            int sum = 0;
            foreach(Post post in this) 
            {
                sum += post.Rating;
            }
            return sum;
        }

        public string ProcessPosts()
        {
            string finalHtml = string.Empty;
            foreach (Post post in this)
            {
                finalHtml += post.Html;
            }
            return finalHtml;
        }
    }
}