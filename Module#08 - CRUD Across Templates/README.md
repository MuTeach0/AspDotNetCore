# Module #08 - CRUD Across Templates

ملخص الموديول:
هذا الموديول يتضمن ثلاثة مشاريع تطبيقية توضح كيفية تنفيذ عمليات CRUD باستخدام ثلاث مقاربات مختلفة في ASP.NET Core:

- `M01.ModelAndInMemoryStoreSetup` - إعداد نموذج وIn-Memory Store (Minimal / API-like).
- `M02.MVCCRUD` - تطبيق ASP.NET Core MVC مع Controllers وViews.
- `M03.RazorPagesCRUD` - تطبيق Razor Pages (Pages + PageModel).

كيفية تشغيل كل مشروع:
انتقل إلى مجلد المشروع المطلوب ثم شغّل:
```powershell
cd "f:\Module#08 - CRUD Across Templates\<project-folder>"
dotnet run
```
ثم افتح المتصفح إلى العنوان الذي يظهر في الـ output (عادة https://localhost:5001 أو http://localhost:5000).

نقاط يجب الانتباه لها:
- جميع المشاريع تستخدم نموذج `Product` وتحتوي على `Store/ProductStore.cs` كمخزن بيانات مؤقت.
- البيانات غير دائمة — عند إعادة التشغيل تفقد.
- هذه المشاريع ممتازة لفهم الفروقات بين الأنماط وتجهز للانتقال لاستخدام EF Core أو قواعد بيانات أخرى.

اقتراحات للتطوير التالي:
- إضافة EF Core مع SQLite أو SQL Server.
- إضافة تحقق (Validation) في النماذج وعرض رسائل الخطأ في Views/Pages.
- كتابة اختبارات وحدة (Unit Tests) للـ `ProductStore` وControllers/PageModels.
