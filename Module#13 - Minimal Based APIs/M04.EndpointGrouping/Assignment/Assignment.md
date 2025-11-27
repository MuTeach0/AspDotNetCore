# تمرين وفحص - M04 Endpoint Grouping

قائمة تحقق:
1. اشرح ما فائدة `MapGroup("/api/products")`.
2. أين ستضيف مصادقة (authentication) مشتركة لكل مسارات المنتجات؟

تمارين:
- (تحسين) أضف Middleware خاص بالمجموعة ليطبّق تحققاً بسيطاً (مثال: فحص هيدر ثابت) على جميع مسارات `/api/products`.
- (إضافة) أضف مسار جديد داخل نفس المجموعة مثل `GET /api/products/search` يقبل `q` كاستعلام.

أسئلة قصيرة:
- كيف يؤثر `WithName` على `CreatedAtRoute`؟

