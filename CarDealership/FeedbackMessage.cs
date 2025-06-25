using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership
{
    public class FeedbackMessage
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string MessageBody { get; set; }
        public DateTime ReceivedAt { get; set; }

        public FeedbackMessage(string fromName, string fromEmail, string messageBody)
        {
            FromName = fromName;
            FromEmail = fromEmail;
            MessageBody = messageBody;
            ReceivedAt = DateTime.Now;
        }
    }
}
