# AccessOptionsPattern

وصف المشروع:
يوضح هذا المشروع كيفية استخدام نمط Options في ASP.NET Core (`IOptions`, `IOptionsSnapshot`, `IOptionsMonitor`) لقراءة إعدادات مربوطة بكلاس `AppSettings`.

نِقاط رئيسية:
- `AddOptions<T>().Bind(Configuration.GetSection(...))` لربط الإعدادات.
- يبين الاختلاف بين `IOptions` (قيمة ثابتة أثناء عمل التطبيق)، `IOptionsSnapshot` (قيمة جديدة لكل طلب ضمن نفس scope)، و`IOptionsMonitor` (يمكن التحديث عند تغيير المصدر).

Endpoints:
- /ioptions -> يعيد `IOptions<AppSettings>.Value`
- /ioptions-snapshot -> يعيد `IOptionsSnapshot<AppSettings>.Value`
- /ioptions-monitor -> يعيد `IOptionsMonitor<AppSettings>.CurrentValue`

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\AccessOptionsPattern"
dotnet run
```

ملاحظات:
- `appsettings.json` يحتوي قسم `AppSettings` مع قيم زمنية ونصية.
- لتجربة `IOptionsMonitor` بالتغيير التلقائي، يمكن تعديل الملف والاطلاع على سلوك `ioptions-monitor` (يتطلب reloadOnChange مفعلًا من البُنية الافتراضية).

انظر `Assignment.md` للتمارين.