using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static partial class adaptiveintegrate{
public static int counter;
public static int evals;
public static double integrate(Func<double,double> f, double a, double b, double sigma=0.001, double ε=0.001, double f2 = Double.NaN, double f3= Double.NaN)
{
double h=b-a;
if(Double.IsNaN(f2)){
	counter = 0; evals = 2;
	f2=f(a+2*h/6); f3=f(a+4*h/6); 
	} // first call, no points to reuse
double f1=f(a+h/6); double f4=f(a+5*h/6); evals +=2;
double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
double err = Abs(Q-q);
if (err <= sigma+ε*Abs(Q)) return Q;
else {
	counter ++;
	return integrate(f,a,(a+b)/2,sigma/Sqrt(2),ε,f1,f2)+integrate(f,(a+b)/2,b,sigma/Sqrt(2),ε,f3,f4);
}
}

public static double errorfunction(double z){;
	if (z < (double) 0){
		return -errorfunction(-z);
	}
	else if ((double) 0 <= z && z <= (double) 1){
		Func<double, double> f1 = x => Exp(-x*x);
		return (2/Sqrt(PI))*integrate(f1,0,z);
	}
	else{
		Func<double, double> f2 = x => Exp(-Pow(z+(1-x)/x,2))/x/x;
		return 1-(2.0/Sqrt(PI))*integrate(f2,0,1);
	}
}
public static double ccintegrate(Func<double,double> f, double a, double b, double del = 0.001, double eps = 0.001, double maxit = 100){
	Func<double, double> g = (double theta) => (f((a+b)/2+(b-a)/2*Cos(theta))*Sin(theta)*(b-a)/2);
	return integrate(g,0,PI,del,eps,maxit);
}

}//class
