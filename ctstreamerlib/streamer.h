#ifndef _H_COMPUTEREX_STREAMER_ORBREMOTE_H_0c67646b641bff9dd9538c8a736defcc
#define _H_COMPUTEREX_STREAMER_ORBREMOTE_H_0c67646b641bff9dd9538c8a736defcc

#include "ScreenLog.h"
#include "CurlWrapper.h"

struct Query
{
	char url[256];
	char data[256];
};

class Streamer
{
public:
	Streamer(HWND hwnd, char* username, char* pwd, char* uploadurl, Query loginq, Query pollq);
	~Streamer();
	void stream(); 
	void changeWindow(HWND newWindow);
	void setres(int resx, int resy);
	int timeoutvalue(){return timeout;}; 
	Query q(char* url, char* data);
private:
	void login();
	void poll();
	static const int polltime=60; // poll time is in seconds! 
	int timeout, lastpoll;
	char username[256], pwd[256], url[256];
	Query loginq, pollq;
	CurlWrapper * curl;
	ScreenLog * screener;
	HWND hwnd;
};

#endif