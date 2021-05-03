# Car Rental Project - Araç Kiralama Sistemi

<img src="https://user-images.githubusercontent.com/32098845/116942427-3af42b00-ac7a-11eb-9609-ce2d3e58bc7b.png" width="990">

## :pushpin: Getting Started
N-Katmanlı mimari yapısı ile hazırlanan, EntitiyFramework kullanılarak CRUD işlemlerinin yapıldığı, Console ve WebAPI arayüzü ile çalışan, Araç Kiralama iş yerlerine yönelik örnek bir projedir.

<br>

## :books: Layers
<img src="https://user-images.githubusercontent.com/32098845/116941924-46932200-ac79-11eb-8c6f-64a0597a4946.png">

### <b>Entities Layer</b>
Veritabanı tablolarının projede kullanılması için oluşturulmuş **Entities Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet ana klasör ve bunların dışında veritabanında olmayan ama projede linq sorguları için kullanılan **DTOs** klasörü bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.

<br>
<img src="https://user-images.githubusercontent.com/32098845/116941922-45fa8b80-ac79-11eb-8664-42692af735ed.png">

###  <b>Data Access Layer</b>
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan **Data Access Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.
Concrete Klasöründe farklı veritabanları ile çalışabilmek için alt klasörlere ayrılmıştır. Biz bu projemizde öncelikle InMemory'de çalıştık, daha sonra projeyi geliştirerek *EntityFramework*'e geçiş yaptık.
<br>


<img src="https://user-images.githubusercontent.com/32098845/116941919-4561f500-ac79-11eb-8060-639aa36c27f8.png">

### <b>Business Layer</b>
Bu katmanda projeye ait iş kurallarımız bulunmaktadır. Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan **Business Katmanı**'nda **Abstract**, **Concrete**, **BusinessAspects**, **Constants**, **DependencyResolvers** ve **ValidationRules** klasörlerimiz bulunmaktadır.  

<br>

<img src="https://user-images.githubusercontent.com/32098845/116941921-45fa8b80-ac79-11eb-85b2-63ed1f34a533.png">

###  <b>Core Layer</b>
Bir framework katmanı olan **Core Katmanı**'nda proje bağımsız tüm projelere entegre edebilmemizi sağlayan alt yapıyı kurmuş bulunuyoruz. Bu katmanda **Aspects**, **CrossCuttingConcerns**, **DependencyResolvers**, **DataAccess**, **Entities**, **Utilities** ve **Extensions** olmak üzere 7 adet klasör bulunmaktadır. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.  

<br>

<img src="https://user-images.githubusercontent.com/32098845/116941920-4561f500-ac79-11eb-8fcb-ff14d69c8539.png">

### <b>Console UI Layer</b>
Test ortamıdır. WebAPI tarafına geçmeden önce uygulamanın ne şekilde çalıştığı ve oluşturulan katmanların doğru çalışıp çalışmadı test edilir.

<br>

<img src="https://user-images.githubusercontent.com/32098845/116941918-4561f500-ac79-11eb-8b29-2d100855a400.png">

### <b>WebAPI Layer</b>
Projenin kullanıcı arayüzleri ile irtibata geçtiği katmandır. Front-end geliştiriciler bu API yapısını kullanarak projenin dış dünyaya sunumunu yapabilirler.

<br>

<img src="https://user-images.githubusercontent.com/32098845/116943149-a25eaa80-ac7b-11eb-99d5-a5facee28151.png">

### <b>Tables</b>
Veritabanı tablolarınızı manuel de oluşturabilirsiniz. Gerekli bilgiler ekteki gibidir.
```
CREATE TABLE [dbo].[BodyTypes] (
    [Id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [BodyTypeName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[Brands] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[CarImages] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [CarId]           INT            NULL,
    [ImagePath]       NVARCHAR (MAX) NULL,
    [ImageUploadDate] DATETIME       NULL
);


CREATE TABLE [dbo].[Cars] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CarModelId]  INT            NULL,
    [DailyPrice]  DECIMAL (5, 2) NULL,
    [Description] NVARCHAR (50)  NULL
);


CREATE TABLE [dbo].[Colors] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[Customers] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [UserId]      INT           NULL,
    [CompanyName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[FuelTypes] (
    [Id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [FuelTypeName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[GearTypes] (
    [Id]           SMALLINT      IDENTITY (1, 1) NOT NULL,
    [GearTypeName] NVARCHAR (50) NULL
);


CREATE TABLE [dbo].[Models] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]    INT           NULL,
    [ModelName]  NVARCHAR (50) NULL,
    [ModelYear]  INT           NULL,
    [ColorId]    INT           NULL,
    [BodyTypeId] SMALLINT      NULL,
    [FuelTypeId] SMALLINT      NULL,
    [GearTypeId] SMALLINT      NULL
);


CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (250) NOT NULL
);


CREATE TABLE [dbo].[Rentals] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [CarId]      INT  NULL,
    [CustomerId] INT  NULL,
    [RentDate]   DATE NULL,
    [ReturnDate] DATE NULL
);


CREATE TABLE [dbo].[Rentals] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [CarId]      INT  NULL,
    [CustomerId] INT  NULL,
    [RentDate]   DATE NULL,
    [ReturnDate] DATE NULL
);


CREATE TABLE [dbo].[Users] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)   NOT NULL,
    [LastName]     NVARCHAR (50)   NOT NULL,
    [Email]        NVARCHAR (50)   NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL
);
```

<br>

<img src="https://user-images.githubusercontent.com/32098845/116942108-a093e780-ac79-11eb-9717-d6ef2393fe86.png">

### <b>NuGet</b>
```
Autofac Version="6.1.0"
Autofac.Extensions.DependencyInjection Version="7.1.0"
Autofac.Extras.DynamicProxy Version="6.0.0"
FluentValidation Version="9.5.1"
Microsoft.AspNetCore.Http Version="2.2.2"
Microsoft.AspNetCore.Http.Features Version="5.0.3"
Microsoft.AspNetCore.Http.Abstractions Version="2.2.0"
Microsoft.EntityFrameworkCore.SqlServer Version="3.1.1"
Microsoft.IdentityModel.Tokens Version="6.8.0"
System.IdentityModel.Tokens.Jwt Version="6.8.0"
```

## :pencil2:Authors
* **Cem Özaydın** - [cemozaydin](https://github.com/cemozaydin)