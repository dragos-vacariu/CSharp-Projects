/*
 * Created by SharpDevelop.
 * User: Black2
 * Date: 16.07.2016
 * Time: 18:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace project15_matrix_calculator
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("How many matrices do you need?");
			int matrixNumber = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("What dimension do you need?");
			int dimension = Convert.ToInt32(Console.ReadLine());
			int [, ,]userarray = new int[matrixNumber,dimension,dimension];
			matrixFiller(userarray, matrixNumber, dimension);
			Console.WriteLine("Press 1 for total addition (A+B+C...+N).\nPress 2 to subtract from first. (A-B-C...-N)" +
			                  "\nPress 3 for subtraction from second. (B-A-C...-N)");
			bool arethree=false;
			if (matrixNumber>=3)
			{
				Console.WriteLine("Press 4 for adding first two and subtract the others (A+B-C-...-N)." +
				                  "\nPress 5 for subtraction from third. (C-A-B...-N)" +
				                  "\nPress 6 for adding second and third and subtract the others(B+C-A-...-N).");
				arethree=true;
			}
			int choice = 0;
			while(choice<1||choice>6)
			{
				Console.Write("Your choice: ");
				choice=Convert.ToInt32(Console.ReadLine());
				if(arethree==false && choice>3 && choice<6 )
				{
					Console.WriteLine("Your option require at least 3 matrices.");
					choice=-1;
				}
			}
			MAdditioner(userarray, matrixNumber, dimension, choice);
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		public static void matrixFiller(int[,,]array, int matrixNumber, int dimension)
		{
			//Reading the matrices;
			for(int i = 0; i<matrixNumber; i++)
			{
				Console.WriteLine("Enter the values for the matrix {0}", i);
				for (int j = 0; j<dimension; j++)
					for (int k = 0; k<dimension; k++)
						array[i,j,k]=Convert.ToInt32(Console.ReadLine());
			}
			//Printing the matrices:
			for(int i = 0; i<matrixNumber; i++)
			{
				Console.WriteLine("Matrix nr. {0} is:", i);
				for (int j = 0; j<dimension; j++)
				{
					Console.Write("[	");
					for (int k = 0; k<dimension; k++)
						Console.Write("{0}	",array[i,j,k]);
					
					Console.WriteLine("]");
				}
			}
		}
		public static void MAdditioner(int[,,]array, int matrixNumber, int dimension, int choice)
		{
			int [,] result = new int[dimension,dimension];
			//Reading the matrix
			for(int i=0;i<matrixNumber;i++)
				for (int j = 0; j<dimension; j++)
					for (int k = 0; k<dimension; k++)
					{
						//result[j,k]+=array[i,j,k];
						result[j,k]=operation(result[j,k], array[i,j,k], choice, i);
					}
			//Printing the matrices:
			Console.WriteLine("Result is:");
			for (int j = 0; j<dimension; j++)
			{
				Console.Write("[	");
				for (int k = 0; k<dimension; k++)
					Console.Write("{0}	",result[j,k]);
				
				Console.WriteLine("]");
			}
		}
		public static int operation(int result, int term, int choice, int matrixNr)
		{
			//This is for TOTAL ADDITION A+B+C+...+N
			if(choice==1)
			{
				result+=term;
				return result;
			}
			//This is for subtraction from first: A-B-C-...-N
			else if (choice==2)
			{
				if(matrixNr==0)
				{
					result=term;
					return result;
				}
				else
				{
					result-=term;
					return result;
				}
			}
			//This is for subtraction from second: B-A-C-...-N
			else if(choice==3)
			{
				if(matrixNr!=1)
				{
					term*=-1; //getting the negate of term.
					result+=term;
					return result;
				}
				else
				{
					result+=term;
					return result;
				}
			}
			//This is for adding the first two and subtract the others: A+B-C-...-N
			else if(choice==4)
			{
				if(matrixNr<2)
				{
					result+=term;
					return result;
				}
				else
				{
					result-=term;
					return result;
				}
			}
			//This is for subtraction from third: C-A-B-...-N
			else if(choice==5)
			{
				if(matrixNr!=2)
				{
					term*=-1; //getting the negate of the term.
					result+=term;
					return result;
				}
				else
				{
					result+=term;
					return result;
				}
			}
			//This is for adding second and third and subtract the others: B+C-A...-N
			else //if(choice==6)
			{
				if(matrixNr>0&&matrixNr<3)
				{
					result+=term;
					return result;
				}
				else
				{
					result-=term;
					return result;
				}
			}
				
		}
	}
}