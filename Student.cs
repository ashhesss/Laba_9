using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_9
{
    public class Student
    {
        private string name;
        private int age;
        private double gpa;

        private static int studentCount;

        public Student()
        {
            name = "NoName";
            age = 18;
            gpa = 0.0;
            studentCount++;
        }

        public Student(string name, int age, double gpa)
        {
            Name = name;
            Age = age;
            Gpa = gpa;
            studentCount++;
        }


        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Имя не должно быть пустым");
                }
                else
                {
                    name = value;
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                    throw new Exception("Возраст должен быть натуральным числом");
                else { age = value; }
            }
        }

        public double Gpa
        {
            get => gpa;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Средний балл не может быть отрицательным");
                }
                else
                {
                    gpa = value;
                }
            }
        }

        public static int StudentCount
        {
            get { return studentCount; }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, GPA: {gpa}");
        }

        // Сравнение двух студентов (нестатическая)
        public string CompareStudents(Student otherStudent)
        {
            string ageComparison = "";
            string gpaComparison = "";

            if (this.age < otherStudent.age)
            {
                ageComparison = $"{this.name} младше {otherStudent.name}. ";
            }
            else if (this.age > otherStudent.age)
            {
                ageComparison = $"{this.name} старше {otherStudent.name}. ";
            }
            else
            {
                ageComparison = $"{this.name} ровесник {otherStudent.name}. ";
            }

            if (this.gpa < otherStudent.gpa)
            {
                gpaComparison = $"GPA {this.name} ниже GPA {otherStudent.name}.";
            }
            else if (this.gpa > otherStudent.gpa)
            {
                gpaComparison = $"GPA {this.name} выше GPA {otherStudent.name}.";
            }
            else
            {
                gpaComparison = $"GPA {this.name} равен GPA {otherStudent.name}.";
            }

            return ageComparison + gpaComparison;
        }

        // Статическая функция для сравнения двух студентов
        public static string CompareStudentsStatic(Student student1, Student student2)
        {
            string ageComparison = "";
            string gpaComparison = "";

            if (student1.age < student2.age)
            {
                ageComparison = $"{student1.name} младше {student2.name}. ";
            }
            else if (student1.age > student2.age)
            {
                ageComparison = $"{student1.name} старше {student2.name}. ";
            }
            else
            {
                ageComparison = $"{student1.name} ровесник {student2.name}. ";
            }

            if (student1.gpa < student2.gpa)
            {
                gpaComparison = $"GPA {student1.name} ниже GPA {student2.name}.";
            }
            else if (student1.gpa > student2.gpa)
            {
                gpaComparison = $"GPA {student1.name} выше GPA {student2.name}.";
            }
            else
            {
                gpaComparison = $"GPA {student1.name} равен GPA {student2.name}.";
            }
            return ageComparison + gpaComparison;
        }

        public static Student operator ~(Student s)
        {
            if (string.IsNullOrEmpty(s.Name)) return s;
            return new Student(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.Name.ToLower()), s.Age, s.Gpa);
        }

        public static Student operator ++(Student s)
        {
            s.Age++;
            return s;
        }

        // Операции приведения типа
        public static explicit operator int(Student s)
        {
            if (s.Age >= 18 && s.Age <= 22)
            {
                return s.Age - 17; // Номер курса
            }
            else if (s.Age > 22)
            {
                return -1; // Флаг невозможности определения курса
            }
            else
            {
                return 0; // Студент моложе 18 лет
            }
        }

        public static implicit operator bool(Student s)
        {
            return s.Gpa < 6;
        }

        // Бинарные операции
        public static Student operator %(Student s, string newName)
        {
            return new Student(newName, s.Age, s.Gpa);
        }

        public static Student operator -(Student s, double d)
        {
            s.Gpa -= d;
            return s;
        }


        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj is Student other)
            {
                return this.Name == other.Name && this.Age == other.Age && this.Gpa == other.Gpa;
            }
            return false;
        }

    }
}
