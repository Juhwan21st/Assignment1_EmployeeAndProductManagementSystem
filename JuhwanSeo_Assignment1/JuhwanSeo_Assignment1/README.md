개발과정

ASP.NET Core Web API 프로젝트를 생성

필수 누겟 패키지 설치
```
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.20" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.InMemory" Version="8.0.20" />
```

Models 폴더 생성 후 Employee와 Product 클래스 생성

Data 폴더 생성 후 AppDbContext 클래스 생성

Repositories 폴더 생성 후 IEmployeeRepository, EmployeeRepository, IProductRepository, ProductRepository 클래스 생성

IEmployeeRepository와 IProductRepository에 CRUD 메서드 정의

Employee Repository와 Product Repository에 CRUD 메서드 구현
다만 SaveChanges() 메서드는 UnitOfWork의 Complete() 메서드에서 호출되도록 구현

Repositories 폴더에 IUnitOfWork 인터페이스와 UnitOfWork 클래스 생성

IUnitOfWork 인터페이스에 Employees, Products 속성과 Complete() 메서드 정의


UnitOfWork 클래스에 Employees, Products 속성과 Complete() 메서드 구현. Complete() 메서드는 DbContext의 SaveChanges() 호출


Program.cs 파일 수정
- In-Memory Database 설정
- Repository와 UnitOfWork DI 설정


Program.cs 파일에 데이터베이스 초기화 코드 추가
using (var scope = app.Services.CreateScope()) 내부에 
`if (app.Environment.IsDevelopment())` 조건문 추가 후 환경에 따라 데이터가 추가되도록 구현하려 하는데 program.cs 파일에서 데이터를 씨드하는 방법에서 막힘.
dbContext.Employees = DbSet<Employee>인 것을 생각해서
DbSet<>의 메소드들을 검토(DbSet has methods like CRUD methods for it's table)
AddRange에 대해 조사해봄.
web reference: https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addrange?view=efcore-8.0
AddRange를 사용하여 다중 엔티티를 추가함.


Controllers 폴더 생성 후 EmployeesController와 ProductsController 클래스 생성

응답 상태 코드의 처리를 위해 다음 문서를 공부했음.
web reference: https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-8.0#asynchronous-action


if the controller uses [ApiController] attribute, there is no need to specify bounding source attributes like [FromRoute], but it can be good for clarity.
바운딩 소스 속성에 대한 자세한 내용은 다음 문서를 공부했음.
web reference: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0#binding-source-parameter-inference


launchSettings.json 파일 수정
set new environment
아래 참고 문서를 참고했음.
web reference: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-8.0

swagger가 개발환경 외에서도 동작하도록 수정 (환경별 씨드 데이터 테스트 목적)