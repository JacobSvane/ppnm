using System;
using static System.Console;
using static System.Math;
class main{
public static void Main(){
	int n = 9;
	var x  = new vector("1,2,3,4,6,9,10,13,15");
	var y  = new vector("117,100,88,72,53,29.5,25.2,15.2,11.1");
	var logy = new vector(n);
	for (int i=0;i<n;i++) logy[i]=Log(y[i]);
	var dy = new vector("5,5,5,4,4,3,3,2,2");
	var logdy = new vector(n);
	for (int i=0;i<n;i++) logdy[i]=(dy[i]/y[i]);
	var fs = new Func<double, double>[] { lambda => 1.0, lambda => lambda};
	(vector c, matrix S) = matlib.lsfit(fs,x,logy,logdy);
	WriteLine("The best fit is found to be given as:");
	WriteLine($"y(t) = {Exp(c[0])}*exp(t*{c[1]})\n");
	WriteLine("The halflife of ThX is found to be:");
	WriteLine($"{-Log(2)/c[1]} - The known value of ²²⁴Ra is 3.631(2) (10.1016/j.apradiso.2019.108933)");
	WriteLine("\nThe covariance matrix is then given as:");
	for (int i=0;i<S.size1;i++){
		for (int j=0;j<S.size1;j++){
			Write($"{S[i,j]}\t");
	}
	WriteLine();
	}
	WriteLine($"\nWhile the uncertainties on the fitting coefficients are calculated to be:\n a = {c[0]} ± {Sqrt(S[0,0])} \n lambda = {c[1]} ± {Sqrt(S[1,1])}\n");
	WriteLine($"The halflife is therefore given : \n t = {-Log(2)/(c[1])} ± {Abs((Sqrt(S[1,1])/c[1])*(-Log(2)/(c[1])))}  - The known value of ²²⁴Ra is 3.631(2) (10.1016/j.apradiso.2019.108933)\n The found uncertainty is thus not amazing compared to known values");

	
	var outfile = new System.IO.StreamWriter("decay_formatted.txt");
	for(int i = 0; i<x.size; i++){
		outfile.WriteLine($"{x[i]}	{y[i]}	{Log(y[i])}	{dy[i]}");
	}
	outfile.Close();

	
	}//Main
}//main
