# M04.NeverNextAfterResponseSent

شرح لمشكلة / مفهوم: لماذا لا يجب استدعاء `next()` بعد إرسال الاستجابة.

التشغيل
1. `cd "M04.NeverNextAfterResponseSent"`
2. `dotnet run`

نقاط للتأمل
- ماذا يحدث عند محاولة الكتابة إلى الاستجابة بعد إغلاقها؟
- كيف تتعامل middlewares مع هذا السيناريو؟
