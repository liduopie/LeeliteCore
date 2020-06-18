# Markdown file
添加当前项目引用到AppHost
在程序包管理控制台运行命令：

Add-Migration InitialCreate -o Migrations/PostgreSQL/PersistedGrants -s AppHost -c PersistedGrantContext
Add-Migration InitialCreate -o Migrations/PostgreSQL/Configurations -s AppHost -c ConfigurationContext


Update-Database -s AppHost -c PersistedGrantContext

Drop-Database -s AppHost -c PersistedGrantContext

Remove-Migration -s AppHost -c PersistedGrantContext

PersistedGrantDesignTimeFactory
ConfigurationDesignTimeFactory
