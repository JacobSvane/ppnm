using System;
using static System.Console;
using static System.Math;
public static class sfunc{
	public static double gamma(double x){
	double gamma = Sqrt(2*PI/x)*(Pow(((x/E)*Sqrt(x*Sinh(1/x)+1/(810*Pow(x,6)))),x));//single precision gamma function (formula from Wikipedia)
	return gamma;
	//return PI/Sin(PI * x)/gamma(1-x); //Euler's reflection formula
	//if(x<9)	return sfunc.gamma(x+1)/x; //Recurrence relation
	//double lngamma=x*Log(x+1/(12*x-1*x*10))-x+Log(2*PI/x)/2;
	//return Exp(lngamma);
}
}
