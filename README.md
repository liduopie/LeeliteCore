# LeeliteCore

## 特点
- 模块化加载
- 领域驱动框架

# 框架组件

## 编译时AOP框架 AspectInjector
[![NuGet](https://buildstats.info/nuget/AspectInjector)](https://www.nuget.org/packages/AspectInjector/)
项目地址：
文档地址：

## 数据验证 Validation
Framework 数据模型的验证组件采用 [FluentValidation](https://github.com/JeremySkinner/FluentValidation)

## 模型映射 AutoMapper
AutoMapper 模型映射转换采用 [AutoMapper](https://github.com/AutoMapper/AutoMapper)
AutoMapper.Extensions.Microsoft.DependencyInjection Asp.Net Core 依赖注入中使用 [AutoMapper.Extensions.Microsoft.DependencyInjection](https://github.com/AutoMapper/AutoMapper.Extensions.Microsoft.DependencyInjection)

## 健康检查 HealthChecks

## 任务管理 HangFire

## 插件管理 McMaster.NETCore.Plugins

## 事件总线 MediatR

https://github.com/jbogard/MediatR

## 性能监控 MiniProfiler

## 缓存 FusionCache

## Api文档 Swashbuckle
Swashbuckle.AspNetCore
Swashbuckle.AspNetCore Api文档 https://github.com/domaindrivendev/Swashbuckle.AspNetCore

## 数据库操作
EntityFrameworkCore

Npgsql
Npgsql https://github.com/npgsql/npgsql
Npgsql.EntityFrameworkCore.PostgreSQL https://github.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL

# 功能组件

| 组件 | 说明 | 版本 | 
| --- | --- | --- | 
| AspectInjector | 编译时AOP框架 | [![NuGet](https://buildstats.info/nuget/AspectInjector)](https://www.nuget.org/packages/AspectInjector/) |  
| AutoMapper | 实体映射 | [![NuGet](https://buildstats.info/nuget/AutoMapper)](https://www.nuget.org/packages/AutoMapper/) |
| HealthChecks | 健康检查 | [![NuGet](https://buildstats.info/nuget/Microsoft.Extensions.Diagnostics.HealthChecks)](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks/) |
| Dapper | 数据库操作 | [![NuGet](https://buildstats.info/nuget/Dapper)](https://www.nuget.org/packages/Dapper/) |
| FluentValidation | 数据验证 | [![NuGet](https://buildstats.info/nuget/FluentValidation)](https://www.nuget.org/packages/FluentValidation/) |
| HangFire | 任务管理 | [![NuGet](https://buildstats.info/nuget/HangFire)](https://www.nuget.org/packages/HangFire/) |  
| IdHelper | ID生成器 | [![NuGet](https://buildstats.info/nuget/IdHelper)](https://www.nuget.org/packages/IdHelper/) |
| JNTemplate | 模板引擎 | [![NuGet](https://buildstats.info/nuget/JNTemplate)](https://www.nuget.org/packages/JNTemplate/) |
| JsonFlatten | Json扁平化 | [![NuGet](https://buildstats.info/nuget/JsonFlatten)](https://www.nuget.org/packages/JsonFlatten/) |
| McMaster | 插件加载 | [![NuGet](https://buildstats.info/nuget/McMaster.NETCore.Plugins)](https://www.nuget.org/packages/McMaster.NETCore.Plugins/) |
| MediatR | 事件总线 | [![NuGet](https://buildstats.info/nuget/MediatR)](https://www.nuget.org/packages/MediatR/) |
| MiniProfiler | 性能监控 | [![NuGet](https://buildstats.info/nuget/MiniProfiler.AspNetCore)](https://www.nuget.org/packages/MiniProfiler.AspNetCore/) |
| Mono.TextTemplating | T4模板引擎 | [![NuGet](https://buildstats.info/nuget/Mono.TextTemplating)](https://www.nuget.org/packages/Mono.TextTemplating/) |
| Newtonsoft.Json | Json操作 | [![NuGet](https://buildstats.info/nuget/Newtonsoft.Json)](https://www.nuget.org/packages/Newtonsoft.Json/) |
| Npgsql | PostgreSQL数据库操作 | [![NuGet](https://buildstats.info/nuget/Npgsql)](https://www.nuget.org/packages/Npgsql/) |
| Pomelo | MySQL数据库操作 | [![NuGet](https://buildstats.info/nuget/Pomelo.EntityFrameworkCore.MySql)](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/) |
| Redis | 数据缓存 | [![NuGet](https://buildstats.info/nuget/StackExchange.Redis)](https://www.nuget.org/packages/StackExchange.Redis/) |  
| Senparc | 微信SDK | [![NuGet](https://buildstats.info/nuget/Senparc.Weixin)](https://www.nuget.org/packages/Senparc.Weixin/) |
| Skoruba | 身份认证 | [![NuGet](https://buildstats.info/nuget/Skoruba.IdentityServer4.Admin.EntityFramework)](https://www.nuget.org/packages/Skoruba.IdentityServer4.Admin.EntityFramework/) |
| Swashbuckle | Api文档 | [![NuGet](https://buildstats.info/nuget/Swashbuckle.AspNetCore)](https://www.nuget.org/packages/Swashbuckle.AspNetCore/) |
| TimeZoneConverter | 时区转换 | [![NuGet](https://buildstats.info/nuget/TimeZoneConverter)](https://www.nuget.org/packages/TimeZoneConverter/) |
| FusionCache | 缓存 | [![NuGet](https://buildstats.info/nuget/FusionCache)](https://www.nuget.org/packages/FusionCache/) |

# 待解决的问题
验证组件 FluentValidation.AspNetCore 的使用。 已经使用
配置文件的使用

# 开发例子 Samples
## 01. 模块例子
## 02. 插件例子
