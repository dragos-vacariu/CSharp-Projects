/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 20.07.2016
 * Time: 18:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.Serialization; //this is used for creating serializable classes, and constructors.

namespace project39_custom_exception_classes
{
	class Program
	{
		public static void Main(string[] args)
		{
			//After making the custom exception class be inherited from Exception class, the throw new exception
			//statement can be used as follows.
			//throw new CustomUserLoggedInException(); //this can also be called even after creating
			//the class (that inherits from Exception class).
			throw new CustomUserLoggedInException("You are logged in!"); //this exception sinthax can also be used
			//now, after creating a constructor that takes a string message as parameter.
			
			//THE CREATED EXCEPTION CAN ALSO BE HANDLED AS FOLLOWS:
			/*
			 * try {
			 * 		throw new CustomUserLoggedInException("You are logged in!");
			 * }
			 * catch(CustomUserLoggedInException cexcept)
			 * {
			 * 		Console.WriteLine("{0}", cexcept.Message);
			 * }
			 */
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	//To create a custom exception class you have to use the System.Exception class as a parent class for your
	//custom class. So CustomUserLoggedInException HAS TO BE INHERITED FROM EXCEPTION.
	
	[Serializable] //this keyword/sinthax makes a class be serializable.
	public class CustomUserLoggedInException: Exception //this always should be public.
	{
		//To provide the flexibility of printing a message inside the Custom Exception class you
		//have to create a constructor that takes an string argument (because the base Exception class use this), 
		//and to invoke the base class constructor
		//CREATING A CONSTRUCTOR THAT ALLOWS MESSAGES TO BE PASSED AND PRINTED ON THE SCREEN.
		public CustomUserLoggedInException(string message) : base (message)
		{
			//This constructor does all the work that the base class constructor does.
		}
		
		//After providing a constructor, the class is not able to be called without using the argument
		//To do so, you have to overload a constructor that takes no parameters. Also the base Exception
		//class has an overloaded constructor without parameters.
		public CustomUserLoggedInException() : base()
		{
			//This constructor does all the workd that the base class default constructor does.
		}
		
		//To track inner exception you also need to create a constructor that takes 2 arguments:
		//the message and one object of type Exception. The base class Exception has an constructor
		//of this type for inner exception so, its functionality can be invoked in this constructor.
		public CustomUserLoggedInException(string message, Exception innerException)
			: base(message,innerException)
		{
			//This constructor now works exactly as the parent class constructor.
		}
		
		//To create an object that can be moved from one application (software) to another that 
		//object must be serializable. A serializable object is an object or instance of a serializable
		//class. A serializable class is a class (like a standard class) which uses functionality that
		//other softwares and application uses. To create serializable class you have to use the keyword:
		//[Serializable]- just as above. A serializable class needs to provide a serializable constructor
		//as follows:
		
		public CustomUserLoggedInException(SerializationInfo information, StreamingContext Info_context)
			: base(information, Info_context) //to create this constructor Systems.Runtime.Serialization
			//namespace must be used (included).
		{
		}
		
	}
}