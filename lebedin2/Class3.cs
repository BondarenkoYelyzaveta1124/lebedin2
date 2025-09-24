using System;

namespace DocumentApp
{
    // Базовий клас
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

    // Похідний клас Pro
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

    // Похідний клас Expert
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

            Console.WriteLine("Введіть ключ доступу (pro / exp):");
            string key = Console.ReadLine();

            DocumentWorker worker;

            if (key == "pro")
            {
                worker = new ProDocumentWorker();
            }
            else if (key == "exp")
            {
                worker = new ExpertDocumentWorker();
            }
            else
            {
                worker = new DocumentWorker();
            }

            Console.WriteLine();
            worker.OpenDocument();
            worker.EditDocument();
            worker.SaveDocument();

            Console.ReadLine();
        }
    }
}
