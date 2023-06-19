using System;
using System.Diagnostics;
using System.IO;
using static System.Console;
using static System.Math;
public class main{
	public static Random rnd = new System.Random(1); 
	public static void Main(){
		testcyclichessenberg();
		determinant();
	}//Main
public static void testcyclichessenberg(){
	WriteLine("Calculation of the Hessenberg matrix");
	WriteLine("A random 5x5 matrix is generated");
	int n = 5;
	matrix A = new matrix(n,n);
	for(int i = 0; i < A.size1; i++)
		for(int j = i; j < A.size1; j++){
			double val = rnd.NextDouble();
			A[i, j] = val; A[j, i] = val; 
}

	matrix Q = A.copy();
	matrix V = matrix.id(n);
	
	for (int i=0;i<n;++i){
		for (int j=0;j<n;++j){
			Write($"{A[i, j],20:N4}");
		}
		WriteLine();
	}
	WriteLine();
	
	
	WriteLine("The matrix is converted to a Hessenberg matrix");
	Stopwatch stopWatchhessenberg = new Stopwatch();
	stopWatchhessenberg.Start();
	jacobi.cyclichessenberg(Q, V);
	stopWatchhessenberg.Stop();
		for (int i=0;i<n;++i){
		for (int j=0;j<n;++j){
			Write($"{Q[i, j],20:N4}");
		}
		WriteLine();
	}
	WriteLine();
	WriteLine("The process is timed. It is found that the generation of the Hessenberg matrix takes ");
	WriteLine($"{stopWatchhessenberg.Elapsed} (hh:mm:ss.ms)");
	WriteLine();
	WriteLine("A function is included in the Makefile to calculate how long time different sizes of matrices take to reduce to Hessenberg form. This is compared to the time the QRGS method made as a homework takes. ");
	
}//testcyclic
public static void determinant(){
	WriteLine();
	WriteLine("Calculation of the determinant:");
	int n = 5;
	matrix A = new matrix(n,n);
	for(int i = 0; i < A.size1; i++)
		for(int j = i; j < A.size1; j++){
			double val = rnd.NextDouble();
			A[i, j] = val; A[j, i] = val; 
	}

	WriteLine("A random 5x5 matrix is generated");
	for (int i=0;i<n;++i){
		for (int j=0;j<n;++j){
			Write($"{A[i, j],20:N4}");
		}
		WriteLine();
	}
	WriteLine();
	
	matrix Q = A.copy();
	matrix V = matrix.id(n);
	matrix R = new matrix(n,n);
	jacobi.cyclichessenberg(Q, V);
	WriteLine("The matrix is converted to a Hessenberg matrix");
	for (int i=0;i<n;++i){
		for (int j=0;j<n;++j){
			Write($"{Q[i, j],20:N4}");
		}
		WriteLine();
	}
	WriteLine();
	
	WriteLine("This Hessenberg matrix is used to generate an upper triangular matrix, which will contain the eigenvalues on the diagonal:");
	(Q,R) = matlib.decomp(Q,R);
	
	for (int i=0;i<n;++i){
		for (int j=0;j<n;++j){
			Write($"{R[i, j],20:N4}");
		}
		WriteLine();
	}
	WriteLine();
	
	WriteLine("The determinant is calculated as the product of the diagonal:");
	double det = 1;
	for (int i=0;i<n;++i){
		det *=R[i,i];
	}

	WriteLine($"{det}");
	

	
}//testcyclic
}//main