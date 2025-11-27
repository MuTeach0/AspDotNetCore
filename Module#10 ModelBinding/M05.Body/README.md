# M05.Body

وصف: استقبال جسم الطلب (request body) كموديل (complex type) عبر عمل model-binding على JSON.

Endpoints
- POST /product-controller
  - Parameter: ProductRequest (بحسب `M05.Body.Requests`)
  - Response: يعيد نفس الـ object كـ JSON

تشغيل
  dotnet run --project "M05.Body/M05.Body.csproj"

مثال اختبار (curl)
- curl -H "Content-Type: application/json" -d "{\"name\":\"Pen\",\"price\":9.99}" http://localhost:5000/product-controller

ملاحظات
- تأكد من Content-Type صحيح وإرسال JSON صالح. إذا لم يكن JSON صالحًا سيعود 400 Bad Request من المودل بايندينغ.
