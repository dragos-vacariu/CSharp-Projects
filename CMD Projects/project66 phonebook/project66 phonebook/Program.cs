/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 18.12.2016
 * Time: 13:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace project66_phonebook
{
	class Program
	{
		public static void Main(string[] args)
		{
			uint menuChoice;
			char answear = 'Y';
			List<Contact> phonebook = new List<Contact>{};
			phonebook.Add( new Contact ("Adam", 082223412, (uint)phonebook.Count));
			while(answear=='Y' || answear=='y')
			{
				Console.WriteLine("\nMENU: \n\n1.Add New Contact\n2.Edit Existing Contact\n3.Display Phonebook\n4.Quit");
				menuChoice=Convert.ToUInt32(Console.ReadLine());
				while(menuChoice<1 && menuChoice>4)
				{
					Console.WriteLine("Wrong Option! Please answear again: ");
					menuChoice=Convert.ToUInt32(Console.ReadLine());
				}
				if (menuChoice==1)
				{
					CreateContact(phonebook);
					Console.WriteLine("The new phonebook looks like this: ");
					DisplayAllContacts(phonebook);
				}
				else if (menuChoice==2)
				{
					ModifyContact(phonebook, GetContactEditIndex(phonebook));
				}
				else if(menuChoice==3)
				{
					DisplayAllContacts(phonebook);
				}
				Console.WriteLine("Do you wish to do something else? Press Y for yes! Press anything else to quit!");
				answear = Convert.ToChar(Console.ReadLine());
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void CreateContact(List <Contact> phonebook)
		{
			Console.WriteLine("Enter the contact details: ");
			string local_name;
			uint local_phoneNumber;
			char answear = 'c';
			Console.Write("Name: ");
			local_name = Convert.ToString(Console.ReadLine());
			Console.Write("Phone Number: ");
			local_phoneNumber = Convert.ToUInt32(Console.ReadLine());
			Console.WriteLine("Do you wish to add an age to your contact?");
			while(answear!='Y' && answear!='N' && answear!='y' && answear!='n')
			{
				Console.WriteLine("Answear with Y/N:");
				answear = Convert.ToChar(Console.ReadLine());
				if(answear=='Y' || answear=='y')
				{
					uint local_age;
					Console.WriteLine("Enter the age: ");
					local_age = Convert.ToUInt32(Console.ReadLine());
					phonebook.Add(new Contact(local_name, local_phoneNumber, (uint)phonebook.Count, local_age));
				}
				else if(answear=='N'|| answear=='n')
				{
					phonebook.Add(new Contact(local_name, local_phoneNumber, (uint) phonebook.Count));
				}
			}
		}
		public static void DisplayAllContacts(List<Contact> phonebook)
		{
			foreach(Contact k in phonebook)
			{
				k.PrintContact();
			}
		}
		public static uint GetContactEditIndex (List <Contact> phonebook)
		{
			uint index;
			Console.WriteLine("Enter the index of the element you would like to Modify: ");
			index=Convert.ToUInt32(Console.ReadLine());
			if(index<0 || index>phonebook.Count-1)
			{
				Console.WriteLine("Invalid index! There is no such element in the Phonebook!");
				while(index<0 || index>phonebook.Count-1) // phonebook.Count-1 because the index starts from zero, and the number of elements
					//starts from 1.
				{
					Console.WriteLine("Enter a valid index!");
					index=Convert.ToUInt32(Console.ReadLine());
				}
				
			}
			return index;
		}
		public static void ModifyContact (List <Contact> phonebook, uint index)
		{
			foreach(Contact k in phonebook)
			{
				if(k.GetIndex() == index)
				{
					char answear;
					Console.WriteLine("Contact name is: {0}", k.GetName());
					Console.WriteLine("Do you wish to change it? Press Y for yes! Anything else to skip!");
					answear = Convert.ToChar(Console.ReadLine());
					if(answear == 'Y' || answear == 'y')
					{
						string name;
						Console.Write("Enter the new name: ");
						name = Convert.ToString(Console.ReadLine());
						k.SetName(name);
					}
					Console.WriteLine("Contact number is: {0}", k.GetPhoneNumber());
					Console.WriteLine("Do you wish to change it? Press Y for yes! Anything else to skip!");
					answear = Convert.ToChar(Console.ReadLine());
					if(answear == 'Y' || answear == 'y')
					{
						uint newPhoneNumber;
						Console.Write("Enter the new phone number: ");
						newPhoneNumber = Convert.ToUInt32(Console.ReadLine());
						k.SetPhoneNumber(newPhoneNumber);
					}
					Console.WriteLine("Contact age is: {0}", k.GetAge());
					Console.WriteLine("Do you wish to change it? Press Y for yes! Anything else to skip!");
					answear = Convert.ToChar(Console.ReadLine());
					if(answear == 'Y' || answear == 'y')
					{
						uint newAge;
						Console.WriteLine("Enter the new age: ");
						newAge = Convert.ToUInt32(Console.ReadLine());
						k.SetAge(newAge);
					}
					
				}
			}
		}
	}
	class Contact
	{
		//Members:
		string Name;
		uint Age;
		uint phonenumber;
		uint index;
		
		//Constructor 1
		public Contact (string newname, uint phnumber, uint newindex, uint newage)
		{
			Name = newname;
			Age = newage;
			phonenumber = phnumber;
			index = newindex;
		}
		//Constructor 2
		public Contact (string newname, uint phnumber, uint newindex)
		{
			Name = newname;
			phonenumber = phnumber;
			index = newindex;
		}
		//Function:
		public void PrintContact()
		{
			Console.Write("{0}.Name: {1}	Phone Number: {2}	", this.index, this.Name, this.phonenumber);
			if(this.Age == 0)
			{
				Console.WriteLine("Age: uninitialized");
			}
			else
			{
				Console.WriteLine("Age: {0}", this.Age);
			}
		}
		//Getters:
		public uint GetIndex()
		{
			return this.index;
		}
		public string GetName()
		{
			return this.Name;
		}
		public uint GetPhoneNumber()
		{
			return this.phonenumber;
		}
		public uint GetAge()
		{
			return this.Age;
		}
		//Setters:
		public void SetName(string newname)
		{
			this.Name=newname;
		}
		public void SetPhoneNumber(uint newPhoneNumber)
		{
			this.phonenumber = newPhoneNumber;
		}
		public void SetAge(uint newAge)
		{
			this.Age = newAge;
		}
	}
}