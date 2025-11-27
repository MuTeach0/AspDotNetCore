# SystemEnvironmentVariableProvider

وصف المشروع:
يعرض هذا المشروع كيفية الوصول إلى قيم التهيئة عبر متغيرات النظام (Environment Variables) وقراءة إعدادات من `IConfiguration` بنفس الطريقة.

Endpoints:
- GET /{key} -> يعيد `config[key]`، مما يسمح بقراءة أي قيمة معرفة عبر الملف أو متغير بيئة.

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\Configrations\\SystemEnvironmentVariableProvider"
dotnet run
```

ملاحظات:
- جرّب ضبط متغير بيئة ثم طلب المفتاح المقابل لمعرفة الفرق مع `appsettings.json`.
- لتعيين متغير بيئة على Windows PowerShell:
```
$env:ServiceName = "FromEnv"
dotnet run
```

راجع `Assignment.md` للتمارين.