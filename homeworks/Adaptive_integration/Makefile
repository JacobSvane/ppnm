all : Errorfunction.txt errorfunction.svg

Errorfunction.txt : main.exe 
	mono $< > $@

errorfunction.svg : Errorfunction.gpi errorfunction.txt Errorfunction_tabulated.data
	gnuplot Errorfunction.gpi

main.exe : main.cs Adaptive_integration.dll 
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
		

Adaptive_integration.dll : Adaptive_integration.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
