# Module#13 - Minimal Based APIs

هذا الموديول يحتوي على مجموعة مشاريع صغيرة تشرح مبادئ Minimal APIs في .NET.

المشاريع داخل الموديول:
- `M01.HttpVerbMethods` - أمثلة على الـ HTTP verbs
- `M02.MinimalEndpointAnatomy` - بنية نقطة النهاية Minimal API
- `M03.MinimalAPIResponseHandling` - طرق إرجاع الاستجابات (IResult, TypedResults)
- `M04.EndpointGrouping` - تجميع النقاط (MapGroup)
- `M05.BuildingRESTFulApi` - مشروع متقدم لبناء RESTful API

كيفية التجربة السريعة لكل مشروع:
- افتح PowerShell في جذر الموديول ثم نفّذ:
```powershell
cd "<project-folder>"
dotnet run
```
واستبدل `<project-folder>` بأحد المشاريع الموجودة أعلاه.

مقترحات للتعلّم:
- ابدأ بالمشاريع بالترتيب (M01 → M05).
- لكل مشروع، افتح `Program.cs` و`Endpoints` و`Data` لفهم سير البيانات.

