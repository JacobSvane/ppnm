using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static partial class montecarlo{
	
public static (double,double) plainmc(Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size; double V=1; for(int i=0;i<dim;i++)V*=b[i]-a[i];
        double sum=0,sum2=0;
	var x=new vector(dim);
	var rnd=new Random();
        for(int i=0;i<N;i++){
                for(int k=0;k<dim;k++)x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
                double fx=f(x); sum+=fx; sum2+=fx*fx;
                }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
}

public static (double,double) quasimc(Func<vector,double> f,vector a,vector b,int N){
        int dim=a.size; double V=1; for(int i=0;i<dim;i++)V*=b[i]-a[i];
        double sum=0,sum2=0;
	var x=new vector(dim);
        for(int i=0;i<N;i++){
                halton(i,dim,x,a,b);
                double fx=f(x); sum+=fx; 
				halton(i,dim,x,a,b,true);
				sum2+=f(x);
                }
        double mean=sum/N, sigma=Abs(sum-sum2)/N*V;
        var result=(mean*V,sigma);
        return result;
}

public static double corput(int n, int b){
	double q = 0; double bk = 1.0/b;
	while(n>0) {
		q += (n % b ) * bk;
		n /= b;
		bk /= b;
	}
	return q;
}//corput

public static void halton(int n, int d, vector x, vector a, vector b, bool lower = false){
	int[] bases = {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61};
	for(int i = 0; i < d; i++){
		if(lower) x[i] = corput(n,bases[i+5])*(b[i]-a[i]);
		else x[i] = corput(n,bases[i])*(b[i]-a[i]);
	}
}//halton
}//class
