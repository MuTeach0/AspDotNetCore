# FirstASPProjectVSCode

وصف المشروع:
مشروع ASP.NET Core بسيط يُظهر كيفية استلام بيانات الطلب وطباعة معلومات الطلب والـ route values والـ headers.

Endpoint المثال:
- GET /authors/{author} -> يعيد JSON يحتوي معلومات عن الطلب: TraceIdentifier, Scheme, Host, Method, Path, Query, Headers, RouteValues, Body

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\FirstASPProjectVSCode"
dotnet run
```

ملاحظات:
- مفيد لتعلم التعامل مع `HttpContext` وقراءة محتوى الطلب.
- ملف `appsettings.json` موجود للتهيئة الأساسية.

انظر `Assignment.md` للتمارين.