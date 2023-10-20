# Calculate Final GPA

This is simple project to develop an Student Grading application. This project guided from [Microsoft Learn](https://learn.microsoft.com/en-us/training/modules/guided-project-calculate-final-gpa/)

## Project Overview

### The parameters for your application are:
* You're given the student's name and class information.
* Each class has a name, the student's grade, and the number of credit hours for that class.
* Your application needs to perform basic math operations to calculate the GPA for the given student.
* Your application needs to output/display the student’s name, class information, and GPA.

### To calculate the GPA:

* Multiply the grade value for a course by the number of credit hours for that course.
* Do this for each course, then add these results together.
* Divide the resulting sum by the total number of credit hours.

## You're provided with the following sample of a student's course information and GPA:

Student: Sophia Johnson

|Course | Grade | Credit Hours | Grade Point |
| --- | :---: | :---: | --- |
|English 101 | 4 (A) | 3 | 12 |
|Algebra 101 | 3 (B) | 3 | 9 |
|Biology 101 | 3 (B) | 4 | 12 |
|Computer Science I | 3 (B) | 4 | 12 |
|Psychology 101 | 4 (A) | 3 | 12 |
|
|Sum | | 17 | 57
|Final GPA: | 3.35 |

## Setup
```
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
```

