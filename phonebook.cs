using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Linq.Expressions;
public class phonebook
{
  public static void Main (string [] args)
  {
    bool docontinue = true;
    Dictionary <string, string> phonebook = new Dictionary <string, string> ();
    while (docontinue){
      Console.WriteLine("Do you want to continue?");
      if (Console.ReadLine() == "yes"){
        Console.WriteLine("Enter 1 for add, 2 for delete, 3 for search, and 4 for the whole phonebook");
        int value = Convert.ToInt32(Console.ReadLine());
        if (value == 1)
        {
          string personname= nameIntake();
          if (phonebook.ContainsKey(personname))
          {
            Console.WriteLine("Person already added");
          }
          else{
            user newPerson = new user (personname, numeberIntake());
            phonebook.Add (newPerson.nameReturn(), newPerson.numberReturn());
          }
        }
        if (value ==2)
        {
          Console.WriteLine("Which person do you want to remove?");
          phonebook.Remove (Console.ReadLine());
        }
        if (value ==3)
        {
          Console.WriteLine("Write 1 for searching a number and 2 for a person");
          string num = Console.ReadLine();
          if (num == "1")
          {
            Console.WriteLine("Which person's number do you need?");
            string keyToSearch = Console.ReadLine();
            if (phonebook.TryGetValue(keyToSearch, out string sth))
            {
                Console.WriteLine($"Number of {keyToSearch}is {sth}");
            }
            else
            {
                Console.WriteLine($"Person '{keyToSearch}' not found.");
            }
          }
          else if (num == "2")
          {
            Console.WriteLine("Which number do you need?");
            string numberToSearch = Console.ReadLine();
            var matchingKey = phonebook.FirstOrDefault(pair => pair.Value == numberToSearch).Key;
            if (matchingKey != null)
            {
                Console.WriteLine($"Person with number {numberToSearch} is: {matchingKey}");
            }
            else
            {
                Console.WriteLine($"No person found with this number {numberToSearch}");
            }
          }
          else {
            Console.WriteLine("Invalid command");
          }

        }
        if (value ==4)
        {
          foreach (var kvp in phonebook)
          {
            string key = kvp.Key;
            string valueagain = kvp.Value;

            Console.WriteLine($"Person: {key}, Number: {valueagain}");
          }
        }
      }
      else {
        docontinue = false;
      }
    }
  }
  //method to get data from the user
  public static string nameIntake ()
  {
    Console.WriteLine("Enter the name of the person:");
    return Console.ReadLine();
  }
  public static string numeberIntake ()
  {
    Console.WriteLine("Enter their number:");
    return Console.ReadLine();
  }
}
public class user
{
    //atributes
    public string name;
    public string number;

    //constructor
    public user (string name1, string number1)
    {
      name = name1;
      number = number1;
    }

    //return methods
    public string nameReturn()
    {
      return name;
    }
    public string numberReturn ()
    {
      return number;
    }
}
