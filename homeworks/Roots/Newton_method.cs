using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static partial class Newton{
public static vector newton(Func<vector,vector>f, vector x, double eps=1e-2){
	int dim = x.size; 
	double dx;
	vector newx; vector fx;
	matrix J = new matrix(dim, dim);
	matrix R	= new matrix(dim, dim);
	do {
		dx = x.norm()*Pow(2,-26); if(dx == 0) dx = Pow(2,-26); 
		fx = f(x);
		
		for(int k = 0; k < dim; k++){
			newx = x.copy();
			newx[k] += dx;
			J[k] = (f(newx)-fx)/dx;
		}
	J = matlib.decomp(J, R);
	newx = matlib.solve(J, R, -fx);
	
	double lambda = 1.0;
	while(((f(x+lambda*newx)).norm() > (1.0-lambda/2)*fx.norm()) && lambda > 1.0/32)
		{lambda = lambda/2;}
	
	x = x + lambda*newx;
	} while(f(x).norm() > eps );
	return x;
}

}//class
