using System;
using static System.Console;
using static System.Math;
public class splines{
public static vector x,y,a,b,c;
public static double linterp(vector x, vector y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
        }
public static int binsearch(vector x, double z){/* locates the interval for z by bisection */ 
	if(!(x[0]<=z && z<=x[x.size-1])) throw new Exception("binsearch: bad z");
	int i=0, j=x.size-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}
public static double linterpInteg(vector x, vector y, double z){
	double integ = 0;
	double dx;
	vector a = new vector(x.size-1);
	vector b = new vector(x.size-1);
	a = x.copy();
	b = y.copy();
	int j=binsearch(x,z);
	for(int i = 0; i<j; i++){
		dx = x[i+1]-x[i];
		integ += b[i]*dx + a[i]/2*Pow(dx,2);
	}
	dx = x[j+1]-x[j];
	integ += b[j]*(z-x[j]) + a[j]/2*Pow(z-x[j],2);
	return integ; 
}
public static (vector,vector, vector) qspline(vector xs, vector ys){
	x=xs.copy(); y=ys.copy(); 
	a = new vector(x.size-1);
	b = new vector(x.size-1);
	c = new vector(x.size-1); 
	a[0] = 0; 
	b[0] = (y[1]-y[0])/(x[1]-x[0]);
	double dx, dy;
	for(int i = 1; i < x.size-1; i++){
		dx = x[i+1]-x[i];
		dy = y[i+1]-y[i];
		b[i] = dy/dx;
		a[i] = 1/(dx*(b[i]-b[i-1]-a[i-1]*(x[i]-x[i-1])));
	}
	c[x.size-2] = 0;
	for(int i = x.size-3; i >= 0; i--){
		dx = x[i+1]-x[i];
		dy = y[i+1]-y[i];
		c[i] = 1/(dx*(b[i+1]-b[i]-c[1+i]*(x[i+2]-x[i+1])));
	}
	for(int i = 0 ; i<x.size-1; i++){
		a[i] += c[i]; a[i] /=2.0;
		b[i] -= a[i]*(x[i+1]-x[i]);
		c[i] = y[i];
	}
	return (a,b,c);
}
public static double evaluate(vector x, vector y, vector a, vector b, vector c, double z){
	int i=binsearch(x,z);
    return y[i]+b[i]*(z-x[i])+c[i]*Pow((z-x[i]),2);
}

public static double derivative(vector x, vector b, vector c, double z){
	int i = binsearch(x,z);
	return b[i]+2*c[i]*(z-x[i]);
}

public static double integral(vector x, vector b, vector c, double z){
	int j = binsearch(x,z);
	double integ = 0;
	double dx;
	for(int i = 0; i<j; i++){
		dx = x[i+1]-x[i];
		integ += c[i]*dx+b[i]/2*Pow(dx,2)+c[i]/3*Pow(dx,3);
	}
	dx = z-x[j];
	integ += c[j]*dx+b[j]/2*Pow(dx,2)+c[j]/3*Pow(dx,3);
	return integ; 
}	
}