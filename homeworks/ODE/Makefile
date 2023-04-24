all : Out.txt ummeqminusu.svg oscillator_with_friction.svg Lotka_volterra.svg

Out.txt : main.exe 
	mono $< > $@

ummeqminusu.svg : ummeqminusu.gpi ummeqminusu.txt 
	gnuplot ummeqminusu.gpi
	
Lotka_volterra.svg : Lotka_volterra.gpi Lotka_volterra.txt 
	gnuplot Lotka_volterra.gpi
	
oscillator_with_friction.svg : oscillator_with_friction.gpi oscillator_with_friction.txt 
	gnuplot oscillator_with_friction.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
		
main-sin.exe: main-sin.cs matlib.dll
	$(CSC) $< -reference:matlib.dll

main-erf.exe: main-erf.cs erf.cs matlib.dll
	$(CSC) -out:$@ -reference:matlib.dll $(filter %.cs,$^)

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs ode.cs genlist.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
