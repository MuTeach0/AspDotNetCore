# Module #10 — Model Binding

وصف الوحدة:
تحتوي هذه الوحدة على أمثلة عملية لكيفية عمل Model Binding في ASP.NET Core: مسارات (Route parameters)، Query strings، Headers، Form data، Request body (JSON)، و Cookies.

المشروعات الموجودة
- M01.RoutingParameter — Route parameter example
- M02.QueryString — Query string & complex binding
- M03.Headers — Binding from headers
- M04.Forms — Form data + file upload
- M05.Body — Request body (JSON) binding
- M06.Cookie — Read/write cookies

كيفية التشغيل السريع
- لتشغيل مشروعٍ واحد: cd إلى مجلد المشروع ثم:
  dotnet run
- أو شغّل الحل من جذر workspace إذا كان موجودًا:
  dotnet run --project "M01.RoutingParameter/M01.RoutingParameter.csproj"

نصائح للامتحان العملي
- افتح كل `Controllers/ProductController.cs` وجرّب الطلبات الموجودة في README لكل مشروع.
- استخدم `request.http` أو curl أو Postman لاختبار السلوك.

هيكلية المجلدات
- كل مشروع يحتوي README و/أو مجلد `Assgnment` مع ملف `Assgnment.md` لتمارين التحقق.

ماذا أفعل بعد ذلك؟
- نفّذ الاسئلة في ملفات Assgnment لكل مشروع وشارك نتائجك أو التغييرات للحصول على مراجعة.
