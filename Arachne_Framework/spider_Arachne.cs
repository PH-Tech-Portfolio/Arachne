using System;
//for web parsing
using HtmlAgilityPack;
//to use system sleep
using System.Threading;
//to use lists
using System.Collections.Generic;
//to download images
using System.Net;
//for writing files
using System.IO;
//using System.Resources;

namespace Arachne_Framework
{
    public static class spider_Arachne
    {
        //properties, (SOME CODE CAN BE REMOVED LATER)
        public static Uri targetSite { get; set; }                          //
        public static HtmlDocument htmlDoc { get; set; }                        //
        public static List<Uri> sites_List { get; set; }                        //
        public static List<HtmlDocument> documents_List { get; set; }           //
        public static List<Uri> links_list { get; set; }                        //
        public static List<Uri> imageLinks_List { get; set; }                   //

        private static int counter_FileName;

        public static Uri targetSite_Uri;

        public enum SaveLocations
        {
            desktop,    //save to desktop folder on computer
            downloads,  //save to downloads folder on computer
            documents   //save to documents folder on computer
        }
        public enum SearchParameters
        {
            MatchingHostName,
            InsideSite,     //only crawl inside the site (don't step outside)
            OutsideSite,    //starts at site but will crawl one layer outside
            FarReach,       //will crawl without bounds, still stays within safety#, THIS IS UNSAFE, AXING THIS OPTION (IT'S NOT ADVISED)
        }
        public enum Source//could have just made an overload accepting a stirng an dothe other accepting a uri but I want to the parse method to use this as well and it looks cleaner
        {
            fromString,     //use an string as source
            fromSiteLink        //use a site as source
            //could add in from document if I wanted???
        }
        public enum LoadSpeed
        {
            slow,       //100ms
            fast        //1ms
        }
        public enum MessageType
        {
            good,//probably wont need this because I will be calling the public static methods from other files
            bad
        }
        public enum FunctionToPerform
        {
            stuff,
            here
        }
        //could have an enum for commands (then pass it to here to see which we want to do)

        
        static spider_Arachne(/*what do I need to ask for*/)
        {
            //need to give targetSite_Uri a uri for source of the target site

            //also here I will createa  nice user experience


            //inicial program setup here
            //Console.ForegroundColor = ConsoleColor.Cyan;


            //ascii program title here

            //ShowMenu();
            //give user a readout of options and description


            //show initial menu for program



            //new StreamReader(Properties.Resources.AsciiSpiderArt)

        }
        
        
        //menu functions
        public static void ShowMenu()
        {
            try
            {
                var WindowWidth = (Console.LargestWindowWidth / 4) * 2;
                var WindowHeight = (Console.LargestWindowHeight / 3) + (Console.LargestWindowHeight / 2);

                Console.WindowWidth = WindowWidth;
                Console.WindowHeight = WindowHeight;
            }
            catch
            {
                WriteLine_MessageResponce("Hey sorry there was an issue setting the console size, " +
                    "we will restore to defualts so don't worry about it", MessageType.bad);
            }

            Random rand = new Random();

            var titleAsciiImage = Properties.Resources.AsciiSpiderArt;
            var titleText = Properties.Resources.AsciiSpiderText04;
            var cArray = titleAsciiImage.ToCharArray();
            var cArray2 = titleText.ToCharArray();

            var something = Enum.GetNames(typeof(ConsoleColor)).Length;

            foreach (char caracter in cArray)//might not have to convert it to a char array
            {
                ConsoleColor cc = (ConsoleColor)rand.Next(something);
                Console.ForegroundColor = cc;
                Console.Write(caracter);
            }
            if (Console.ForegroundColor == ConsoleColor.Black)
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.Write("Loading Program");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write("\b \b");
                Thread.Sleep(300);
                Console.Write("\b \b");
                Thread.Sleep(300);
                Console.Write("\b \b");
                Thread.Sleep(300);
            }
            Console.WriteLine();
            Thread.Sleep(500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (char caracter in cArray2)
            {
                Console.Write(caracter);
                if (!(char.IsWhiteSpace(caracter) || caracter == ' '))          //only delay on spider limbs/parts
                    Thread.Sleep(1);
            }
            Console.WriteLine("\n\n");
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
                //delay for effect
                Thread.Sleep(1);
            }
            var authorName = "Author: Paulson Hanel";
            Console.WriteLine();
            foreach (char c in authorName)
            {
                Console.Write(c);
                //delay for effect
                Thread.Sleep(1);
            }
            var programVersion = "Version: 1.5";
            Console.Write("             ");
            foreach (char c in programVersion)
            {
                Console.Write(c);
                //delay for effect
                Thread.Sleep(1);
            }
            Console.Write("\b\b\b\b\b");
            Console.WriteLine();
            for (int i = 0; i < 80; i++)
            {
                Console.Write("-");
                //delay for effect
                Thread.Sleep(1);
            }
            Console.WriteLine();
            Console.Write("Loading");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write("\b");
                Console.Write("/");
                Thread.Sleep(200);
                Console.Write("\b");
            }
            Console.Write("\b\b\b\b\b\b\b");
            Console.ResetColor();
            Console.WriteLine("\n\n\n\n\n");
        }
        public static void GoodbyeMenu()
        {
            Random rand = new Random();
            var titleAsciiImage = Properties.Resources.AsciiSpiderArt;
            var titleText = Properties.Resources.AsciiSpiderText_ClosingMenuText;
            var cArray = titleAsciiImage.ToCharArray();
            var cArray2 = titleText.ToCharArray();
            var something = Enum.GetNames(typeof(ConsoleColor)).Length;

            foreach (char caracter in cArray)//might not have to convert it to a char array
            {
                ConsoleColor cc = (ConsoleColor)rand.Next(something);
                Console.ForegroundColor = cc;
                Console.Write(caracter);
                if (!(char.IsWhiteSpace(caracter) || caracter == ' '))          //only delay on spider limbs/parts
                    Thread.Sleep(1);
            }
            Console.WriteLine();
            Thread.Sleep(4000);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (char caracter in cArray2)
            {
                Console.Write(caracter);
                if (!(char.IsWhiteSpace(caracter) || caracter == ' '))          //only delay on spider limbs/parts
                    Thread.Sleep(1);
            }
            string mg1 = "Drinking Warm Milk!";
            string mg2 = "Reading a Bedtime Story!";
            string mg3 = "Tucking in baby Spiders";

            Console.WriteLine("\n\n");
            foreach (char c in mg1)
            {
                Console.Write(c);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            foreach (char c in "██████████████████████████████████████████████████████████████████████████████")
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
            Console.WriteLine("\n\n");
            foreach (char c in mg2)
            {
                Console.Write(c);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            foreach (char c in "██████████████████████████████████████████████████████████████████████████████")
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
            Console.WriteLine("\n\n");
            foreach (char c in mg3)
            {
                Console.Write(c);
                Thread.Sleep(100);
            }
            Console.WriteLine();
            foreach (char c in "██████████████████████████████████████████████████████████████████████████████")
            {
                Console.Write(c);
                Thread.Sleep(1);
            }
            //Console.WriteLine("\n\n");
            //Console.WriteLine("Press Any Key To Leave!");
            //Console.ReadKey();
            Console.WriteLine("\n\n");
            Console.WriteLine($"See Ya Later {Environment.UserName}");
            Console.WriteLine();
        }


        //don't really need this, (REMOVABLE CODE)
        public static void CrawlSite(Uri targetSiteUri, Source chosenSource)
        {
            htmlDoc = ParseSite(targetSiteUri);

        }

        
        //parse a site
        public static HtmlDocument ParseSite(Uri targetSiteUri, Source sourceType = Source.fromSiteLink)
        {
            //encapsulate in try catch statement
            try
            {
                switch (sourceType)
                {
                    //case Source.fromString:
                    //    HtmlDocument tmpDoc_0 = new HtmlDocument();
                    //    string tmpTarget = targetSiteUri.ToString();
                    //    tmpDoc_0.LoadHtml(tmpTarget);//WHERE AM I GETTING THIS STRING FROM???, maybe from restSharp idk, should save sit as html
                    //    return tmpDoc_0;

                    case Source.fromSiteLink://USE THIS ONE TILL I GET THE OTHER is WORKING
                        HtmlWeb tmpWeb_1 = new HtmlWeb();
                        HtmlDocument tmpDoc_2 = null;
                        if (!(targetSiteUri is null))
                        {
                            tmpDoc_2 = tmpWeb_1.Load(targetSiteUri); 
                            //was getting an null error here.
                            //Pretty sure I am saying return null values if a value isn't selected (gotta be carful in code)
                        }
                        else
                        {
                            targetSiteUri = targetSite;
                            tmpDoc_2 = tmpWeb_1.Load(targetSiteUri);
                        }
                        return tmpDoc_2;

                    default://MAKE SURE THIS IS NOT FIRING, I SHOULD BE CHECKING FOR NULL DOCUMENTS ANYWAY
                        HtmlDocument justANullDocument = new HtmlDocument();
                        return justANullDocument;
                }
            }
            catch (Exception)
            {
                WriteLine_MessageResponce("There was an Parse error. Turns out ur site is not viable!", MessageType.bad);
                return null;
            }
        }


        //search for data
        public static List<Uri> SearchFor_Links(Uri targetSiteUri, SearchParameters searchParams, Source chosenSource = Source.fromSiteLink)
        {
            htmlDoc = ParseSite(targetSiteUri);

            List<Uri> tmpList_Links = new List<Uri>();

            if (searchParams == SearchParameters.MatchingHostName)
            {
                tmpList_Links = new List<Uri>();
                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                int x = 0;
                foreach (var href in nodes)
                {
                    var links = string.Empty;
                    if (href.Attributes["href"] != null)
                        links = href.Attributes["href"].Value;
                    if (links.Contains("http") | links.Contains("https"))
                    {
                        Uri tmpUri_link = new Uri(links);

                        string tmpString = tmpUri_link.ToString();

                        if (tmpString.Contains(targetSiteUri.Host))
                            tmpList_Links.Add(tmpUri_link);
                    }
                    Loading_Percent(++x, nodes.Count, "Loading Links", LoadSpeed.fast);
                }

                Console.WriteLine();
                WriteLine_MessageResponce($"We found {tmpList_Links.Count} links!", MessageType.good);
                return tmpList_Links;
            }
            else if (searchParams == SearchParameters.InsideSite)
            {
                tmpList_Links = new List<Uri>();
                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                int x = 0;
                foreach (var href in nodes)
                {
                    var links = string.Empty;
                    if (href.Attributes["href"] != null)
                        links = href.Attributes["href"].Value;
                    if (links.Contains("http") | links.Contains("https"))
                    {
                        Uri tmpUri_link = new Uri(links);
                        tmpList_Links.Add(tmpUri_link);
                    }
                    Loading_Percent(++x, nodes.Count, "Loading Links", LoadSpeed.fast);
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {tmpList_Links.Count} links!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Links.Count} links!", MessageType.good);
                return tmpList_Links;
            }
            else if (searchParams == SearchParameters.OutsideSite)
            {
                tmpList_Links = new List<Uri>();
                List<HtmlDocument> tmpDocList = new List<HtmlDocument>();

                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                foreach (var href in nodes)
                {
                    var links = string.Empty;
                    if (href.Attributes["href"] != null)
                        links = href.Attributes["href"].Value;
                    if (links.Contains("http") | links.Contains("https") /*and if it doesn't have .png or other ???*/)
                    {
                        Uri tmpUri_link = new Uri(links);
                        tmpList_Links.Add(tmpUri_link);
                    }
                }
                int x = 0;
                foreach (Uri uri in tmpList_Links)
                {
                    HtmlDocument tmpTestDoc;
                    HtmlWeb tmpTestWeb = new HtmlWeb();

                    try
                    {
                        tmpTestDoc = tmpTestWeb.Load(uri);
                        tmpDocList.Add(tmpTestDoc);
                    }
                    catch
                    {
                    }

                    Loading_Percent(++x, tmpList_Links.Count, "The Hard Part", LoadSpeed.fast);
                    //Loading(x++, tmpList_Links.Count, "The Hard Part");
                }
                foreach (HtmlDocument document in tmpDocList)
                {
                    var tmpDocListNodes = htmlDoc.DocumentNode.SelectNodes("//a");
                    foreach (var tmpHref in tmpDocListNodes)
                    {
                        var tmpLinks = string.Empty;
                        if (tmpHref.Attributes["href"] != null)
                            tmpLinks = tmpHref.Attributes["href"].Value;
                        if ((tmpLinks.Contains("http") | tmpLinks.Contains("https"))/* && !tmpLinks.Contains(".png") || !tmpLinks.Contains(".jpg") || !tmpLinks.Contains(".jpeg") || !tmpLinks.Contains(".webp")*/)
                        {
                            Uri tmpUri_link_TmpDocs = new Uri(tmpLinks);
                            tmpList_Links.Add(tmpUri_link_TmpDocs);
                        }
                    }
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {tmpList_Links.Count} links!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Links.Count} links!", MessageType.good);
                return tmpList_Links;
            }
            else return tmpList_Links;

        }
        public static List<Uri> SearchFor_ImageLinks(Uri targetSiteUri, SearchParameters searchParams)
        {
            htmlDoc = ParseSite(targetSiteUri);

            List<Uri> tmpList_Links = new List<Uri>();

            if (searchParams == SearchParameters.MatchingHostName)
            {
                WriteLine_MessageResponce("Sorry that option is not avalable in this function!", MessageType.bad);
                return null;
            }
            else if (searchParams == SearchParameters.InsideSite)
            {
                tmpList_Links = new List<Uri>();

                var nodes = htmlDoc.DocumentNode.SelectNodes("//a/img/@src");
                int x = 0;
                foreach (var src in nodes)
                {
                    var link = string.Empty;
                    if (src.Attributes["src"] != null)
                        link = src.Attributes["src"].Value;
                    try
                    {
                        Uri tmpUri_link = new Uri(link);
                        tmpList_Links.Add(tmpUri_link);
                    }
                    catch
                    {
                    }
                    Loading_Percent(++x, nodes.Count, $"Searching {nodes.Count} Sources For Viable Data", LoadSpeed.slow);
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {tmpList_Links.Count} images!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Links.Count} images!", MessageType.good);
                return tmpList_Links;
            }
            else if (searchParams == SearchParameters.OutsideSite)
            {
                tmpList_Links = new List<Uri>();

                List<Uri> retImgLinks = new List<Uri>();

                List<HtmlDocument> tmpDocList = new List<HtmlDocument>();

                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                foreach (var href in nodes)
                {
                    var link = string.Empty;
                    if (href.Attributes["href"] != null)
                        link = href.Attributes["href"].Value;
                    try
                    {
                        Uri tmpUri_link = new Uri(link);
                        tmpList_Links.Add(tmpUri_link);
                    }
                    catch
                    {

                    }
                }
                int x = 0;
                foreach (Uri uri in tmpList_Links)
                {
                    HtmlDocument tmpTestDoc;
                    HtmlWeb tmpTestWeb = new HtmlWeb();

                    try
                    {
                        tmpTestDoc = tmpTestWeb.Load(uri);
                        tmpDocList.Add(tmpTestDoc);
                    }
                    catch
                    {
                    }

                    Loading_Percent(++x, tmpList_Links.Count, $"Crawling through {tmpList_Links.Count} potencial sources", LoadSpeed.fast);
                }
                x = 0;
                foreach (HtmlDocument document in tmpDocList)
                {
                    var tmpDocListNodes = htmlDoc.DocumentNode.SelectNodes("//a/img/@src");
                    foreach (var tmpSrc in tmpDocListNodes)
                    {
                        var tmpLinks = string.Empty;
                        if (tmpSrc.Attributes["src"] != null)
                            tmpLinks = tmpSrc.Attributes["src"].Value;

                        try
                        {
                            Uri tmpUri_link_TmpDocs = new Uri(tmpLinks);
                            retImgLinks.Add(tmpUri_link_TmpDocs);
                        }
                        catch
                        {
                        }
                    }
                    Loading_Percent(++x, tmpDocList.Count, $"Crawling for images in {tmpDocList.Count} potencial sources", LoadSpeed.fast);
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {retImgLinks.Count} images!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {retImgLinks.Count} images!", MessageType.good);
                return retImgLinks;
            }
            else return tmpList_Links;
        }
        public static List<string> SearchFor_Data_UrPick_InText (Uri targetSiteUri, SearchParameters searchParams, string searchThis)
        {
            htmlDoc = ParseSite(targetSiteUri);

            List<string> tmpList_Links = new List<string>();

            List<string> tmpList_Findings = new List<string>();

            if (searchThis == " " || string.IsNullOrEmpty(searchThis)) WriteLine_MessageResponce("Please enter an acceptable value", MessageType.bad);

            if (searchParams == SearchParameters.MatchingHostName)
            {
                WriteLine_MessageResponce("Sorry that option is not avalable in this function!", MessageType.bad);
                return null;
            }
            else if (searchParams == SearchParameters.InsideSite)
            {
                List<string> paragrahs = new List<string>();

                int x = 0;
                foreach (var item in htmlDoc.DocumentNode.SelectNodes("//p"))
                {
                    paragrahs.Add(item.InnerText);
                    Loading_Percent(++x, htmlDoc.DocumentNode.SelectNodes("//p").Count, $"Searching {htmlDoc.DocumentNode.SelectNodes("//p").Count} paragraphs", LoadSpeed.slow);
                }

                //split paragraph into words, paragraph already initalized when find word called, go through paragraphs
                foreach (string paragraph in paragrahs)
                {
                    //split paragraph by spaces, into words list
                    string[] tmpParagraph = paragraph.Split(' ');

                    //go through each word in each paragraph
                    for (int y = 0; y < tmpParagraph.Length; y++)
                    {
                        //clean all words
                        tmpParagraph[y] = tmpParagraph[y].CleanResponce();
                        if (tmpParagraph[y] != "")
                        {
                            if (tmpParagraph[y].Contains(searchThis))
                                tmpList_Findings.Add(tmpParagraph[y]);
                        }
                    }
                    //between paragraphs have a space
                    Console.WriteLine("\n");
                }

                Console.WriteLine();
                if (tmpList_Findings.Count == 0)
                    WriteLine_MessageResponce($"We found {/*paragrahs*/tmpList_Findings.Count} potencial matches for '{searchThis}'!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Findings.Count} potencial matches for '{searchThis}'!", MessageType.good);
                return /*paragrahs*/tmpList_Findings;
            }
            else if (searchParams == SearchParameters.OutsideSite)
            {
                tmpList_Links = new List<string>();
                List<HtmlDocument> tmpDocList = new List<HtmlDocument>();

                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                foreach (var href in nodes)
                {
                    var link = string.Empty;
                    if (href.Attributes["href"] != null)
                        link = href.Attributes["href"].Value;
                    try
                    {
                        tmpList_Links.Add(link);
                    }
                    catch
                    {
                    }
                }
                Console.WriteLine();
                int x = 0;
                foreach (string l in tmpList_Links)
                {
                    HtmlDocument tmpTestDoc;
                    HtmlWeb tmpTestWeb = new HtmlWeb();

                    try
                    {
                        tmpTestDoc = tmpTestWeb.Load(l);
                        tmpDocList.Add(tmpTestDoc);
                    }
                    catch
                    {
                    }
                    Loading_Percent(++x, tmpList_Links.Count, $"Crawling through {tmpList_Links.Count} potencial sources", LoadSpeed.fast);
                }
                Console.WriteLine();
                x = 0;
                List<string> paragrahs_Uncleaned = new List<string>();
                foreach (HtmlDocument document in tmpDocList)
                {
                    List<string> tmpParagrahs = new List<string>();

                    foreach (var item in htmlDoc.DocumentNode.SelectNodes("//p"))
                    {
                        tmpParagrahs.Add(item.InnerText);
                        paragrahs_Uncleaned.Add(item.InnerText);
                    }

                    foreach (string paragraph in tmpParagrahs)
                    {
                        string[] tmpParagraph = paragraph.Split(' ');

                        for (int y = 0; y < tmpParagraph.Length; y++)
                        {
                            tmpParagraph[y] = tmpParagraph[y].CleanResponce();
                            if (tmpParagraph[y] != "")
                                if (tmpParagraph[y].Contains(searchThis))
                                    //if (!tmpList_Findings.Contains(tmpParagrahs[y]))
                                    tmpList_Findings.Add(tmpParagraph[y]);
                        }
                    }
                    Loading_Percent(++x, tmpDocList.Count, $"Searching {paragrahs_Uncleaned.Count} uncleaned paragraphs", LoadSpeed.fast);
                }

                int NumberOfWords = 0;
                foreach (string paragraph in paragrahs_Uncleaned)
                {
                    string[] tmpParagraph02 = paragraph.Split(' ');
                    foreach (string word in tmpParagraph02)
                        //could easily add code to track all the words here too
                        NumberOfWords++;
                }

                Console.WriteLine();
                if (tmpList_Findings.Count == 0)
                    WriteLine_MessageResponce($"We found {paragrahs_Uncleaned.Count} paragraphs and {tmpList_Findings.Count} potencial matches for '{searchThis}' out of {NumberOfWords} words searched!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {paragrahs_Uncleaned.Count} paragraphs and {tmpList_Findings.Count} potencial matches for '{searchThis}' out of {NumberOfWords} words searched!", MessageType.good);
                return tmpList_Findings;
            }
            else return tmpList_Links;
        }
        public static List<string> SearchFor_NamesOfConnectedSites(Uri targetSiteUri, SearchParameters searchParams)    //Note: in some instances the origional links are carried unless I make a new temp list
        {
            htmlDoc = ParseSite(targetSiteUri);

            List<string> tmpList_Links = new List<string>();

            List<HtmlDocument> tmpDocList = new List<HtmlDocument>();

            if (searchParams == SearchParameters.MatchingHostName)
            {
                WriteLine_MessageResponce("Sorry that option is not avalable in this function!", MessageType.bad);
                return null;
            }
            else if (searchParams == SearchParameters.InsideSite)
            {
                tmpList_Links = new List<string>();
                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                int x = 0;
                Console.WriteLine();
                foreach (var href in nodes)
                {
                    var link = string.Empty;
                    if (href.Attributes["href"] != null)
                        link = href.Attributes["href"].Value;
                    if (link.Contains("http") | link.Contains("https"))
                    {
                        Uri tmpUri_link = new Uri(link);
                        if (!tmpList_Links.Contains(tmpUri_link.Host))
                            tmpList_Links.Add(link);
                    }
                    Loading_Percent(++x, nodes.Count, "Looking at connected sites", LoadSpeed.fast);
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {tmpList_Links.Count} connected websites!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Links.Count} connected websites!", MessageType.good);
                return tmpList_Links;
            }
            else if (searchParams == SearchParameters.OutsideSite)
            {
                tmpList_Links = new List<string>();
                var nodes = htmlDoc.DocumentNode.SelectNodes("//a");
                int x = 0;
                Console.WriteLine();
                foreach (var href in nodes)
                {
                    var link = string.Empty;
                    if (href.Attributes["href"] != null)
                        link = href.Attributes["href"].Value;
                    if (link.Contains("http") | link.Contains("https"))
                    {
                        Uri tmpUri_link = new Uri(link);
                        if (!tmpList_Links.Contains(tmpUri_link.Host))
                            tmpList_Links.Add(link);
                    }

                    Loading_Percent(++x, nodes.Count, "Looking for connected sites", LoadSpeed.fast);
                }

                x = 0;
                Console.WriteLine();
                foreach (string s in tmpList_Links)
                {
                    HtmlDocument tmpTestDoc;
                    HtmlWeb tmpTestWeb = new HtmlWeb();

                    try
                    {
                        tmpTestDoc = tmpTestWeb.Load(s);
                        tmpDocList.Add(tmpTestDoc);
                    }
                    catch
                    {
                    }

                    Loading_Percent(++x, tmpList_Links.Count, "Crawling around related sites", LoadSpeed.fast);
                }

                x = 0;
                Console.WriteLine();
                foreach (HtmlDocument document in tmpDocList)
                {
                    var tmpDocListNodes = htmlDoc.DocumentNode.SelectNodes("//a");
                    foreach (var tmpHref in tmpDocListNodes)
                    {
                        var tmpLink = string.Empty;
                        if (tmpHref.Attributes["href"] != null)
                            tmpLink = tmpHref.Attributes["href"].Value;
                        try
                        {
                            Uri tmpUri_link_TmpDocs = new Uri(tmpLink);
                            if (!tmpList_Links.Contains(tmpUri_link_TmpDocs.Host))
                                tmpList_Links.Add(tmpLink);
                        }
                        catch
                        {
                        }

                    }
                    Loading_Percent(++x, tmpDocList.Count, "Looking for connected sites in similar sites", LoadSpeed.fast);
                }

                Console.WriteLine();
                if (tmpList_Links.Count == 0)
                    WriteLine_MessageResponce($"We found {tmpList_Links.Count} connected websites in connected websites!", MessageType.bad);
                else WriteLine_MessageResponce($"We found {tmpList_Links.Count} connected websites in connected websites!", MessageType.good);
                return tmpList_Links;
            }
            else
            {
                WriteLine_MessageResponce("Make sure to specify ur type!", MessageType.bad);
                return null;
            }
        }


        //save the html site to the disk at a location, use ENUM for this
        public static void SaveSite(Uri siteHtmlCode, SaveLocations locationToSaveTo = SaveLocations.downloads)
        {
            htmlDoc = ParseSite(siteHtmlCode);

            string folder = string.Empty;
            string path = string.Empty;

            if (locationToSaveTo == SaveLocations.desktop)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
            else if (locationToSaveTo == SaveLocations.documents)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
            else if (locationToSaveTo == SaveLocations.downloads)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads" + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
        }
        public static void SaveSite(HtmlDocument websiteAsDocumentToSave, SaveLocations locationToSaveTo = SaveLocations.downloads)
        {
            htmlDoc = websiteAsDocumentToSave;

            string folder = string.Empty;
            string path = string.Empty;

            if (locationToSaveTo == SaveLocations.desktop)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
            else if (locationToSaveTo == SaveLocations.documents)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
            else if (locationToSaveTo == SaveLocations.downloads)
            {
                folder = "export";
                path = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads" + "\\" + folder);
                System.IO.Directory.CreateDirectory(path);
                htmlDoc.Save($"{path}\\file{DateTime.Now.Ticks}.html");
            }
        }


        //save image to desired location
        public static void SaveImage(List<Uri> imageURIs, SaveLocations locationToSaveTo = SaveLocations.downloads)
        {
            Console.WriteLine();
            using (WebClient downloaderClient = new WebClient())
            {
                if (locationToSaveTo == SaveLocations.desktop)
                {
                    string path = string.Empty;
                    try
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\images{DateTime.Now.Ticks}";
                        System.IO.Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        WriteLine_MessageResponce($"Issue creating image directory in {path}", MessageType.bad);
                    }
                    int x = 0;
                    
                    try
                    {
                        foreach (Uri imageLink in imageURIs)
                        {
                            int l = imageLink.Segments.Length - 1;
                            string name = $"{ x++ }{ imageLink.Segments[l]}";
                            if (!(imageLink.ToString().Contains("https:") || imageLink.ToString().Contains("http:")))
                                downloaderClient.DownloadFile("https:" + imageLink.OriginalString, path + $"\\{name}");
                            else downloaderClient.DownloadFile(imageLink.OriginalString, path + $"\\{name}");
                            Loading_Percent(x, imageURIs.Count, $"Downloading Images to {path}", LoadSpeed.fast);
                        }
                    }
                    catch
                    {
                    }
                    Console.WriteLine();
                    Console.WriteLine($"printed {x} images");
                }

                else if (locationToSaveTo == SaveLocations.documents)
                {
                    string path = string.Empty;
                    try
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\images{DateTime.Now.Ticks}";
                        System.IO.Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        WriteLine_MessageResponce($"Issue creating image directory in {path}", MessageType.bad);
                    }
                    int x = 0;

                    try
                    {
                        foreach (Uri imageLink in imageURIs)
                        {
                            int l = imageLink.Segments.Length - 1;
                            string name = $"{ x++ }{ imageLink.Segments[l]}";
                            downloaderClient.DownloadFile("https:" + imageLink.OriginalString, path + $"\\{name}");
                            Loading_Percent(x, imageURIs.Count, $"Downloading Images to {path}", LoadSpeed.fast);
                        }
                    }
                    catch
                    {
                    }
                    Console.WriteLine();
                    Console.WriteLine($"printed {x} images");
                }

                else if (locationToSaveTo == SaveLocations.downloads)
                {
                    string path = string.Empty;
                    try
                    {
                        path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads" + $"\\images{DateTime.Now.Ticks}";
                        System.IO.Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        WriteLine_MessageResponce($"Issue creating image directory in {path}", MessageType.bad);
                    }
                    int x = 0;

                    try
                    {
                        foreach (Uri imageLink in imageURIs)
                        {
                            int l = imageLink.Segments.Length - 1;
                            string name = $"{ x++ }{ imageLink.Segments[l]}";
                            downloaderClient.DownloadFile("https:" + imageLink.OriginalString, path + $"\\{name}");
                            Loading_Percent(x, imageURIs.Count, $"Downloading Images to {path}", LoadSpeed.fast);
                        }
                    }
                    catch
                    {
                    }
                    Console.WriteLine();
                    Console.WriteLine($"printed {x} images");
                }

                else WriteLine_MessageResponce("Please specify a save location!", MessageType.bad);
            }
        }


        //save information as txt file
        public static void SaveAsTxt(List<string> informationToSave, SaveLocations locationToSaveTo)
        {
            string fileName = $"\\txtExport{DateTime.Now.Ticks}";
            if (locationToSaveTo == SaveLocations.desktop)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{fileName}"))
                {
                    foreach (string s in informationToSave)
                        writer.WriteLine(s);
                }
            }
            else if (locationToSaveTo == SaveLocations.documents)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{fileName}"))
                {
                    foreach (string s in informationToSave)
                        writer.WriteLine(s);
                }
            }
            else if (locationToSaveTo == SaveLocations.downloads)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads"}{fileName}"))
                {
                    foreach (string s in informationToSave)
                        writer.WriteLine(s);
                }
            }
            else WriteLine_MessageResponce("Please enter a location!", MessageType.bad);
        }
        public static void SaveAsTxt(List<Uri> informationToSave, SaveLocations locationToSaveTo)
        {
            string fileName = $"\\txtExport{DateTime.Now.Ticks}";
            if (locationToSaveTo == SaveLocations.desktop)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{fileName}"))
                {
                    foreach (Uri s in informationToSave)
                        writer.WriteLine(s.ToString());
                }
            }
            else if (locationToSaveTo == SaveLocations.documents)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}{fileName}"))
                {
                    foreach (Uri s in informationToSave)
                        writer.WriteLine(s.ToString());
                }
            }
            else if (locationToSaveTo == SaveLocations.downloads)
            {
                using (StreamWriter writer = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\downloads"}{fileName}"))
                {
                    foreach (Uri s in informationToSave)
                        writer.WriteLine(s.ToString());
                }
            }
            else WriteLine_MessageResponce("Please enter a location!", MessageType.bad);
        }


        //methdos for displaying information
        public static void DisplayInformation(List<string> listToDisplay)
        {
            Console.WriteLine("Info Display:\n");
            foreach (string s in listToDisplay)
            {
                Console.Write(s);
                Console.WriteLine();        //space after link/paragraph
            }
            Console.WriteLine();
        }
        public static void DisplayInformation(List<Uri> listToDisplay)
        {
            Console.WriteLine("Info Display:\n");
            foreach (Uri s in listToDisplay)
            {
                Console.Write(s.ToString());
                Console.WriteLine();        //space after link/paragraph
            }
            Console.WriteLine();
        }


        //for displaying progress in a function (great for loops)
        public static void Loading_Percent(double startValue, double endValue, string displayText, LoadSpeed speed)
        {
            double percentValue = (startValue / endValue) * 100;
            string message = $"{displayText}: {(int)percentValue}%";// /{100}
            Console.Write(message);
            if (speed == LoadSpeed.slow)
                Thread.Sleep(100);
            else if (speed == LoadSpeed.fast)
                Thread.Sleep(1);
            foreach (char c in message)
                Console.Write("\b");
        }
        public static void Loading(int startValue, int endValue, string displayText)
        {
            string message = $"{displayText}: {startValue}/{endValue}";
            Console.Write(message);
            Thread.Sleep(50);
            foreach (char c in message)
                Console.Write("\b");
        }
        
        
        //used for writing responce lines, either good or bad, to the User
        public static string WriteLine_MessageResponce(string message, MessageType messageType)
        {
            Console.WriteLine();
            switch (messageType)
            {
                case MessageType.good:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return message;

                case MessageType.bad:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return message;

                default://WHY AM I RETURNING A STRING AGAIN???
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return message;
            }
        }
        public static void WriteLine_MenuOption(string menuMessageToDisplay)
        {
            Console.WriteLine();                                        //add a clear line of space
            Console.ForegroundColor = ConsoleColor.DarkCyan;            //change to menu text color
            Console.WriteLine(menuMessageToDisplay);                    //diplay the menu text
            Console.ForegroundColor = ConsoleColor.Cyan;                //reset the console color
            Console.WriteLine();                                        //add another clear line of space after menu line
        }
        
        
        //used for taking the Users input
        public static string InputLine_UserInput()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string userInput = Console.ReadLine();
            //Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            return userInput;
        }
    }
}
