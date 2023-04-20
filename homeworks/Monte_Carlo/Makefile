all : Out.txt unit_circle_area.svg Fancy_integral.svg

Out.txt : main.exe 
	mono $< > $@

unit_circle_area.svg : unit_circle_area.gpi unit_circle_area.txt 
	gnuplot unit_circle_area.gpi

Fancy_integral.svg : Fancy_integral.gpi Fancy_integral.txt 
	gnuplot Fancy_integral.gpi

main.exe : main.cs Monte_Carlo.dll 
	mcs -target:exe -out:$@ \
		$(filter %.cs,$^) $(addprefix -reference:,$(filter %.dll,$^))
		
Monte_Carlo.dll : Monte_Carlo.cs vector.cs
	mcs -target:library -out:$@ $^
	
.PHONEY : clean
clean:
	$(RM) *.exe *.dll [Oo]ut* log* *.svg *.txt
