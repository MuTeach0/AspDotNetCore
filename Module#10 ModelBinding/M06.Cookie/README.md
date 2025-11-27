# M06.Cookie

وصف: مثال على قراءة Cookies من الطلب وعرض تفضيلات المستخدم.

Endpoints
- GET /Preferences
  - يقرأ الـ cookies: theme, language, timeZone
  - Response: JSON يحتوي القيم المقروءة (قد تكون null إذا لم تُرسل)

تشغيل
  dotnet run --project "M06.Cookie/M05.Body.csproj"
  (ملاحظة: مشروع داخل المجلد اسمه M05.Body.csproj حسب الهيكلة الحالية)

اختبار (PowerShell / curl)
- curl -H "Cookie: theme=dark; language=en; timeZone=UTC" http://localhost:5000/Preferences

ملاحظات
- راجع ملفات Requests أو Program.cs لإنشاء Cookie من الخادم إن رغبت في اختبار إنشاء/قراءة.
