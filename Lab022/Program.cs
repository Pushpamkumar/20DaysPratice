using System;
using System.Collections.Generic;
using System.Linq;

// ================================================================
// Student class
// Represents one student in the roster.
// ================================================================
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Marks { get; set; }

    public Student(int id, string name, double marks)
    {
        Id = id;
        Name = name;
        Marks = marks;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Marks: {Marks:F2}";
    }
}


// ================================================================
// ByNameComparer
//
// Custom comparer used to sort students alphabetically by name.
// ================================================================
public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
        if (x == null && y == null)
            return 0;

        if (x == null)
            return -1;

        if (y == null)
            return 1;

        return string.Compare(
            x.Name,
            y.Name,
            StringComparison.OrdinalIgnoreCase
        );
    }
}


// ================================================================
// Lab 2
// ================================================================
public class Lab2
{
    // Generic List<Student> is appropriate because:
    // - It provides type safety.
    // - It supports easy adding/removing/updating.
    // - It supports built-in sorting.
    static List<Student> students = new List<Student>();


    // ============================================================
    // AddStudent
    // Adds a student to the roster.
    // ============================================================
    static void AddStudent(Student student)
    {
        students.Add(student);
    }


    // ============================================================
    // RemoveStudent
    // Removes a student using the student's ID.
    // ============================================================
    static bool RemoveStudent(int id)
    {
        Student student = students.Find(s => s.Id == id);

        if (student == null)
        {
            return false;
        }

        students.Remove(student);
        return true;
    }


    // ============================================================
    // UpdateMarks
    // Updates marks for the student with the given ID.
    // ============================================================
    static bool UpdateMarks(int id, double newMarks)
    {
        Student student = students.Find(s => s.Id == id);

        if (student == null)
        {
            return false;
        }

        student.Marks = newMarks;
        return true;
    }


    // ============================================================
    // GetTopStudent
    // Returns the student with the highest marks.
    // ============================================================
    static Student GetTopStudent()
    {
        if (students.Count == 0)
        {
            return null;
        }

        return students
            .OrderByDescending(s => s.Marks)
            .First();
    }


    // ============================================================
    // PrintRoster
    // Prints all students.
    // ============================================================
    static void PrintRoster()
    {
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }


    public static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("LAB 2 - STUDENT ROSTER");
        Console.WriteLine("========================================");

        // ========================================================
        // ADD STUDENTS
        // ========================================================

        Console.WriteLine("\n--- Adding Students ---");

        AddStudent(new Student(1, "Alice", 88.5));
        AddStudent(new Student(2, "Bob", 92.0));
        AddStudent(new Student(3, "Charlie", 79.5));
        AddStudent(new Student(4, "David", 95.0));

        PrintRoster();


        // ========================================================
        // UPDATE MARKS
        // ========================================================

        Console.WriteLine("\n--- Updating Bob's Marks ---");

        bool updated = UpdateMarks(2, 96.5);

        Console.WriteLine(
            updated
                ? "Marks updated successfully."
                : "Student not found."
        );

        PrintRoster();


        // ========================================================
        // REMOVE STUDENT
        // ========================================================

        Console.WriteLine("\n--- Removing Student ID 3 ---");

        bool removed = RemoveStudent(3);

        Console.WriteLine(
            removed
                ? "Student removed successfully."
                : "Student not found."
        );

        PrintRoster();


        // ========================================================
        // TOP STUDENT
        // ========================================================

        Console.WriteLine("\n--- Top Student ---");

        Student topStudent = GetTopStudent();

        if (topStudent != null)
        {
            Console.WriteLine(topStudent);
        }


        // ========================================================
        // SORT BY MARKS - DESCENDING
        // ========================================================
        // List<T>.Sort accepts a Comparison<T> delegate.
        // A lambda is used here for custom sorting.
        // ========================================================

        Console.WriteLine("\n--- Sorted by Marks (Descending) ---");

        students.Sort(
            (a, b) => b.Marks.CompareTo(a.Marks)
        );

        PrintRoster();


        // ========================================================
        // SORT BY NAME - ASCENDING
        // ========================================================
        // This time we use a separate IComparer<Student> class.
        // ========================================================

        Console.WriteLine("\n--- Sorted by Name (Ascending) ---");

        students.Sort(new ByNameComparer());

        PrintRoster();
    }
}