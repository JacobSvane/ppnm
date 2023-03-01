N=5e8
TIME = time --portability --append --output $@
Out.txt : main.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N -threads:1 >>$@
	$(TIME) mono $< -terms:$N -threads:2 >>$@
	$(TIME) mono $< -terms:$N -threads:3 >>$@
	$(TIME) mono $< -terms:$N -threads:4 >>$@
	
Outpfor.txt : pfor.exe Makefile
	>$@
	$(TIME) mono $< -terms:$N >>$@

main.exe : main.cs
	mcs $< 
	
pfor.exe : pfor.cs
	mcs $< 
