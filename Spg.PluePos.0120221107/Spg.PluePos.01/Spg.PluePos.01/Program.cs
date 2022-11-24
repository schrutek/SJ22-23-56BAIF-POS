using Spg.PluePos._01.Model;
using System;

namespace Spg.PluePos._01
{
    public class Program
    {
        static void Main(string[] args)
        {
            SmartPhoneApp posts = new SmartPhoneApp("0x4711")
            {
                new TextPost("TextPost 1") { Content = "Content von TextPost 1", Rating = 1 },
                new ImagePost("ImagePost 2") { Url = "https://Image2.png", Rating = 1 },
                new TextPost("TextPost 4") { Content = "Content von TextPost 4", Rating = 1 },
                new ImagePost("ImagePost 7") { Url = "https://Image7.png", Rating = 3 },
                new ImagePost("ImagePost 8") { Url = "https://Image8.png", Rating = 1 },
                new TextPost("TextPost 5") { Content = "Content von TextPost 5", Rating = 2 },
                new ImagePost("ImagePost 4") { Url = "https://Image4.png", Rating = 4 },
                new TextPost("TextPost 6") { Content = "Content von TextPost 6", Rating = 2 },
                new ImagePost("ImagePost 9") { Url = "https://Image9.png", Rating = 2 },
                new ImagePost("ImagePost 3") { Url = "https://Image3.png", Rating = 1 },
                new TextPost("TextPost 2") { Content = "Content von TextPost 2", Rating = 1 },
                new ImagePost("ImagePost 5") { Url = "https://Image5.png", Rating = 4 },
                new TextPost("TextPost 3") { Content = "Content von TextPost 3", Rating = 4 },
                new TextPost("TextPost 7") { Content = "Content von TextPost 7", Rating = 2 },
                new ImagePost("ImagePost 1") { Url = "https://Image1.png", Rating = 3 },
                new ImagePost("ImagePost 6") { Url = "https://Image6.png", Rating = 5 },
            };
            posts.ProcessPosts();

            Console.WriteLine(posts.CalcRating());

            //Console.WriteLine(posts["TextPost 6"]?.Html ?? string.Empty);
        }
    }
}
