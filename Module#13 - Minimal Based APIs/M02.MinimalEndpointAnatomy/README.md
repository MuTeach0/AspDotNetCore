# M02 - Minimal Endpoint Anatomy

وصف المشروع:
- يشرح بنية Minimal API: طريقة تعريف المسارات، معالجاتها، وحقن الخدمات مثل `ProductRepository`.

النقاط الأساسية في `Program.cs`:
- يقوم بتسجيل `ProductRepository` كـ singleton.
- يظهر أمثلة على ربط المعاملات (parameter binding) من المسار والخدمات.
- يحتوي على مثال `GetAllProducts` و `GetProduct` كمثال على فصل المنطق في دوال مستقلة.

مسارات أساسية:
- GET /api/products
- GET /api/products/{id:guid}

كيفية التشغيل:
```powershell
cd "M02.MinimalEndpointAnatomy"
dotnet run
```

ملفات مهمة:
- `Program.cs`
- `Data/ProductRepository.cs`
- `Responses/ProductResponse.cs`

ملاحظات:
- هذا المشروع يوضح كيفية فصل منطق المعالجة إلى دوال واستخدام DI لتمرير `ProductRepository`.
