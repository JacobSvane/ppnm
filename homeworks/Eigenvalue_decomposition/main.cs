using System;
using System.IO;
using static System.Console;
using static System.Math;
public class main{
	public static Random rnd = new System.Random(1); 
	public static void Main(){
		testtimesJ();
		testJtimes();
		testcyclic();
		hamiltonianvarryingdr();
		hamiltonianvarryingrmax();
	}//Main
	public static void testtimesJ(){
		int n = 5;
		matrix A = new matrix(n,n);
		for (int i=0;i<n;++i){
			for (int j=0;j<n;++j){
				A[i, j] = rnd.NextDouble();
			}
		}
		matrix Q= A.copy();
		jacobi.timesJ(Q, 1, 2, 23);
	}//testtimesJ
	public static void testJtimes(){
		int n = 5;
		matrix A = new matrix(n,n);
		for (int i=0;i<n;++i){
			for (int j=0;j<n;++j){
				A[i, j] = rnd.NextDouble();
			}
		}
		matrix Q= A.copy();
		jacobi.Jtimes(Q, 1, 2, 23);
	}//testJtimes
	public static void testcyclic(){
		int n = 3;
		matrix A = new matrix(n,n);
		for (int i=0;i<n;++i){
			for (int j=0;j<n;++j){
				A[i, j] = rnd.NextDouble();
			}
		}
		matrix Q = A.copy();
		matrix V = matrix.id(n);
		jacobi.cyclic(Q, V);
		
		WriteLine("testing VTAV==D"); 
		if ((V.transpose()*A*V).approx(Q)) WriteLine("passed");
		
		WriteLine("testing VDVT==A"); 
		if ((V*Q*V.transpose()).approx(A)) WriteLine("passed");
		
		WriteLine("testing VTV==1"); 
		if ((V.transpose()*V).approx(matrix.id(n))) WriteLine("passed");
		
		WriteLine("testing VVT==1"); 
		if ((V*V.transpose()).approx(matrix.id(n))) WriteLine("passed");
	}//testcyclic
	public static void hamiltonianvarryingdr(){
		var outfile = new StreamWriter("varyingdr.txt");
		double rmax=10;
		for (double dr = 1.5+1/32;dr > 0.0;dr -=1.0/8){
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);
		for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
			matrix.set(H,i,i,-2);
			matrix.set(H,i,i+1,1);
			matrix.set(H,i+1,i,1);
		}
		matrix.set(H,npoints-1,npoints-1,-2);
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
		matrix V = matrix.id(npoints);
		
		jacobi.cyclic(H, V);
		
		outfile.WriteLine($"{dr} {H[0,0]}");
		}
		outfile.Close();
	}
	public static void hamiltonianvarryingrmax(){
		var outfile = new StreamWriter("varyingrmax.txt");
		double dr=0.1;
		for (double rmax = 2+1/32; rmax < 12.0; rmax +=1.0/16){
		int npoints = (int)(rmax/dr)-1;
		vector r = new vector(npoints);
		for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
		matrix H = new matrix(npoints,npoints);
		for(int i=0;i<npoints-1;i++){
			matrix.set(H,i,i,-2);
			matrix.set(H,i,i+1,1);
			matrix.set(H,i+1,i,1);
		}
		matrix.set(H,npoints-1,npoints-1,-2);
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];
		matrix V = matrix.id(npoints);
		jacobi.cyclic(H, V);
		
		outfile.WriteLine($"{rmax} {H[0,0]}");
		}
		outfile.Close();
	}
}//main