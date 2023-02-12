Out.txt : main.exe
	mono main.exe > Out.txt
	
vec.dll: vec.cs
	mcs -target:library -out:vec.dll vec.cs
	
cmath.dll: cmath.cs complex.cs 
	mcs $^ -target:library -out:$@

main.exe: main.cs vec.dll cmath.dll
	mcs -target:exe -out:main.exe -reference:vec.dll -reference:cmath.dll  main.cs
