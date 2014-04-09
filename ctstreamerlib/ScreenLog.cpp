#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "ScreenLog.h"


int GetEncoderClsid(const WCHAR* format, CLSID* pClsid)
{
   UINT  num = 0;          // number of image encoders
   UINT  size = 0;         // size of the image encoder array in bytes

   ImageCodecInfo* pImageCodecInfo = NULL;

   GetImageEncodersSize(&num, &size);
   if(size == 0)
      return -1;  // Failure

   pImageCodecInfo = (ImageCodecInfo*)(malloc(size));
   if(pImageCodecInfo == NULL)
      return -1;  // Failure

   GetImageEncoders(num, size, pImageCodecInfo);

   for(UINT j = 0; j < num; ++j)
   {
      if( wcscmp(pImageCodecInfo[j].MimeType, format) == 0 )
      {
         *pClsid = pImageCodecInfo[j].Clsid;
         free(pImageCodecInfo);
         return j;  // Success
      }    
   }

   free(pImageCodecInfo);
   return -1;  // Failure
}
void ScreenLog::setres(int width, int height)
{
	this->resx=width;
	this->resy=height;
}
ScreenLog::ScreenLog(HWND hwnd, char * fname, int rate, bool override)
{
	this->hwnd=hwnd;
	strcpy(this->fname, fname);
	this->rate=rate; 
	this->override=override;
	this->quality=15; 
	width = height = samples = 0;
	lasttime = GetTickCount(); 
	bitmap = 0;
	resx = 960;
	resy = 540;
	GdiplusStartup(&gdiplusToken, &gdiplusstartup, NULL);
	GetEncoderClsid(L"image/jpeg", &encoderClsid);
    encoderParameters.Count = 1;
    encoderParameters.Parameter[0].Guid = EncoderQuality;
    encoderParameters.Parameter[0].Type = EncoderParameterValueTypeLong;
    encoderParameters.Parameter[0].NumberOfValues = 1;
	encoderParameters.Parameter[0].Value = &(this->quality);

	
	// initialization
	resize(); 
}

ScreenLog::~ScreenLog()
{		
	DeleteObject(bitmap);
	GdiplusShutdown(gdiplusToken);
}

void ScreenLog::timestep()
{
	DWORD ctime = GetTickCount();
	if ( (ctime-lasttime) >= rate ) {
		shoot();
		lasttime=ctime;	
	}
}
void ScreenLog::changeWindow(HWND newWindow)
{
	hwnd=newWindow;
	resize();
}
void ScreenLog::resize()
{
	// get boundaries of the client region
	RECT rect;
	GetClientRect(hwnd, &rect);
	width=rect.right;
	height=rect.bottom;
	//MessageBox(0, "resizing", "resizing", MB_OK);
	// window resize
	if ( bitmap != 0 ){
		DeleteObject(bitmap);
	}

	HDC hDC = GetDC(hwnd);
	bitmap = CreateCompatibleBitmap(hDC, resx, resy);
	ReleaseDC(hwnd, hDC);
}

void ScreenLog::shoot()
{
	HDC hDC = GetDC(hwnd);
	HDC dc = CreateCompatibleDC(hDC);
	SelectObject(dc, bitmap);

	SetStretchBltMode(dc, HALFTONE);
	StretchBlt(dc, 0, 0, resx, resy, hDC, 0, 0, width, height, SRCCOPY);
	
	DeleteDC(dc);
	ReleaseDC(hwnd, hDC);
	samples++; 
	
	char buffer[256];
	if (override)
		strcpy(buffer, fname);
	else
		sprintf(buffer, "%s%d.jpg", fname, samples);

	Bitmap * img = new Bitmap(bitmap, 0);
	wchar_t cb[256];
	mbstowcs(cb, buffer, 256);
	img->Save(cb, &encoderClsid, &encoderParameters);
	delete img;
}
