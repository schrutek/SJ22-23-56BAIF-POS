using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public abstract class Post
    {
        public string Title { get; private set; } = string.Empty;
        public DateTime Created { get; private set; }
        public int Rating 
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Range muss zwischen 1 und 5 liegen!");
                }
                _rating = value;
            }
        }
        private int _rating;

        public abstract string Html { get; }
        public SmartPhoneApp SmartPhone { get; set; } = new("4711");

        public Post(string title, DateTime created)
        {
            if (title is null)
            {
                throw new ArgumentNullException("Titel war NULL!");
            }

            Title = title;
            Created = created;
        }

        public Post(string title)
            : this(title, DateTime.Now)
        { }

        public string ToString()
        {
            return Html;
        }
    }
}
