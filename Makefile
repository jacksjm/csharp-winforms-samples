output: mcs.e mono.e
 
mcs.e:
	mcs Program.cs -r:System.Windows.Forms.dll,System.Drawing.dll
 
mono.e:
	mono Program.exe
 
clean:
	rm *.exe