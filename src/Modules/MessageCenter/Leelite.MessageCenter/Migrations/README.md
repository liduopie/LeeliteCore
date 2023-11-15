# Markdown file
在设计模式Factory中增加数据库迁移支持
MessageDesignTimeFactory

添加当前项目引用到 ConsoleHost

官方文档 使用单独的迁移项目
https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli
官方文档 迁移多个提供程序
https://docs.microsoft.com/zh-cn/ef/core/managing-schemas/migrations/providers?tabs=dotnet-core-cli

命令行

第一次初始化
MessageDesignTimeFactory 类中UseMySql、UseNpgsql MigrationsAssembly使用默认，第二次以后再调整成拆分的项目

1.在 MessageCenter 项目中生成迁移文件
PostgreSQL
dotnet ef migrations add DbInitMessageCenter -s ../../../Hosts/ConsoleHost -o Migrations/PostgreSQL -c MessageContext -- PostgreSQL
Add-Migration InitDbMessageCenter -OutputDir Migrations/PostgreSQL -StartupProject WebHost -Context MessageContext

2.将 Migrations 目录移动到 MessageCenter.PostgreSQL 项目中

Leelite.MessageCenter.PostgreSQL 执行
Add-Migration ChangeTableName -OutputDir Migrations/PostgreSQL -StartupProject WebHost -Context MessageContext


MySql
dotnet ef migrations add DbInitMessageCenter -s ../../../Hosts/ConsoleHost -o Migrations/MySql -c MessageContext -- MySql
2.将 Migrations 目录移动到 MessageCenter.MySql 项目中


向项目添加新的迁移
PostgreSQL
dotnet ef migrations add AddPushRecordUserId -s ../../../Hosts/ConsoleHost -p ../Leelite.Modules.MessageCenter.PostgreSQL -c MessageContext -- PostgreSQL
dotnet ef migrations remove -s ../../../Hosts/ConsoleHost -p ../Leelite.Modules.MessageCenter.PostgreSQL -c MessageContext -- PostgreSQL

Add-Migration InitDbMessageCenter -o Migrations/PostgreSQL -s WebHost -Project Leelite.MessageCenter.PostgreSQL -Context MessageContext
Remove-Migration -s WebHost -Project Leelite.MessageCenter.PostgreSQL -Context MessageContext

MySql
dotnet ef migrations add AddPushRecordUserId -s ../../../Hosts/ConsoleHost -p ../Leelite.Modules.MessageCenter.MySql -c MessageContext -- MySql
dotnet ef migrations remove -s ../../../Hosts/ConsoleHost -p ../Leelite.Modules.MessageCenter.MySql -c MessageContext -- MySql


生成数据库初始化SQL
PostgreSQL
dotnet ef migrations script -i -o ../Leelite.Modules.MessageCenter.PostgreSQL/Sql/install.sql -s ../../../Hosts/ConsoleHost -- PostgreSQL

MySql
dotnet ef migrations script -i -o ../Leelite.Modules.MessageCenter.MySql/Sql/install.sql -s ../../../Hosts/ConsoleHost -- MySql

更新数据库
dotnet ef database update -s ../../../Hosts/ConsoleHost -c MessageContext -- PostgreSQL

Update-Database -s WebHost -Context MessageContext