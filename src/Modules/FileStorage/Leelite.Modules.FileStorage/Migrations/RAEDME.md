# Markdown file
添加当前项目引用到AppHost
在程序包管理控制台运行命令：

Add-Migration InitialFileStorage -o Migrations/PostgreSQL -s AppHost -c FileStorageContext

Update-Database -s AppHost -c FileStorageContext

Drop-Database -s AppHost -c FileStorageContext

Remove-Migration InitialCreate -s AppHost -c FileStorageContext

Migrations
CreateIdentitySchema