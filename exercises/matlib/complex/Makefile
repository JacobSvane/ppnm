Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs cmath.dll
	mcs -reference:cmath.dll main.cs

#DIR = $(HOME)/repos/ppnm/exercises/matlib/complex          # or whatever your directory is
cmath.dll : $(HOME)/repos/ppnm/exercises/matlib/complex/cmath.cs $(HOME)/repos/ppnm/exercises/matlib/complex/complex.cs
	mcs -target:library -out:./cmath.dll $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*


