using System;
using static System.Console;
using static System.Math;

class main{
public static void Main(){
	testmontecarlo();
	testquasimc();
}//Main
public static void testmontecarlo(){
	vector a1 = new vector(0.0,0.0);
	vector b1 = new vector(1.0,2*PI);
	double exact1 = PI;
	var outfile1 = new System.IO.StreamWriter("unit_circle_area.txt");
	for(int i = 200; i <= 10000; i = i + 200){
		(double q1, double e1) = montecarlo.plainmc((f) => (f[0]),a1,b1,i);
		outfile1.WriteLine($"{i} {q1} {e1} {Abs(q1-exact1)}");
	}
	outfile1.Close();
	
	WriteLine("Part A.1\nThe area of the unit circle was calculated and plotted as a function of the sampling points.\nThe estimated error was also calculated and plotted. It seemed that the estimated error was larger than the 1/Sqrt(N)\n");
	
	vector a2 = new vector(0.0,0.0,0.0);
	vector b2 = new vector(PI,PI,PI);
	double exact2 = 1.3932039296856768591842462603255;
	var outfile2 = new System.IO.StreamWriter("Fancy_integral.txt");
	for(int i = 205; i <= 10005; i = i + 200){
		(double q2, double e2) = montecarlo.plainmc((f) => (1/PI/PI/PI/(1-Cos(f[0])*Cos(f[1])*Cos(f[2]))),a2,b2,i);
		outfile2.WriteLine($"{i} {q2} {e2} {Abs(q2-exact2)}");
	}
	outfile2.Close();
	
	WriteLine("Part A.2\n∫0π  dx/π ∫0π  dy/π ∫0π  dz/π [1-cos(x)cos(y)cos(z)]-1 was calculated and plotted as a function of sampling points.\nThe estimated error was also calculated and plotted. The estimated error seemed to be quite close to 1/Sqrt(N)\n");
	
	}//testmontecarlo

public static void testquasimc(){
	vector a3 = new vector(0.0,0.0);
	vector b3 = new vector(1.0,2*PI);
	double exact3 = PI;
	var outfile3 = new System.IO.StreamWriter("unit_circle_area_quasi.txt");
	for(int i = 200; i <= 10000; i = i + 200){
		(double q3, double e3) = montecarlo.quasimc((f) => (f[0]),a3,b3,i);
		outfile3.WriteLine($"{i} {q3} {e3} {Abs(q3-exact3)}");
	}
	outfile3.Close();
	WriteLine("Part B\nThe quatsi random method was used to calculate the area of the unit circle. It was found that the method worked much faster than the plain monte carlo method.\nThe calculated area and the error from the quasi random method is plotted along with the plain method");
	}//testquasimc
}//main
