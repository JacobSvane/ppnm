using System;
using static System.Console;
using static System.Math;
using static cmath;
public static class QRGS{
	public static void decomp(ref matrix A,ref matrix R){ 
	matrix Q=A.copy( );
	for(int i =0; i<A.size2; i++){
		R[i,i]=Q[i].norm( );
		Q[i]/=R[i,i];
			for(int j=i+1; j<A.size2; j++){
				R[i,j]=Q[i].dot(Q[j]);
				Q[j] -= Q[i]*R[i,j];}
		}
	A=Q;
	}//decomp
	public static vector solve(matrix Q, matrix R, vector b){
		vector x = Q.transpose()*b;
		for (int i = x.size - 1; i >= 0; i--){
			double sum = 0; 
			for (int k = i + 1; k<R.size2; k++){
				sum += R[i,k]*x[k];
			}				
		x[i]=1/R[i,i]*(x[i]-sum);
		}
	return x;
	}//vector solve
	public static double determinant(matrix R){
		double det = 1;
		int n = R.size1;
		for (int i=0;i<n;++i){
			det *=R[i,i];
		}
	return det;
	}//vector solve
	public static matrix inverse(matrix Q, matrix R){
		matrix inverse = new matrix(R.size1,R.size2);
		for (int i=0; i<R.size1;i++){
			vector ei = new vector(R.size1); ei[i]=1;
			inverse[i] = solve(Q,R,ei);
		}
	return inverse;
	}//matrix inverse
}//Class



