#include <Windows.h>
#include <string>
#include <algorithm>
#include <float.h>
#include <vector> 
#include <commctrl.h>
#include <math.h>

#pragma comment( lib, "comctl32.lib")

#pragma comment( linker, "/manifestdependency:\"type='win32' \
        name='Microsoft.Windows.Common-Controls' version='6.0.0.0' \
        processorArchitecture='*' publicKeyToken='6595b64144ccf1df' \
        language='*'\"")


#define LASERFPS 25
#define CREATECOLLECTOR 1500
#define DELETECOLLECTOR 1501
#define CREATEDRAW 1600
#define DELETEDRAW 1601
#define OFFSETX 400


HANDLE hThread1;
HANDLE hThread2;




DWORD WINAPI Thread1(LPVOID t);
DWORD WINAPI Thread2(LPVOID t);



BOOL thread1_working = false;
BOOL thread2_working = false;


int LSHIFTPRESSED = false, RSHIFTPRESSED = false;

COLORREF ACTUALCOLOR = RGB(255, 255, 255);
COLORREF ACTUALCOLOR2 = RGB(255, 255, 255);
/*CLASS*/

/*CLASS*/
/*CLASS*/
/*CLASS*/
/*CLASS*/
/*CLASS*/
/*CLASS*/
/*CLASS*/
/*CLASS*/


void NewColor() {
	ACTUALCOLOR = RGB(rand() % 155 + 100, rand() % 155 + 100, rand() % 155 + 100);
}
void NewColor2() {
	ACTUALCOLOR2 = RGB(rand() % 155 + 100, rand() % 155 + 100, rand() % 155 + 100);
}








DWORD WINAPI Thread1(LPVOID t) {
	//     _         _       ____    _____   ____     
		//| |       / \     / ___|  | ____| |  _ \   
		//| |      / _ \    \___ \  | _|    | |_) |   
		//| |___  / ___ \    ___) | | |__   | _ < |  
		//|_____| /_ / \_\  |____/  |_____| |_ | \_\ 
	int iter = 0;
	while (true) {
		RECT rect;
		rect.bottom = 700;
		rect.right = 630 + OFFSETX;
		rect.left = 200 + OFFSETX;
		rect.top = 150;
		HDC hdc = GetDC(HWND(t));
		FillRect(hdc, &rect, CreateSolidBrush(RGB(0, 0, 0)));

		PAINTSTRUCT ps;
		BeginPaint(HWND(t), &ps);
		HPEN Pen = CreatePen(PS_DASH, 10, ACTUALCOLOR);
		HPEN Box = (HPEN)SelectObject(hdc, Pen);
		SelectObject(hdc, Pen);
		MoveToEx(hdc, 400 + OFFSETX, 400, NULL);
		LineTo(hdc, 300 + 50 * sin(iter) + rand() % 50 + OFFSETX, 200 + (400 * LSHIFTPRESSED));
		Pen = CreatePen(PS_DASH, 10, ACTUALCOLOR2);
		Box = (HPEN)SelectObject(hdc, Pen);
		SelectObject(hdc, Pen);
		MoveToEx(hdc, 400 + OFFSETX, 400, NULL);
		LineTo(hdc, 500 + 50 * sin(iter) + rand() % 50 + OFFSETX, 200 + (400 * RSHIFTPRESSED));
		ReleaseDC(HWND(t), hdc);
		iter++;
		Sleep(1000 / LASERFPS);
	}




	return 0;
}



DWORD WINAPI Thread2(LPVOID t) {
	//SHIFTSTATE
	/*	 ____    _   _   ___   _____   _____
		/ ___|  | | | | |_ _| |  ___| |_   _|
		\___ \  | |_| |  | |  | |_      | |
		___) |  |  _  |  | |  |  _|     | |
		|____/  |_| |_| |___| |_|       |_|*/
	HFONT hFont = CreateFont(60, 0, 0, 0, 0, 0, 0, 0,
		DEFAULT_CHARSET,
		0, 0, 0, 0,
		L"Comic Sans"
	);
	HDC hdc = GetDC((HWND)t);
	SetBkMode(hdc, TRANSPARENT);
	SelectObject(hdc, hFont);
	while (true) {

		BOOL LSHIFT = GetAsyncKeyState(VK_LSHIFT);
		BOOL RSHIFT = GetAsyncKeyState(VK_RSHIFT);
		if (LSHIFT) {
			SetTextColor(hdc, RGB(0, 255, 0));
			LSHIFTPRESSED = true;
			NewColor();
		}
		else {
			SetTextColor(hdc, RGB(255, 0, 0));
			LSHIFTPRESSED = false;
		}

		RECT LEFTRECT;
		LEFTRECT.top = 0;
		LEFTRECT.bottom = 100;
		LEFTRECT.right = 200;
		LEFTRECT.left = 0;
		DrawText(hdc, L"LSHIFT", 10, &LEFTRECT, NULL);
		if (RSHIFT) {
			SetTextColor(hdc, RGB(0, 255, 0));
			RSHIFTPRESSED = true;
			NewColor2();
		}
		else {
			SetTextColor(hdc, RGB(255, 0, 0));
			RSHIFTPRESSED = false;
		}
		RECT RIGHTRECT;
		RIGHTRECT.top = 0;
		RIGHTRECT.bottom = 100;
		RIGHTRECT.right = 400;
		RIGHTRECT.left = 200;
		DrawText(hdc, L"RSHIFT", 10, &RIGHTRECT, NULL);
		Sleep(100);
	}
	return 0;
}




POINT Cursor;
bool fDraw = true;

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{

	switch (uMsg) {

	case WM_PAINT:
	{

	}

	return 0;

	case WM_MOUSELEAVE:
	{

	}
	case WM_CTLCOLORSTATIC:
	{


	}
	return 0;
	case WM_COMMAND:
	{

		if (LOWORD(wParam) == 120) {

		}
		if (LOWORD(wParam) == 2) {

		}
		if (LOWORD(wParam) == DELETEDRAW) {
			TerminateThread(hThread1, 0);
			thread1_working = false;

		}
		if (LOWORD(wParam) == DELETECOLLECTOR) {
			TerminateThread(hThread2, 0);
			thread2_working = false;
		}
		if (LOWORD(wParam) == CREATECOLLECTOR) {
			thread2_working = true;
			hThread2 = CreateThread(NULL, 0, Thread2, hWnd, 0, NULL);
		}
		if (LOWORD(wParam) == CREATEDRAW) {
			thread1_working = true;
			hThread1 = CreateThread(NULL, 0, Thread1, hWnd, 0, NULL);
		}

	}
	return 0;
	case WM_LBUTTONDOWN:
	{



	}
	return 0;
	case WM_RBUTTONDOWN:
	{

	}
	return 0;
	case WM_CREATE:
	{

		RECT Window;
		GetClientRect(hWnd, &Window);




		HWND CreateDButton = CreateWindow(L"BUTTON", L"DISCOTEKA", WS_CHILD | WS_VISIBLE, Window.right - 150, 450, 150, 20, hWnd, (HMENU)CREATEDRAW, NULL, NULL);
		HWND CreateCButton = CreateWindow(L"BUTTON", L"SHIFT HUYNA", WS_CHILD | WS_VISIBLE, Window.right - 150, 470, 150, 20, hWnd, (HMENU)CREATECOLLECTOR, NULL, NULL);
		HWND DeleteDButton = CreateWindow(L"BUTTON", L"KONEC DISCO", WS_CHILD | WS_VISIBLE, Window.right - 150, 490, 150, 20, hWnd, (HMENU)DELETEDRAW, NULL, NULL);
		HWND DeleteCButton = CreateWindow(L"BUTTON", L"KONEC SHIFTU", WS_CHILD | WS_VISIBLE, Window.right - 150, 510, 150, 20, hWnd, (HMENU)DELETECOLLECTOR, NULL, NULL);
	}
	return 0;
	case WM_DESTROY:
	{
		PostQuitMessage(0);
	}
	return 0;
	}
	return DefWindowProc(hWnd, uMsg, wParam, lParam);
};




int CALLBACK wWinMain(HINSTANCE hInstance, HINSTANCE, PWSTR szCmdLine, int nCmdShow) {
	MSG msg{};
	HWND hwnd{};
	WNDCLASSEX wc{ sizeof(WNDCLASSEX) };

	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hbrBackground = CreateSolidBrush(RGB(0, 0, 0));
	wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wc.hIcon = LoadIcon(nullptr, IDI_APPLICATION);
	wc.hInstance = hInstance;

	wc.lpfnWndProc = WndProc;
	wc.lpszClassName = L"Class";
	wc.lpszMenuName = NULL;
	wc.style = CS_VREDRAW | CS_HREDRAW;
	LoadLibrary(TEXT("Msftedit.dll"));
	if (!RegisterClassEx(&wc)) {
		return EXIT_FAILURE;
	}
	hwnd = CreateWindow(wc.lpszClassName, L"Lab_1", WS_OVERLAPPEDWINDOW, 0, 0, 1200, 800, NULL, NULL, wc.hInstance, NULL);
	if (hwnd == INVALID_HANDLE_VALUE)
	{
		return EXIT_FAILURE;
	}
	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	while (GetMessage(&msg, nullptr, 0, 0)) {
		DispatchMessage(&msg);
		TranslateMessage(&msg);
	}
	return static_cast<int>(msg.wParam);
}

