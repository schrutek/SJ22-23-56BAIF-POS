using Spg.PluePos._01.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Spg.PluePos._01.Test
{
    public class TestPostTest
    {
        private SmartPhoneApp _posts;

        public TestPostTest()
        {
            _posts = new SmartPhoneApp("0x4711")
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
        }

        [Fact()]
        public void TestTextPostTitleOk()
        {
            Assert.Equal("testtitle", new TextPost("testtitle").Title);
        }

        [Fact()]
        public void TestTextPostTitleToStringOk()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            post.Content = "testcontent";
            Assert.Equal("<h1>testtitle</h1><p>testcontent</p>", post.ToString());
        }

        [Fact()]
        public void TestTextPostCreatedOk()
        {
            Assert.Equal(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                new DateTime(new TextPost("testtitle").Created.Year,
                new TextPost("testtitle").Created.Month,
                new TextPost("testtitle").Created.Day));
        }

        [Fact()]
        public void TestTextPostCreatedWithOtherDateTime()
        {
            Assert.Equal(new DateTime(2020, 10, 01), 
                new TextPost("testtitle", new DateTime(2020, 10, 01)).Created);
        }

        [Fact()]
        public void TestTextPostHtmlOk()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            post.Content = "testcontent";
            Assert.Equal("<h1>testtitle</h1><p>testcontent</p>", post.Html);
        }

        [Fact()]
        public void TestTextPostHtmlContectArgumentNullException()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            Assert.Throws<ArgumentNullException>(() => post.Html);
        }

        [Fact()]
        public void TestTextPostRatingOk()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            post.Rating = 3;
            Assert.Equal(3, post.Rating);
        }

        [Fact()]
        public void TestTextPostRatingToSmallArgumentOutOfRangeException()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            Assert.Throws<ArgumentOutOfRangeException>(() => post.Rating = 0);
        }

        [Fact()]
        public void TestTextPostRatingToBigArgumentOutOfRangeException()
        {
            TextPost post = new TextPost("testtitle", new DateTime(2020, 10, 01));
            Assert.Throws<ArgumentOutOfRangeException>(() => post.Rating = 6);
        }

        [Fact()]
        public void TestTextPostTitleKonstruktor1ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                new TextPost(null, new DateTime(2020, 10, 01)));
        }

        [Fact()]
        public void TestTextPostTitleKonstruktor2ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new TextPost(null));
        }


        [Fact()]
        public void TestImagePostUrlHtmlOk()
        {
            ImagePost post = new ImagePost("testtitle", new DateTime(2020, 10, 01));
            post.Url = "https://Image2.png";
            Assert.Equal("<h1>testtitle</h1><img src=https://Image2.png />", post.Html);
        }

        [Fact()]
        public void TestImagePostUrlHtmlContectArgumentNullException()
        {
            ImagePost post = new ImagePost("testtitle", new DateTime(2020, 10, 01));
            Assert.Throws<ArgumentNullException>(() => post.Html);
        }

        [Fact()]
        public void TestSmartPhoneAppCalcRatings()
        {
            Assert.Equal(37, _posts.CalcRating());
        }

        [Fact()]
        public void TestSmartPhoneAppAddExcludeNullItems()
        {
            _posts.Add(null);
            Assert.Equal(16, _posts.Count);
        }

        [Fact()]
        public void SmartPhoneAppAddCheckSmartPhoneReference()
        {
            _posts.Add(new TextPost("SmartPhoneAppAddOkAddedItemTitle") { Content = "SmartPhoneAppAddOk" });
            Assert.Equal("0x4711", _posts[5].SmartPhone.SmartPhoneId);
        }

        [Fact()]
        public void TestSmartPhoneAppProcessPosts()
        {
            string expected = "<h1>TextPost 1</h1><p>Content von TextPost 1</p><h1>ImagePost 2</h1><img src=https://Image2.png /><h1>TextPost 4</h1><p>Content von TextPost 4</p><h1>ImagePost 7</h1><img src=https://Image7.png /><h1>ImagePost 8</h1><img src=https://Image8.png /><h1>TextPost 5</h1><p>Content von TextPost 5</p><h1>ImagePost 4</h1><img src=https://Image4.png /><h1>TextPost 6</h1><p>Content von TextPost 6</p><h1>ImagePost 9</h1><img src=https://Image9.png /><h1>ImagePost 3</h1><img src=https://Image3.png /><h1>TextPost 2</h1><p>Content von TextPost 2</p><h1>ImagePost 5</h1><img src=https://Image5.png /><h1>TextPost 3</h1><p>Content von TextPost 3</p><h1>TextPost 7</h1><p>Content von TextPost 7</p><h1>ImagePost 1</h1><img src=https://Image1.png /><h1>ImagePost 6</h1><img src=https://Image6.png />";
            Assert.Equal(expected, _posts.ProcessPosts());
        }

        //[Fact()]
        //public void TestSmartPhoneAppIterator()
        //{
        //    string expected = "<h1>TextPost 6</h1><p>Content von TextPost 6</p>";
        //    Assert.Equal(expected, _posts["TextPost 6"].Html);
        //}

        //[Fact()]
        //public void TestSmartPhoneAppIteratorReturnsNull()
        //{
        //    string expected = null;
        //    Assert.Equal(expected, _posts["TextPost 4711"]?.Html ?? null);
        //}
    }
}
