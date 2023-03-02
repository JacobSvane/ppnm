using static System.Console;
class main{
static void Main(){
	for(double xerf=0+1.0/128;xerf<=0.16;xerf+=1.0/64){
		WriteLine($"{xerf} {sfuns.erf(xerf)}");
	}
}
}
