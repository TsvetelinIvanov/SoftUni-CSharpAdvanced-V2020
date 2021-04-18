using System;

namespace _18BehavioralPatterns_TemplateMethod
{
    public class PDFDocument : DocumentReader
    {
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with PDF Interpreter");
        }
    }
}