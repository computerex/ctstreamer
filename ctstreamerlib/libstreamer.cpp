#define LIBSTREAMER_IMPLEMENTATION
#include "streamer.h"
#include "libstreamer.h"
#include <stdio.h>

Streamer * streamer = 0;


LIBSTREAMERFUNC void initstreamer(HWND hwnd, char* username, char* pwd, char* uploadurl, char* loginurl, char* loginData, char* pollurl, char* polldata)
{
	if ( streamer != 0 )
		delete streamer; 
	streamer = new Streamer(hwnd, username, pwd, uploadurl, streamer->q(loginurl, loginData), streamer->q(pollurl, polldata));
}
LIBSTREAMERFUNC void stream()
{
	if ( streamer == 0 ) return;
	streamer->stream();
}
LIBSTREAMERFUNC int  timeoutvalue()
{
	if ( streamer == 0 ) return 0;
	return streamer->timeoutvalue();
}

LIBSTREAMERFUNC void cleanup()
{
	if ( streamer ) 
		delete streamer;
	streamer = 0;
}

LIBSTREAMERFUNC void changeWindow(HWND newWindow)
{
	if ( streamer )
		streamer->changeWindow(newWindow);
}

LIBSTREAMERFUNC void setres(int width, int height)
{
	if ( streamer )
		streamer->setres(width, height);
}