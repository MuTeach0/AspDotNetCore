# FileProviders

وصف المشروع:
يوضح هذا المشروع كيفية إضافة مصادر تهيئة مخصصة من ملفات: JSON مخصص (`mycustomeconfig.json`) وملف INI (`config.INI`) بالإضافة إلى `appsettings.json`.

Endpoints:
- GET /{key} -> يقرأ من التهيئة العامة
- GET /ini/{key} -> مثال لاستخدام مفتاح من ملف INI

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\FileProviders"
dotnet run
```

ملاحظات:
- الملفات `mycustomeconfig.json` و`config.INI` موجودة في مجلد المشروع ويُضافان عبر `AddJsonFile` و`AddIniFile`.
- `reloadOnChange: true` مفعل مما يسمح بالتحديث أثناء التشغيل.

انظر `Assignment.md` للمهام.