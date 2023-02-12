using System;
using static System.Console;
using static System.Math;
public class main{ 
	public static bool approx
		(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) < acc) return true;
		else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
		else return false;
	}
	public static void Main(){
		int i=1; 
		while(i+1>i) {i++;}
		Write($"my max int = {i}\n",i);
		Write($"{int.MaxValue}\n");
		int k=1;
		while(k>k-1) {k -= 1;}
		Write($"my min int = {k}\n",i);
		Write($"{int.MinValue}\n");
		
		double x=1; while(1+x!=1){x/=2;} x*=2;
		Write($"Calcuilated machine epsilon, double = {x}\n",i);
		Write($"System machine epsilon, double = {System.Math.Pow(2,-52)}\n",i);
		float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
		Write($"Calcuilated machine epsilon, float = {y}\n",i);
		Write($"System machine epsilon, float = {System.Math.Pow(2,-23)}\n",i);
		
		
		int n=(int)1e6;
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double sumA=0,sumB=0;

		sumA+=1; for(int ii=0;ii<n;ii++){sumA+=tiny;}
		for(int ii=0;ii<n;ii++){sumB+=tiny;} sumB+=1;
		
		WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
		WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
		WriteLine($"The difference is because of the way the 1 is added to the sum");
		
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;
		
		WriteLine($"d1={d1:e15}");
		WriteLine($"d2={d2:e15}");
		WriteLine($"d1==d2 ? => {d1==d2}");
		
		WriteLine($"d1==d2 using approx bool? => {approx(d1,d2)}");
}
}