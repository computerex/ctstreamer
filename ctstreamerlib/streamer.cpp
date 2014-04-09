#include <string.h>
#include <stdlib.h>
#include "streamer.h"

Streamer::Streamer(HWND hwnd, char* username, char* pwd, char* uploadurl, Query loginq, Query pollq)
{
	strcpy(this->username, username);
	strcpy(this->pwd, pwd);
	strcpy(this->url, uploadurl);
	
	/*strcpy(this->loginq.url, loginq.url);
	strcpy(this->pollq.url, pollq.url);
	strcpy(this->loginq.data, loginq.data);
	strcpy(this->pollq.data, pollq.data); */

	this->loginq=q(loginq.url, loginq.data);
	this->pollq=q(pollq.url, pollq.data);

	timeout=50; 
	curl = new CurlWrapper();
	screener = new ScreenLog(hwnd, "sample.jpg", timeout, true);
	login();
}
void Streamer::setres(int resx, int resy)
{
	screener->setres(resx, resy);
}
Streamer::~Streamer()
{
	curl->post("http://127.0.0.1/logout.php", "");
	delete screener;
	delete curl; 
}
void Streamer::stream()
{
	DWORD ctime = GetTickCount();
	DWORD dt = (ctime-lastpoll)/1000;
	if(dt>=polltime){
		poll();
		lastpoll=ctime;
	}
	screener->timestep();
	curl->uploadFile(url, "sample.jpg", "sample.jpg");
}
void Streamer::changeWindow(HWND newWindow)
{
	screener->changeWindow(newWindow);
}
void Streamer::login()
{
	curl->post(loginq.url, loginq.data);
}
void Streamer::poll()
{
	curl->get(pollq.url);
	//curl->post(pollq.url, "");
}
Query Streamer::q(char* url, char* data)
{
	Query qw;
	strcpy(qw.url, url);
	strcpy(qw.data, data);
	return qw; 
}
