# تمرين وفحص - M01 Http Verb Methods

قائمة تحقق لفهم المشروع:

1. اذكر كل المسارات والـ HTTP verbs المستخدمة.
2. ما هي القيم المرجعة لكل مسار حالياً (مثال: Ok, NoContent)؟
3. أين يمكن إضافة استدعاء للمخزن `ProductRepository`؟

تمارين مقترحة:
- (عملي) عدل مسار GET `/api/products` ليُرجِع قائمة منتجات من `ProductRepository` بدلاً من `Results.Ok()`.
- (تحقق) عدل PUT أو PATCH بحيث تُرجِع `Results.NotFound()` عندما لا يوجد المنتج بالـ id المطلوب.
- (إضافة) أضف مسار GET `/api/products/{id}/reviews` ليُرجع مراجعات المنتج من `ProductRepository`.

طرق التحقق:
- استخدم `dotnet run` ثم نفّذ طلبات عبر `curl` أو ملف `request.http` الموجود بالمشروع.

أسئلة قصيرة (اكتب الإجابات):
- ما الفرق بين `Results.Ok()` و `Results.NoContent()`؟
- متى نستخدم `MapMethods(..., ["OPTIONS"])`؟

