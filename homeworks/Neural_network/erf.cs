using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

public static partial class matlib{

public static vector F(double x, vector y){
	double f=Exp(-x*x)*2/Sqrt(PI);
	return new vector(f);
	}

public static double erf(double z){
	if(z<0)return -erf(-z);
	double a=0;
	vector ya=new vector(0.0);
	double h=0.05,acc=1e-3,eps=1e-3;
	vector y = ode.driver(F,a,ya,z,acc,eps,h);
	return y[0];
	}

static bool approx(double a,double b, double acc=1e-6, double eps=1e-6){
	if( Abs(a-b)<acc )return true;
	if( Abs(a-b)<eps*Max(Abs(a),Abs(b)) ) return true;
	return false;
	}

}
