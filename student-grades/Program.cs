﻿// initialize variables - graded assignments 
int currentAssignments = 5;

int sophia1 = 93;
int sophia2 = 87;
int sophia3 = 98;
int sophia4 = 95;
int sophia5 = 100;

int nicolas1 = 80;
int nicolas2 = 83;
int nicolas3 = 82;
int nicolas4 = 88;
int nicolas5 = 85;

int zahirah1 = 84;
int zahirah2 = 96;
int zahirah3 = 73;
int zahirah4 = 85;
int zahirah5 = 79;

int jeong1 = 90;
int jeong2 = 92;
int jeong3 = 98;
int jeong4 = 100;
int jeong5 = 97;


// * Declare int var sum for each student
int sophiaSum = sophia1 + sophia2 + sophia3 + sophia4 + sophia5;
int nicolasSum = nicolas1 + nicolas2 + nicolas3 + nicolas4 + nicolas5;
int zahirahSum = zahirah1 + zahirah2 + zahirah3 + zahirah4 + zahirah5;
int jeongSum = jeong1 + jeong2 + jeong3 + jeong4 + jeong5;

// * Store the average
// ! When you want the result of a division calculation 
// ! to be a decimal value, either the dividend or divisor 
// ! must be of type decimal (or both). 
// ! apply a technique know as casting to "convert" and int to decimal.
decimal sophiaScore = (decimal) sophiaSum / currentAssignments;
decimal nicolasScore = (decimal) nicolasSum / currentAssignments;
decimal zahirahScore = (decimal) zahirahSum / currentAssignments;
decimal jeongScore = (decimal) jeongSum / currentAssignments;

// * Display sum scores
// Console.WriteLine("Sophia: " + sophiaScore);
// Console.WriteLine("Nicolas: " + nicolasScore);
// Console.WriteLine("Zahirah: " + zahirahScore);
// Console.WriteLine("Jeong: " + jeongScore);

// * Display grade after score
// Console.WriteLine("Sophia: " + sophiaScore + " A");
// Console.WriteLine("Nicolas: " + nicolasScore + " B");
// Console.WriteLine("Zahirah: " + zahirahScore + " B");
// Console.WriteLine("Jeong: " + jeongScore + " A");

// * Format the output
Console.WriteLine("Student\t\tGrade\n");
Console.WriteLine("Sophia:\t\t" + sophiaScore + "\tA");
Console.WriteLine("Nicolas:\t" + nicolasScore + "\tB");
Console.WriteLine("Zahirah:\t" + zahirahScore + "\tB");
Console.WriteLine("Jeong:\t\t" + jeongScore + "\tA");











