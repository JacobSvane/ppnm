using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static partial class ode{

public static (vector,vector) rkstep12(
Func<double,vector,vector> F, double x, vector y, double h
){// Runge-Kutta mid-point step
	vector k0 = F(x,y);
	vector k1 = F(x+h/2,y+k0*(h/2));
	vector yh = y+k1*h;
	vector er = (k1-k0)*h;
	return (yh, er);
}

public static (vector,vector) rkstep23(
Func<double,vector,vector> F, double x, vector y, double h){// Runge-Kutta mid-point step
	vector k0 = F(x,y);
	vector k1 = F(x+h/2,y+k0*(h/2));
	vector k2 = F(x+3*h/4,y+k1*(3*h/4));
	vector ka = k0*(2.0/9)+k1*(3.0/9)+k2*(4.0/9);
	vector kb = k1;
	vector yh = y+ka*h;
	vector er = (ka-kb)*h;
	return (yh, er);
}

public static vector driver(
	Func<double,vector,vector> F,
	double a, vector ya, double b, 
	double acc=1e-2, double eps=1e-2, double h=0.01,
	genlist<double> xlist=null, genlist<vector> ylist=null
	){// ODE driver
if(a>b) throw new Exception("driver: a>b");
double x=a; vector y=ya;
if(xlist!=null){xlist.clear();xlist.push(x);}
if(ylist!=null){ylist.clear();ylist.push(y);}
do	{
	if(x>=b) return y;
	if(x+h>b) h=b-x;
	var (yh,erv) = rkstep12(F,x,y,h);
	double tol =Max(acc,yh.norm()*eps)*Sqrt(h/(b-a));
	double err = erv.norm();
	if(err<tol){
		x+=h; y=yh;
		if(xlist!=null)xlist.push(x);
		if(ylist!=null)ylist.push(y);
		} // accept step
	h *= Min( Pow(tol/err,0.25)*0.95 ,2);
	}while(true);
}//driver

}//class
