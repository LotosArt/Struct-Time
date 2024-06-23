using System.Diagnostics;

namespace HomeWorkStruct;

class Program
{
    static void Main(string[] args)
    {
        // 1.
        // Train train1 = new Train("123A", new DateTime(2024, 6, 23, 12, 0, 0), new DateTime(2024, 6, 23, 8, 0, 0), "North", 400);
        // Train train2 = new Train("456B", new DateTime(2024, 6, 23, 15, 30, 0), new DateTime(2024, 6, 23, 10, 0, 0), "East", 500);

        // Console.WriteLine(train1);
        // Console.WriteLine(train2);
        
        // 2.
        // Country[] countries = new[]
        // {
        //     new Country("France", "Paris"),
        //     new Country("Germany", "Berlin"),
        //     new Country("Italy", "Rome"),
        //     new Country("Spain", "Madrid"),
        //     new Country("United Kingdom", "London")
        // };
        // int correct = 0;
        // for (int i = 0; i < countries.Length; i++)
        // {
        //     Console.WriteLine("The capital of {0} is ", countries[i].Name);
        //     string answer = Console.ReadLine();
        //     if (countries[i].Capital.Equals(answer))
        //     {
        //         correct++;
        //     }
        // }
        //
        // Console.WriteLine("Count of correct answers is {0}", correct);
        
        // 3.
        // Console.WriteLine("Count of students: ");
        // int cnt = int.Parse(Console.ReadLine());
        // if (cnt < 1)
        // {
        //     Console.WriteLine("Wrong number");
        // }
        // else
        // {
        //     Student[] students = new Student[cnt];
        //     for (int i = 0; i < cnt; i++)
        //     {
        //         Console.WriteLine("Student name: ");
        //         string name = Console.ReadLine();
        //         Console.WriteLine("Student lastname: ");
        //         string lastname = Console.ReadLine();
        //         Console.WriteLine("Student grade: ");
        //         double grade = double.Parse(Console.ReadLine());
        //
        //         students[i] = new Student() { Name = name, Lastname = lastname, Grade = grade };
        //     }
        //
        //     
        //     double avgGrade = 0;
        //     double sumGrade = 0;
        //     for (int i = 0; i < students.Length; i++)
        //     {
        //         sumGrade += students[i].Grade;
        //     }
        //
        //     avgGrade = sumGrade / students.Length;
        //
        //     for (int i = 0; i < students.Length; i++)
        //     {
        //         if (students[i].Grade >= avgGrade)
        //         {
        //             Console.WriteLine(students[i].Name + " " + students[i].Lastname + " " + students[i].Grade);
        //         }
        //     }
        // }
        
        // 4.
        Random random = new Random();
        string[] names = { "Alice", "Bob", "Charlie", "David", "Eve", "Frank", "Grace", "Hannah", "Ivy", "Jack" };

        User[] users = new User[1000000];
        
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new User
            {
                Name = names[random.Next(names.Length)],
                Phone = random.Next(1000000000, 1999999999).ToString()
            };
        }
        User[] usersForArraySort = (User[])users.Clone();
        User[] usersForBubbleSort = (User[])users.Clone();

        Stopwatch stopwatch = new Stopwatch();

        // Array.Sort
        stopwatch.Start();
        Array.Sort(usersForArraySort, (x, y) => x.Name.CompareTo(y.Name));
        stopwatch.Stop();
        Console.WriteLine("Array.Sort time: " + stopwatch.ElapsedMilliseconds + " ms");

        // Bubble Sort
        stopwatch.Restart();
        BubbleSort(usersForBubbleSort);
        stopwatch.Stop();
        Console.WriteLine("Bubble Sort time: " + stopwatch.ElapsedMilliseconds + " ms");
        
    }
    
    static void BubbleSort(User[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j].Name.CompareTo(array[j + 1].Name) > 0)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}

// 1. Описать структуру Train, со следующими полями: № поезда, время прибытия, время отбытия, направление, расстояние.
// Вывести среднюю скорость каждого поезда.
//
struct Train(string trainNumber, DateTime arrivalTime, DateTime departureTime, string direction, double distance)
{
    public string Num { get; set; } = trainNumber;
    public DateTime Arrival { get; set; } = arrivalTime;
    public DateTime Departure { get; set; } = departureTime;
    public string Direction { get; set; } = direction;
    private double Distance { get; set; } = distance;
    
    public double CalculateAverageSpeed()
    {
        return Distance / (Arrival - Departure).TotalHours;
    }

    public override string ToString()
    {
        return $"Train {Num}, Direction: {Direction}, Distance: {Distance} km, Average Speed: {CalculateAverageSpeed():F2} km/h";
    }
}


// 2. На основе структуры, реализовать игру – пользователю выводится название страны, пользователь указывает
// столицу страны (необходимо выбрать правильный ответ из 3-ех вариантов). После отображения страны, ее больше
// не использовать. Огласить количество правильных ответов.
//
struct Country
{
    public string Name;
    public string Capital;

    public Country(string name, string capital)
    {
        Name = name;
        Capital = capital;
    }
}

// 3. Пользователь вводит данные о количестве студентов, их фамилии, имена и балл для каждого. Программа должна
// определить средний балл и вывести фамилии и имена студентов, чей балл выше среднего. Предусмотреть все возможные
// исключительные ситуации в программе.
//
struct Student
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public double Grade { get; set; }
}
// 4. Создать класс пользователь: id, name, phone. Создать массив класса на 1 млн. значений. Заполнить с помощью
// генератора случайных чисел (имя подставлять случайное из перечисленных в отдельном массиве). 
// Отсортировать 2 способами: 
// 1) Array.Sort 
// 2) Пузырьковая сортировка или сортировка вставками. Используя Stopwatch, замерить время сортировок и определить, ту,
// которая сортирует быстрее.
public class User
{
    public string Id = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Phone { get; set; }
}

