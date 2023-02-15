using System;
using static System.Console;
using static System.Math;
using static cmath;
public static class main{
	public static void Main(){
		var complexa=new complex(-1);
		WriteLine($"square root of -1 with cmath = {cmath.sqrt(complexa)}");
		var complexb=new complex(0,1);
		WriteLine($"square root of I with cmath = {cmath.sqrt(complexb)}");
		WriteLine($"exponential of I with cmath = {cmath.exp(complexb)}");
		WriteLine($"exponential of I*pi with cmath = {cmath.exp(complexb*PI)}");
		WriteLine($"log of I with cmath = {cmath.log(complexb)}");
		WriteLine($"sin of I*pi with cmath = {cmath.sin(complexb*PI)}");
	}
}


