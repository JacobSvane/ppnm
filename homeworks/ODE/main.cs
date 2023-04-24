using System;
using static System.Console;
using static System.Math;

class main{
public static void Main(){
	Oscillator_with_friction();
	ummeqminusu();
	Lotka_volterra();
}
public static void ummeqminusu(){
	Func<double,vector,vector> F=delegate(double t, vector y){
		double y1 = y[0], y2 = y[1];
		return new vector(y2,-y1);
		};
	double a=0,d=10;
	vector ya=new vector(0.0,1.0);
	var xs=new genlist<double>();
	var ys=new genlist<vector>();
	double h=0.01,acc=1e-2,eps=1e-2;
	ode.driver(F,a,ya,d,acc,eps,h,xs,ys);
	var outfile1 = new System.IO.StreamWriter("ummeqminusu.txt");
	for(int i = 0; i<xs.size-1; i++){
		outfile1.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	}
	outfile1.Close();		
	}

public static void Oscillator_with_friction(){
	double b=0.25, c=5;
	Func<double,vector,vector> F=delegate(double t, vector y){
		double theta = y[0], omega = y[1];
		return new vector(omega,-b*omega-c*Sin(theta));
		};
	double a=0,d=10;
	vector ya=new vector(PI-0.1,0.0);
	var xs=new genlist<double>();
	var ys=new genlist<vector>();
	double h=0.01,acc=1e-2,eps=1e-2;
	ode.driver(F,a,ya,d,acc,eps,h,xs,ys);
	var outfile = new System.IO.StreamWriter("oscillator_with_friction.txt");
	for(int i = 0; i<xs.size-1; i++){
		outfile.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	}
	outfile.Close();		
	}
public static void Lotka_volterra(){
	double a1=1.5, b1=1, c1=3, d1=1;
	Func<double,vector,vector> F = (x,y) => new vector(a1*y[0]-b1*y[0]*y[1],-c1*y[1]+d1*y[0]*y[1]);
	double a=0,d=15;
	vector ya=new vector(10.0,5.0);
	var xs=new genlist<double>();
	var ys=new genlist<vector>();
	double h=0.01,acc=1e-2,eps=1e-2;
	ode.driver(F,a,ya,d,acc,eps,h,xs,ys);
	var outfile1 = new System.IO.StreamWriter("Lotka_volterra.txt");
	for(int i = 0; i<xs.size-1; i ++){
		outfile1.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
	}
	outfile1.Close();		
	}
}
