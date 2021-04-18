﻿namespace _07CreationalPatterns_DependancyInjection
{
    public class PdfService : IDocumentService
    {
        public string ReadDocument(string path)
        {
            return "PDF document content from path " + path;
        }
    }
}