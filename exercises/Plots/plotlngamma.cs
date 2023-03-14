using static System.Console;
class main{
static void Main(){
	for(double xlngamma=0+1.0/128;xlngamma<=10;xlngamma+=1.0/64){
		WriteLine($"{xlngamma} {sfuns.lngamma(xlngamma)}");
	}
}
}
