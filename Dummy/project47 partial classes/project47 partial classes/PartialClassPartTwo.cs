/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 16:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project47_partial_classes //IMPORTANT: the class parts must be in the same namespace.
{
	/// <summary>
	/// Description of PartialClassPartTwo.
	/// </summary>
	partial class MyClass //the partial keyword must be used for all the parts of the class.
	{
		public void PrintInfo()
		{
			Console.WriteLine("Name: {0} 	Age: {1}", _Name, _Age);
		}
	}
}
