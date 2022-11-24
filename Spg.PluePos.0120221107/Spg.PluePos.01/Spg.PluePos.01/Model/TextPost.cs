using System;

namespace Spg.PluePos._01.Model
{
    public class TextPost : Post
    {
        public string? Content { get; set; }
        public int Length => Content?.Length ?? 0;

        public override string Html
        {
            get 
            {
                if (Content is null) 
                {
                    throw new ArgumentNullException("Content war NULL!");
                }
                return $"<h1>{Title}</h1><p>{Content}</p>";
            }
        }

        public TextPost(string title) : base(title, DateTime.Now)
        { }

        public TextPost(string title, DateTime created) : base(title, created)
        { }
    }
}