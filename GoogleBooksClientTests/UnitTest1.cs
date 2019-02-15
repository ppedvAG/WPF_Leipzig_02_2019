using System;
using System.Collections.Generic;
using GoogleBooksClient;
using GoogleBooksClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleBooksClientTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWebService()
        {
           List<string> booktitles = new List<string>()
           {
               "WPF",
               "Warum lesen doof ist",
               "LVZ",
               "Unbekannt",
           };

            foreach (var item in booktitles)
            {
                TestBook(item);
            }

            var results = BookWebServiceHandler.SearchBooksAsync("amdiasjdiasjdiasjdisajdisajdiasjdi").Result;
            Assert.AreEqual(0, results.Count);

        }

        public void TestBook(string title)
        {
            var results = BookWebServiceHandler.SearchBooksAsync(title).Result;
            Assert.AreEqual(10, results.Count);
            Assert.AreEqual(false, string.IsNullOrEmpty(results[0].Title));
        }
    }
}
