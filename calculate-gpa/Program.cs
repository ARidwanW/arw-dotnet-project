string studentName = "Sophia Johnson";
string course1Name = "English 101";
string course2Name = "Algebra 101";
string course3Name = "Biology 101";
string course4Name = "Computer Science I";
string course5Name = "Psychology 101";

int course1Credit = 3;
int course2Credit = 3;
int course3Credit = 4;
int course4Credit = 4;
int course5Credit = 3;


// * Store the numeric grade values for each course
int gradeA = 4;
int gradeB = 3;

int course1Grade = gradeA;
int course2Grade = gradeB;
int course3Grade = gradeB;
int course4Grade = gradeB;
int course5Grade = gradeA;


// * Calculate the sums of credit hours and grade points
int totalCreditHours = 0;
totalCreditHours += course1Credit;
totalCreditHours += course2Credit;
totalCreditHours += course3Credit;
totalCreditHours += course4Credit;
totalCreditHours += course5Credit;

// Another solution
// * totalCreditHours = course1Credit + course2Credit + course3Credit + course4Credit + course5Credit;

int totalGradePoints = 0;
totalGradePoints += course1Credit * course1Grade;
totalGradePoints += course2Credit * course2Grade;
totalGradePoints += course3Credit * course3Grade;
totalGradePoints += course4Credit * course4Grade;
totalGradePoints += course5Credit * course5Grade;

// ?? Notice that the code you wrote breaks down the problem into manageable pieces rather than trying to calculate the GPA in one large operation.

// Check
// Console.WriteLine($"{totalGradePoints} {totalCreditHours}");


// * Format the decimal output
decimal gradePointAverage = (decimal) totalGradePoints / totalCreditHours;
int leadingDigit = (int) gradePointAverage;     // never round up
int firstDigit = (int) (gradePointAverage * 10) % 10;       // if gpa = 3.351232 -->*10 3(3).51232 -->%10 gpa = (3)
int secondDigit = (int) (gradePointAverage * 100) % 10;     // if gpa = 3.351232 -->*100 33(5).1232 -->%10 gpa = (5)

// * solution 2
// Console.WriteLine($"{gradePointAverage:F2}");

// * solution 3
// Console.WriteLine($"{gradePointAverage:0.00}");

// * solution 4
// Console.WriteLine(gradePointAverage.ToString("F2"));


// * Format the output using escaped character sequences
Console.WriteLine($"Student: {studentName}\n");
Console.WriteLine("Course\t\t\tGrade\tCredit Hours");


// * Display Output
Console.WriteLine($"{course1Name}\t\t{course1Grade}\t\t{course1Credit}");
Console.WriteLine($"{course2Name}\t\t{course2Grade}\t\t{course2Credit}");
Console.WriteLine($"{course3Name}\t\t{course3Grade}\t\t{course3Credit}");
Console.WriteLine($"{course4Name}\t{course4Grade}\t\t{course4Credit}");
Console.WriteLine($"{course5Name}\t\t{course5Grade}\t\t{course5Credit}");
Console.WriteLine($"\nFinal GPA:\t\t{leadingDigit}.{firstDigit}{secondDigit}");





