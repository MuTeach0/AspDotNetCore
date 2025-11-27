Assignment — AccessingConfiguration

أجب عن الأسئلة التالية أو نفّذ التمارين.

1) ما الناتج المتوقع من طلب GET /get-value-by-Key مع إعدادات `appsettings.json` الحالية؟ اذكر القيمة المحددة.

2) عدّل `appsettings.json` لغيّر `ServiceName` إلى قيمة جديدة (مثلاً "My Test Service") ثم شغّل المشروع واطلب /get-value-by-Key لتتحقق.

3) استخدم /get-connection-string لعرض سلسلة الاتصال. ثم عدل اسم الاتصال في `appsettings.json` وحاول قراءته مجدداً.

4) أضف حقل جديد داخل `AppSettings` في `appsettings.json` (مثلاً `SupportEmail`) ثم حدّث كلاس `AppSettings` لقراءة هذا الحقل. تحقق من أنك تستطيع رؤيته عبر /get أو /bind.

5) اختبر: ماذا يحدث لو وضعت قيمة غير صحيحة لزمن (مثل `OpenAt`)؟ كيف تتصرف `GetSection().Bind()` مع القيم غير المتوافقة؟

تحقق من كل تمرين بتسجيل النتيجة (قيمة الاستجابة، أي أخطاء، وسطر أو سطرين يصفان ما فعلته).