# M01.DependencyHell

هدف المشروع: إظهار مشكلة "Dependency Hell" حيث يكون الكود مترابطًا بشكل قوي ويصعب تغييره.

تشغيل المشروع:

```powershell
dotnet run --project ./M01.DependencyHell/M01.DependencyHell.csproj
```

ملفات مهمة:
- `Program.cs` — نقطة الدخول.
- `M01.DependencyHell.csproj` — تعريف المشروع.

ماذا تلاحظ؟
- كيف يتم إنشاء الاعتماديات مباشرة داخل الكود.
- ما الصعوبات عند تغيير أو اختبار مكوّن معين.

راجع `../Assignment/ASSIGNMENT.md` لأسئلة الفهم.
