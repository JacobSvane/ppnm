all : Out.txt Higgs.svg Higgs_simplex.svg

Out.txt : main.exe 
	mono $< <higgs.data > $@

Higgs.svg : higgs.data Higgs_fit.txt
	gnuplot Higgs.gpi
	
Higgs_simplex.svg : higgs.data Higgs_simplex_fit.txt
	gnuplot Higgs_simplex.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs qnewton.cs genlist.cs simplex.cs givensqr.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
