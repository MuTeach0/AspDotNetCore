# UserSecretProvider

وصف المشروع:
يعرض هذا المشروع أمثلة أساسية للقراءة من التهيئة باستخدام `IConfiguration` — عادة يُستخدم لمناقشة User Secrets لكن الملف يظهر endpoints بسيطة لقراءة المفاتيح.

Endpoint:
- GET /{key} -> يعيد `config[key]`.

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\UserSecretProvider"
dotnet run
```

ملاحظات:
- لتجربة User Secrets تحتاج إلى تشغيل الأوامر المناسبة من dotnet user-secrets (ليس مضمنًا هنا افتراضيًا).
- `Assignment.md` يحتوي تمارين لكيفية تجربة السرّيات محليًا.