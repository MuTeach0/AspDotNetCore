# M03.Headers

وصف: قراءة قيم من HTTP Headers باستخدام [FromHeader]. مثال على قراءة نسخة API من header خاص.

Endpoints
- GET /product-controller
  - [FromHeader(Name = "X-API-Version")] string apiVersion
  - Response: نص مثل "API Version: {apiVersion}"

تشغيل
  dotnet run --project "M03.Headers/M03.Headers.csproj"

اختبارات
- curl -H "X-API-Version: v1" http://localhost:5000/product-controller

ملاحظات
- تأكد من إرسال الـ header بنفس الاسم (`X-API-Version`).
- راجع كيف يتعامل النظام مع غياب الـ header (قد يرجع null).
