using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classes are passed "by reference",
// meaning changes WILL affect the passed-in object because its the original
public class Phone
{
    public int number;
    public List<string> contacts;
}

// Structures are passed "by value",
// meaning changes WILL NOT affect the passed-in object because its a copy
public struct Phone2
{
    public int number;
}

public class Student
{
    public int id = -1;
    public string name;
    public int age;
    public float debt;
    public Phone phone;
    public int phoneCount;
    public bool hasJob;
    public float grade = 100.0f;
}
