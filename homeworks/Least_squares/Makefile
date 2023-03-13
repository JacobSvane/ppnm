TIME = time --portability --append --output $@

all : out.txt decay.svg

out.txt : main.exe
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
