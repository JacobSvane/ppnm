using static System.Console;
class main{
static void Main(){
	for(double xgamma=-5+1.0/128;xgamma<=5;xgamma+=1.0/256){
		WriteLine($"{xgamma} {sfuns.gamma(xgamma)}");
	}
}
}
