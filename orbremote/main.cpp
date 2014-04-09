#define STRICT
#define ORBITER_MODULE

#include <orbitersdk.h>
#include <Windows.h>
#include <libstreamer.h>
volatile long exitsimulation = 0; 
HANDLE handle;

DWORD WINAPI thread(LPVOID param)
{
	while (!exitsimulation)
	{
		stream();
		Sleep(timeoutvalue());
	}
	return 0;
}

DLLCLBK void opcOpenRenderViewport(HWND hRenderWnd, DWORD w, DWORD h, BOOL fullscreen)
{
	initstreamer(hRenderWnd, "mohd", "majid", "http://127.0.0.1/simupdate.php", 
						"http://127.0.0.1/login.php", "username=mohd&password=majid", "http://127.0.0.1/streampoll.php", "");
	handle=CreateThread(NULL, 0, thread, 0, 0, NULL);  
}
DLLCLBK void opcCloseRenderViewport()
{
	InterlockedIncrement(&exitsimulation);
	WaitForSingleObject(handle, INFINITE);
}
