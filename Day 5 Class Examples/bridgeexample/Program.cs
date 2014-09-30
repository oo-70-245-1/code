using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bridgeexample
{
    class Program
    {
        public interface IMessageSender
        {
            void SendMessage(string subject, string body);
        }

        public abstract class Message
        {
            public IMessageSender MessageSender { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public abstract void Send();
        }

        public class SystemMessage : Message
        {
            public override void Send()
            {
                MessageSender.SendMessage(Subject, Body);
            }
        }

        public class UserMessage : Message
        {
            public string UserComments { get; set; }
            public override void Send()
            {
                string fullbody = string.Format("{0}\nUser Comments:{1}", Body, UserComments);
                MessageSender.SendMessage(Subject, fullbody);
            }
        }

        public class EmailSender : IMessageSender
        {
            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
            }
        }

        public class MSMQSender : IMessageSender
        {
            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("MSMQ\n{0}\n{1}\n", subject, body);
            }
        }

        public class WebServiceSender : IMessageSender
        {

            public void SendMessage(string subject, string body)
            {
                Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
            }
        }

        static void Main(string[] args)
        {
            IMessageSender email = new EmailSender();
            IMessageSender queue = new MSMQSender();
            IMessageSender web = new WebServiceSender();

            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "This is a test message";
            message.MessageSender = email;
            message.Send();

            message.MessageSender = queue;
            message.Send();

            message.MessageSender = web;
            message.Send();

            UserMessage usermsg = new UserMessage();
            usermsg.Subject = "Test user message";
            usermsg.Body = "This is a test user message";
            usermsg.UserComments = "C# is awesome!";

            usermsg.MessageSender = email;
            usermsg.Send();
        }
    }
}
