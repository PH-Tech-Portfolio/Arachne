using System;
//for the HAP web parcer
using HtmlAgilityPack;
//for lists
using System.Collections.Generic;
using System.IO;

namespace Arachne_Framework
{
    public abstract class spider_InfoSearcherBASE
    {
        //properties

        //NOTE: would it maybe be better to store some of these in the other files in case
        //I resinstanciate a list from another running class and acidentaly erase saved contents
        public HtmlWeb targetSite { get; set; }
        public HtmlDocument htmlDoc { get; set; }
        public List<HtmlDocument> documents_List { get; set; }
        public List<string> links_list { get; set; }
        public List<string> imageLinks_List { get; set; }

        //
        private int counter_FileName;

        public enum SaveLocations
        {
            desktop,    //save to desktop folder on computer
            downloads,  //save to downloads folder on computer
            documents   //save to documents folder on computer
        }
        public enum SearchParameters
        {
            WithinSite,     //only crawl inside the site (don't step outside)
            OutsideSite,    //starts at site but will crawl one layer outside
            FarReach,       //will crawl without bounds, still stays within safety#, THIS IS UNSAFE
        }
        public enum Source
        {
            fromString,     //use an string as source
            fromSiteLink        //use a site as source
        }

        //
        public void CrawlSite(Uri targetSiteUri, Source chosenSource)
        {
            htmlDoc = ParseSite(targetSiteUri, chosenSource);


        }

        //
        private HtmlDocument ParseSite(Uri targetSiteUri, Source sourceType)
        {
            //encapsulate in try catch statement
            try
            {
                switch (sourceType)
                {
                    case Source.fromString:
                        HtmlDocument tmpDoc_0 = new HtmlDocument();
                        tmpDoc_0.LoadHtml("STRINGOFHTML");//WHERE AM I GETTING THIS STRING FROM???, maybe from restSharp idk
                        return tmpDoc_0;

                    case Source.fromSiteLink://USE THIS ONE TILL I GET THE OTHER is WORKING
                        HtmlWeb tmpWeb_1 = new HtmlWeb();
                        HtmlDocument tmpDoc_2 = tmpWeb_1.Load(targetSiteUri); //see if this one liner works???
                        return tmpDoc_2;

                    default://MAKE SURE THIS IS NOT FIRING, I SHOULD BE CHECKING FOR NULL DOCUMENTS ANYWAY
                        HtmlDocument justANullDocument = new HtmlDocument();
                        return justANullDocument;
                }
            }
            catch (Exception)
            {
                spider_Arachne.WriteLine_MessageResponce("There was an Parse error, please check source is valid", spider_Arachne.MessageType.bad);
                return null;
            }
        }

        //
        public void SaveImage_AsFile()
        {

        }

        //save the html site to the disk at a location, use ENUM for this
        public void SaveSite_AsFile()
        {

        }
    }
}
