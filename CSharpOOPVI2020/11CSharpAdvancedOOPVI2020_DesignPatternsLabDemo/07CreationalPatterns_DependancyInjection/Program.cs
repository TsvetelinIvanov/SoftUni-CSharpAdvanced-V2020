using Microsoft.Extensions.DependencyInjection;

namespace _07CreationalPatterns_DependancyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IPrintService, ConsolePrinter>()
                .AddSingleton<IDocumentService, PdfService>()
                .BuildServiceProvider();

            //do the actual work here
            IPrintService printer = serviceProvider.GetService<IPrintService>();
            printer.Print("C:/Files/test.pdf");//PDF document content from path C:/Files/test.pdf
        }
    }
}