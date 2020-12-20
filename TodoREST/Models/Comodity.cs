using System;

namespace CryptoGrabber
{

    // for CryptoNator API
    public class Comodity
    {
        public int ID { get; set; }
        public DateTime datetime { get; set; }
        public string name { get; set; }
        public string category { get; set; }        // "Goldbarren"
        public string weight { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string price_per_gram { get; set; }
    }

}
