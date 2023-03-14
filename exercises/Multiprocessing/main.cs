using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
class main{

public class data { public int a,b; public double sum; }
public static void harmonic(object obj){
	var local = (data)obj;
	local.sum=0;
	for(int i=local.a;i<local.b;i++)local.sum+=1.0/i;
	}
	
public static int nterms=(int)1e8, nthreads=1; //default values

public static int Main(string[] args){
	foreach(var arg in args)
		{
		var words = arg.Split(':');
		if(words[0]=="-terms"  )nterms    =(int)float.Parse(words[1]);
		if(words[0]=="-threads")nthreads=int.Parse(words[1]);
		}

	data[] x = new data[nthreads];
	for(int i=0;i<nthreads;i++)
		{
		x[i] = new data();
		x[i].a = 1 + (i*nterms)/nthreads;
		x[i].b = 1 + ((i+1)*nterms)/nthreads;
		}
	x[x.Length-1].b=nterms+1;
	Thread[] threads = new Thread[nthreads];
	for(int i=0;i<nthreads;i++)
		{
		threads[i] = new Thread(harmonic);
		threads[i].Start(x[i]);
		}
	for(int i=0;i<nthreads;i++)
		{
		threads[i].Join();
		}
	double sum=0;
	for(int i=0;i<nthreads;i++)
		{
		sum+=x[i].sum;
		}

	WriteLine($"sum = {sum}");
	return 0;
	}


}
