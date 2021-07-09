# Markdown file
添加当前项目引用到AppHost
默认项目选中当前项目
在程序包管理控制台运行命令：

Add-Migration InitialSettings -o Migrations/PostgreSQL -s AppHost -c MessageContext

Update-Database -s AppHost -c MessageContext

Script-Migration -s AppHost -c MessageContext

Drop-Database -s AppHost -c MessageContext

Remove-Migration Check -s AppHost -c MessageContext

SettingsDesignTimeFactory

命令行
// 生成迁移文件
dotnet ef migrations add InitialMessageCenter -o Migrations/PostgreSQL -s ../../../Hosts/AppHost -c MessageContext
dotnet ef migrations add MySqlInitialMessageCenter -o Migrations/MySql -s ../../../Hosts/AppHost -c MessageContext

生成数据库初始化SQL
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -p Leelite.Modules.Settings.csproj -s ../../../Hosts/AppHost/AppHost.csproj
简化版本
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -s ../../../Hosts/AppHost
