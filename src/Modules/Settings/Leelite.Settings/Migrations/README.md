# Markdown file
添加当前项目引用到AppHost
默认项目选中当前项目
在程序包管理控制台运行命令：

Add-Migration InitialSettings -o Migrations/PostgreSQL -s AppHost -c SettingsContext

Update-Database -s AppHost -c SettingsContext

Script-Migration -s AppHost -c SettingsContext

Drop-Database -s AppHost -c SettingsContext

Remove-Migration Check -s AppHost -c SettingsContext

SettingsDesignTimeFactory

生成数据库初始化SQL
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -p Leelite.Settings.csproj -s ../../../Hosts/AppHost/AppHost.csproj
简化版本
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -s ../../../Hosts/AppHost
