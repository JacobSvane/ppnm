using System;
using static System.Console;
using static System.Math;
using System.Collections;
using System.Collections.Generic;

class main{
static bool approx(double a,double b, double acc=1e-6, double eps=1e-6){
	if( Abs(a-b)<acc )return true;
	if( Abs(a-b)<eps*Max(Abs(a),Abs(b)) ) return true;
	return false;
}

static Func<double,vector,vector>
F=delegate(double x, vector y){
	return new vector(y[1],-y[0]);
		};

public static double sin(double z){
	double x0=0;
	vector y0=new vector(0.0,1.0);
	//double h=0.01,acc=1e-2,eps=1e-2;
	vector y = ode.driver(F,x0,y0,z);
	return y[0];
	}

public static double cos(double z){
	double x0=0;
	vector y0=new vector(0.0,1.0);
	//double h=0.01,acc=1e-2,eps=1e-2;
	vector y = ode.driver(F,x0,y0,z);
	return y[1];
	}

static void Main(){
	for(double z=0;z<=10;z+=1.0/8){
		double x=z*PI/2;
		WriteLine($"{x} {sin(x)} {cos(x)}");
		}
}
}
