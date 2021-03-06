﻿#include <stdafx.h>
#include <Windows.h>

HWND secondWindow;
int CALLBACK wWinMain(HINSTANCE hInstance, HINSTANCE, PWSTR szCmdLine, int nCmdShow) {
	MSG msg{};
	HWND hwnd{};
	WNDCLASSEX wc{ sizeof(WNDCLASSEX) };
	HBRUSH silver = CreateSolidBrush(RGB(192, 202, 206));

	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hbrBackground = silver;
	wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
	wc.hIcon = LoadIcon(nullptr, IDI_APPLICATION);
	wc.hInstance = hInstance;

	wc.lpfnWndProc = [](HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)->LRESULT
	{
		PAINTSTRUCT ps;
		HDC hdc;
		RECT rectPlace;
		GetClientRect(hWnd, &rectPlace);
		static LPCWSTR text = L"Press LBM";
		static WPARAM hWndtoSend;
		switch (uMsg) {
		case WM_PAINT:
		{

			hdc = BeginPaint(hWnd, &ps);
			SetBkMode(hdc, TRANSPARENT);
			HFONT hFont = CreateFont(30, 0, 0, 0, 0, 0, 0, 0,
				DEFAULT_CHARSET,
				0, 0, 0, 0,
				L"Courier New"
			);
			SelectObject(hdc, hFont);
			SetTextColor(hdc, RGB(0, 0, 0));
			DrawText(hdc, text, wcslen(text), &rectPlace, DT_SINGLELINE | DT_CENTER | DT_VCENTER);
			EndPaint(hWnd, &ps);
		}
		return 0;
		case WM_LBUTTONDOWN:
		{
			secondWindow = FindWindow(L"lab2_2", L"lab2_2");
			if (secondWindow) text = L"Window found";
			else text = L"Can`t find window";
			InvalidateRect(hWnd, &rectPlace, true);
			hWndtoSend = (WPARAM)hWnd;
			SendMessage(secondWindow, WM_USER + 1, hWndtoSend, 0);
		}
		return 0;
		case WM_USER + 1:
		{
			PostQuitMessage(0);
		}
		case WM_RBUTTONDOWN:
		{
			HWND secondWindow = FindWindow(L"lab2_2", L"lab2_2");
			SendMessage(secondWindow, WM_USER + 2, NULL, 0);
		}
		return 0;
		case WM_CREATE:
		{
			HMENU hMenubar = CreateMenu();
			HMENU hMenu = CreateMenu();
			AppendMenu(hMenubar, MF_POPUP, (UINT_PTR)hMenu, L"Меню");
			AppendMenu(hMenu, MF_STRING, 1337, L"Открыть");
			AppendMenu(hMenu, MF_STRING, 1338, L"Закрыть");
			SetMenu(hWnd, hMenubar);
		}
		return 0;
		case WM_DESTROY:
		{
			PostQuitMessage(0);
		}
		return 0;

		case WM_COMMAND:
		{
			if (LOWORD(wParam) == 1337) {
				WinExec("C:\\Users\\Ollegik\\Desktop\\LAB2OK2\\Debug\\LAB2OK2.exe", SW_SHOW);
			}
			if (LOWORD(wParam) == 1338) {
				SendMessage(secondWindow, WM_CLOSE, NULL, NULL);
			}
		}

		}
		return DefWindowProc(hWnd, uMsg, wParam, lParam);
		
	};
	wc.lpszClassName = L"Class";
	wc.lpszMenuName = NULL;
	wc.style = CS_VREDRAW | CS_HREDRAW;

	if (!RegisterClassEx(&wc)) {
		return EXIT_FAILURE;
	}
	hwnd = CreateWindow(wc.lpszClassName, L"Lab_1", WS_OVERLAPPEDWINDOW, 0, 0, 400, 400, NULL, NULL, wc.hInstance, NULL);
	if (hwnd == INVALID_HANDLE_VALUE)
	{
		return EXIT_FAILURE;
	}
	ShowWindow(hwnd, nCmdShow);
	UpdateWindow(hwnd);

	while (GetMessage(&msg, nullptr, 0, 0)) {
		DispatchMessage(&msg);
	}
	return static_cast<int>(msg.wParam);
}

