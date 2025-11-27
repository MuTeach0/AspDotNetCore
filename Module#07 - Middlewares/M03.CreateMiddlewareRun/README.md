# M03.CreateMiddlewareRun

مثال يشرح استخدام `app.Run(...)` لإنهاء السلسلة وتوليد استجابة مباشرة.

التشغيل
1. `cd "M03.CreateMiddlewareRun"`
2. `dotnet run`

الملفات الرئيسية
- `Program.cs` — يعرض استخدام `Run` لإنهاء المعالجة.

ملاحظات
- لاحظ أن `Run` عادة لا تستدعي `next()`، وتُنهي السلسلة.
