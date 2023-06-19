using static System.Console;
using System;

public class ocounting{
	public static int n;
	public static Random rnd = new Random(1);
	public static void Main(string[] args) {
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0] == "-N")
				n = (int) double.Parse(words[1]);
		}
		matrix A = new matrix(n,n);
		matrix R = matrix.id(n);
		for(int i = 0; i < A.size1; i++)
			for(int j = i; j < A.size1; j++){
				double val = rnd.NextDouble();
				A[i, j] = val; A[j, i] = val; 
			}
		jacobi.cyclichessenberg(A, R);
	}
}