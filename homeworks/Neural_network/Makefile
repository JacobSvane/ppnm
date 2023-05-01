all : Out.txt PartA.svg PartB_deriv.svg PartB_antideriv.svg

Out.txt : main.exe 
	mono $< > $@

PartA.svg : Calculated_function.txt Training_points.txt
	gnuplot PartA.gpi

PartB_antideriv.svg : Calculated_function_PartB.txt Training_points_PartB.txt
	gnuplot PartB_antideriv.gpi
	
PartB_deriv.svg : Calculated_function_PartB.txt Training_points_PartB.txt
	gnuplot PartB_deriv.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs ode.cs genlist.cs ann.cs qnewton.cs simplex.cs givensqr.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
