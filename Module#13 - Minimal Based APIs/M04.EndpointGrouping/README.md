# M04 - Endpoint Grouping

وصف المشروع:
- يوضح كيفية تجميع نقاط النهاية (Endpoint Group) باستخدام `MapGroup` وفصل تعريف endpoints في ملف مستقل (`Endpoints/ProductEndpoints.cs`).

ما يقوم به:
- ينشىء مجموعة مسارات تحت `/api/products` ثم يعرّف المسارات الفرعية:
  - GET    /api/products/
  - GET    /api/products/{id}
  - POST   /api/products/
  - PUT    /api/products/{id}
  - DELETE /api/products/{id}

كيفية التشغيل:
```powershell
cd "M04.EndpointGrouping"
dotnet run
```

ملفات مهمة:
- `Endpoints/ProductEndpoints.cs` (حيث تُعرّف المجموعة)
- `Program.cs` (يستدعي `MapProductEndpoints()`)

ملاحظات:
- تجميع النقاط مفيد لتنظيم مشاريع أكبر ولإضافة سمات/متوسطة (middlewares) على مستوى مجموعة.
