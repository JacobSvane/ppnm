Out.txt : hello.exe
	mono hello.exe > Out.txt

hello.exe : hello.cs
	mcs -out:hello.exe hello.cs

.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log*
