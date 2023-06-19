using System;
using static System.Console;
using static System.Math;
public class main{
	public static Random rnd = new System.Random(1); 
	public static void Main(){
		testQRGSdecomp();
		testQRGSsolve();
		testQRGSdeterminant();
		testQRGSinverse();
	}//Main
	public static void testQRGSdecomp(){
		int n = 5, m = 4;
		matrix A = new matrix(n,m);
		for (int i=0;i<n;++i){
			for (int j=0;j<m;++j){
				A[i, j] = rnd.NextDouble();
			}
		}
	matrix Q= A.copy();
	matrix R = new matrix(m,m);
	QRGS.decomp(ref Q, ref R);
	
	//Testing whether R is upper triangular
	WriteLine("Testing whether the R matrix is upper triangular:");
	bool ut = true;
	for (int i=0;i<R.size2;++i){
		if(matrix.approx(R[i,i],0)) ut = false;
		for (int j=0;j<i;++j){
			if(!matrix.approx(R[i,j],0)) ut = false;
	}
	}
	if (ut == true) WriteLine("matrix R is upper triangular");
	else WriteLine("matrix R is not upper triangular");
	
	//Testing whether Q^TQ=1
	WriteLine("Testing whether the Q^TQ = 1:");
	if ((Q.transpose()*Q).approx(matrix.id(Q.size2))) WriteLine("Q^TQ=1");
	else WriteLine("Q^TQ=/=1");
	
	//Testing whether the QR=A
	WriteLine("Testing whether the decomposition worked:");
	if(A.approx(Q*R))  WriteLine("The decomposition worked, i.e. QR=A");
	else WriteLine("The decomposition did not work at all");
	}//testQRGSdecomp
	public static void testQRGSsolve(){
		int n1 = 5, m1 = 5;
		matrix A1 = new matrix(n1,m1);
		for (int i=0;i<n1;++i){
			for (int j=0;j<m1;++j){
				A1[i, j] = rnd.NextDouble();
			}
		}
		matrix Q1= A1.copy();
		matrix R1 = new matrix(m1,m1);
		QRGS.decomp(ref Q1, ref R1);
		
		vector b1 = new vector(n1);
		for (int i=0;i<n1;++i){
			b1[i] = rnd.NextDouble();
		}
		
		vector sol = QRGS.solve(Q1, R1, b1);
		
		//Testing solitions
		WriteLine("Testing solution to vector problem");
		if ((A1*sol).approx(b1)) WriteLine("Ax=b is found to be true");
		else WriteLine("The solution is not found to be correct");
	}//testsolve
	public static void testQRGSdeterminant(){
		int n1 = 5, m1 = 5;
		matrix A1 = new matrix(n1,m1);
		for (int i=0;i<n1;++i){
			for (int j=0;j<m1;++j){
				A1[i, j] = rnd.NextDouble();
			}
		}
		matrix Q1= A1.copy();
		matrix R1 = new matrix(m1,m1);
		QRGS.decomp(ref Q1, ref R1);
		WriteLine("\nFinding determinant of randon 5x5 matrix:");
		WriteLine($"{QRGS.determinant(Q1)}\n");
	}//testdeterminant
	public static void testQRGSinverse(){
		int n2 = 5, m2 = 5;
		matrix A2 = new matrix(n2,m2);
		for (int i=0;i<n2;++i){
			for (int j=0;j<m2;++j){
				A2[i, j] = rnd.NextDouble();
			}
		}
	matrix Q2= A2.copy();
	matrix R2 = new matrix(m2,m2);
	QRGS.decomp(ref Q2, ref R2);
	
	matrix B = QRGS.inverse(Q2, R2);
	
	// testing that AB=I
	WriteLine("Testing that AB=I");
	if ((A2*B).approx(matrix.id(Q2.size2))) WriteLine("AB=I is found to be true");
	else WriteLine("The solution is not found to be correct");
	}//test inverse
}//main