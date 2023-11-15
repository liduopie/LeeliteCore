# Markdown file
添加当前项目引用到WebHost
默认项目选中当前项目
在程序包管理控制台运行命令：

Add-Migration InitDataDictionary -o Migrations/PostgreSQL -s WebHost -Context DataDictionaryContext

Update-Database -s WebHost -Context DataDictionaryContext

Script-Migration -s AppHost -Context DataDictionaryContext

Drop-Database -s AppHost -Context DataDictionaryContext

Remove-Migration -s WebHost -Context DataDictionaryContext

SettingsDesignTimeFactory

生成数据库初始化SQL
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -p Leelite.Settings.csproj -s ../../../Hosts/AppHost/AppHost.csproj
简化版本
dotnet ef migrations script -i -o Migrations/PostgreSQL/install.sql -s ../../../Hosts/AppHost
