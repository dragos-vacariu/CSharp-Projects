/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 16.07.2016
 * Time: 17:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project14_matrix_addition
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Declaration of 2D Arrays:
			int [,] userarray1 = new int[10,10];
			int [,] userarray2 = new int[10,10];
			Console.WriteLine("Enter the dimension for the matrix.");
			int dimension = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the elements for the first matrix: ");
			//Arrays are automatically passed by reference;
			matrixGetter(userarray1, dimension);
			Console.WriteLine("Enter the elements for the second matrix: ");
			matrixGetter(userarray2, dimension);
			Console.WriteLine("Press 1 for addition.\nPress 2 for subtraction.");
			int choice=0;
			while(choice<1||choice>2)
			{
				choice=Convert.ToInt32(Console.ReadLine());
			}
			switch(choice)
			{
				case 1:
					{
						addition(userarray1,userarray2,dimension);
						break;
					}
				case 2:
					{
						subtraction(userarray1, userarray2, dimension);
						break;
					}
			}
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void addition (int [,] array1, int [,] array2, int dimension)
		{
			int [,] result = new int[dimension, dimension];
			for (int i=0; i<dimension; i++)
			{
				for(int j=0; j<dimension; j++)
				{
					result[i,j]=array1[i,j]+array2[i,j];
				}
			}
			Console.WriteLine("The result of addition between the 2 matrices is: ");
			for (int i=0; i<dimension; i++)
			{
				Console.Write("[	");
				for(int j=0; j<dimension; j++)
				{
					Console.Write("{0}	",result[i,j]);
				}
				Console.WriteLine("]");
			}
		}
		public static void subtraction (int [,] array1, int [,] array2, int dimension)
		{
			int [,] result = new int[dimension, dimension];
			for (int i=0; i<dimension; i++)
			{
				for(int j=0; j<dimension; j++)
				{
					result[i,j]=array1[i,j]-array2[i,j];
				}
			}
			Console.WriteLine("The result of subtraction between the 2 matrices is: ");
			for (int i=0; i<dimension; i++)
			{
				Console.Write("[	");
				for(int j=0; j<dimension; j++)
				{
					Console.Write("{0}	",result[i,j]);
				}
				Console.WriteLine("]");
			}
		}
		public static void matrixGetter(int [,]array, int dimension)
		{
			for (int i=0; i<dimension;i++)
			{
				for (int j=0; j<dimension; j++)
				{
					array[i,j]=Convert.ToInt32(Console.ReadLine());
				}
			}
			Console.WriteLine("Your First Matrix is: ");
			for (int i=0; i<dimension;i++)
			{
				Console.Write("[	");
				for (int j=0; j<dimension; j++)
				{
					Console.Write("{0}	", array[i,j]);
				}
				Console.WriteLine("]");
			}
		}
	}
}