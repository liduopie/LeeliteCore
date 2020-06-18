# 数据表

User

| 字段名               |          数据类型           | 主键  |  空   | 备注               |
| :------------------- | :-------------------------: | :---: | :---: | :----------------- |
| Id                   |           integer           |  是   |  否   | 标识               |
| UserName             |      character varying      |  否   |  是   | 用户名             |
| NormailzedUserName   |      character varying      |  否   |  是   | 标准用户名         |
| Email                |      character varying      |  否   |  是   | 电子邮箱           |
| NormailzedEmail      |      character varying      |  否   |  是   | 标准电子邮箱       |
| EmailConfirmed       |           boolean           |  否   |  否   | 是否确认电子邮箱   |
| PasswordHash         |            text             |  否   |  是   | 用户密码           |
| SecurityStamp        |            text             |  否   |  是   | 防伪印章           |
| ConcurrencyStamp     |            text             |  否   |  是   | 防伪印章           |
| PhoneNumber          |            text             |  否   |  是   | 手机号             |
| PhoneNumberConfirmed |           boolean           |  否   |  否   | 是否确认手机号     |
| TwoFactorEnabled     |           boolean           |  否   |  否   | 是否启用双因子验证 |
| LockoutEnd           | timestamp without time zone |  否   |  是   | 锁定结束时间       |
| LockoutEnabled       |           boolean           |  否   |  否   | 是否启用锁定       |
| AccessFailedCount    |           integer           |  否   |  否   | 登陆失败次数       |
