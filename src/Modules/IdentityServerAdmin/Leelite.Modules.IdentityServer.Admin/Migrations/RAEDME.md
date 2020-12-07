# Markdown file
添加当前项目引用到AppHost
在程序包管理控制台运行命令：

Add-Migration InitialCreate -o Migrations/PostgreSQL/AdminLogs -s AppHost -c AdminLogContext
Add-Migration InitialCreate -o Migrations/PostgreSQL/AdminAuditLogs -s AppHost -c AdminAuditLogContext


Update-Database -s AppHost -c AdminLogContext

Drop-Database -s AppHost -c AdminLogContext

Remove-Migration -s AppHost -c AdminLogContext

AdminLogDesignTimeFactory
AuditLogDesignTimeFactory
