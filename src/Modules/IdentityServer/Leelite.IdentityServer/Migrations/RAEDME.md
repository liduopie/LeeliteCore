# Markdown file
添加当前项目引用到AppHost
在程序包管理控制台运行命令：

Add-Migration InitialCreate -o Migrations/PostgreSQL/Configurations -s WebHost -c ConfigurationContext
Add-Migration InitialCreate -o Migrations/PostgreSQL/PersistedGrants -s WebHost -c PersistedGrantContext
Add-Migration InitialCreate -o Migrations/PostgreSQL/DataProtections -s WebHost -c DataProtectionDbContext

Update-Database -s WebHost -Context ConfigurationContext
Update-Database -s WebHost -Context PersistedGrantContext
Update-Database -s WebHost -Context DataProtectionDbContext

Drop-Database -s WebHost -c PersistedGrantContext

Remove-Migration -s WebHost -c ConfigurationContext
Remove-Migration -s WebHost -c PersistedGrantContext
Remove-Migration -s WebHost -c DataProtectionDbContext

PersistedGrantDesignTimeFactory
ConfigurationDesignTimeFactory
