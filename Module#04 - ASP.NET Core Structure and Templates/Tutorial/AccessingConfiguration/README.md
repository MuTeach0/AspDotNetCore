# AccessingConfiguration

وصف المشروع:
هذا المشروع يوضح كيفية الوصول إلى قيم التهيئة (configuration) من `IConfiguration` في تطبيق ASP.NET Core.

نِقاط رئيسية:
- يعرض أمثلة على قراءة القيم مباشرة بالـ key، بالـ path (مثلاً `ConnectionStrings:DefaultConnection`) وباستخدام `GetConnectionString`.
- يعرض كيفية الحصول على قسم مخصص `AppSettings` وتحويله إلى كلاس.

Endpoints (موجودة في `Program.cs`):
- GET /get-value-by-Key -> يعيد قيمة `ServiceName`
- GET /get-value-by-Path -> يعيد `ConnectionStrings:DefaultConnection`
- GET /get-connection-string -> يعيد `GetConnectionString("DefaultConnection")`
- GET /get-value -> يعيد `ServiceName` باستخدام `GetValue<string>`
- GET /get -> يعيد الـ POCO المربوط بالقسم `AppSettings`
- GET /bind -> يملأ كائن `AppSettings` بواسطة `Bind` ويعيده

تشغيل المشروع:
1. افتح Terminal في مجلد المشروع `AccessingConfiguration`.
2. شغل:

```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\AccessingConfiguration"
dotnet run
```

ثم افتح المتصفح أو استخدم `curl` لطلب أي endpoint أعلاه.

ملاحظات على التهيئة:
- `appsettings.json` يحتوي على `ServiceName`, `ConnectionStrings` و`AppSettings`.

ملف المهمة يوجد بجانبي `Assignment.md` يحتوي أسئلة وتمارين قصيرة للتحقق من الفهم.