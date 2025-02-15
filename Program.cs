using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Laba_9
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Задание №1");
            // Создание объектов Student с использованием разных конструкторов

            //Пустой конструктор
            try
            {
                Student student1 = new Student();
                student1.PrintInfo();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            //Конструктор с параметрами
            try
            {
                Student student2 = new Student("Alice", 20, 3.8);
                student2.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Student student3 = new Student("bob", 20, 3.5);

            //Конструктор с копированием объекта
            try
            {
                //Student student4 = new Student(student3);
                //student4.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Проверка исключительных ситуаций

            //Ошибка имени
            try
            {
                Student studentTest1 = new Student(" ", 0, 0);
                studentTest1.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании объекта studentTest1: {ex.Message}");
            }

            //Ошибка возраста
            try
            {
                Student studentTest2 = new Student("Aaron", -5, 3.5);
                studentTest2.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании объекта studentTest2: {ex.Message}");
            }

            //Ошибка Gpa
            try
            {
                Student studentTest3 = new Student("Ethan", 18, -5.35325);
                studentTest3.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании объекта studentTest3: {ex.Message}");
            }


            Student student5 = new Student("Alex", 19, 4.3);
            // Использование метода класса для сравнения (не статического)
            string comparisonResult1 = student3.CompareStudents(student5);
            Console.WriteLine("\nРезультат сравнения student3 и student5 (метод класса):");
            Console.WriteLine(comparisonResult1);


            // Использование статической функции для сравнения
            string comparisonResult2 = Student.CompareStudentsStatic(student3, student5);
            Console.WriteLine("\nРезультат сравнения student3 и student5 (статическая функция):");
            Console.WriteLine(comparisonResult2);

            // Вывод количества созданных объектов
            Console.WriteLine($"\nКоличество созданных объектов Student: {Student.StudentCount}");

            //Перегрузка операций

            Console.WriteLine("\nЗадание №2");

            //Перегрузка операции ~
            Student student6 = ~student3;
            student6.PrintInfo();

            //Перегрузка операции ++
            Student student7 = ++student6;
            student7.PrintInfo();

            //Явное преобрзование
            int courseNum = (int)student7;
            Console.WriteLine($"Номер курса: {courseNum}");

            //Неявное преобразование
            bool studentMark = student3;
            Console.WriteLine($"GPA < 6?: {studentMark}");

            //Бинарные операции

            Student newNameStudent = student7 % "Anthony";
            newNameStudent.PrintInfo();

            Student student8 = newNameStudent - 2;
            student8.PrintInfo();

            //Часть 3
            Console.WriteLine("\nЗадание №3");
            //Конструктор без параметров
            StudentArray students0 = new StudentArray();

            //Конструктор с параметром
            StudentArray students1 = new StudentArray(5); //Случайное генерирование
            Console.WriteLine("Сгенерированные студенты:");
            //Ручное заполнение первых 3 студентов
            students1[0] = new Student("Steve", 20, 5.6);
            students1[1] = new Student("Ann", 18, 7.89);
            students1[2] = new Student("Mike", 23, 3.515);
            students1.PrintElements();

            //Нахождение самого старшего студента с GPA > 8
            try
            {
                Student oldest = students1.FindOldestStudentWithHighGPA();
                Console.WriteLine($"Самый старший студент с GPA > 8: {oldest.Name}, Возраст: {oldest.Age}, GPA: {oldest.Gpa}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Копирование
            try
            {
                StudentArray students2 = new StudentArray(students1);
                Console.WriteLine("Копия студентов:");
                students2.PrintElements();

                //Проверка глубокого копирования
                students1[3] = new Student("Sigma", 22, 5.2); //Изменили элемент в оригинальной коллекции
                Console.WriteLine("\nОригинальная коллекция:");
                students1.PrintElements();
                Console.WriteLine("\nКопия коллекции:");
                students2.PrintElements();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании коллекции: {ex.Message}");
            }

            Console.WriteLine($"Общее количество созданных объектов: {StudentArray.GetObjectCount()}");

            // Проверка индексатора
            try
            {
                //Существующий индекс
                students1[0] = new Student("John", 25, 9);
                Console.WriteLine($"Обновленный студент: {students1[0].Name}");

                //Получение объекта за пределом массива
                Student test = students1[10];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine("\nЗапись индекса за пределами массива");
                students1[6] = new Student("Billie", 25, 1.23);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
