/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 22.07.2016
 * Time: 17:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project48_partial_methods_and_functions
{
	/// <summary>
	/// Description of PartialClassPartTwo.
	/// </summary>
	partial class MyClass
	{
		//This method will access the partial function/method.
		public void AccessingPartialMethod()
		{
			this.PrintingAMessage(); //accessing the partial function/method.
		}
	}
}
