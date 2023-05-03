TIME = time --portability --append --output $@

all : Out.txt decay.svg

Out.txt : main.exe
	mono $< > $@
	
decay.svg : decay.gpi decay.data
	gnuplot decay.gpi

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs Leastsquares.cs
	mcs -target:library -out:$@ $^

clean :
	$(RM) *.dll *.exe [Oo]ut* *.svg *.txt
