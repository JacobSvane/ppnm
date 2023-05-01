using System;
using static System.Math;
using static System.Console;
class main{
static Func<double,double> g=(x)=>Cos(5*x-1)*Exp(-x*x);
static void Main(){
	PartA();
	PartB();
}//Main
public static void PartA(){
int n=6;
	var network=new ann(n);
	double a=-1,b=1;
	int nx=20;
	var xs=new double[nx];
	var ys=new double[nx];
	var outfile1 = new System.IO.StreamWriter($"Training_points.txt");
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1);
		ys[i]=g(xs[i]);
		outfile1.Write($"{xs[i]} {ys[i]}\n");
		}
	outfile1.Close();
	var outfile2 = new System.IO.StreamWriter($"Calculated_function.txt");
	network.train(xs,ys);
	for(double z=a;z<=b;z+=1.0/64) outfile2.Write($"{z} {network.func(z)}\n");
	outfile2.Close();
}//PartA

public static void PartB(){
int n=6;
	var network=new ann(n);
	double a=-1,b=1,h=0.001;
	int nx=20;
	var xs=new double[nx];
	var ys=new double[nx];
	var outfile1 = new System.IO.StreamWriter($"Training_points_PartB.txt");
	for(int i=0;i<nx;i++){
		xs[i]=a+(b-a)*i/(nx-1);
		ys[i]=g(xs[i]);
		outfile1.Write($"{xs[i]} {ys[i]}\n");
		}
	outfile1.Close();
	network.train(xs,ys);
	vector k = new vector((int)((b-a)/h));
	var outfile2 = new System.IO.StreamWriter($"Calculated_function_PartB.txt");
	for(int z=0;z<=k.size-1;z++) outfile2.Write($"{(z-1/h)*h} {network.func((z-1/h)*h)} {network.deriv1(a,b,h)[z]} {network.deriv2(a,b,h)[z]} {network.antideriv(a,b,h)[z]}\n");
	outfile2.Close(); 

}//PartB
}//main
