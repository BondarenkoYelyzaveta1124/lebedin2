using System;

namespace University
{
    class Student
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }

        public virtual void Study()
        {
            Console.WriteLine($"{Name} навчається звичайно.");
        }

        public virtual void Program()
        {
            Console.WriteLine($"{Name} програмує звичайно.");
        }

        public virtual void PlayFootball()
        {
            Console.WriteLine($"{Name} грає у футбол звичайно.");
        }
    }
    class ExcellentStudent : Student
    {
        public ExcellentStudent(string name) : base(name) { }

        public override void Study()
        {
            Console.WriteLine($"{Name} навчається відмінно!");
        }

        public override void Program()
        {
            Console.WriteLine($"{Name} програмує на високому рівні!");
        }

        public override void PlayFootball()
        {
            Console.WriteLine($"{Name} не дуже любить футбол, але може грати.");
        }
    }
    class GoodStudent : Student
    {
        public GoodStudent(string name) : base(name) { }

        public override void Study()
        {
            Console.WriteLine($"{Name} навчається добре.");
        }

        public override void Program()
        {
            Console.WriteLine($"{Name} програмує впевнено.");
        }

        public override void PlayFootball()
        {
            Console.WriteLine($"{Name} добре грає у футбол.");
        }
    }
    class BadStudent : Student
    {
        public BadStudent(string name) : base(name) { }

        public override void Study()
        {
            Console.WriteLine($"{Name} не дуже хоче вчитися.");
        }

        public override void Program()
        {
            Console.WriteLine($"{Name} майже не програмує.");
        }

        public override void PlayFootball()
        {
            Console.WriteLine($"{Name} відмінно грає у футбол!");
        }
    }
    class Group
    {
        private Student[] students;
        public Group(Student s1, Student s2, Student s3, Student s4)
        {
            students = new Student[] { s1, s2, s3, s4 };
        }

        public Group(Student s1, Student s2, Student s3, Student s4, params Student[] others)
        {
            students = new Student[4 + others.Length];
            students[0] = s1;
            students[1] = s2;
            students[2] = s3;
            students[3] = s4;

            for (int i = 0; i < others.Length; i++)
                students[4 + i] = others[i];
        }

        public void ShowGroupInfo()
        {
            Console.WriteLine("=== Інформація про групу ===");
            foreach (var student in students)
            {
                student.Study();
                student.Program();
                student.PlayFootball();
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new ExcellentStudent("Анна");
            var s2 = new GoodStudent("Іван");
            var s3 = new BadStudent("Петро");
            var s4 = new GoodStudent("Марія");
            var s5 = new ExcellentStudent("Олег");

            var group = new Group(s1, s2, s3, s4, s5);

            group.ShowGroupInfo();

            Console.ReadLine();
        }
    }
}
