# تمرين وفحص - M02 Minimal Endpoint Anatomy

قائمة تحقق:
1. اشرح كيف يتم حقن `ProductRepository` في دوال مسارات Minimal API.
2. ما هو دور قيد المسار `{id:guid}`؟
3. لماذا قد نفصل المعالج إلى دالة منفصلة بدلاً من lambda مباشرة؟

تمارين:
- (عملي) أضف مسار POST `/api/products` يقوم بإنشاء منتج جديد وارجاع `CreatedAtRoute` لعرض الموقع.
- (تحقق) أدخل تأخيراً اصطناعياً (Task.Delay) في `GetAllProducts` ولاحظ كيف تتعامل الدالة مع async.

أسئلة قصيرة:
- متى يستخدم الإطار الربط التلقائي من الـ body مقابل الـ route؟

