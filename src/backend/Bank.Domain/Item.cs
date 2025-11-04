using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank.Domain
{
    public class Item
    {

        public Item() { }
        private Item(string _positionld, string _productId, string _clientId, DateTime _date, decimal _value, decimal _quantity)
        {
            positionId = _positionld;
            productId = _productId;
            clientId = _clientId;
            date = _date;
            value =    _value;
            quantity = _quantity;

        }

        public string positionId { get;  set; }
        public string productId { get;  set; }
        public string clientId { get;  set; }
        public DateTime date { get;  set; }
        public decimal value { get;  set; }
        public decimal quantity { get;  set; }


    }
}
