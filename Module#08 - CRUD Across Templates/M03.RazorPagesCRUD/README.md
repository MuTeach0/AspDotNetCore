# M03 - Razor Pages CRUD

وصف المشروع:
مشروع يستخدم Razor Pages لتنفيذ عمليات CRUD على `Product`. كل صفحة لها ملف `.cshtml` وملف PageModel `.cshtml.cs` مرتبط به.

الهدف:
- فهم نمط Razor Pages (صفحة = View + PageModel).
- مشاهدة كيفية كتابة منطق صفحة لكل عملية CRUD داخل PageModel.

ملفات مهمة:
- `Pages/Products/` - يحتوي على صفحات `Create.cshtml`, `Edit.cshtml`, `Details.cshtml`, `Delete.cshtml`, `index.cshtml` مع ملفات الكود-behind (`.cshtml.cs`).
- `Models/Product.cs` - تعريف النموذج.
- `Store/ProductStore.cs` - تخزين مؤقت بالذاكرة.

كيفية التشغيل (PowerShell):
```powershell
cd "f:\Module#08 - CRUD Across Templates\M03.RazorPagesCRUD"
dotnet run
```
ثم افتح المتصفح على المسار المعروض، واذهب إلى `/Products`.

ملاحظة سريعة حول الفرق مع MVC:
- في Razor Pages، كل صفحة تتعامل مع بياناتها داخل PageModel وتميل لتكون أبسط للـ UI التي تكون صفحة-مركزة.
- في MVC، لديك Controllers منفصلة تدير الـ Views.
