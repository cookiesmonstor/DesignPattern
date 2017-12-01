# DesignPattern
设计模式.

一些简单定义和示例.

#创建型模式

#### 1.简单工厂:工厂类(通常为静态类)的工厂方法,根据指定的参数,生成指定产品(接口/抽象类)的具体子类.
######  在产品具体子类数量有限的情况下使用,用于分离端和具体子类之间的耦合.
    FCL:Encoding即是工厂类,又是产品抽象基类.

#### 2.工厂方法:定义一个提供产品对象的工厂(接口/抽象类,工厂方法提供具体产品),由具体工厂子类决定实例化哪个具体产品子类.
###### 在工厂类必须创建与之相关的产品,但只有具体工厂子类才知道具体产品类时使用.非常适合聚合关系(如:鸟->鸟蛋,鸡:鸟->鸡蛋:鸟蛋).
###### 相比简单工厂,更容易扩展.
    FCL:IEnumerable(工厂方法:GetEnumerator)->IEnumerator

#### 3.抽象工厂:提供创建一系列相关/相互依赖的产品对象,而无须指定具体的类.
###### 在需要创建一系列产品族时使用.
###### 相比工厂方法,其可以创建一组/一系列相关产品,而非只是单一一个(即包含多个工厂方法,分别创建相关的不同类型产品).
    FCL:DbProviderFactory(SqlClientFactory)->DbCommand,DbCommandBuilder,DbConnection,DbConnectionStringBuilder,DbDataSourceEnumerator....
