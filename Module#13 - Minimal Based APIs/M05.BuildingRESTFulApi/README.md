# M05 - Building RESTFul API

وصف المشروع:
- مشروع أكثر تقدماً لبناء API شبيه بالـ REST مع إمكانيات متعددة: paging, file download, redirects, PATCH, head/options, background processing simulation.

أهم المسارات (موجز):
- OPTIONS /api/products
- HEAD /api/products/{productId}
- GET /api/products (paged)
- GET /api/products/{productId}
- POST /api/products
- POST /api/products/{productId}/reviews
- PUT /api/products/{productId}
- PATCH /api/products/{productId}
- DELETE /api/products/{productId}
- POST /api/products/process (async job)
- GET /api/products/status/{jobId}
- GET /api/products/csv
- GET /api/products/physical-csv-file
- GET /api/products/products-legacy (redirect)
- GET /api/products/temp-products
- GET /api/products/legacy-products (permanent redirect)
- GET /api/products/product-catalog

ميزات إضافية:
- استخدام `TypedResults` و `Results` في أماكن مختلفة
- إنشاء ملفات CSV وإرجاعها كتحميل
- دعم JsonPatch للـ PATCH

كيفية التشغيل:
```powershell
cd "M05.BuildingRESTFulApi"
dotnet run
```

ملفات مهمة:
- `Endpoints/ProductEndpoints.cs` (منفذ كل المنطق)
- `Data/ProductRepository.cs`
- `Requests/` و `Responses/` (أنواع الطلب والاستجابة)

ملاحظات:
- هذا المشروع أقرب إلى حالة واقعية، مع حالات خطأ واضحة (Conflict, NotFound, 500) ومعالجة طلبات متقدمة.
