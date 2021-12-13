using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
//
using Arachne_Framework;
using HtmlAgilityPack;

namespace myTests_RENAME
{
    [TestClass]
    public class tests_CrawlingScraping_HAP
    {
        //sites for testing
        public Uri testWebsite01_StaticInfo = new Uri("https://en.wikipedia.org/wiki/Main_Page");    //good for testing
        public Uri testWebsite02_DynamicInfo = new Uri("https://www.cnn.com/politics");              //could crawl through posts

        Uri website = new Uri(/*"https://en.wikipedia.org/wiki/War"*/"https://en.wikipedia.org/wiki/Main_Page");
        Uri website_withEmails = new Uri("https://www.leadsplease.com/email-lists/consumer");
        Uri website_withEmails02 = new Uri("https://en.wikipedia.org/wiki/Gmail");  //bout 2k sources here
        Uri website_withEmails_Local = new Uri("https://en.wikipedia.org/wiki/Gmail");

        //test01, can program load sites?
        [TestMethod]
        public void TestFor_ParseSuccess()
        {
            HtmlDocument tmpTestDoc = spider_Arachne.ParseSite(testWebsite01_StaticInfo, spider_Arachne.Source.fromSiteLink);
            Assert.IsNotNull(tmpTestDoc);
        }

        [TestMethod]
        public void TestFor_CheckFor_Links_MatchingHostName()
        {
            List<Uri> tmpUriTestList = spider_Arachne.SearchFor_Links(testWebsite01_StaticInfo, spider_Arachne.SearchParameters.MatchingHostName);
            Assert.IsNotNull(tmpUriTestList);
        }
        [TestMethod]
        public void TestFor_CheckFor_Links_InsideSite()
        {
            List<Uri> tmpUriTestList01 = spider_Arachne.SearchFor_Links(testWebsite01_StaticInfo, spider_Arachne.SearchParameters.InsideSite);
            Assert.IsNotNull(tmpUriTestList01);
        }
        [TestMethod]
        public void TestFor_CheckFor_Links_OutsideSite()
        {
            List<Uri> tmpUriTestList01 = spider_Arachne.SearchFor_Links(testWebsite01_StaticInfo, spider_Arachne.SearchParameters.InsideSite);
            List<Uri> tmpUriTestList02 = spider_Arachne.SearchFor_Links(testWebsite01_StaticInfo, spider_Arachne.SearchParameters.OutsideSite);

            Assert.IsTrue(tmpUriTestList01.Count < tmpUriTestList02.Count);
        }
    }
}
