TIME = time --portability --append --output $@

all : out.txt timing.txt Matrixtiming.txt Matrixtiming.svg

timing.txt : ocounting.exe
	echo N 100 >$@
	$(TIME) mono $< -N:100 >>$@
	echo N 200 >>$@
	$(TIME) mono $< -N:200 >>$@
	echo N 300 >>$@
	$(TIME) mono $< -N:300 >>$@
	echo N 400 >>$@
	$(TIME) mono $< -N:400 >>$@
	echo N 500 >>$@
	$(TIME) mono $< -N:500 >>$@
	echo N 600 >>$@
	$(TIME) mono $< -N:600 >>$@
	echo N 700 >>$@
	$(TIME) mono $< -N:700 >>$@
	echo N 1000 >>$@
	$(TIME) mono $< -N:1000 >>$@

Matrixtiming.data : timing.txt Readingtxt.exe
	mono $(filter %.exr,$^)< $^ >$@

Readingtxt.exe : Readingtxt.cs timing.txt Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

out.txt : main.exe
	mono $< > $@

Matrixtiming.svg : Matrixtiming.gpi Matrixtiming.data
	gnuplot Matrixtiming.gpi

ocounting.exe : ocounting.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

main.exe : main.cs Matrixreduction.dll
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))

Matrixreduction.dll : Matrixreduction.cs vector.cs matrix.cs cmath.cs complex.cs
	mcs -target:library -out:$@ $^

clean :
	$(RM) *.dll *.exe [Oo]ut*
