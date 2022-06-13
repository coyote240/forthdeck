# As recommended by the Mecrisp-Stellaris unofficial docs
# @ https://mecrisp-stellaris-folkdoc.sourceforge.io/serial-terminals.html
connect:
	picocom -b 115200 /dev/ttyUSB0 \
		--imap lfcrlf,crcrlf \
		--omap delbs,crlf \
		--send-cmd "ascii-xfr -s -l200"
