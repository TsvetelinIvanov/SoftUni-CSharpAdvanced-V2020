using System;

namespace _18BehavioralPatterns_TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Document Reader - PDF doc ----");//---- Document Reader - PDF doc ----
            DocumentReader documenteReader = new PDFDocument();
            documenteReader.OpenDocument();
            //Document File loaded
            //Document file is processed with PDF Interpreter
            //Document File opens

            Console.WriteLine("---- Document Reader - RTF doc ----");//---- Document Reader - RTF doc ----
            documenteReader = new RTFDocument();
            documenteReader.OpenDocument();
            //Document File loaded
            //Document file is processed with RTF Interpreter
            //Document File opens
        }
    }
}