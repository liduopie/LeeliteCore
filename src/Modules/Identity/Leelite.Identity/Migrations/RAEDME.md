# Markdown file
添加当前项目引用到AppHost
在程序包管理控制台运行命令：

Add-Migration InitialIdentity -o Migrations/PostgreSQL -s WebHost -c IdentityContext

Update-Database -s AppHost -c IdentityContext

Drop-Database -s AppHost -c IdentityContext

Remove-Migration InitialCreate -s AppHost -c IdentityContext

Migrations
CreateIdentitySchema

生成sql
 dotnet ef migrations script -i -o Sql/install.sql -s ../../../Hosts/ConsoleHost -- PostgreSQL