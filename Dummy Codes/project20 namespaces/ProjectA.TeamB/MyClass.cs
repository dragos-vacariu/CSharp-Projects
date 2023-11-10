/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 17.07.2016
 * Time: 19:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ProjectA.TeamB
{
	//This are called XML Coments, and are used to create descriptions.
	/// <summary>
	/// This is an Outside Class Project that contains a PrintName Function.
	/// </summary>
	public class MyClass
	{
		public void PrintName()
		{
			Console.WriteLine("This is an external Class Project called ProjectA.TeamA");
		}
	}
}
/*The code above is equivalent to this:
 * 
 * namespace ProjectA
{
	namespace TeamB
	{
		public class MyClass
		{
			public void PrintName()
			{
				Console.WriteLine("This is an external Class Project called ProjectA.TeamA");
			}
		}
	}
}
 //THIS IS CALLED NASTED NAMESPACE (or a namespace inside of another).
 */