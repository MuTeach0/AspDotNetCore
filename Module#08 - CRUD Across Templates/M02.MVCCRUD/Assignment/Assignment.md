# Assignment - M02 MVCCRUD

أجب على الأسئلة التالية للتحقق من فهمك:

1) أين يُعرَّف الـ routing لإجراءات التحكم (controller actions)؟

2) ما الفرق بين View وPartial View (بإيجاز)؟ هل يوجد Partial Views هنا؟

3) كيف يتم تمرير بيانات Product من Controller إلى View؟ اذكر المثال البسيط (اسم المتغير أو الكود الموجز).

4) ماذا تفعل صفحة `Create.cshtml` و`Create` action في الـ Controller؟

5) أين توضع ملفات الـ Views لمشروع MVC هذا؟

---

اقتراح إجابات:

1) الـ routing يتم عبر الـ Controller واحترافيًا يمكن تكوينه في `Program.cs` أو الاعتماد على convention-based routing (مثلاً `app.MapControllerRoute`).

2) View عبارة عن صفحة كاملة تُعرض للمستخدم، بينما Partial View تُستخدم لإعادة استخدام قطعة من HTML داخل View أخرى. المشروع قد لا يحتوي Partial Views افتراضيًا.

3) Controller action يُرجع `View(model)` حيث `model` هو كائن `Product` أو قائمة `List<Product>`؛ داخل View تستعمل `@model` للوصول إليه.

4) `Create.cshtml` تعرض نموذج إدخال (form). عند الإرسال، `Create` POST action يتلقى الـ model ويقوم بإضافة المنتج إلى الـ `ProductStore` ثم يعيد التوجيه إلى Index.

5) داخل `Views/Products/` يوجد كل View الخاصة بالمنتجات.
