using System;
using static System.Console;
using static System.Math;

class main{
public static void Main(){
	testNewton();
	Hydrogen();
}//Main
public static void testNewton(){
	WriteLine("Test of the newton method");
	WriteLine("First a simple linear equation f(x)=x+2 is tested, starting point set as 2 for the search\nThe algorithm provides the following root:");
	vector x1 = Newton.newton((vector a1) => (a1.copy() + new vector(2.0)), new vector(2.0));
	WriteLine($"{x1[0]}");
	
	WriteLine("Next the function f(x,y)=(4x+3y+2,x²) is tested, starting points are set as 2,3 for the search\nThe algorithm provides the following root:");
	vector x2 = Newton.newton((vector a2) => new vector(a2[0]*4+3*a2[1]+2,a2[1]*a2[1]), new vector(2.0,3.0));
	WriteLine($"{x2[0]}, {x2[1]}");
	
	WriteLine("Finally the Rosenbrock's valley function is tested, starting points are set as -3,-3 for the search. The expected value is 1,1 for the solution\nThe algorithm provides the following root:");
	vector x3 = Newton.newton((vector a3) => new vector((-2.0+2*a3[0]-400*(a3[1]-a3[0]*a3[0])*a3[0]),200*(a3[1]-a3[0]*a3[0])), new vector(-3,-3));
	WriteLine($"{x3[0]}, {x3[1]}");
	Write("It is thus found that the algorithm works as intended\nThe algorithm is now used to calculated the solution to the energy of a Hydrogen atom in Hartree.\nResulting plots from the exercise can be found in the plots provided");
}//testNewton
public static void Hydrogen(){
	// double rmax=10;
	var outfile1 = new System.IO.StreamWriter("Energies.txt");
	outfile1.Write("# rmax, e\n");
for(double i =1; i<=10; i= i+1){
	Func<vector,vector> master = (vector v)=>{
		double e=v[0];
		double frmax=hydrogen.Fe(e,i);
		return new vector(frmax);
		};

	vector vstart=new vector(-1.0);
	vector vroot=Newton.newton(master,vstart,eps:1e-4);
	double energy=vroot[0];
	var outfile = new System.IO.StreamWriter($"Function{i}.txt");
	for(double r=0; r<=i; r+=i/64){
		outfile.WriteLine($"{r} {hydrogen.Fe(energy,r)} {r*Exp(-r)}");
	}
	outfile.Close();

	outfile1.Write($"{i} {energy}\n");	
}
outfile1.Close();
}//Hydrogen

}//main
