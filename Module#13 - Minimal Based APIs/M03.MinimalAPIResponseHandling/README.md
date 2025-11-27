# M03 - Minimal API Response Handling

وصف المشروع:
- يوضح أساليب إرجاع الاستجابات في Minimal APIs: نص عادي، JSON، `IResult`, `Results<T>` و `TypedResults`.

المسارات المهمة من `Program.cs`:
- GET /text  -> يعيد نصاً عادياً
- GET /json  -> يعيد كائن JSON
- GET /api/products-mr-ir/{id:guid}  -> يستخدم IResult
- GET /api/products-le-ir/{id:guid}  -> يستخدم Lambda و IResult
- GET /api/products-mr-tr/{id:guid} -> استخدام `Results<Ok<Product>, NotFound>` (TypedResults)
- GET /api/products-le-tr/{id:guid} -> نفس باستخدام تعبير lambda

كيفية التشغيل:
```powershell
cd "M03.MinimalAPIResponseHandling"
dotnet run
```

ملفات مهمة:
- `Program.cs`
- `Data/ProductRepository.cs`
- `Models/Product.cs`

ملاحظات:
- هذه الأمثلة مفيدة لفهم كيفية التعبير عن أنواع الاستجابة المختلفة التي يتوقعها المستهلك (client) وTooling مثل OpenAPI.
