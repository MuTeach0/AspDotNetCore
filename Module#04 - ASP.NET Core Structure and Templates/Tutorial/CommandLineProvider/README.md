# CommandLineProvider

وصف المشروع:
هذا المشروع يبين استخدام مزود القيم من سطر الأوامر (command line configuration provider) أو ببساطة الوصول إلى الإعدادات عبر `IConfiguration` باستخدام مفاتيح.

نقطة التنفيذ:
- يوجد `Program.cs` تحت `Properties` ويعرّف endpoint واحد يستقبل `{key}` ويعيد `config[key]`.

كيفية التشغيل:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\CommandLineProvider"
dotnet run
```

مثال استخدام:
- شغل التطبيق ثم: GET http://localhost:5238/ServiceName

راجع `Assignment.md` للمهام.