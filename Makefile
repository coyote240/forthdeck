connect:
	picocom -b 115200 /dev/ttyUSB0 \
		--imap lfcrlf,crcrlf \
		--omap delbs,crlf \
		--send-cmd "ascii-xfr -s -l200"
