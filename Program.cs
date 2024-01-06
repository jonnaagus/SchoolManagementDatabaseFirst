using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolManagementDatabaseFirst.Models;
using System.ComponentModel.Design;
using System.Data;
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

            Console.Title = "School Management System";

            // Visa en välkomstskärm
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*************************************************");
            Console.WriteLine("       Welcome to School Management System       ");
            Console.WriteLine("*************************************************");
            Console.ResetColor();

            // Fördröjning för en cool effekt
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            // Visa en laddningsskärm
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************************************************");
            Console.WriteLine("           Loading... Please wait!              ");
            Console.WriteLine("************************************************");
            Console.ResetColor();

            // Simulera arbete genom att vänta
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            // Visa att systemet är klart
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("************************************************");
            Console.WriteLine("         School Management System Ready!        ");
            Console.WriteLine("************************************************");

            // Lägg till mellanrum för att öka läsbarheten
            Console.WriteLine();
            Console.ResetColor();
            while (true)
            {
                // Meny som användaren får välja från                
                Console.WriteLine("Välj ett alternativ:");
                Console.WriteLine();
                Console.WriteLine("1. Hämta personal");
                Console.WriteLine("2. Hämta alla elever");
                Console.WriteLine("3. Hämta elever i en viss klass");
                Console.WriteLine("4. Hämta alla betyg satta senaste månaden");
                Console.WriteLine("5. Hämta snittbetyg per kurs");
                Console.WriteLine("6. Lägg till ny elev");
                Console.WriteLine("7. Lägg till ny personal");
                Console.WriteLine("8. Visa en lista på aktiva kurser");
                Console.WriteLine("9. Avsluta programmet");
                // Lägg till mellanrum för att öka läsbarheten
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------");
                Console.ResetColor();

                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Felaktig inmatning. Ange ett heltal.");
                    // Lägg till mellanrum för att öka läsbarheten
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("------------------------------------------------------");
                    Console.ResetColor();
                    continue; // Gå tillbaka till början av loopen
                                            
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("1. Alla anställda");
                        Console.WriteLine("2. Visa lärare");
                        Console.WriteLine("3. Visa personal");
                        Console.WriteLine("4. Visa antal lärare per avdelning");
                        Console.WriteLine("5. Visa den totala månadslönen per avdelning");
                        Console.WriteLine("6. Visa rektorer som varit/är anställda på skolan");
                        Console.WriteLine("7. Gå tillbaka till huvudmenyn");

                        try
                        {
                            int categoryChoice = int.Parse(Console.ReadLine());
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                            if (categoryChoice >= 1 && categoryChoice <= 7)
                            {
                                if (categoryChoice == 7)
                                {
                                    // Användaren väljer att gå tillbaka till huvudmenyn
                                    break; // Bryt loopen och återvänd till föregående meny
                                }
                                if (categoryChoice == 1)
                                {
                                    // Hämta alla anställda
                                    var teachersData = dbContext.Teachers
                                                         .Select(t => new { Id = t.TeacherID, Firstname = t.FirstName, Lastname = t.LastName, Place = t.Position, StartDate = t.StartDate })
                                                         .AsEnumerable();

                                    var staffsData = dbContext.Staffs
                                                         .Select(s => new { Id = s.StaffID, Firstname = s.FirstName, Lastname = s.LastName, Place = s.Position, StartDate = s.StartDate })
                                                         .AsEnumerable();

                                    var currentPrincipalData = dbContext.Principals
                                                          .Where(p => p.PrincipalID == 12) // PrincipalID 12 är nuvarande anställd
                                                          .Select(p => new { Id = p.PrincipalID, Firstname = p.FirstName, Lastname = p.LastName, Place = p.Position, StartDate = p.StartDate })
                                                          .AsEnumerable();

                                    if (teachersData != null && staffsData != null && currentPrincipalData != null)
                                    {
                                        var allEmployees = teachersData.Concat(staffsData).Concat(currentPrincipalData);

                                        // Skriv ut resultaten
                                        foreach (var employee in allEmployees)
                                        {
                                            Console.WriteLine($"ID: {employee.Id}, Firstname: {employee.Firstname}, Lastname: {employee.Lastname}, Place: {employee.Place}, StartDate: {employee.StartDate}");                                            
                                        }
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Det uppstod ett problem vid hämtning av anställda.");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }

                                }
                                else if (categoryChoice == 2)
                                {
                                    // Hämta lärare
                                    var teachers = dbContext.Teachers
                                                    .Select(t => new { Id = t.TeacherID, Firstname = t.FirstName, Lastname = t.LastName, Place = t.Position, StartDate = t.StartDate })
                                                    .ToList();

                                    if (teachers != null)
                                    {
                                        // Skriv ut resultaten
                                        foreach (var teacher in teachers)
                                        {
                                            Console.WriteLine($"ID: {teacher.Id}, Förnamn: {teacher.Firstname}, Efternamn: {teacher.Lastname}, Position: {teacher.Place}, Startdatum: {teacher.StartDate}");
                                        }
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Det uppstod ett problem vid hämtning av lärare.");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }

                                }
                                else if (categoryChoice == 3)
                                {
                                    // Hämta personal
                                    var staffs = dbContext.Staffs
                                                    .Select(s => new { Id = s.StaffID, Firstname = s.FirstName, Lastname = s.LastName, Place = s.Position, StartDate = s.StartDate })
                                                    .ToList();

                                    if (staffs != null)
                                    {
                                        // Skriv ut resultaten
                                        foreach (var staff in staffs)
                                        {
                                            Console.WriteLine($"ID: {staff.Id}, Förnamn: {staff.Firstname}, Efternamn: {staff.Lastname}, Position: {staff.Place}, Startdatum: {staff.StartDate}");
                                        }
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Det uppstod ett problem vid hämtning av personal.");
                                    }
                                    
                                }
                                else if (categoryChoice == 4)
                                {
                                    // Hämta antal lärare per avdelning
                                    var teachersPerPosition = dbContext.Teachers
                                        .GroupBy(t => t.Position)
                                        .Select(group => new { Position = group.Key, TeacherCount = group.Count() })
                                        .ToList();

                                    // Skriv ut resultaten
                                    foreach (var result in teachersPerPosition)
                                    {
                                        Console.WriteLine($"Avdelning: {result.Position}, Antal lärare: {result.TeacherCount}");
                                    }
                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();

                                }
                                else if (categoryChoice == 5)
                                {
                                    // Visa löner per avdelning per månad
                                    var teacherSalaries = dbContext.Teachers.GroupBy(t => t.Position, (key, group) => new { Position = key, TotalSalary = group.Sum(t => t.Salary) }).ToList();

                                    var staffSalaries = dbContext.Staffs.GroupBy(s => s.Position, (key, group) => new { Position = key, TotalSalary = group.Sum(s => s.Salary) }).ToList();

                                    // Skriv ut resultaten för lärare
                                    Console.WriteLine("Totala löner för lärare per avdelning:");
                                    foreach (var salary in teacherSalaries)
                                    {
                                        Console.WriteLine($"Avdelning: {salary.Position}, Total lön: {salary.TotalSalary}");
                                    }

                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();

                                    // Skriv ut medellönen för lärare separat
                                    var teacherAverageSalary = dbContext.Teachers.Average(t => t.Salary);
                                    Console.WriteLine($"Medellön för lärare: {teacherAverageSalary}");

                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();

                                    // Skriv ut resultaten för personal
                                    Console.WriteLine("Totala löner för personal per avdelning:");
                                    foreach (var salary in staffSalaries)
                                    {
                                        Console.WriteLine($"Avdelning: {salary.Position}, Total lön: {salary.TotalSalary}");
                                    }

                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();

                                    // Skriv ut medellönen för personal separat
                                    var staffAverageSalary = dbContext.Staffs.Average(s => s.Salary);
                                    Console.WriteLine($"Medellön för personal: {staffAverageSalary}");

                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();
                                }
                                else if (categoryChoice == 6)
                                {
                                    var principals = dbContext.Principals
                                        .Select(p => new { Id = p.PrincipalID, Firstname = p.FirstName, Lastname = p.LastName, Position = p.Position, StartDate = p.StartDate })
                                        .ToList();

                                    // Skriv ut resultaten och markera den nuvarande rektorn
                                    foreach (var principal in principals)
                                    {
                                        Console.WriteLine($"ID: {principal.Id}, Förnamn: {principal.Firstname}, Efternamn: {principal.Lastname}, Position: {principal.Position}, Startdatum: {principal.StartDate}");

                                        if (principal.Id == 12)
                                        {
                                            Console.WriteLine("Skolans nuvarande rektor");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Inte längre anställd");
                                        }

                                    }

                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();

                                }
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ogiltig inmatning. Ange ett heltal.");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Ogiltig inmatning. Det angivna värdet är för stort eller för litet.");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 2:
                        // Hämta alla elever
                        Console.WriteLine("1. Sortera efter förnamn");
                        Console.WriteLine("2. Sortera efter efternamn");

                        // Lägg till mellanrum för att öka läsbarheten
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------");
                        Console.ResetColor();

                        int sortChoice = 0;
                        try
                        {
                            sortChoice = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ogiltig inmatning för sortering. Ange ett heltal.");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                            break;
                        }

                        // Hämta och sortera elever baserat på val
                        try
                        {
                            var students = dbContext.Students.OrderBy(s => sortChoice == 1 ? s.FirstName : s.LastName).ToList();
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                            // Skriv ut resultaten
                            foreach (var student in students)
                            {
                                Console.WriteLine($"ID: {student.StudentID}, Förnamn: {student.FirstName}, Efternamn: {student.LastName}");
                                
                            }

                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                            // Undermeny för att hämta information om en specifik elev
                            Console.WriteLine("1. Hämta information om en specifik elev");
                            Console.WriteLine("2. Spara ner nya betyg");
                            Console.WriteLine("3. Gå tillbaka till huvudmenyn");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                            int submenuChoice = 0;
                            try
                            {
                                submenuChoice = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ogiltig inmatning för undermeny. Ange ett heltal.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                                break;
                            }
     
                            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";

                            if (submenuChoice == 3)
                            {
                                // Användaren väljer att gå tillbaka till huvudmenyn
                                break; // Hoppa ut från den aktuella undermenyn och återvänd till huvudmenyn
                            }

                            if (submenuChoice == 1)
                            {
                                Console.WriteLine("Ange StudentID för den elev du vill hämta information om:");

                                int studentId = 0;
                                try
                                {
                                    studentId = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ogiltig inmatning för StudentID. Ange ett heltal.");
                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();
                                    break;
                                }

                                // Anropa lagrad procedur för att hämta information om en specifik elev
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    try
                                    {
                                        connection.Open();

                                        using (SqlCommand command = new SqlCommand("GetStudentInfo", connection))
                                        {
                                            command.CommandType = CommandType.StoredProcedure;
                                            command.Parameters.AddWithValue("@StudentID", studentId);

                                            using (SqlDataReader reader = command.ExecuteReader())
                                            {
                                                if (reader.HasRows)
                                                {
                                                    while (reader.Read())
                                                    {
                                                        // Hämta och skriv ut informationen om den valda eleven
                                                        Console.WriteLine($"ID: {reader["StudentID"]}, Förnamn: {reader["FirstName"]}, Efternamn: {reader["LastName"]}, Personnummer: {reader["PersonalIdnr"]}, Klass: {reader["ClassName"]}");
                                                        // Lägg till mellanrum för att öka läsbarheten
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("------------------------------------------------------");
                                                        Console.ResetColor();
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"Ingen information hittades för student med ID {studentId}.");
                                                    // Lägg till mellanrum för att öka läsbarheten
                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                    Console.WriteLine("------------------------------------------------------");
                                                    Console.ResetColor();
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Det uppstod ett problem vid körning av lagrad procedur: {ex.Message}");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }
                                }
                            }
                            else if (submenuChoice == 2)
                            {
                                // Lägg till betyg för en elev i en kurs
                                Console.WriteLine("Ange StudentID för den elev du vill lägga till betyg för:");

                                int studentId = 0;
                                if (int.TryParse(Console.ReadLine(), out studentId) && studentId != 0)
                                {
                                    // Låt användaren välja kurs
                                    Console.WriteLine("Välj kurs:");
                                    var courses = dbContext.Courses.ToList();

                                    foreach (var course in courses)
                                    {
                                        Console.WriteLine($"{course.CourseID}. {course.CourseName}");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }

                                    int courseId = 0;
                                    try
                                    {
                                        courseId = int.Parse(Console.ReadLine());
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Ogiltig inmatning för kurs-ID. Ange ett heltal.");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                        break;
                                    }

                                    if (courseId != 0)
                                    {
                                        // Låt användaren välja lärare
                                        Console.WriteLine("Välj lärare:");
                                        var teachers = dbContext.Teachers.ToList();

                                        foreach (var teacher in teachers)
                                        {
                                            Console.WriteLine($"{teacher.TeacherID}. {teacher.FirstName} {teacher.LastName}");
                                            // Lägg till mellanrum för att öka läsbarheten
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("------------------------------------------------------");
                                            Console.ResetColor();
                                        }

                                        int teacherId = 0;
                                        try
                                        {
                                            teacherId = int.Parse(Console.ReadLine());
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Ogiltig inmatning för lärar-ID. Ange ett heltal.");
                                            // Lägg till mellanrum för att öka läsbarheten
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("------------------------------------------------------");
                                            Console.ResetColor();
                                            break;
                                        }

                                        if (teacherId != 0)
                                        {
                                            // Visa betygsskala för användaren
                                            Console.WriteLine("Betygsskala: A, B, C, D, E, F");

                                            // Låt användaren ange betyg
                                            Console.Write("Ange betyg: ");
                                            string gradeValue = Console.ReadLine().ToUpper(); // Gör om till versaler för att matcha betygsskalan

                                            // Kontrollera om betyget redan finns för den specifika kombinationen
                                            var existingGrade = dbContext.Grades
                                                .FirstOrDefault(g =>
                                                    g.FKTeacherID == teacherId &&
                                                    g.FKCourseID == courseId &&
                                                    g.FKStudentID == studentId &&
                                                    g.GradeValue == gradeValue);

                                            if (existingGrade == null)
                                            {
                                                // Generera ett slumpmässigt GradeID mellan 0 och 500
                                                int randomGradeId = new Random().Next(0, 501);

                                                // Skapa en ny Grade och spara den i databasen
                                                var gradeRecord = new Grade
                                                {
                                                    GradeId = randomGradeId,
                                                    FKTeacherID = teacherId,
                                                    FKCourseID = courseId,
                                                    FKStudentID = studentId,
                                                    GradeValue = gradeValue,
                                                    GradeDate = DateTime.Now // Använder aktuellt datum som standard
                                                };

                                                dbContext.Grades.Add(gradeRecord);
                                                dbContext.SaveChanges();

                                                // Hämta namnen för student, kurs och lärare
                                                var studentName = dbContext.Students
                                                    .Where(s => s.StudentID == studentId)
                                                    .Select(s => $"{s.FirstName} {s.LastName}")
                                                    .FirstOrDefault();

                                                var courseName = dbContext.Courses
                                                    .Where(c => c.CourseID == courseId)
                                                    .Select(c => c.CourseName)
                                                    .FirstOrDefault();

                                                var teacherName = dbContext.Teachers
                                                    .Where(t => t.TeacherID == teacherId)
                                                    .Select(t => $"{t.FirstName} {t.LastName}")
                                                    .FirstOrDefault();

                                                Console.WriteLine($"Betyget {gradeValue} har lagts till för student {studentName} i kurs {courseName} av lärare {teacherName}!");
                                                // Lägg till mellanrum för att öka läsbarheten
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("------------------------------------------------------");
                                                Console.ResetColor();
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Betyget {gradeValue} finns redan för den valda kombinationen av elev, kurs och lärare.");
                                                // Lägg till mellanrum för att öka läsbarheten
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("------------------------------------------------------");
                                                Console.ResetColor();
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ogiltigt lärar-ID.");
                                            // Lägg till mellanrum för att öka läsbarheten
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("------------------------------------------------------");
                                            Console.ResetColor();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ogiltigt kurs-ID.");
                                        // Lägg till mellanrum för att öka läsbarheten
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("------------------------------------------------------");
                                        Console.ResetColor();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ogiltigt student-ID.");
                                    // Lägg till mellanrum för att öka läsbarheten
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("------------------------------------------------------");
                                    Console.ResetColor();
                                }

                                
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 3:
                        try
                        {
                            // Hämta elever i en viss klass
                            Console.WriteLine("Välj en klass:");

                            // Visa en lista med alla unika klasser från Student-tabellen
                            var uniqueClasses = dbContext.Students
                                                   .Select(s => s.ClassName)
                                                   .Distinct()
                                                   .ToList();

                            // Skriv ut klasserna för användaren att välja
                            for (int i = 0; i < uniqueClasses.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {uniqueClasses[i]}");
                            }
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                            // Låt användaren välja en klass
                            int classChoice = 0;
                            try
                            {
                                classChoice = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ogiltig inmatning för klassval. Ange ett heltal.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                                break;
                            }

                            if (classChoice >= 1 && classChoice <= uniqueClasses.Count)
                            {
                                // Hämta elever baserat på vald klass
                                var selectedClass = uniqueClasses[classChoice - 1];
                                var studentsInClass = dbContext.Students
                                                        .Where(s => s.ClassName == selectedClass)
                                                        .ToList();

                                // Skriv ut eleverna i den valda klassen
                                Console.WriteLine($"Elever i klass {selectedClass}:");
                                foreach (var student in studentsInClass)
                                {
                                    Console.WriteLine($"ID: {student.StudentID}, Förnamn: {student.FirstName}, Efternamn: {student.LastName}");
                                }
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();

                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                            }

                            
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 4:
                        try
                        {
                            // Hämta betyg senaste månaden
                            DateTime lastMonth = DateTime.Now.AddMonths(-1);

                            // Hämta betyg baserat på datum och inkludera information om elev, kurs och lärare
                            var gradesLastMonth = dbContext.Grades
                                                    .Where(g => g.GradeDate >= lastMonth)
                                                    .Include(g => g.Student)
                                                    .Include(g => g.Course)
                                                    .Include(g => g.Teacher)
                                                    .ToList();

                            // Skriv ut resultaten
                            Console.WriteLine("Betyg satta den senaste månaden:");
                            foreach (var grade in gradesLastMonth)
                            {
                                string studentName = grade.Student != null ? $"{grade.Student.FirstName} {grade.Student.LastName}" : "N/A";
                                string courseName = grade.Course != null ? grade.Course.CourseName : "N/A";
                                string teacherName = grade.Teacher != null ? $"{grade.Teacher.FirstName} {grade.Teacher.LastName}" : "N/A";

                                Console.WriteLine($"ID: {grade.GradeId}, Student: {studentName}, Kurs: {courseName}, Lärare: {teacherName}, Betyg: {grade.GradeValue}, Datum: {grade.GradeDate}");
                            }
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 5:
                        try
                        {
                            // Hämta snittbetyg per kurs
                            var averageGradesPerCourse = dbContext.Grades
                                .Include(g => g.Course)
                                .ToList()
                                .GroupBy(g => g.Course)
                                .Select(group => new
                                {
                                    Course = group.Key.CourseName,
                                    AverageGrade = group.Average(g => CalculateNumericGrade(g.GradeValue))
                                })
                                .ToList();

                            // Skriv ut resultaten
                            Console.WriteLine("Snittbetyg per kurs:");
                            foreach (var avgGrade in averageGradesPerCourse)
                            {
                                Console.WriteLine($"Kurs: {avgGrade.Course}, Snittbetyg: {avgGrade.AverageGrade}");                               
                            }
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 6:
                        try
                        {
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
                                newStudentId = new Random().Next(0, 500);
                            } while (dbContext.Students.Any(s => s.StudentID == newStudentId));

                            // Skapa en ny elev och lägg till den i DbSet
                            var newStudent = new Student
                            {
                                StudentID = newStudentId,
                                FirstName = firstName,
                                LastName = lastName,
                                PersonalIDNr = personalIdNr,
                                ClassName = sClass,
                            };

                            dbContext.Students.Add(newStudent);

                            // Spara ändringarna i databasen
                            dbContext.SaveChanges();

                            Console.WriteLine("En ny elev har lagts till i databasen.");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 7:
                        try
                        {
                            // Lägga till ny personal
                            Console.WriteLine("Lägg till ny personal:");

                            // Användaren får välja om de vill lägga till en Teacher eller Staff
                            Console.WriteLine("Välj typ av personal:");
                            Console.WriteLine("1. Lärare");
                            Console.WriteLine("2. Personal");                          
                            int personalTypeChoice = int.Parse(Console.ReadLine());

                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                            // Användarens input om förnamn, efternamn och position
                            Console.Write("Förnamn: ");
                            string _firstName = Console.ReadLine();

                            Console.Write("Efternamn: ");
                            string _lastName = Console.ReadLine();

                            string position;

                            // Beroende på användarens val, mata in ytterligare information
                            if (personalTypeChoice == 1)
                            {
                                Console.Write("Ämne: ");
                                position = Console.ReadLine();
                            }
                            else if (personalTypeChoice == 2)
                            {
                                Console.Write("Position: ");
                                position = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                                break;
                            }
                            // Start datum för nyanställd
                            Console.Write("Startdatum (YYYY-MM-DD): ");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());

                            // Generera ett slumpmässigt och unikt PersonalId som fungerar för Teacher och Staff
                            int newPersonalId;
                            do
                            {
                                newPersonalId = new Random().Next(0, 500);
                            } while (dbContext.Teachers.Any(t => t.TeacherID == newPersonalId) || dbContext.Staffs.Any(s => s.StaffID == newPersonalId));

                            // Skapa ny personal och lägg till i DbSet baserat på position
                            if (personalTypeChoice == 1)
                            {
                                var newTeacher = new Teacher
                                {
                                    TeacherID = newPersonalId,
                                    FirstName = _firstName,
                                    LastName = _lastName,
                                    Position = position,
                                    StartDate = startDate
                                };
                                dbContext.Teachers.Add(newTeacher);
                            }
                            else if (personalTypeChoice == 2)
                            {
                                var newStaff = new Staff
                                {
                                    StaffID = newPersonalId,
                                    FirstName = _firstName,
                                    LastName = _lastName,
                                    Position = position
                                };
                                dbContext.Staffs.Add(newStaff);
                            }
                            else
                            {
                                Console.WriteLine("Ogiltig position. Vänligen försök igen.");
                                // Lägg till mellanrum för att öka läsbarheten
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("------------------------------------------------------");
                                Console.ResetColor();
                                break;
                            }

                            // Spara ändringarna i databasen
                            dbContext.SaveChanges();

                            Console.WriteLine("Ny personal har lagts till i databasen.");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 8:
                        try
                        {
                            // Visa en lista över alla kurser
                            var allCourses = dbContext.Courses.ToList();

                            // Skriv ut resultaten
                            Console.WriteLine("Lista över alla kurser:");
                            foreach (var course in allCourses)
                            {
                                Console.WriteLine($"ID: {course.CourseID}, Kursnamn: {course.CourseName}");   
                            }
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    case 9:
                        try
                        {
                            // Avsluta programmet
                            Environment.Exit(0);
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;                          
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ett fel uppstod: {ex.Message}");
                            // Lägg till mellanrum för att öka läsbarheten
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------------------------------------------------------");
                            Console.ResetColor();
                        }
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        // Lägg till mellanrum för att öka läsbarheten
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("------------------------------------------------------");
                        Console.ResetColor();
                        break;

                }
            }
        }

        private static decimal CalculateNumericGrade(string value)
        {
            switch (value.ToUpper())
            {
                case "A":
                    return 5.0m;
                case "B":
                    return 4.0m;
                case "C":
                    return 3.0m;
                case "D":
                    return 2.0m;
                case "E":
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