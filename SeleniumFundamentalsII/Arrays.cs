using System;
using System.Collections;

//Arrays

String[] a = { "John", "Mike"};

int[] b = { 1,2,3,4};

String[] str = new string[2];

str[0] = "John";
str[1] = "Varun";

//Console.WriteLine(str.Length);

//Console.WriteLine(str[0]);

for (int i = 0; i < str.Length; i++)
{
    //Console.WriteLine(a[i]);

    if (str[i] == "Varun")
    {
        Console.WriteLine(str[i]);
        break;
    }
}


/// Array Lists

ArrayList al = new ArrayList();
al.Add("John");
al.Add("varun");
al.Add("Jacob");

foreach(String item in al)
{
    Console.WriteLine($"{item}");
    
}

bool val = al.Contains("Jarren");

if(val)
{
    Console.WriteLine("Value is present");
}
else
{
    Console.WriteLine("Value is not present");
}

//Array list sorting

Console.WriteLine("Array before sorting");

foreach(String item in al)
{
    Console.WriteLine($"{item}");
}

Console.WriteLine("Array after sorting");

al.Sort();

foreach(String item in al)
{
    Console.WriteLine($"{item}");
}