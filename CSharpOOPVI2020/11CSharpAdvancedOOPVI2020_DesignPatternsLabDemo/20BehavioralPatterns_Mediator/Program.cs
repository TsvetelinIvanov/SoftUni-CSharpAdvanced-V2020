namespace _20BehavioralPatterns_Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatroom chatroom = new Chatroom();

            Participant Eddie = new Actor("Eddie");
            Participant Jennifer = new Actor("Jennifer");
            Participant Bruce = new Actor("Bruce");
            Participant Tom = new Actor("Tom");
            Participant Tony = new NonActor("Tony");

            chatroom.Register(Eddie);
            chatroom.Register(Jennifer);
            chatroom.Register(Bruce);
            chatroom.Register(Tom);
            chatroom.Register(Tony);

            Tony.Send("Tom", "Hey Tom! I got a mission for you.");//To an Actor: Tony to Tom: 'Hey Tom! I got a mission for you.'
            Jennifer.Send("Bruce", "Teach me to act and I'll teach you to dance");//To an Actor: Jennifer to Bruce: 'Teach me to act and I'll teach you to dance'
            Bruce.Send("Eddie", "How come you don't do standup anymore?");//To an Actor: Bruce to Eddie: 'How come you don't do standup anymore?'
            Jennifer.Send("Tom", "Do you like math?");//To an Actor: Jennifer to Tom: 'Do you like math?'
            Tom.Send("Tony", "Teach me to sing.");//To a non-Actor: Tom to Tony: 'Teach me to sing.'
        }
    }
}