#include <windows.h>
#include <xstring>
int r, g, b = 0;
LRESULT CALLBACK WindowProcess(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInst,
    HINSTANCE hPrevInst,
    LPSTR pCommandLine,
    int nCommandShow) {
    TCHAR className[] = L"Мой класс";
    HWND hWindow;
    MSG message;
    WNDCLASSEX windowClass;
  


    windowClass.cbSize = sizeof(windowClass);
    windowClass.style = CS_HREDRAW | CS_VREDRAW;
    windowClass.lpfnWndProc = WindowProcess;
    windowClass.lpszMenuName = NULL;
    windowClass.lpszClassName = className;
    windowClass.cbWndExtra = NULL;
    windowClass.cbClsExtra = NULL;
    windowClass.hIcon = LoadIcon(NULL, IDI_WINLOGO);
    windowClass.hIconSm = LoadIcon(NULL, IDI_WINLOGO);
    windowClass.hCursor = LoadCursor(NULL, IDC_ARROW);
    windowClass.hbrBackground = CreateSolidBrush(RGB(0 + r, 100 + g, 255 + b));
    windowClass.hInstance = hInst;



    if (!RegisterClassEx(&windowClass))
    {
        MessageBox(NULL, L"Не получилось зарегистрировать класс!", L"Ошибка", MB_OK);
        return NULL;
    }
    hWindow = CreateWindow(className,
        L"Программа ввода символов",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT,
        NULL,
        CW_USEDEFAULT,
        NULL,
        (HWND)NULL,
        NULL,
        HINSTANCE(hInst),
        NULL
    );
    if (!hWindow) {
        MessageBox(NULL, L"Не получилось создать окно!", L"Ошибка", MB_OK);
        return NULL;
    }
    ShowWindow(hWindow, nCommandShow);
    UpdateWindow(hWindow);
    while (GetMessage(&message, NULL, NULL, NULL)) {
        TranslateMessage(&message);
        DispatchMessage(&message);
    }
    return message.wParam;
}



LRESULT CALLBACK WindowProcess(HWND hWindow,
    UINT uMessage,
    WPARAM wParameter,
    LPARAM lParameter)
{
    HDC hDeviceContext;
    PAINTSTRUCT paintStruct;
    RECT rectPlace;
    HFONT hFont;
    static wchar_t* text=new wchar_t[50] ;
    static int counter = 0;
    switch (uMessage)
    {
    case WM_CREATE:
        MessageBox(NULL,
            L"Вводите символы и они будут отображаться на экране",
            L"Козинов Олег ИУ5-45Б", MB_ICONASTERISK | MB_OK);
        break;

    case WM_LBUTTONDOWN: {
        
            MessageBox(0, L"ЛКМ", L"Сообщение о нажатии", MB_OK);
        
    }
    return 0;
    case WM_RBUTTONDOWN: {
        hDeviceContext = GetDC(hWindow); 
        RECT rectangle;
        GetClientRect(hWindow, &rectangle);
        FillRect(hDeviceContext, &rectangle, CreateSolidBrush(RGB(rand() % 155 + 100, rand() % 155 + 100, rand() % 155 + 100))); //рандомыч
        ReleaseDC(hWindow, hDeviceContext);
        r = rand() % 100; g = rand() % 100; b = rand() % 100;
        counter = 0; // no text
        return 0;
    }
    
    case WM_PAINT:
        hDeviceContext = BeginPaint(hWindow, &paintStruct); 
        GetClientRect(hWindow, &rectPlace);
        SetTextColor(hDeviceContext, NULL);
        hFont = CreateFont(45, 0, 0, 0, 0, 0, 0, 0,
            DEFAULT_CHARSET,
            0, 0, 0, 0,
            L"Arial Bold"
            
        );
        SelectObject(hDeviceContext, hFont);
        SetBkMode(hDeviceContext, TRANSPARENT);
        rectPlace.left=1000;
        DrawText(hDeviceContext, (LPCWSTR)text, counter, &rectPlace, NULL); //текстик
        EndPaint(hWindow, &paintStruct);
        break;

    case WM_KEYDOWN:
        switch (wParameter)
        {
        case VK_HOME:case VK_END:case VK_PRIOR:
        case VK_NEXT:case VK_LEFT:case VK_RIGHT:
        case VK_UP:case VK_DOWN:case VK_DELETE:
        case VK_SHIFT:case VK_SPACE:case VK_CONTROL:
        case VK_CAPITAL:case VK_MENU:case VK_TAB:
        case VK_BACK:case VK_RETURN:
            break;
        default:
            text[counter] = (char)wParameter;
            counter++;   // для очистки текста
            InvalidateRect(hWindow, NULL, TRUE);
            break;
        }break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWindow, uMessage, wParameter, lParameter);
    }
    return NULL;
}