using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvisIpsum.Models
{
    public class WordProvider : IWordProvider
    {
        // Used to avoid repeating 2 consecutive words
        private int lastChoice = -1;

        static String[] words = new String[] { "Avis", "car", "hire", "extras", "insurance", "waiver", "book", "now", "zero excess",
            "satnav", "flat tyre", "Terms and Conditions", "Bracknell", "unlimited mileage", "driver", "upgrade", "vehicle",
            "pay now", "pay later", "3 minute promise", "loyalty", "delivers", "pick up", "drop off", "winter tyres", "child seat",
            "airport", "Wizard", "service", "damage", "return", "order", "booking", "rental", "duration", "payment method", "AWD",
            "customer", "experience", "satisfaction", "you", "Preferred", "Preferred First", "Preferred First Plus"}.Distinct ().ToArray<string>();
        static Random random = new Random ();

        public string GetRandomWord ()
        {
            int newChoice;
            
            do {
                newChoice=random.Next(words.Count());
            }
            while (newChoice == lastChoice);
            
            lastChoice = newChoice;

            return words[newChoice];
        }
    }
}