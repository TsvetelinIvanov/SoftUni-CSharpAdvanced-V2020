namespace _23BehavioralPatterns_Interpreter
{
    public class Context
    {        
        public Context(string input)
        {
            this.Input = input;
        }

        public string Input { get; set; }

        public int Output { get; set; }
    }
}