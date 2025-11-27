# تمرين وفحص - M05 Building RESTFul API

قائمة تحقق:
1. اذكر ثلاث حالات خطأ مُعالجة في `ProductEndpoints` (مثال: Conflict, NotFound, 500).
2. كيف يتم إنتاج CSV وأُرجِع كملف؟
3. ما دور `JsonPatchDocument` في الـ PATCH؟

تمارين:
- (عملي) جرب إنشاء منتج جديد عبر POST وتأكد أن `CreatedAtRoute` يعمل (تحقق من Location header).
- (تحليل) أضف فحصاً في `CreateProduct` ليتحقق من طول اسم المنتج وأنه غير فارغ، ثم اختبر الحالة Conflict.
- (إضافة) أضف endpoint صغير لفحص صحة API (health) مثل `GET /api/products/health` يعيد `200 OK` مع json بسيط.

أسئلة قصيرة:
- ما الفرق بين Redirect العادي و Permanent Redirect؟

