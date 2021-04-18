using System;

namespace _07CreationalPatterns_DependancyInjection
{
    public class ConsolePrinter : IPrintService
    {
        private IDocumentService document;
        public ConsolePrinter(IDocumentService document)
        {
            this.document = document;
        }
        public void Print(string path)
        {
            Console.WriteLine(document.ReadDocument(path));
        }
    }
}