all : Out.txt S-wave.svg Energies.svg S-wave_rmax8.svg Convergence.svg

Out.txt : main.exe 
	mono $< > $@

S-wave.svg : S-wave.gpi Function1.txt Function2.txt Function3.txt Function4.txt Function5.txt Function6.txt Function7.txt Function8.txt Function9.txt Function10.txt 
	gnuplot S-wave.gpi
	
S-wave_rmax8.svg : S-wave_rmax8.gpi Function8.txt
	gnuplot S-wave_rmax8.gpi

Convergence.svg : Convergence.gpi Convergence.txt
	gnuplot Convergence.gpi
	
Energies.svg : Energies.gpi Energies.txt 
	gnuplot Energies.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs Newton_method.cs ode.cs hydrogen.cs genlist.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
