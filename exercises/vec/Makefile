Out.txt : main.exe
	mono main.exe > Out.txt
	
vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs
	
DIR = $(Home)/repos/ppnm/exercises/matlib/complex          # or whatever your directory is
cmath.dll : $(Home)~/repos/ppnm/exercises/matlib/complex/cmath.cs $(Home)~/repos/ppnm/exercises/matlib/complex/complex.cs
	mcs -target:library -out:./cmath.dll $^
	
main.exe: main.cs vec.dll cmath.dll
	mcs -target:exe -out:main.exe -reference:vec.dll -reference:cmath.dll  main.cs
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*

