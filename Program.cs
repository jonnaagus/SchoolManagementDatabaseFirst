using Microsoft.EntityFrameworkCore;
using SchoolManagementDatabaseFirst.Models;
using System.Linq;

// Elev: Jonna Gustafsson
// Klass: .NET23

namespace SchoolManagementDatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new SchoolDatabaseContext();

            while (true)
            {
                // Meny som användaren får välja från
                Console.WriteLine("Välkommen till Skolbyns databas!");
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine("1. Hämta personal");
                Console.WriteLine("2. Hämta alla elever");
                Console.WriteLine("3. Hämta elever i en viss klass");
                Console.WriteLine("4. Hämta betyg senaste månaden");
                Console.WriteLine("5. Hämta snittbetyg per kurs");
                Console.WriteLine("6. Lägg till ny elev");
                Console.WriteLine("7. Lägg till ny personal");
                Console.WriteLine("8. Avsluta programmet");

                int choice = int.Parse(Console.ReadLine());

                // Lägg till mellanrum för att öka läsbarheten
                Console.WriteLine("************************************************");

                switch (choice)
                {
                    case 1:
                        // Hämta personal
                        Console.WriteLine("1. Alla anställda");
                        Console.WriteLine("2. Teachers");
                        Console.WriteLine("3. Staffs");
                        int categoryChoice = int.Parse(Console.ReadLine());


                        if (categoryChoice == 1)
                        {
                            // Hämta alla anställda
                            var teachersData = dbContext.Teachers
                                                .Select(t => new { Id = t.TeacherId, Firstname = t.FirstName, Lastname = t.LastName, Place = t.Position })
                                                .ToList();

                            var staffsData = dbContext.Staffs
                                                .Select(s => new { Id = s.StaffId, Firstname = s.FirstName, Lastname = s.LastName, Place = s.Position })
                                                .ToList();

                            if (teachersData != null && staffsData != null)
                            {
                                var allEmployees = teachersData.Concat(staffsData);

                                // Skriv ut resultaten
                                foreach (var employee in allEmployees)
                                {
                                    Console.WriteLine($"ID: {employee.Id}, Firstname: {employee.Firstname}, Lastname: {employee.Lastname}, Place: {employee.Place}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Det uppstod ett problem vid hämtning av anställda.");
                            }
                        }
                        else if (categoryChoice == 2)
                        {
                            // Hämta lärare
                            var teachers = dbContext.Teachers
                                            .Select(t => new { Id = t.TeacherId, Firstname = t.FirstName, Lastname = t.LastName, Place = t.Position })
                                            .ToList();

                            if (teachers != null)
                            {
                                // Skriv ut resultaten
                                foreach (var teacher in teachers)
                                {
                                    Console.WriteLine($"ID: {teacher.Id}, Firstname: {teacher.Firstname}, Lastname: {teacher.Lastname}, Place: {teacher.Place}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Det uppstod ett problem vid hämtning av lärare.");
                            }
                        }
                        else if (categoryChoice == 3)
                        {
                            // Hämta personal
                            var staffs = dbContext.Staffs
                                            .Select(s => new { Id = s.StaffId, Firstname = s.FirstName, Lastname = s.LastName, Place = s.Position })
                                            .ToList();

                            if (staffs != null)
                            {
                                // Skriv ut resultaten
                                foreach (var staff in staffs)
                                {
                                    Console.WriteLine($"ID: {staff.Id}, Firstname: {staff.Firstname}, Lastname: {staff.Lastname}, Place: {staff.Place}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Det uppstod ett problem vid hämtning av personal.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        }
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 2:
                        // Hämta alla elever
                        Console.WriteLine("1. Sortera efter förnamn");
                        Console.WriteLine("2. Sortera efter efternamn");
                        int sortChoice = int.Parse(Console.ReadLine());

                        // Hämta och sortera elever baserat på val
                        var students = dbContext.Students.OrderBy(s => sortChoice == 1 ? s.FirstName : s.LastName).ToList();

                        // Skriv ut resultaten
                        foreach (var student in students)
                        {
                            Console.WriteLine($"ID: {student.StudentID}, Firstname: {student.FirstName}, Lastname: {student.LastName}");
                        }
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 3:
                        // Hämta elever i en viss klass
                        Console.WriteLine("Välj en klass:");

                        // Visa en lista med alla unika klasser från Student-tabellen
                        var uniqueClasses = dbContext.Students
                                               .Select(s => s.Class)
                                               .Distinct()
                                               .ToList();

                        // Skriv ut klasserna för användaren att välja
                        for (int i = 0; i < uniqueClasses.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {uniqueClasses[i]}");
                        }

                        // Låt användaren välja en klass
                        int classChoice = int.Parse(Console.ReadLine());

                        if (classChoice >= 1 && classChoice <= uniqueClasses.Count)
                        {
                            // Hämta elever baserat på vald klass
                            var selectedClass = uniqueClasses[classChoice - 1];
                            var studentsInClass = dbContext.Students
                                                    .Where(s => s.Class == selectedClass)
                                                    .ToList();

                            // Skriv ut eleverna i den valda klassen
                            Console.WriteLine($"Elever i klass {selectedClass}:");
                            foreach (var student in studentsInClass)
                            {
                                Console.WriteLine($"ID: {student.StudentID}, Firstname: {student.FirstName}, Lastname: {student.LastName}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        }
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 4:
                        // Hämta betyg senaste månaden
                        DateTime lastMonth = DateTime.Now.AddMonths(-1);

                        // Hämta betyg baserat på datum och inkludera information om elev och kurs
                        var gradesLastMonth = dbContext.Grades
                                                .Where(g => g.GradeDate >= lastMonth)
                                                .Include(g => g.Student)
                                                .Include(g => g.Course)
                                                .ToList();

                        // Skriv ut resultaten
                        Console.WriteLine("Betyg satta den senaste månaden:");
                        foreach (var grade in gradesLastMonth)
                        {
                            string studentName = grade.Student != null ? $"{grade.Student.FirstName} {grade.Student.LastName}" : "N/A";
                            string courseName = grade.Course != null ? grade.Course.CourseName : "N/A";

                            Console.WriteLine($"ID: {grade.GradeId}, Student: {studentName}, Course: {courseName}, Grade: {grade.Value}, Date: {grade.GradeDate}");
                        }
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 5:
                        // Hämta snittbetyg per kurs
                        var averageGradesPerCourse = dbContext.Grades
                            .Include(g => g.Course)  
                            .ToList()  
                            .GroupBy(g => g.Course)
                            .Select(group => new
                            {
                                Course = group.Key.CourseName,  
                                AverageGrade = group.Average(g => CalculateNumericGrade(g.Value)) 
                            })
                            .ToList();

                        // Skriv ut resultaten
                        Console.WriteLine("Snittbetyg per kurs:");
                        foreach (var avgGrade in averageGradesPerCourse)
                        {
                            Console.WriteLine($"Kurs: {avgGrade.Course}, Snittbetyg: {avgGrade.AverageGrade}");
                        }

                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 6:
                        // Lägga till nya elever
                        Console.WriteLine("Lägg till ny elev:");

                        Console.Write("Förnamn: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Efternamn: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Personnummer: ");
                        string personalIdNr = Console.ReadLine();

                        Console.Write("Klass: ");
                        string sClass = Console.ReadLine();

                        // Generera ett slumpmässigt och unikt StudentId
                        int newStudentId;
                        do
                        {
                            newStudentId = new Random().Next(10, 10000);
                        } while (dbContext.Students.Any(s => s.StudentID == newStudentId));

                        // Skapa en ny elev och lägg till den i DbSet
                        var newStudent = new Student
                        {
                            StudentID = newStudentId,
                            FirstName = firstName,
                            LastName = lastName,
                            PersonalIdnr = personalIdNr,
                            Class = sClass,

                        };

                        dbContext.Students.Add(newStudent);

                        // Spara ändringarna i databasen
                        dbContext.SaveChanges();

                        Console.WriteLine("En ny elev har lagts till i databasen.");
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 7:
                        // Lägga till ny personal
                        Console.WriteLine("Lägg till ny personal:");

                        // Användaren får mata in uppgifter om den nya personalen
                        Console.Write("Förnamn: ");
                        string _firstName = Console.ReadLine();

                        Console.Write("Efternamn: ");
                        string _lastName = Console.ReadLine();

                        Console.Write("Position (t.ex. Teacher, Staff): ");
                        string position = Console.ReadLine();

                        // Generera ett slumpmässigt och unikt PersonalId som fungerar för Teacher och Staff
                        int newPersonalId;
                        do
                        {
                            newPersonalId = new Random().Next(1000, 10000);
                        } while (dbContext.Teachers.Any(t => t.TeacherId == newPersonalId) || dbContext.Staffs.Any(s => s.StaffId == newPersonalId));

                        // Skapa ny personal och lägg till i DbSet baserat på position
                        if (position.Equals("Teacher", StringComparison.OrdinalIgnoreCase))
                        {
                            var newTeacher = new Teacher
                            {
                                TeacherId = newPersonalId,
                                FirstName = _firstName,
                                LastName = _lastName,
                                Position = position
                            };
                            dbContext.Teachers.Add(newTeacher);
                        }
                        else if (position.Equals("Staff", StringComparison.OrdinalIgnoreCase))
                        {
                            var newStaff = new Staff
                            {
                                StaffId = newPersonalId,
                                FirstName = _firstName,
                                LastName = _lastName,
                                Position = position
                            };
                            dbContext.Staffs.Add(newStaff);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltig position. Vänligen försök igen.");
                            break;
                        }

                        // Spara ändringarna i databasen
                        dbContext.SaveChanges();

                        Console.WriteLine("Ny personal har lagts till i databasen.");
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    case 8:
                        // Avsluta programmet
                        Environment.Exit(0);
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.WriteLine("************************************************");
                        break;

                }
            }
        }

        private static decimal CalculateNumericGrade(string value)
        {
            switch (value.ToUpper())
            {
                case "A":
                    return 4.0m;
                case "B":
                    return 3.0m;
                case "C":
                    return 2.0m;
                case "D":
                    return 1.0m;
                case "F":
                    return 0.0m;
                default:
                    // Hantera andra fall eller kasta ett undantag för ogiltiga betyg
                    throw new ArgumentException("Ogiltit betygsvärde", nameof(value));
            }
        }
    }
}