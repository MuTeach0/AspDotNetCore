# M02 - MVC CRUD

وصف المشروع:
مشروع ASP.NET Core MVC يوفّر واجهة CRUD كاملة لإدارة `Product` باستخدام Controllers و Views.

الهدف:
- فهم بنية MVC (Model, View, Controller).
- معرفة كيفية تمرير البيانات من Controller إلى View.
- مشاهدة صفحات Create/Edit/Details/Delete/Index داخل `Views/Products`.

ملفات مهمة:
- `Controllers/ProductsController.cs` - سياسات الـ CRUD والـ routing للـ MVC.
- `Models/Product.cs` - نموذج المنتج.
- `Store/ProductStore.cs` - تخزين بيانات مؤقت في الذاكرة (يُستخدم من قِبل الـ Controller).
- `Views/Products/*.cshtml` - قوالب العرض (Index, Create, Edit, Details, Delete).

كيفية التشغيل (PowerShell):
```powershell
cd "f:\Module#08 - CRUD Across Templates\M02.MVCCRUD"
dotnet run
```
ثم افتح المتصفح على `https://localhost:5001` أو العنوان الذي يظهر في الـ output، واذهب إلى `/Products`.

ملاحظات:
- Views موجودة ضمن `Views/Products` وتعرض نموذج HTML مع روابط لإجراءات CRUD.
- هذا المشروع يُظهر كيفية الربط بين الـ Controller والـ View وModel.
