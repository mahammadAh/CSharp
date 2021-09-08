using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.Json;
using Monefy;

namespace Monefy
{




    public class Rootobject
    {
        public string disclaimer { get; set; }
        public string date { get; set; }
        public int timestamp { get; set; }
        public string _base { get; set; }
        public Rates rates { get; set; }
    }

    public class Rates
    {
        public float AUD { get; set; }
        public float AZN { get; set; }
        public float GBP { get; set; }
        public float AMD { get; set; }
        public float BYN { get; set; }
        public float BGN { get; set; }
        public float BRL { get; set; }
        public float HUF { get; set; }
        public float HKD { get; set; }
        public float DKK { get; set; }
        public float USD { get; set; }
        public float EUR { get; set; }
        public float INR { get; set; }
        public float KZT { get; set; }
        public float CAD { get; set; }
        public float KGS { get; set; }
        public float CNY { get; set; }
        public float MDL { get; set; }
        public float NOK { get; set; }
        public float PLN { get; set; }
        public float RON { get; set; }
        public float XDR { get; set; }
        public float SGD { get; set; }
        public float TJS { get; set; }
        public float TRY { get; set; }
        public float TMT { get; set; }
        public float UZS { get; set; }
        public float UAH { get; set; }
        public float CZK { get; set; }
        public float SEK { get; set; }
        public float CHF { get; set; }
        public float ZAR { get; set; }
        public float KRW { get; set; }
        public float JPY { get; set; }
    }



    class CurrencyExchange
    {

        public float Exchange(string from , string to)
        {
            float coefficient = 1;


            WebClient web = new WebClient();
            string url = $"https://www.cbr-xml-daily.ru/latest.js";


            WebClient webClient = new WebClient();
            string response = webClient.DownloadString(url);
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(response);
            
          
            coefficient /= Search(result, from);
            coefficient *= Search(result, to);
            return coefficient;

        } // Метод конвертирующий валюту (на урове коэфицинета )

        private float Search (Rootobject result, string currencyName)
        {
            float coefficient = 1;

            switch (currencyName)
            {
                case "AUD":
                    coefficient = result.rates.AUD;
                    break;
                case "AZN":
                    coefficient = result.rates.AZN;
                    break;
                case "GBP":
                    coefficient = result.rates.GBP;
                    break;
                case "AMD":
                    coefficient = result.rates.AMD;
                    break;
                case "BYN":
                    coefficient = result.rates.BYN;
                    break;
                case "BGN":
                    coefficient = result.rates.BGN;
                    break;
                case "BRL":
                    coefficient = result.rates.BRL;
                    break;
                case "HUF":
                    coefficient = result.rates.HUF;
                    break;
                case "HKD":
                    coefficient = result.rates.HKD;
                    break;
                case "DKK":
                    coefficient = result.rates.DKK;
                    break;
                case "USD":
                    coefficient = result.rates.USD;
                    break;
                case "EUR":
                    coefficient = result.rates.EUR;
                    break;
                case "INR":
                    coefficient = result.rates.INR;
                    break;
                case "KZT":
                    coefficient = result.rates.KZT;
                    break;
                case "CAD":
                    coefficient = result.rates.CAD;
                    break;
                case "KGS":
                    coefficient = result.rates.KGS;
                    break;
                case "CNY":
                    coefficient = result.rates.CNY;
                    break;
                case "MDL":
                    coefficient = result.rates.MDL;
                    break;
                case "NOK":
                    coefficient = result.rates.NOK;
                    break;
                case "PLN":
                    coefficient = result.rates.PLN;
                    break;
                case "RON":
                    coefficient = result.rates.RON;
                    break;
                case "XDR":
                    coefficient = result.rates.XDR;
                    break;
                case "SGD":
                    coefficient = result.rates.SGD;
                    break;
                case "TJS":
                    coefficient = result.rates.TJS;
                    break;
                case "TRY":
                    coefficient = result.rates.TRY;
                    break;
                case "TMT":
                    coefficient = result.rates.TMT;
                    break;
                case "UZS":
                    coefficient = result.rates.UZS;
                    break;
                case "UAH":
                    coefficient = result.rates.UAH;
                    break;
                case "CZK":
                    coefficient = result.rates.CZK;
                    break;
                case "SEK":
                    coefficient = result.rates.SEK;
                    break;
                case "CHF":
                    coefficient = result.rates.CHF;
                    break;
                case "ZAR":
                    coefficient = result.rates.ZAR;
                    break;
                case "KRW":
                    coefficient = result.rates.KRW;
                    break;
                case "JPY":
                    coefficient = result.rates.JPY;
                    break;
                case "RUB":
                    coefficient = 1;
                    break;
                default:
                    break;
            }


            return coefficient;
        } // Метод для поиска нужной валюта и возвращающий его коэффицинет
    }
}
