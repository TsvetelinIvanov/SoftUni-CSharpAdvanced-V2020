using System;

namespace _18BehavioralPatterns_TemplateMethod
{
    public class RTFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with RTF Interpreter");
        }
    }
}