# Assgnment — M05.MiddlewareChaining

أسئلة وتمارين:

1) ارسم تسلسل تنفيذ ثلاث middlewares: A -> B -> C عندما كل واحد ينفذ `await next()` ثم يكتب بعده.
2) مهمّة عملية: أضِف ثلاث middlewares تطبع رسائل قبل وبعد `next()` ثم لاحظ ترتيب الرسائل في الـ console.
3) متى يكون ترتيب middlewares مهمًا جدًا؟ اذكر حالة تطبيقية.
