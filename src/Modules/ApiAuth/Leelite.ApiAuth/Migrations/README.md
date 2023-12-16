# Markdown file
添加当前项目引用到WebHost
默认项目选中当前项目
在程序包管理控制台运行命令：

Add-Migration InitApiAuth -o Migrations/PostgreSQL -s WebHost -Context ApiAuthContext

Update-Database -s WebHost -Context ApiAuthContext

Script-Migration -s AppHost -Context ApiAuthContext

Drop-Database -s AppHost -Context ApiAuthContext

Remove-Migration -s WebHost -Context ApiAuthContext

SettingsDesignTimeFactory

生成数据库初始化SQL
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -p Leelite.Settings.csproj -s ../../../Hosts/AppHost/AppHost.csproj
简化版本
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -s ../../../Hosts/AppHost
