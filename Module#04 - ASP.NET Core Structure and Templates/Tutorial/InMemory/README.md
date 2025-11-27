# InMemory

وصف المشروع:
يعرض هذا المشروع كيفية إضافة مزود إعدادات من الذاكرة (`AddInMemoryCollection`) لحقن قيم تهيئة ديناميكية عند وقت التشغيل.

Endpoint:
- GET /{key} -> يعيد قيمة التهيئة للـ key المطلوب

تشغيل المشروع:
```
cd "f:\\Module#04 - ASP.NET Core Structure and Templates\\Tutorial\\InMemory"
dotnet run
```

ملاحظات:
- القيم مضافة برمجياً في `Program.cs` عبر `AddInMemoryCollection`.
- مفيد للاختبارات أو سيناريوهات التجريب السريع.

انظر `Assignment.md`.