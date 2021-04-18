namespace _13StructuralPatterns_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSender text = new TextSender();
            IMessageSender web = new WebServiceSender();

            Message message = new SystemMessage();
            message.Subject = "A Message";
            message.Body = "Hi there, Please accept this message.";

            message.MessageSender = text;
            message.Send();
            //Text
            //--------------
            //Subject:  A Message from Text
            //Body:  Hi there, Please accept this message.

            message.MessageSender = web;
            message.Send();
            //Web Service
            //--------------
            //Subject:  A Message from Web Service
            //Body:  Hi there, Please accept this message.
        }
    }
}