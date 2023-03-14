using System;
using static System.Console;
using static System.Math;
public static partial class matlib{
public static (vector,matrix) lsfit(Func<double,double>[] fs,vector x,vector y,vector dy){
int n=x.size, m=fs.Length;
matrix A=new matrix(n,m);
vector b=new vector(n);
for(int i=0;i<n;i++){
	b[i]=y[i]/dy[i];
	for(int k=0;k<m;k++) A[i,k] = fs[k](x[i])/dy[i];
}
matrix R = new matrix(A.size2,A.size2);
matrix Q = decomp(A, R);

matrix covariance = inverse(Q.transpose()*Q,R);
return (solve(Q, R, b),covariance);
}
}