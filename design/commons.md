# 基础组件库 Commons

## 01. Aspects

Aop 面向切面编程的拦截器

- DebugLogAspect 调试日志拦截器
- ValidationAspect 参数验证拦截器

## 02. Assembly

- IAssemblyLoader 应用程序集加载器接口

## 03. Convention

负责开发约定加载与解释，通过应用程序集扫描完成。

## 03. Helpers

DoNet 基础库的扩展帮助库。

- 数据类型转换
- Type扩展程序

## 04. Host

负责Hosting中的Host构建。

- CoreHostOptions 默认配置
- HostBuilder 扩展配置
- 保留全局实例

## 05. Lifetime

对象的生命周期约定接口定义。

- Scope 作用域
- Singleton 单态
- Transient 瞬态

## 06. Mapper

MapperConfigurationContext AutoMapper配置上下文

## 07. Validation

使用 FluentValidation 作为模型验证组件

- 模型验证器接口

TODO:移除验证 ValidAttribute 或实现验证器的手工指定
