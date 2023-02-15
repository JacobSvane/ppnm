using System;
using static System.Console;
using static System.Math;
public class main{
	public static void Main(){
	double sqrt2 = System.Math.Sqrt(2.0);
	Write($"sqrt(2) = {sqrt2}\n");
	Write($"2^1/5 = {Pow(2.0,1/5)}\n");
	Write($"2^1/5.0 = {Pow(2,1/5.0)}\n");
	Write($"e^pi = {Pow(E,PI)}\n");
	Write($"pi^e = {Pow(PI,E)}\n");
	Write($"Gamma(1) = {sfuns.gamma(1)}\n");
	Write($"Gamma(2) = {sfuns.gamma(2)}\n");
	Write($"Gamma(3) = {sfuns.gamma(3)}\n");
	Write($"Gamma(10) = {sfuns.gamma(10)}\n");
	Write($"lngamma(10) = {sfuns.lngamma(10)}\n");
	Write($"lngamma(-10) = {sfuns.lngamma(-10)}\n");
	}
}

