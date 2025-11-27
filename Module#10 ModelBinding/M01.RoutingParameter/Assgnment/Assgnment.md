Assgnment — M01 Routing Parameter

أسئلة ومهام للتحقق من الفهم:

1) اشرح بكلماتك ماذا يحدث عندما ترسل GET إلى `/product-controller/10`؟
   - اذكر من أين تأتي القيمة وكيف تُحوّل لنوع `int`.

2) عدّل الكود لتقبّل id اختياري (nullable) وارجع رسالة مخصصة عندما لا يُعطى id.
   - Acceptance: إرسال GET إلى `/product-controller` يرد برسالة توضح أن id مفقود.

3) ماذا سيحدث لو أرسلت `/product-controller/abc`؟ اشرح النتيجة ولماذا.

4) اختبار: نفّذ كل من الطلبات التالية وسجّل استجابة الخادم:
   - `/product-controller/1`
   - `/product-controller/0`
   - `/product-controller/abc`

التسليم
- أرسل ملف `Program.cs`/Controller المعدّل أو وصف التغييرات ورسائل الردّات المتوقعة.
