#ifndef _H_COMPUTEREX_ORB_REMOTE_LIBSTREAMER_H_8a8b07577acc4e7ab57a14c1c7b74185
#define _H_COMPUTEREX_ORB_REMOTE_LIBSTREAMER_H_8a8b07577acc4e7ab57a14c1c7b74185

#define DLLEXPORT extern "C" __declspec(dllexport) 
#define DLLIMPORT extern "C" __declspec(dllimport)

#ifdef LIBSTREAMER_IMPLEMENTATION
#define LIBSTREAMERFUNC DLLEXPORT
#else
#define LIBSTREAMERFUNC DLLIMPORT
struct Query
{
	char url[256];
	char data[256];
};

#endif

// LibStreamer C interface 
LIBSTREAMERFUNC void initstreamer(HWND hwnd, char* username, char* pwd, char* uploadurl, char* loginurl, char* loginData, char* pollurl, char* polldata);
LIBSTREAMERFUNC void stream(); 
LIBSTREAMERFUNC int  timeoutvalue(); 
LIBSTREAMERFUNC void cleanup(); 
LIBSTREAMERFUNC void changeWindow(HWND newWindow);
LIBSTREAMERFUNC void setres(int width, int height);
#endif
