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