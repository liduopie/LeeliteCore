# LeeliteCore

模块化加载
领域驱动框架

| 技术 | 名称 | 版本 | 
| --- | --- | --- | 
| AspectInjector | 编译时AOP框架 | [![nuget](https://img.shields.io/nuget/v/AspectInjector?cacheSeconds=10800)](https://www.nuget.org/packages/AspectInjector/)  [![nuget](https://img.shields.io/nuget/dt/AspectInjector)](https://www.nuget.org/packages/AspectInjector/) |  
| AutoMapper | 实体映射 |  [![nuget](https://img.shields.io/nuget/v/AutoMapper?cacheSeconds=10800)](https://www.nuget.org/packages/AutoMapper/)  [![nuget](https://img.shields.io/nuget/dt/AutoMapper)](https://www.nuget.org/packages/AutoMapper/) |  
| Redis | 数据缓存 |   [![nuget](https://img.shields.io/nuget/v/StackExchange.Redis?cacheSeconds=10800)](https://www.nuget.org/packages/StackExchange.Redis/)  [![nuget](https://img.shields.io/nuget/dt/StackExchange.Redis)](https://www.nuget.org/packages/StackExchange.Redis/) |  
| HangFire | 定时任务 |  [![nuget](https://img.shields.io/nuget/v/HangFire?cacheSeconds=10800)](https://www.nuget.org/packages/HangFire/)  [![nuget](https://img.shields.io/nuget/dt/HangFire)](https://www.nuget.org/packages/HangFire/) |  


# 开发例子 Samples
## 01. 模块例子
## 02. 插件例子


# 第三方组件

Validation
Framework 数据模型的验证组件采用 [FluentValidation](https://github.com/JeremySkinner/FluentValidation)

AutoMapper
AutoMapper 模型映射转换采用 [AutoMapper](https://github.com/AutoMapper/AutoMapper)
AutoMapper.Extensions.Microsoft.DependencyInjection Asp.Net Core 依赖注入中使用 [AutoMapper.Extensions.Microsoft.DependencyInjection](https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection)

Npgsql
Npgsql https://github.com/npgsql/npgsql
Npgsql.EntityFrameworkCore.PostgreSQL https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL

Swashbuckle.AspNetCore
Swashbuckle.AspNetCore Api文档 https://github.com/domaindrivendev/Swashbuckle.AspNetCore

https://github.com/jbogard/MediatR

# 要解决的问题
验证组件 FluentValidation.AspNetCore 的使用。 已经使用
配置文件的使用
