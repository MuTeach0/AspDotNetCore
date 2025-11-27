# Module 04 - ASP.NET Core Structure and Templates

هذا الموديول يحتوي مشاريع قصيرة تشرح طرقًا مختلفة لقراءة التهيئة (configuration) في ASP.NET Core:

المشاريع المتضمنة:
- `AccessingConfiguration` — قراءة القيم وSections وBinding إلى كلاس.
- `AccessOptionsPattern` — استخدام نمط Options (`IOptions`, `IOptionsSnapshot`, `IOptionsMonitor`).
- `CommandLineProvider` — مزود القيم من سطر الأوامر.
- `Configrations/SystemEnvironmentVariableProvider` — قراءة من متغيرات البيئة.
- `FileProviders` — إضافة مصادر تهيئة من ملفات JSON/INI/مُخصّص.
- `FirstASPProjectVSCode` — مثال للتعامل مع HttpContext وقراءة الطلب.
- `InMemory` — إضافة قيم تهيئة برمجياً عبر InMemory provider.
- `UserSecretProvider` — توضيح فكرة User Secrets (التعليمات في Assignment).

كيفية تشغيل مشروع واحد:
- افتح Terminal في مسار الموديول ثم انتقل لمجلد المشروع المطلوب ثم نفّذ `dotnet run`.

أهداف التعلم:
- فهم كيفية دمج مصادر تهيئة متعددة وترتيب الأولويات.
- التعرف على نمط Options وكيفية استخدامه بفعالية.
- كيفية إدارة القيم الحساسة أثناء التطوير.

انظر `Assignment.md` على مستوى الموديول لتمارين شاملة.