# M01.RoutingParameter

وصف: مثال بسيط يوضح استخدام Route Parameters في ASP.NET Core.

ما يفعله المشروع:
- يعرّف endpoint واحد GET يستقبل معرفًا صحيحًا من المسار ويرجع نفس القيمة.

Endpoints
- GET /product-controller/{id:int}
  - باراميتر: id (int) - يأخذ قيمة من مسار URL
  - رد: قيمة الـ id كـ 200 OK

تشغيل المشروع
- من PowerShell داخل مجلد المشروع:
  dotnet run
- أو تشغيل الحل من جذر workspace:
  dotnet run --project "M01.RoutingParameter/M01.RoutingParameter.csproj"

اختبار سريع (PowerShell / curl)
- طلب بسيط:
  curl http://localhost:5000/product-controller/5

ملاحظات
- راقب كيفية مطابقة نوع الـ route (int) والتعامل مع قيم غير صالحة (404 أو خطأ مطابقة المسار).
- الملف المسؤول: `Controllers/ProductController.cs`.
