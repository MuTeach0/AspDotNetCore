# Module: Middlewares (Module#07)

محتوى هذا الموديول
- يحتوي على أمثلة ومشاريع قصيرة توضح مفاهيم مختلفة في ASP.NET Core middleware: إنشاء middleware، chaining، order, branching (`Map`, `MapWhen`, `UseWhen`)، وفهم متى لا يجب استدعاء `next()`.

طريقة التشغيل العامة
1. انتقل إلى مجلد المشروع الذي تريد تجربته، مثلاً:
   - `cd "M01.Overview"`
2. شغّل التطبيق:
   - `dotnet run`

متطلبات
- .NET SDK مثبت (نسخة تدعم مشاريع ASP.NET Core المستخدمة هنا). تأكد من `dotnet --version`.

قائمة المشاريع (موجز)
- `M01.Overview` — نظرة عامة.
- `M02.CreateMiddlewareUse` — إنشاء middleware باستخدام `Use`.
- `M03.CreateMiddlewareRun` — استخدام `Run` لإنهاء السلسلة.
- `M04.NeverNextAfterResponseSent` — مشاكل استدعاء `next()` بعد الإرسال.
- `M05.MiddlewareChaining` — chaining والآثار.
- `M06.MiddlewareOrderIsCritical` — أهمية الترتيب.
- `M07.MiddlewareBranching` — فرع باستخدام `Map`.
- `M08.MiddlewarBranchMapWhen` — فرع باستخدام `MapWhen`.
- `M09.MiddlewarBranchUseWhen` — شروط باستخدام `UseWhen`.
