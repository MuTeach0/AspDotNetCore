# Module Assignment - CRUD Across Templates

هذا ملف للتحقق من فهمك العام للموديول. أجب على الأسئلة التالية وعلّق إجاباتك.

1) اشرح باختصار الفرق بين MVC و Razor Pages و Minimal/API-style (كما في M01).

2) أين تُخزن البيانات في هذه المشاريع؟ وكيف تحولها إلى تخزين دائم (قواعد بيانات)؟

3) اذكر خطوات إضافة صفحة/صفحة عرض جديدة تعرض تفاصيل منتج مُخصص.

4) كيف تُشارك منطق الوصول للبيانات بين المشاريع الثلاثة بطريقة نظيفة؟

5) ما خطوات إضافة التحقق من صحة الـ Model (Data Annotations) وعرض الأخطاء في واجهة المستخدم؟

---

اقتراح إجابات مختصرة:

1) MVC: فصل واضح بين Controller و Views و Models. Razor Pages: صفحة مرتبطة بـ PageModel، أبسط للصفحات المعتمدة على UI. Minimal/API-style: نقطة دخول بسيطة لربط endpoints وواجهات API بدون Controllers/Views.

2) حاليًا البيانات في `Store/ProductStore.cs` (in-memory). للتحويل إلى دائم: إنشاء `DbContext`, تكوين سلسلة اتصال، استبدال `ProductStore` بRepository يستخدم EF Core، تحديث تسجيل الخدمات في `Program.cs`.

3) الخطوات العامة: تعريف route/endpoint (MVC -> action + view, Razor -> page + PageModel), إضافة طريقة لجلب المنتج بالـ id، إنشاء View/Page ليعرض الخصائص.

4) استخراج الRepository أو واجهة `IProductRepository` ووضعها في مشروع مشترك أو مكتبة منفصلة، ثم حقنها (dependency injection) في كل مشروع.

5) أضف Data Annotations إلى خصائص `Product` (مثل `[Required]`, `[Range]`) ثم في View/Pages استدعِ `ModelState.IsValid` أو استخدم tag-helpers لعرض رسائل الخطأ.



---
أخبرني إن أردت أن أملأ إجاباتك داخل ملفات الـ Assignment مباشرة أو أن أضيف مزيدًا من الأسئلة/اختبارات تلقائية بسيطة (مثلاً unit tests).