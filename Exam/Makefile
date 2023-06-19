TIME = time --portability --append --output $@

all : out.txt Matrixtiming.data Matrixtiming.svg

out.txt : main.exe 
	mono $< > $@
	
timing.txt : ocounting.exe
	echo N 25 >$@
	$(TIME) mono $< -N:25 >>$@
	echo N 50 >>$@
	$(TIME) mono $< -N:50 >>$@
	echo N 75 >>$@
	$(TIME) mono $< -N:75 >>$@
	echo N 100 >>$@
	$(TIME) mono $< -N:100 >>$@
	echo N 125 >>$@
	$(TIME) mono $< -N:125 >>$@
	echo N 150 >>$@
	$(TIME) mono $< -N:150 >>$@
	echo N 175 >>$@
	$(TIME) mono $< -N:175 >>$@
	echo N 200 >>$@
	$(TIME) mono $< -N:200 >>$@
	
Readingtxt.exe : Readingtxt.cs timing.txt Jacobidiagonalization.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixtiming.data : timing.txt Readingtxt.exe
	mono $(filter %.exr,$^)< $^ >$@
	
Matrixtiming.svg : Matrixtiming.gpi Matrixtiming.data MatrixtimingQR.data
	gnuplot Matrixtiming.gpi

ocounting.exe : ocounting.cs Jacobidiagonalization.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

main.exe : main.cs Jacobidiagonalization.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Jacobidiagonalization.dll : Jacobidiagonalization.cs vector.cs matrix.cs cmath.cs complex.cs Matrixreduction.cs 
	mcs -target:library -out:$@ $^

clean :
	$(RM) *.dll *.exe [Oo]ut* *.svg
