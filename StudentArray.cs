using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    public class StudentArray
    {
        private Student[] students;
        private static int objectCount = 0;

        //Конструктор без параметров
        public StudentArray()
        {
            students = new Student[0];
            objectCount++;
        }

        //Конструктор с параметрами
        public StudentArray(int size)
        {
            if (size <= 0)
            {
                throw new Exception("Размер должен быть больше нуля");
            }

            students = new Student[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                students[i] = new Student("Student" + (i + 1), rand.Next(18, 22), rand.NextDouble() * 10);
            }
            objectCount++;
        }

        //Конструктор копирования
        public StudentArray(StudentArray orig)
        {
            if (orig == null || orig.students == null)
            {
                throw new Exception("Kоллекция не может быть пустой.");
            }

            students = new Student[orig.students.Length];
            for (int i = 0; i < orig.students.Length; i++)
            {
                students[i] = new Student(orig.students[i].Name, orig.students[i].Age, orig.students[i].Gpa);
            }
            objectCount++;
        }

        //Индексатор
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Length)
                    throw new Exception("Индекс вне диапазона массива");
                return students[index];
            }
            set
            {
                if (index < 0 || index >= students.Length)
                    throw new Exception("Индекс вне диапазона массива");
                students[index] = value;
            }
        }

        public int Count => students.Length;

        //Вывод элементов
        public string PrintElements()
        {
            StringBuilder outputOfStudents = new StringBuilder();
            for (int i = 0; i < students.Length; i++)
            {
                outputOfStudents.AppendLine($"Имя: {students[i].Name}, Возраст: {students[i].Age}, GPA: {students[i].Gpa}");
            }
            return outputOfStudents.ToString();
        }

        //Счетчик объектов
        public static int GetObjectCount()
        {
            return objectCount;
        }

        public Student FindOldestStudentWithHighGPA()
        {
            Student oldest = null;
            foreach (var student in students)
            {
                if (student.Gpa > 8)
                {
                    if (oldest == null || student.Age > oldest.Age)
                    {
                        oldest = student;
                    }
                }
            }
            return oldest ?? throw new Exception("Нет студентов с GPA > 8");
        }
    }
}
