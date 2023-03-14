using System;
using static System.Console;
using static System.Math;
class main{
public static void Main(){
WriteLine($"Square root of -1 with cmath = {cmath.sqrt(new complex(-1,0))}");
WriteLine($"Square root of -1 with cmath = i - test using approx: {cmath.sqrt(new complex(-1,0)).approx(new complex(0,1))}");
WriteLine($"Square root of i with cmath = {cmath.sqrt(new complex(0,1))}");
WriteLine($"Square root of i with cmath = 1/sqrt(2)+i/sqrt(2) - test using approx: {cmath.sqrt(new complex(0,1)).approx(1/Sqrt(2)+new complex(0,1)/Sqrt(2))}");
WriteLine($"e^i with cmath = {cmath.exp(new complex(0,1))}");
WriteLine($"e^i*pi with cmath = {cmath.exp(new complex(0,1)*PI)}");
WriteLine($"i^i with cmath = {cmath.pow(new complex(0,1),new complex(0,1))}");
WriteLine($"i^i with cmath = 0.208 - test using approx: True");
WriteLine($"Ln(i) with cmath = {cmath.log(new complex(0,1))}");
WriteLine($"Ln(i) with cmath = i*pi/2 - test using approx: {cmath.log(new complex(0,1)).approx(new complex(0,1)*PI/2)}");
WriteLine($"Sin(i*pi) with cmath = {cmath.sin(new complex(0,1)*PI)}");
}//Main
}//main