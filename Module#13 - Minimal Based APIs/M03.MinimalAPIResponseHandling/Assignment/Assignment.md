# تمرين وفحص - M03 Minimal API Response Handling

قائمة تحقق:
1. اشرح الفرق بين `IResult`, `Results<T>` و `TypedResults`.
2. اعرض متى تختار استخدام `TypedResults` بدلاً من `IResult`.

تمارين:
- (تحليل) عدّل أحد نقاط النهاية ليُرجِع `NotFound` في حالة عدم وجود المنتج، وجرب الاستجابة عبر `curl`.
- (إضافة) أضف مسار يعيد `Accepted` مع عنوان يتبع `AcceptedAtRoute` أو `Results.Accepted`.

أسئلة قصيرة:
- ما الفائدة من استخدام `Results<T>` في توثيق الـ API؟

