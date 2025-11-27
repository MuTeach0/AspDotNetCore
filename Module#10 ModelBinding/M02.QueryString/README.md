# M02.QueryString

وصف: أمثلة على قراءة بيانات من Query String وModel binding للأنواع البسيطة والمعقّدة والمصفوفات.

Endpoints (مستخلصة من `Controllers/ProductController.cs`)
- GET /product-controller?page={page}&pageSize={pageSize}
  - Parameters: page (int), pageSize (int)
  - Response: نص يصف صفحة وكمية العناصر

- GET /product-controller-complex-query
  - Parameter: complex query object ([FromQuery] SearchRequest)
  - Response: يعيد الـ SearchRequest كـ JSON

- GET /product-controller-array?ids={guid1}&ids={guid2}&ids={guid3}
  - Parameter: ids[] (Guid[])
  - Response: يعيد قائمة الـ GUIDs

- GET /date-range-controller
  - Parameter: DateRangeQuery (model مُجمّع من query)

تشغيل
  dotnet run --project "M02.QueryString/M02.QueryString.csproj"

أمثلة اختبار
- curl "http://localhost:5000/product-controller?page=2&pageSize=10"
- curl "http://localhost:5000/product-controller-array?ids=GUID1&ids=GUID2"

ملاحظات
- راجع ملف `Models/DateRangeQuery.cs` و`SearchRequest` لمعرفة أسماء الحقول المتوقعة في الـ query.
- تحقق كيف يُحوّل الـ framework أنواع المصفوفات وـ Guid من query string.
