using System;
using System.Collections.Generic; //this is required to use lists.
using System.Threading.Tasks;

namespace project9_phonebook
{
	class Program
	{
		//STATIC members cannot be accessed outside the struct.
		public struct Phonebook //this struct needs to be public, to can pass an object of this as argument for
			//a function.
		{
			string name, phonenumber; //a private keyword would make this variable inaccesible from the outside
			public Phonebook(string newname, string newphonenumber)
			{
				name = newname;
				phonenumber=newphonenumber;
			}
			//GETTERS to get the private variables values of the struct.
			public string getname() //a static keyword in here would make this function inaccesible from the outside
			{
				return name;
			}
			public string getnumber() //a static keyword in here would make this function inaccesible from the outside
			{
				return phonenumber;
			}
		}
		public static void Main(string[] args)
		{
			List <Phonebook> MyContacts = new List <Phonebook> ();
			Phonebook phonebook = new Phonebook("Joe", "0742403278");
			Phonebook phonebook2 = new Phonebook("Mark", "0742433421");
			Phonebook phonebook3 = new Phonebook("Allan", "0742403827");
			MyContacts.Add(phonebook);
			MyContacts.Add(phonebook2);
			MyContacts.Add(phonebook3);
			//This works too:
			/*foreach (Phonebook iter in MyContacts)
			{
				Console.WriteLine("Name: " + iter.getname() + " Number: " + iter.getnumber());
			}*/
			DisplayP(MyContacts);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		/*In order to call this function from the STATIC void Main function, this need also to be a STATIC function.
		 Otherwise(if this function would not be static) an Instance of the class would be needed to access this.*/
		public static void DisplayP(List <Phonebook> Mylist)
		{
			foreach(Phonebook iter in Mylist)
			{
				Console.WriteLine(iter.getname() + " " + iter.getnumber());
			}
		}
	}
}