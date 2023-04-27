using System;
using static System.Console;
using static System.Math;

class main{
static System.Collections.Generic.List<double> energy,signal,error;

static int ncalls=0;

static double chi2(vector x){
	ncalls++;
	double m = x[0];
	double G = x[1];
	double A = x[2];
	double sum=0;
	for(int i=0;i<energy.Count;i++){
		double e=energy[i];
		double y=signal[i];
		double dy=error[i];
		sum+=Pow((A*breitwigner(e,m,G)-y),2)/dy/dy;
		}
	return sum;
	}

static double breitwigner(double e, double m, double G){
	return 1/(Pow((e-m),2)+Pow(G,2)/4);
}

public static void Main(){
	Quasinewton();
	Quasinewton2();
	Higgs();
	Simplex();
}//Main
public static void Quasinewton(){
	int nsteps1,nsteps2,nsteps3,nsteps4,nsteps5;
	vector s1 = new vector(1,1);
	vector s2 = new vector(17,19);
	vector s3 = new vector(-5,9);
	vector s4 = new vector(4,-3);
	vector s5 = new vector(2,6);
	vector p1 = s1;
	vector p2 = s2;
	vector p3 = s3;
	vector p4 = s4;
	vector p5 = s5;
	(nsteps1,p1) = qnewton.min((vector f1) => Pow((1-f1[0]),2)+100*Pow(f1[1]-Pow(f1[0],2),2),ref p1);
	(nsteps2,p2) = qnewton.min((vector f2) => Pow((1-f2[0]),2)+100*Pow(f2[1]-Pow(f2[0],2),2),ref p2);
	(nsteps3,p3) = qnewton.min((vector f3) => Pow((1-f3[0]),2)+100*Pow(f3[1]-Pow(f3[0],2),2),ref p3);
	(nsteps4,p4) = qnewton.min((vector f4) => Pow((1-f4[0]),2)+100*Pow(f4[1]-Pow(f4[0],2),2),ref p4);
	(nsteps5,p5) = qnewton.min((vector f5) => Pow((1-f5[0]),2)+100*Pow(f5[1]-Pow(f5[0],2),2),ref p5);
	WriteLine("The Rosenbrock's valley fuction is tested using different starting points");
	WriteLine($"Starting point: {s1[0]}, {s1[1]}\nNumber of steps used: {nsteps1}\nMinimum location: {p1[0]}, {p1[1]}\nExpected location: 1, 1\n");
	WriteLine($"Starting point: {s2[0]}, {s2[1]}\nNumber of steps used: {nsteps2}\nMinimum location: {p2[0]}, {p2[1]}\nExpected location: 1, 1\n");
	WriteLine($"Starting point: {s3[0]}, {s3[1]}\nNumber of steps used: {nsteps3}\nMinimum location: {p3[0]}, {p3[1]}\nExpected location: 1, 1\n");
	WriteLine($"Starting point: {s4[0]}, {s4[1]}\nNumber of steps used: {nsteps4}\nMinimum location: {p4[0]}, {p4[1]}\nExpected location: 1, 1\n");
	WriteLine($"Starting point: {s5[0]}, {s5[1]}\nNumber of steps used: {nsteps5}\nMinimum location: {p5[0]}, {p5[1]}\nExpected location: 1, 1\n");
	}//Quasinewton
public static void Quasinewton2(){
	int nsteps1,nsteps2,nsteps3,nsteps4,nsteps5;
	vector s1 = new vector(2,1);
	vector s2 = new vector(17,19);
	vector s3 = new vector(-5,9);
	vector s4 = new vector(4,-3);
	vector s5 = new vector(2,6);
	vector p1 = s1;
	vector p2 = s2;
	vector p3 = s3;
	vector p4 = s4;
	vector p5 = s5;
	(nsteps1,p1) = qnewton.min((vector f1) => Pow(Pow(f1[0],2)+f1[1]-11,2)+Pow(f1[0]+Pow(f1[1],2)-7,2),ref p1);
	(nsteps2,p2) = qnewton.min((vector f2) => Pow(Pow(f2[0],2)+f2[1]-11,2)+Pow(f2[0]+Pow(f2[1],2)-7,2),ref p2);
	(nsteps3,p3) = qnewton.min((vector f3) => Pow(Pow(f3[0],2)+f3[1]-11,2)+Pow(f3[0]+Pow(f3[1],2)-7,2),ref p3);
	(nsteps4,p4) = qnewton.min((vector f4) => Pow(Pow(f4[0],2)+f4[1]-11,2)+Pow(f4[0]+Pow(f4[1],2)-7,2),ref p4);
	(nsteps5,p5) = qnewton.min((vector f5) => Pow(Pow(f5[0],2)+f5[1]-11,2)+Pow(f5[0]+Pow(f5[1],2)-7,2),ref p5);
	WriteLine("The Himmelblau's valley fuction is tested using different starting points");
	WriteLine($"Starting point: {s1[0]}, {s1[1]}\nNumber of steps used: {nsteps1}\nMinimum location: {p1[0]}, {p1[1]}\nExpected location: 3, 2\n");
	WriteLine($"Starting point: {s2[0]}, {s2[1]}\nNumber of steps used: {nsteps2}\nMinimum location: {p2[0]}, {p2[1]}\nExpected location: 3, 2\n");
	WriteLine($"Starting point: {s3[0]}, {s3[1]}\nNumber of steps used: {nsteps3}\nMinimum location: {p3[0]}, {p3[1]}\nExpected location: -2.805, 3.131\n");
	WriteLine($"Starting point: {s4[0]}, {s4[1]}\nNumber of steps used: {nsteps4}\nMinimum location: {p4[0]}, {p4[1]}\nExpected location: 3.584, -1.848\n");
	WriteLine($"Starting point: {s5[0]}, {s5[1]}\nNumber of steps used: {nsteps5}\nMinimum location: {p5[0]}, {p5[1]}\nExpected location: 3, 2\n");
	}//Quasinewton2
public static void Higgs(){
energy = new System.Collections.Generic.List<double>();
signal = new System.Collections.Generic.List<double>();
error  = new System.Collections.Generic.List<double>();
System.IO.TextReader stdin = Console.In;
char[] separators = new char[] {' '};
do{
	string s=stdin.ReadLine();
	if(s==null)break;
	string[] w=s.Split(separators,StringSplitOptions.RemoveEmptyEntries);
	energy.Add(double.Parse(w[0]));
	signal.Add(double.Parse(w[1]));
	error.Add (double.Parse(w[2]));
	}while(true);
vector p,start=new vector("123 3 6");
double m, G, A;
int nsteps;
p=start.copy();
ncalls=0; (nsteps,p)=qnewton.min(chi2,ref p,acc:1e-3,method:"sr1");
m=p[0]; G=p[1]; A=p[2];
WriteLine($"Number of steps used for the quasi newton medthod to find a minima: {nsteps}");
var outfile = new System.IO.StreamWriter($"Higgs_fit.txt");
	for(double e=energy[0];e<=energy[energy.Count-1];e+=1.0/16)
	outfile.WriteLine($"{e} {A*breitwigner(e,m,G)}");
outfile.Close();
}//Higgs
public static void Simplex(){
vector p,start=new vector("123 3 6");
double m, G, A;
int nsteps;
p=start.copy();
ncalls=0; (nsteps,p)=simplex.downhill(chi2,ref p,step:0.5,sizegoal:1e-3);
m=p[0]; G=p[1]; A=p[2];
WriteLine($"Number of steps used for the simplex medthod to find a minima: {nsteps}");
var outfile = new System.IO.StreamWriter($"Higgs_simplex_fit.txt");
	for(double e=energy[0];e<=energy[energy.Count-1];e+=1.0/16)
	outfile.WriteLine($"{e} {A*breitwigner(e,m,G)}");
outfile.Close();
}//Higgs
}//main
