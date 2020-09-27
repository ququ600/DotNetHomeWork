using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
namespace _20200921
{
    public class Order
    {
        public OrderDetails details;
        public Order(string orderNo, string goodName, string clientName, double orderPrice)
        {
            this.details.orderNo = orderNo;
            this.details.goodName = goodName;
            this.details.clientName = clientName;
            this.details.orderPrice = orderPrice;
        }
        public override bool Equals(object obj)
        { Order order = obj as Order;
            return order != null && order.details.clientName == details.clientName &&
                order.details.orderNo == details.orderNo && order.details.goodName == details.goodName
                && order.details.orderPrice == details.orderPrice;
        }
        public override int GetHashCode()
        {
            return int.Parse(details.orderNo);
        }
        public override string ToString()
        {
            return "订单号:" + details.orderNo + " 商品名:" + details.goodName 
                + " 客户名:" + details.clientName
                + " 价格:" + details.orderPrice.ToString();
        }
    }
    public class OrderDetails
    {
        public string orderNo;
        public string goodName;
        public string clientName;
        public double orderPrice;
        public OrderDetails(string orderNo,string goodName,string clientName, double orderPrice)
        {
            this.orderNo = orderNo;
            this.goodName = goodName;
            this.clientName = clientName;
            this.orderPrice = orderPrice;
        }
    }
    [Serializable]
    public class OrderService
    {
        private List<Order> orderList;
        public void AddOrder(Order order) {
            orderList.Add(order);
        }
        public void DeleteOrder(int n)
        {
            try
            {
                orderList.RemoveAt(n);
            }
            catch(ArrayTypeMismatchException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }

        }
        public void ChangeOrder(string orderNo,Order order)
        {
            try
            {
                var orderToChange = orderList.Where(c => c.details.orderNo == orderNo).FirstOrDefault();
                orderToChange = order;
            }
            catch(ArrayTypeMismatchException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
        }
        public void SearchOrderByNo(string orderNo)
        {
            var order = from orders in orderList
                        where orders.details.orderNo == orderNo
                        orderby orders.details.orderPrice
                        select orders;
        }
        public void SearchOrderByName(string goodName)
        {
            var order = from orders in orderList
                        where orders.details.goodName == goodName
                        orderby orders.details.orderPrice
                        select orders;
        }
        public void SearchOrderByClient(string clientName)
        {
            var order = from orders in orderList
                        where orders.details.clientName == clientName
                        orderby orders.details.orderPrice
                        select orders;
        }
        public void SearchOrderByPrice(double orderPrice)
        {
            var order = from orders in orderList
                        where orders.details.orderPrice == orderPrice
                        orderby orders.details.orderPrice
                        select orders;
        }
        public void SortByOrderNo()
        {
            orderList = orderList.OrderBy(order => order.details.orderNo).ToList<Order>();
        }
        public void Export(object obj, string path)
        {
          
            XmlSerializer xz = new XmlSerializer(obj.GetType());
            string content = string.Empty;
            using(StringWriter writer = new StringWriter())
            {
                xz.Serialize(writer, obj);
                content = writer.ToString();
            }
            // save to file
            using(StreamWriter stream_writer = new StreamWriter(path))
            {
                stream_writer.Write(content);
            }
          
        }
        public object Import(string path,Type Object_type)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(Object_type);
            using(StreamReader reader = new StreamReader(path))
            {
                return xmlSerializer.Deserialize(reader);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
