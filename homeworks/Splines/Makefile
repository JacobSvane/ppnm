all : Out.txt Linearinterp.svg

Out.txt : main.exe 
	mono $< > $@
	
Linearinterp.svg : Linearinterp.gpi Interpolation_xx.txt Function_xx.txt
	gnuplot Linearinterp.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs Splines.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
