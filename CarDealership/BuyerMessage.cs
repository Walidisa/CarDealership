using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class BuyerMessage
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string MessageBody { get; set; }
        public Car RelatedCar { get; set; }
        public DateTime ReceivedAt { get; set; }

        public BuyerMessage(string fromName, string fromEmail, string messageBody, Car relatedCar)
        {
            FromName = fromName;
            FromEmail = fromEmail;
            MessageBody = messageBody;
            RelatedCar = relatedCar;
            ReceivedAt = DateTime.Now;
        }
        public BuyerMessage(string fromName, string fromEmail, string messageBody)
        {
            FromName = fromName;
            FromEmail = fromEmail;
            MessageBody = messageBody;
            ReceivedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{ReceivedAt}] {FromName} wants to buy {RelatedCar.Make} {RelatedCar.Model}";
        }
    }
}
