﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace KijijiAdNotify {
    class KijijiFloater : KjijijScraperInterface {
        //I thought floater would represent how this bot
        //floats on kjiji scraping and filtering to notify
        //the user. probably gonna rename later.
        //TODO add filtering for price after getting listing
        //TODO tidy up the code and implement some delegates for alert code
        //TODO make the program alert you


        public List<Listing> donkeyDick(ScrapeOptions options, ScrapeParameters parameters, bool cancelRequested) {
            //make list of new listings ince you called
            List<Listing> listA = ScrapeKijiji(parameters);
            List<Listing> listC = new List<Listing>();

            while (!cancelRequested) {

                Thread.Sleep(300000);

                List<Listing> listB = ScrapeKijiji(parameters);

                //Scan for new listings using URL as an ID 
                foreach (Listing elemB in listB) {
                    bool isMatch = false;
                    foreach (Listing elemA in listA.Where(elemA => elemA.Url == elemB.Url)) {
                        isMatch = true;
                    }
                    if (!isMatch) listC.Add(elemB);
                }

                listA = listB;
            }

            return listC;
        }

        public void alert(ScrapeOptions options, ScrapeParameters parameters, bool cancelRequested) {
            //make list of new listings ince you called
            List<Listing> listA = ScrapeKijiji(parameters);

            while (!cancelRequested) {
                Thread.Sleep(60000);

                List<Listing> listB = ScrapeKijiji(parameters);

                //Scan for new listings using URL as an ID 
                foreach (Listing elemB in listB) {

                    bool isMatch = false;
                    foreach (Listing elemA in listA.Where(elemA => elemA.Url == elemB.Url)) {
                        isMatch = true;
                    }

                    if (!isMatch) {
                        Console.WriteLine(elemB.Title);
                        Console.WriteLine(elemB.Url);
                        Console.WriteLine();
                    }
                }

                listA = listB;
            }

        }
    }
}
