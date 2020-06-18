
# 应用组件库 Framework

## 00. Conventions

开发框架约定

- AutoMapper 配置注册约定
- CRUD Commands 约定 TODO:约定类名称需要调整
- Lifetime 生命周期约定
- MediatR 使用约定 TODO:需要明确 MediatR 作用和功能
- Validation 验证器注册约定

## 01. Data

数据库访问层

- 数据查询
  - 条件查询规则
  - 区间查询规则
  - 排序
  - 分页
  - 查询参数
- 数据仓库
  - 基础操作集合
  - 查询仓库
  - 仓库

## 02. Domain

领域层

- 聚合根
- 命令总线
- 上下文
- 领域事件
- 模型
- 仓储
- 领域服务
- 工作单元

## 03. EntityFramework

EntityFramework 对Domain的实现

- Data >> Store 仓库实现
- Domain >> Context 上下文实现
- Domain >> Repository 仓储实现
- Domain >> UnitOfWork 工作单元实现

## 04. Models

领域模型扩展常见数据类型。

- Audit 审计模型 TODO:接口类需要拆分
- DataAccessSet 数据访问权限模型
- Enabled 启用/禁用模型
- History 历史记录模型
- SoftDelete 软删除模型
- State 状态模型
- Tenant 多租户模型
- Tree 树形结构模型
- RowVersion 行版本号模型 TODO: 需要修改类名称
- Version 版本号模型 TODO:重新设计模型

## 05. Package

Framework Nuget 包

## 06. Service

应用服务层

- Aspects 拦截器
  - ServiceLog 服务日志拦截器
  - UnitOfWork 工作单元拦截器
- CRUD 操作命令
- 数据传输对象
- 应用服务事件
- 应用服务接口
- 应用服务
  - Crud服务
  - 查询服务

## 07. WebApi

通用WebApi实现
