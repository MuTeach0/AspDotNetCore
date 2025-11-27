# M04.Forms

وصف: أمثلة على Model Binding من بيانات النموذج (form data) ورفع ملفات عبر IFormFile.

Endpoints
- GET /product-controller
  - [FromForm] string name, [FromForm] decimal price
  - Response: JSON يحتوي name و price

- POST /upload-controller
  - Parameter: IFormFile file (multipart/form-data)
  - Function: يحفظ الملف في مجلد `uploads/` ويعيد رسالة نجاح

تشغيل
  dotnet run --project "M04.Forms/M04.Forms.csproj"

اختبار رفع ملف (PowerShell + curl مثال)
- curl -F "file=@C:\path\to\file.jpg" http://localhost:5000/upload-controller

ملاحظات
- تأكد من إرسال Content-Type: multipart/form-data لرفع الملفات.
- ملف الـ uploads موجود في جذر المشروع.
