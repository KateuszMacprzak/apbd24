
using ConsoleApp3;
using System.Linq;

var students = new List<Student>();

students.Add(new Student()
{
    IdStudent = 1,
    LastName = "Kowalski",
    Age = 22
});
students.Add(new Student()
{
    IdStudent = 2,
    LastName = "Malewski",
    Age = 28
});
students.Add(new Student()
{
    IdStudent = 3,
    LastName = "Kwiatkowski",
    Age = 20
});

//======================================
// SELECT * FROM Students WHERE Age>20;
// WHERE LastName Like 'A%'
// GROUP BY Age
// ORDER BY Age;
var results = new List<Student>();
foreach (Student s in students)
{
    if (s.Age > 20)
    {
        results.Add(s);
    }
}

// Query Syntax
var results2 = from st in students
                                where st.Age > 20 && st.LastName.Contains("A")
                                select st;

// SELECT LastName ....
var results3 = from st in students
    where st.Age > 20 && st.LastName.Contains("A")
    select st.LastName;
    
    
//Select Age, LastName
var results4 = from st in students
    where st.Age > 20 && st.LastName.Contains("A")
    select new
    {
        Nazwisko=st.LastName,
        Wiek=st.Age
    };
    
    
//Extensions methods, Anynymous types, Lambda
var results5 = students.Where(st => st.Age>20 && st.LastName.Contains("A"));

var results6 = students.Where(st => st.Age > 20 && st.LastName.Contains("A"))
    .Select(st => st.LastName);

var results7 = students.Where(st => st.Age > 20 && st.LastName.Contains("A"))
    .Select(st => new
    {
        Nazwisko = st.LastName,
        Wiek = st.Age
    })
    .OrderBy(s => s.Nazwisko)
    .Where(s => s.Nazwisko.Length == 10);

var results8 = students.Max(s => s.Age);



