Out.txt : main.exe input.txt
	mono main.exe -input:input.txt -output:Out.txt

main.exe : main.cs
	mcs -target:exe -out:main.exe main.cs
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*
