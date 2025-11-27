# M01 - Http Verb Methods

ملف يشرح مشروع M01 - أمثلة على استخدام HTTP verbs في Minimal APIs.

ما يقوم به المشروع:
- يعرض أمثلة بسيطة على خرائط المسارات باستخدام MapGet, MapPost, MapPut, MapPatch, MapDelete, MapMethods (OPTIONS).

النقاط الأساسية:
- مسارات موجودة:
  - GET  /api/products
  - POST /api/products
  - PUT  /api/products/{id}
  - PATCH /api/products/{id}
  - DELETE /api/products/{id}
  - OPTIONS /api/products

كيفية التشغيل (PowerShell):
```powershell
cd "M01.HttpVerbMethods"
dotnet run
```

ملفات مهمة:
- `Program.cs` (تعريف المسارات)
- `Data/ProductRepository.cs` (مصدر بيانات افتراضي)
- `Models/` (نماذج المنتجات والمراجعات)

ملاحظات:
- هذه نسخة تعليمية بسيطة — معالجات المسارات ترجع نتائج ثابتة حالياً (مثل Results.Ok و Results.NoContent). يمكنك تعديل المنطق للتعامل مع البيانات من المخزن `ProductRepository`.
