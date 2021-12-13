using System;
//for the time delays
using System.Threading;
//for all comands
using Arachne_Framework;
//
using System.Collections.Generic;

namespace Arachne_Crawler
{                                                   //AFTER DONE ERROR CHECKING WRAP WHOLE THING IN A TRY CATCH FOR FATAL ERRORS, THEN ADD UP LINES OF CODE ####
    public class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Notes:
             * Next time I think it would be pretty cool to have a spider nest, then have it so different
             * spiders in the nest (spider objects) can do different things. Would be like characters (pretty cool)!
             * 
             * Also:
             * I should make the image extractors better at extracting images from blogs.
             * I think webp images might be tricky for it
             * 
             * Also:
             * I should make it so it doesn't push you to the main menu every time you make a mistake
             * 
             * Also:
             * I should figure out why on red/bad messages is sometimes adds lots of blank lines
             * 
             * Also:
             * I should make sure there are loading functions in all the places that might cause a pause and concearn User
             * 
             * Also:
             * I should make it so if the fatal error try catch fires then it prints a txt to the desktop.
             * The user can sent that txt file to me and it will have the error message that it failed on!
             * 
             */

            /* Demo Test Websites */
            //Uri wikiSite01 = new Uri("https://en.wikipedia.org/wiki/Main_Page");
            //Uri wikiSite02 = new Uri("https://en.wikipedia.org/wiki/War");
            //Uri interestingReadingConspicaryThing = new Uri("https://www.nytimes.com/2021/12/09/technology/birds-arent-real-gen-z-misinformation.html?utm_source=pocket-newtab");
            //Uri website_withEmails = new Uri("https://www.leadsplease.com/email-lists/consumer");                       //^^^birds are just goverment survelance
            //Uri website_withEmails02 = new Uri("https://en.wikipedia.org/wiki/Gmail");                                  //bout 2k sources here
            //Uri website_withEmails_Local = new Uri("https://en.wikipedia.org/wiki/Gmail");                              //local tatoo place

            //Console.ForegroundColor = ConsoleColor.Cyan;

            /* Demo Loading Functions (Examples 1 & 2) */
            //for (int i = 1; i < 430; i++)
            //{
            //    spider_Arachne.Loading_Percent(i, 430, "Demo Loading", spider_Arachne.LoadSpeed.fast);       //mencion the 2 speeds for timer_percent
            //}
            //for (int i = 1; i < 430; ++i)
            //{
            //    spider_Arachne.Loading(i, 430, "Demo Loading");
            //}

            ///* Demo Search Links */
            //List<Uri> tmpListOfUri_Demo01_01 = spider_Arachne.SearchFor_Links(website, spider_Arachne.SearchParameters.MatchingHostName);       //LEVEL 0 SEARCH
            //List<Uri> tmpListOfUri_Demo01_02 = spider_Arachne.SearchFor_Links(website, spider_Arachne.SearchParameters.InsideSite);             //LEVEL 1 SEARCH
            //List<Uri> tmpListOfUri_Demo01_03 = spider_Arachne.SearchFor_Links(website, spider_Arachne.SearchParameters.OutsideSite);            //LEVEL 2 SEARCH

            ///* Demo Data Search */
            //spider_Arachne.SearchFor_Data_UrPick_InText(website_withEmails, spider_Arachne.SearchParameters.OutsideSite, /*"the"*//*"@"*/"ASK FOR SHUGGESTION");        //LEVEL 2 SEARCH
            //spider_Arachne.SearchFor_NamesOfConnectedSites(website_withEmails, spider_Arachne.SearchParameters.OutsideSite);                                            //LEVEL 2 SEARCH

            ///* Demo Download Images (LEVEL 1 SEARCH) */
            //List<Uri> tmpListOfUri_Demo02 = spider_Arachne.SearchFor_ImageLinks(wikiSite01, spider_Arachne.SearchParameters.InsideSite);
            //spider_Arachne.SaveImage(tmpListOfUri_Demo02, spider_Arachne.SaveLocations.desktop);
            //spider_Arachne.SaveImage(tmpListOfUri_Demo02, spider_Arachne.SaveLocations.documents);
            //spider_Arachne.SaveImage(tmpListOfUri_Demo02, spider_Arachne.SaveLocations.downloads);


            //EVERYTHING COMMENTED OUT UNTIL WE ARE READY TO RUN


            try
            {
                Console.Title = "Arachne Crawler";
                spider_Arachne.ShowMenu();
                Console.ForegroundColor = ConsoleColor.Cyan;

                bool goodWebsite = false;       //
                bool success = false;           //
                do
                {
                    Uri targetWebsite_Link = null;
                    while (goodWebsite != true)
                    {
                        spider_Arachne.WriteLine_MenuOption("What is the Target/Orgin Website for Arachne?");
                        string targetWebsite_UserText = spider_Arachne.InputLine_UserInput();

                        if (!targetWebsite_UserText.Contains("https://"))
                            spider_Arachne.WriteLine_MessageResponce("Please enter valid URL/URI!", spider_Arachne.MessageType.bad);
                        else
                        {
                            if (targetWebsite_UserText.Contains("http://") && !targetWebsite_UserText.Contains("https://"))
                                Console.WriteLine("Target website is not secure, but we will parse anyway!");

                            //arbatraty delay
                            Console.WriteLine();
                            Console.WriteLine("Searching for Webpage!");
                            for (int i = 0; i < 2; i++)
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

                            targetWebsite_Link = new Uri(targetWebsite_UserText);
                            spider_Arachne.targetSite = new Uri(targetWebsite_UserText);
                            spider_Arachne.WriteLine_MessageResponce($"Your website from {targetWebsite_Link.Host} is acceptable!", spider_Arachne.MessageType.good);
                            goodWebsite = true;
                        }
                    }

                    spider_Arachne.WriteLine_MenuOption("What should Arachne look for in her crawl?");

                    Console.WriteLine("[1] Look for Links!");                                                   //easily expandable menu/choices/options
                    Console.WriteLine("[2] Look for Words, Chars, or Phrases!");                                //Note To Self: I want to keep expanding 
                    Console.WriteLine("[98] Change Website");                                                   //this programs options in the future!
                    Console.WriteLine("[99] End Program...");

                    string userPick = spider_Arachne.InputLine_UserInput();

                    switch (userPick)
                    {
                        case "1":
                            spider_Arachne.WriteLine_MenuOption("Link Spider Options:");
                            Console.WriteLine("[1] Crawl for Links within the site!");
                            Console.WriteLine("[2] Crawl for Links a step outside the site!");
                            Console.WriteLine("[3] Crawl for Image Links within the site!");
                            Console.WriteLine("[4] Crawl for Image Links a step outside the site!");
                            Console.WriteLine("[5] Crawl for Names of Connected Sites within the site!");
                            Console.WriteLine("[6] Crawl for Names of Connected Sites outside the site!");
                            Console.WriteLine("[99] Past menu!");

                            string userResponce_op1 = spider_Arachne.InputLine_UserInput();

                            if (string.IsNullOrEmpty(userResponce_op1) || string.IsNullOrWhiteSpace(userResponce_op1))
                                spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                            else
                            {
                                List<Uri> tmpDisplayList_uri = new List<Uri>();         //some methods return different types of lists

                                List<string> tmpDisplayList_str = new List<string>();   //^^^ and that is why I have 2 (last 2 ops)

                                if (userResponce_op1 == "1")
                                {
                                    tmpDisplayList_uri = spider_Arachne.SearchFor_Links(targetWebsite_Link, spider_Arachne.SearchParameters.InsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Text File To Desktop!");
                                    Console.WriteLine("[3] Export as Text File To Documents!");
                                    Console.WriteLine("[4] Export as Text File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_uri);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "2")
                                {
                                    tmpDisplayList_uri = spider_Arachne.SearchFor_Links(targetWebsite_Link, spider_Arachne.SearchParameters.OutsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Text File To Desktop!");
                                    Console.WriteLine("[3] Export as Text File To Documents!");
                                    Console.WriteLine("[4] Export as Text File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_uri);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_uri, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "3")
                                {
                                    tmpDisplayList_uri = spider_Arachne.SearchFor_ImageLinks(targetWebsite_Link, spider_Arachne.SearchParameters.InsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Image File To Desktop!");
                                    Console.WriteLine("[3] Export as Image File To Documents!");
                                    Console.WriteLine("[4] Export as Image File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_uri);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "4")
                                {
                                    tmpDisplayList_uri = spider_Arachne.SearchFor_ImageLinks(targetWebsite_Link, spider_Arachne.SearchParameters.OutsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Image File To Desktop!");
                                    Console.WriteLine("[3] Export as Image File To Documents!");
                                    Console.WriteLine("[4] Export as Image File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_uri);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveImage(tmpDisplayList_uri, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "5")
                                {
                                    tmpDisplayList_str = spider_Arachne.SearchFor_NamesOfConnectedSites(targetWebsite_Link, spider_Arachne.SearchParameters.InsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Text File To Desktop!");
                                    Console.WriteLine("[3] Export as Text File To Documents!");
                                    Console.WriteLine("[4] Export as Text File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_str);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "6")
                                {
                                    tmpDisplayList_str = spider_Arachne.SearchFor_NamesOfConnectedSites(targetWebsite_Link, spider_Arachne.SearchParameters.OutsideSite);

                                    spider_Arachne.WriteLine_MenuOption("View/Export Options:");
                                    Console.WriteLine("[1] View in CLI!");
                                    Console.WriteLine("[2] Export as Text File To Desktop!");
                                    Console.WriteLine("[3] Export as Text File To Documents!");
                                    Console.WriteLine("[4] Export as Text File To Downloads!");
                                    Console.WriteLine("[5] Don't Export!");

                                    string userResponce_Links_op1 = spider_Arachne.InputLine_UserInput();

                                    if (string.IsNullOrEmpty(userResponce_Links_op1) || string.IsNullOrWhiteSpace(userResponce_Links_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                    {
                                        if (userResponce_Links_op1 == "1")
                                        {
                                            spider_Arachne.DisplayInformation(tmpDisplayList_str);
                                        }
                                        else if (userResponce_Links_op1 == "2")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.desktop);
                                        }
                                        else if (userResponce_Links_op1 == "3")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.documents);
                                        }
                                        else if (userResponce_Links_op1 == "4")
                                        {
                                            spider_Arachne.SaveAsTxt(tmpDisplayList_str, spider_Arachne.SaveLocations.downloads);
                                        }
                                        else if (userResponce_Links_op1 == "5") { }
                                        else spider_Arachne.WriteLine_MessageResponce("Please Select a Valid Option!", spider_Arachne.MessageType.bad);
                                    }
                                }
                                else if (userResponce_op1 == "99") Console.WriteLine("Returning to Previous Menu!");
                                else spider_Arachne.WriteLine_MessageResponce("Choose an acceptable option!", spider_Arachne.MessageType.bad);
                            }

                            break;

                        case "2":
                            spider_Arachne.WriteLine_MenuOption("Data Spider Options:");
                            Console.WriteLine("[1] Crawl within the site!");
                            Console.WriteLine("[2] Crawl a step outside the site!");
                            Console.WriteLine("[99] Past menu!");

                            string userResponce_op2 = spider_Arachne.InputLine_UserInput();

                            if (string.IsNullOrEmpty(userResponce_op2) || string.IsNullOrWhiteSpace(userResponce_op2))
                                spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                            else
                            {
                                if (userResponce_op2 == "1")
                                {
                                    Console.WriteLine("Enter Data!");
                                    string userResponce_Data_op1 = spider_Arachne.InputLine_UserInput();
                                    if (string.IsNullOrEmpty(userResponce_Data_op1) || string.IsNullOrWhiteSpace(userResponce_Data_op1))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                        spider_Arachne.SearchFor_Data_UrPick_InText(targetWebsite_Link, spider_Arachne.SearchParameters.InsideSite, userResponce_Data_op1);
                                }
                                else if (userResponce_op2 == "2")
                                {
                                    Console.WriteLine("Enter Data!");
                                    string userResponce_Data_op2 = spider_Arachne.InputLine_UserInput();
                                    if (string.IsNullOrEmpty(userResponce_Data_op2) || string.IsNullOrWhiteSpace(userResponce_Data_op2))
                                        spider_Arachne.WriteLine_MessageResponce("Please Enter an acceptable value", spider_Arachne.MessageType.bad);
                                    else
                                        spider_Arachne.SearchFor_Data_UrPick_InText(targetWebsite_Link, spider_Arachne.SearchParameters.OutsideSite, userResponce_Data_op2);
                                }
                                else if (userResponce_op2 == "99") Console.WriteLine("Returning to Previous Menu!");
                                else spider_Arachne.WriteLine_MessageResponce("Choose an acceptable option!", spider_Arachne.MessageType.bad);
                            }

                            break;

                        case "3":

                            break;

                        case "98":
                            goodWebsite = false;
                            continue;

                        case "99":
                            //user is done with program for now
                            success = true;
                            //clear console
                            Console.Clear();
                            break;

                        //defualt option if not satisfied
                        default:
                            spider_Arachne.WriteLine_MessageResponce("Please seelct a valid option:", spider_Arachne.MessageType.bad);
                            break;
                    }

                } while (success != true);

                //close program
                spider_Arachne.GoodbyeMenu();
            }
            catch (Exception mg)
            {
                spider_Arachne.WriteLine_MessageResponce($"Well this is really to bad... A fatel error has occured! Contact me and give me '{mg}', you don't have to know what it is!", spider_Arachne.MessageType.bad);
            }
        }
    }
}
