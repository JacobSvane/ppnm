using System;
using static System.Console;
using static System.Math;

class main{
public static void Main(){
	testintegrals();
	Errorfunction();
	CCtransformation();
}//Main
public static void testintegrals(){
	Func<double, double> f1 = x => Sqrt(x);
	Func<double, double> f2 = x => 1/Sqrt(x);
	Func<double, double> f3 = x => 4*Sqrt(1-x*x);
	Func<double, double> f4 = x => Log(x)/Sqrt(x);
	var outfile1 = new System.IO.StreamWriter("testintegrals.txt");
	outfile1.WriteLine("Testing integrals within the expected accuracy which is given as 0.001 in this case");
	outfile1.WriteLine("The integrals are tested using Math.Abs(clac-known) <= 0.001. If this is true, the integral is printed");
	if (Abs(adaptiveintegrate.integrate(f1,0,1) - (double) 2/3) <= 0.001){
		outfile1.WriteLine($"∫\x2080\x00B9 dx √(x) = {adaptiveintegrate.integrate(f1,0,1)}, expected value = 2/3");
	outfile1.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations\n");}
	else
		outfile1.WriteLine($"The integral is not within the accuracy goal");
if (Abs(adaptiveintegrate.integrate(f2,0,1) - (double) 2) <= 0.001){
		outfile1.WriteLine($"∫\x2080\x00B9 dx 1/√(x) = {adaptiveintegrate.integrate(f2,0,1)}, expected value = 2");
outfile1.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations\n");}
	else
		outfile1.WriteLine($"The integral is not within the accuracy goal");
if (Abs(adaptiveintegrate.integrate(f3,0,1) - (double) PI) <= 0.001){
		outfile1.WriteLine($"∫\x2080\x00B9 dx 4*√(1-x²) = {adaptiveintegrate.integrate(f3,0,1)}, expected value = {PI}");
outfile1.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations\n");}
	else
		outfile1.WriteLine($"The integral is not within the accuracy goal");
if (Abs(adaptiveintegrate.integrate(f4,0,1) - (double) -4) <= 0.001){
		outfile1.WriteLine($"∫\x2080\x00B9 dx ln(x)/√(x) = {adaptiveintegrate.integrate(f4,0,1)}, expected value = -4");
outfile1.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations\n");}
	else
		outfile1.WriteLine($"The integral is not within the accuracy goal");
	outfile1.Close();	
	}//testintegrals

public static void Errorfunction(){
	var outfile2 = new System.IO.StreamWriter("errorfunction.txt");
	for(double i = -3; i <= 3; i = i + 0.064){
		outfile2.WriteLine($"{i} {adaptiveintegrate.errorfunction(i)}");
	}
	outfile2.Close();
	}
public static void CCtransformation(){
	var outfile3 = new System.IO.StreamWriter("CCtransformation.txt");
	Func<double, double> f5 = x => 1/Sqrt(x);
	Func<double, double> f6 = x => Log(x)/Sqrt(x);
	outfile3.WriteLine($"∫\x2080\x00B9 dx 1/√(x) = {adaptiveintegrate.ccintegrate(f5,0,1)}, expected value = 2");
	outfile3.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations");
	outfile3.WriteLine($"∫\x2080\x00B9 dx ln(x)/√(x) = {adaptiveintegrate.ccintegrate(f6,0,1)}, expected value = -4");
	outfile3.WriteLine($"The number of subdivisions was {adaptiveintegrate.counter} with {adaptiveintegrate.evals} evaluations");
	outfile3.WriteLine($"\nThe routine now solves the integrals faster. The integrals were also solved using scipy in python.\n∫\x2080\x00B9 dx 1/√(x) was solved in 6 subdivisions and 231 evaluations while ∫\x2080\x00B9 dx ln(x)/√(x) was solved in 8 subdivisions and 315 evaluations.\nThus it is found that the function made in c# solves ∫\x2080\x00B9 dx 1/√(x) in fewer divisions and evaluations while ∫\x2080\x00B9 dx ln(x)/√(x) is solved using fewer evaluations but more subdivisions.");
	outfile3.Close();
	}
}//main
