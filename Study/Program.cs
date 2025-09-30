using System;
using System.Collections.Generic;

namespace StudentsGroup
{
    class Student
    {
        public virtual void Study()
        {
            Console.WriteLine("Студент вчиться.");
        }
        public virtual void Program()
        {
            Console.WriteLine("Студент програмує.");
        }
        public virtual void PlayFootball()
        {
            Console.WriteLine("Студент грає у футбол.");
        }
    }
    class ExcellentStudent : Student
    {
        public override void Study()
        {
            Console.WriteLine("Вiдмiнник вчиться з натхненням i глибиною.");
        }
        public override void Program()
        {
            Console.WriteLine("Вiдмiнник програмує професiйно i якiсно.");
        }
        public override void PlayFootball()
        {
            Console.WriteLine("Вiдмiнник рiдко грає у футбол, бiльше часу навчається.");
        }
    }
    class GoodStudent : Student
    {
        public override void Study()
        {
            Console.WriteLine("Хороший студент вчиться старанно.");
        }
        public override void Program()
        {
            Console.WriteLine("Хороший студент програмує впевнено.");
        }
        public override void PlayFootball()
        {
            Console.WriteLine("Хороший студент iз задоволенням грає у футбол.");
        }
    }
    class BadStudent : Student
    {
        public override void Study()
        {
            Console.WriteLine("Поганий студент вчиться неохоче.");
        }
        public override void Program()
        {
            Console.WriteLine("Поганий студент програмує з помилками.");
        }
        public override void PlayFootball()
        {
            Console.WriteLine("Поганий студент бiльше грає у футбол, нiж вчиться.");
        }
    }
    class Group
    {
        private List<Student> students = new List<Student>();

        public Group(params Student[] members)
        {
            if (members.Length < 4)
                throw new ArgumentException("У групi має бути не менше 4 студентiв.");

            foreach (var student in members)
                students.Add(student);
        }
        public void ShowGroup()
        {
            Console.WriteLine("Iнформацiя про студентiв групи:");
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
        static void Main()
        {
            Group group = new Group(new ExcellentStudent(),new GoodStudent(),new GoodStudent(),new BadStudent());
            group.ShowGroup();
        }
    }
}