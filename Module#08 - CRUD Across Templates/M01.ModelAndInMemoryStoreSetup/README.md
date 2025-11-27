# M01 - Model and In-Memory Store Setup

وصف المشروع:
هذا المشروع يعرّف نموذج البيانات (`Product`) ويُعد تخزينًا بسيطًا في الذاكرة عبر `ProductStore` لتجربة CRUD دون قاعدة بيانات.

الهدف:
- فهم تعريف النماذج (Models).
- تجربة تخزين بيانات مؤقت في الذاكرة.
- اختبار endpoints أو واجهة الAPI البسيطة باستخدام `request.http` أو أدوات مثل `curl`.

ملفات مهمة:
- `Models/Product.cs` - تعريف كلاس المنتج.
- `Store/ProductStore.cs` - تخزين بيانات مؤقت (in-memory) ومنطق CRUD.
- `Program.cs` - نقطة الدخول وإعداد الـ endpoints أو الخدمات.
- `request.http` - أمثلة طلبات HTTP لاختبار الـ API.

كيفية التشغيل (PowerShell):
```powershell
cd "f:\Module#08 - CRUD Across Templates\M01.ModelAndInMemoryStoreSetup"
dotnet run
```
ثم افتح `request.http` أو استخدم curl لعمل طلبات إلى الـ endpoints المعروضة في الـ logs.

ملاحظات:
- هذا مشروع تعلمي؛ البيانات تختفي عند إعادة تشغيل التطبيق.
- مناسب كـ scaffold قبل الانتقال إلى قاعدة بيانات حقيقية.
