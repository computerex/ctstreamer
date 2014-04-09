#ifndef _H_COMPUTEREX_H_ORBITER_SCREEN_LOG_H_ff5ea5c2c5598d33645c89c4a3fd32dc
#define _H_COMPUTEREX_H_ORBITER_SCREEN_LOG_H_ff5ea5c2c5598d33645c89c4a3fd32dc

#include <Windows.h>
#include <GdiPlus.h>

using namespace Gdiplus;

int GetEncoderClsid(const WCHAR* format, CLSID* pClsid);

class ScreenLog
{
public:
	ScreenLog(HWND hwnd, char * fname, int rate, bool override=true);
	~ScreenLog();
	void changeWindow(HWND newWindow);
	void timestep();
	void resize();
	void setres(int width, int height);
private:
	void shoot(); 

	HWND hwnd; 
	HBITMAP bitmap; 
	// time is in ms 
	int width, height, rate, lasttime, samples, resx, resy; 
	char fname[256];
	bool override;
	ULONG quality; 
	GdiplusStartupInput gdiplusstartup;
	ULONG_PTR gdiplusToken;
	CLSID             encoderClsid;
    EncoderParameters encoderParameters;
};


#endif
