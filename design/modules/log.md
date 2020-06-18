# Log

|    字段名     |          数据类型           | 是否为主键 | 是否为空 |     备注     |
| :-----------: | :-------------------------: | :--------: | :------: | :----------: |
|      Id       |           bigint            |     是     |    否    |     主键     |
|    LogName    |   character varying(128)    |     否     |    否    |   日志名称   |
|     Level     |    character varying(64)    |     否     |    否    |     级别     |
|    TraceId    |    character varying(64)    |     否     |    否    |   权限名称   |
| OperationTime | timestamp without time zone |     否     |    否    | 日志记录时间 |
|   Duration    |    character varying(64)    |     否     |    否    | 操作持续时间 |
|      Ip       |    character varying(64)    |     否     |    否    |   全球唯一   |
|     Host      |    character varying(64)    |     否     |    否    |     域名     |
|   ThreadId    |    character varying(64)    |     否     |    否    |   线程名称   |
|    Browser    |   character varying(4096)   |     否     |    否    |  浏览器信息  |
|      Url      |   character varying(4096)   |     否     |    否    |     路径     |
|    UserId     |    character varying(64)    |     否     |    否    |    用户Id    |
|    Content    |            jsonb            |     否     |    否    |  内容jsonb   |
|   Exception   |            jsonb            |     否     |    否    |  异常jsonb   |
|   Signature   |   character varying(128)    |     否     |    否    |     签名     |