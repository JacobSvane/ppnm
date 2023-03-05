TIME = time --portability --append --output $@

all : out.txt Eigenfunctions.svg

out.txt : main.exe
	mono $< > $@
	
Eigenfunctions.svg : Eigenfunctions.gpi varyingdr.txt varyingrmax.txt
	gnuplot Eigenfunctions.gpi

main.exe : main.cs Jacobidiagonalization.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Jacobidiagonalization.dll : Jacobidiagonalization.cs vector.cs matrix.cs cmath.cs complex.cs
	mcs -target:library -out:$@ $^

clean :
	$(RM) *.dll *.exe [Oo]ut* *.svg
