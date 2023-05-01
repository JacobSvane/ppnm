using System;
using static System.Math;
using static System.Console;
public class ann{

public Func<double,double> f  = z => Exp(-z*z)*z;
public vector p;
public readonly int n;
public double a(int i) { return(p[i]); }
public double b(int i) { return(p[i+n]); }
public double w(int i) { return(p[i+2*n]); }
public void seta(int i,double z) { p[i]=z; }
public void setb(int i,double z) { p[i+n]=z; }
public void setw(int i,double z) { p[i+2*n]=z; }

public ann(int n){ this.n=n; p=new vector(3*n); }

public ann(vector p) { this.n=p.size/3; this.p=p; }

public double func(double x){
	double sum=0;
	for(int i=0;i<n;i++) sum+=w(i)*f((x-a(i))/b(i));
	return sum;
	}

public void train(double[] xs,double[] ys){
	for(int i=0;i<n;i++){
		setw(i,1);
		setb(i,1);
		seta(i,xs[0]+(xs[xs.Length-1]-xs[0])*i/(n-1));
	}
	int ncalls=0;
	Func<vector,double> mismatch = (u) => {
		ncalls++;
		ann annu = new ann(u);
		double sum=0;
		for(int k=0;k<xs.Length;k++)
			sum+=Pow(annu.func(xs[k])-ys[k],2);
		return sum/xs.Length;
		};
double step=0.7;
simplex.downhill(mismatch,ref p,step:step,sizegoal:1e-6);
	}
public vector deriv1(double a, double b, double h){
	vector deriv = new vector((int)((b-a)/h));
	for(int z=0;z<=deriv.size-1;z++) deriv[z]=(func((z-1/h)*h+h)-func((z-1/h)*h-h))/(2*h);
	return deriv;
	}
public vector deriv2(double a, double b, double h){
	vector deriv = new vector((int)((b-a)/h));
	for(int z=0;z<=deriv.size-1;z++) deriv[z]=(func((z-1/h)*h+h)-2*func((z-1/h)*h)+func((z-1/h)*h-h))/(h*h);
	return deriv;
	}
public vector antideriv(double a, double b, double h){
	vector antideriv = new vector((int)((b-a)/h));
	double acc = 0.0;
	for(int z=0;z<=antideriv.size-1;z++) {
		acc+=(func((z-1/h)*h)+func((z-1/h)*h-h))/2*((z-1/h)*h-((z-1/h)*h-h));
		antideriv[z]=acc;
	}
	return antideriv;
	}
}//ann
