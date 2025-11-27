# M02.CreateMiddlewareUse

مثال يوضح كيفية إنشاء Middleware باستخدام `app.Use(...)` في ASP.NET Core.

كيفية التشغيل
1. افتح الطرفية داخل المجلد:
   - `cd "M02.CreateMiddlewareUse"`
2. شغّل:
   - `dotnet run`

الملفات المهمة
- `Program.cs` - بناء الـ pipeline مع `Use` middleware.
- `request.http` - أمثلة لاختبار التتابع.

ما يجب ملاحظته
- كيف تُستخدم `Use` للحصول على سلوك قبل/بعد `next()`.
