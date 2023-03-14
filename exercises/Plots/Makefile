Gamma.svg Errorfunc.svg lngamma.svg : gamma.gpi gamma.data factorials.data errorfunc.gpi erf.data errorfunc.data lngamma.gpi lngamma.data 
	gnuplot gamma.gpi 
	gnuplot errorfunc.gpi
	gnuplot lngamma.gpi

gamma.data : plotgamma.exe
	mono $< > $@

erf.data : ploterf.exe
	mono $< > $@

lngamma.data : plotlngamma.exe
	mono $< > $@

plotgamma.exe : plotgamma.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

ploterf.exe : ploterf.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

plotlngamma.exe : plotlngamma.cs sfuns.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

sfuns.dll : gamma.cs erf.cs
	mcs -target:library -out:$@ $^

factorials.data : Makefile
	>$@
	echo 0 1 >>$@
	echo 1 1 >>$@
	echo 2 2 >>$@
	echo 3 6 >>$@
	echo 4 24 >>$@
	echo 5 120 >>$@
	echo 6 $$(echo '6*120' | bc) >>$@

errorfunc.data : Makefile
	>$@
	echo 0 0 >>$@
	echo 0.02 0.022564575 >>$@
	echo 0.04 0.045111106 >>$@
	echo 0.06 0.067624594 >>$@
	echo 0.08 0.090078126 >>$@
	echo 0.1  0.112462916 >>$@
	

.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.data
