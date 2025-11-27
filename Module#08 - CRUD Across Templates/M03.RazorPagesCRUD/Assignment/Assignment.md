# Assignment - M03 RazorPagesCRUD

أسئلة للتحقق من الفهم:

1) أين يتم وضع منطق الصفحة (مثل الاستجابة لعملية POST) في Razor Pages؟

2) كيف تستلم صفحة `Edit` بيانات المنتج لتحريره؟ (ملاحظة: PageModel binding أو query parameter).

3) ما الفرق العملي بين `Pages/Products/index.cshtml` و`Views/Products/Index.cshtml` في مشروع MVC؟

4) إذا أردت إعادة استخدام منطق CRUD بين المشاريع الثلاثة، أين تضعه؟

---

اقتراح إجابات:

1) في ملف الـ PageModel (`.cshtml.cs`) المترافق مع الصفحة، عبر تعريف طرق مثل `OnGet`, `OnPost`.

2) عادةً يتم تمرير `id` في الـ route أو query string، ثم في `OnGet` تُحمّل المنتج من `ProductStore` وتضعه في خاصية منقوشة مع `[BindProperty]` أو تعرضه لـ View.

3) اسم الملف والمجلد يختلف: Razor Pages تعتمد على هيكل `Pages/` حيث كل صفحة مستقلة مع PageModel. MVC تجمع Views تحت `Views/ControllerName/` ويتم استدعاؤها من Controller.

4) من الأفضل استخراج منطق الوصول للبيانات إلى مكتبة/خدمة مشتركة (مثلاً `Store/ProductStore` أو واجهة `IProductRepository`) ثم إعادة استخدامها.
