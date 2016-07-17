using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_4._1_struct
{
    struct Article
    {
        public int productID;
        public string productName;
        public decimal productPrice;
    }

    struct Client
    {
        public int clientID;
        public Name clientName;
        public Address clientAddress;
        public string clientTelephone;
        public int ordersHistoryQuantity;
        public decimal ordersHistorySum;

        public struct Name
        {
            public string firstName;
            public string middleName;
            public string lastName;
        }

        public struct Address
        {
            public string country;
            public string city;
            public string street;
            public int buildingNumber;
        }
    }

    struct RequestItem
    {
        public Article product;
        public int quantity;
    }

    struct Request
    {
        public int requestID;
        public Client client;
        public DateTime orderDate;
        public List<RequestItem> requestItemList;
        private decimal OrderSum
        {
            get
            {
                decimal sum = 0;
                for (int i = 0; i < requestItemList.Count(); i++)
                {
                    sum += (requestItemList[i].product.productPrice * requestItemList[i].quantity);
                }
                return sum;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
