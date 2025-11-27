# Module Assignment - Minimal Based APIs

قائمة تحقق شاملة للموديول:

1. اشرح الاختلاف بين `IResult`, `Results<T>` و `TypedResults` مع مثال لكلٍ منهم.
2. اشرح كيف تعمل parameter binding (FromRoute, FromServices, FromQuery, FromBody) مع مثال لكل مشروع.
3. أذكر ثلاثة سيناريوهات عملية تستخدم فيها `MapGroup` وميزته.

تمارين مقترحة:
- (مشروع تراكمي) أضف واجهة بسيطة (Swagger أو OpenAPI) لكل مشروع إن لم تكن موجودة، أو وثّق يدوياً مسارات مهمة.
- (اختبار) اكتب سيناريوهات اختبار بسيطة (باستخدام HTTP client أو `request.http`) للتحقق من إنشاء، تحديث، حذف منتج في `M05`.

خطوات التحقق السريع:
- لكل مشروع: `cd <project>` → `dotnet run` → استخدام `request.http` أو curl لتنفيذ المسارات المذكورة في README لكل مشروع.

ملاحظات ختامية:
- إذا تريد، أستطيع الآن فتح أي README ومعدّل Assignment وأجري تغييرات أو أضيف أمثلة `curl`/PowerShell جاهزة للاستخدام.
