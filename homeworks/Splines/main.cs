using System;
using static System.Console;
using static System.Math;
class main{
public static vector x, x1, y, y2, y3;
public static void Main(){
	double limit = 3; double res = 5.0;	
	x = new vector((int) (limit*2*res));
	x1 = new vector((int) (6));
	y = new vector((int) (limit*2*res));
	y2 = new vector((int) (6));
	y3 = new vector((int) (6));
	for(int i=0; i < x.size; i++){
		x[i] = ((double) i);
		y[i] = ((double) i*(double) i);
	}
	for(int i=0; i < x1.size; i++){
		x1[i] = ((double) i);
		y2[i] = ((double) i);
		y3[i] = 1;
	}
	LinearInterpolation();
	CubicInterpolation();
}//Main
	public static void LinearInterpolation(){
		int k = x.size-1;
		vector z = new vector(k);
		vector intz = new vector(k);
		for(int i = 0; i<x.size-1; i++){
			double point = x[i]+1.0/2;
			z[i] = splines.linterp(x,y,point);
			intz[i] = splines.linterpInteg(x,y,point);
		}
	var outfile = new System.IO.StreamWriter("Function_xx.txt");
	var outfile2 = new System.IO.StreamWriter("Interpolation_xx.txt");
	for(int i = 0; i<x.size-1; i++){
		outfile.WriteLine($"{x[i],0:F5}  \t{y[i],0:F5}");
		outfile2.WriteLine($"{x[i]+1.0/2,0:F5}  \t{z[i],0:F5}  \t{intz[i],0:F5}");
	}
	outfile.Close();
	outfile2.Close();
	}//LinearInterpolation
	public static void CubicInterpolation(){
		int k = x.size-1;
		(vector a,vector b,vector c) = splines.qspline(x,y);
		(vector a2,vector b2,vector c2) = splines.qspline(x1,y2);
		(vector a3,vector b3,vector c3) = splines.qspline(x1,y3);
		vector z = new vector(k);
		vector intz = new vector(k);
		vector diffz = new vector(k);
		for(int i = 0; i<x.size-1; i++){
			double point = x[i]+1.0/2;
			z[i] = splines.evaluate(x,y,a,b,c,point);
			intz[i] = splines.integral(x,b,c,point);
			diffz[i] = splines.derivative(x,b,c,point);
		}
	var outfile3 = new System.IO.StreamWriter("Function_xx_cubic.txt");
	var outfile4 = new System.IO.StreamWriter("Function_x_cubic.txt");
	var outfile5 = new System.IO.StreamWriter("Function_1_cubic.txt");
	outfile3.WriteLine("Expected and calculated values for a, b and c for the f(x) = x² function");
	outfile4.WriteLine("Expected and calculated values for a, b and c for the f(x) = x function");
	outfile5.WriteLine("Expected and calculated values for a, b and c for the f(x) = 1 function");
	for(int i = 0; i<x.size-1; i++){
		outfile3.WriteLine($"Calculated value = {a[i],0:F5}\t\tExpected value = 1\t|\tCalculated value = {b[i],0:00.00000}\t\tExpected value = {2*x[i],0:00.00000}\t|\tCalculated value = {c[i],0:000.00}\t\tExpected value = {x[i]*x[i],0:000.00}");
	}
	for(int i = 0; i<x1.size-1; i++){
		outfile4.WriteLine($"Calculated value = {a2[i],0:F5}  \tExpected value = 0  \tCalculated value = {b2[i],0:F5}     \tExpected value = 1    \tCalculated value = {c2[i],0:F5}\t\tExpected value = {x[i]}");
		outfile5.WriteLine($"Calculated value = {a3[i],0:F5}  \tExpected value = 0  \tCalculated value = {b3[i],0:F5}     \tExpected value = 0    \tCalculated value = {c3[i],0:F5}\t\tExpected value = 1");
	}
	outfile3.Close();
	outfile4.Close();
	outfile5.Close();
	}//LinearInterpolation

}//main