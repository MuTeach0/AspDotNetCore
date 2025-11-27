Assignment — AccessOptionsPattern

1) اشرح بالـ 2-3 جمل الفرق بين `IOptions`, `IOptionsSnapshot`, و`IOptionsMonitor`.

2) شغل المشروع ثم قم بتعديل `AppSettings` في `appsettings.json` (غيّر `MaxDailyAppointment`). ماذا يحدث عند استدعاء كل endpoint من endpoints الثلاثة بعد التعديل؟ سجّل النتائج.

3) غيّر الكود لاستخدام `Configure<T>(...)` بدلاً من `AddOptions<T>().Bind(...)`. هل يتغير السلوك؟ اشرح.

4) أضف اختبارًا بسيطًا (يمكني أن أوضح كيف) يحقّق أن `IOptions<AppSettings>.Value.MaxDailyAppointment` يأخذ القيمة المتوقعة عند تشغيل التطبيق مع ملف تهيئة مخصص.