using System;

namespace DocumentApp
{
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ відкритий");
        }
        public virtual void EditDocument()
        {
            Console.WriteLine("Редагування документа доступно у версії Про");
        }
        public virtual void SaveDocument()
        {
            Console.WriteLine("Збереження документа доступно у версії Про");
        }
    }
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Документ відредагований");
        }
        public override void SaveDocument()
        {
            Console.WriteLine("Документ збережений в старому форматі, збереження в новому форматі доступно у версії Експерт");
        }
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ збережений в новому форматі");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.Write("Введіть ключ доступу (pro / exp): ");
            string key = Console.ReadLine();
            DocumentWorker doc;

            if (key == "pro") doc = new ProDocumentWorker();
            else if (key == "exp") doc = new ExpertDocumentWorker();
            else doc = new DocumentWorker();

            doc.OpenDocument();
            doc.EditDocument();
            doc.SaveDocument();
        }
    }
}