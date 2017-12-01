using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory {
    #region Structure
    //Products
    public interface IProductA { }
    public interface IProductB { }
    public interface IProductC { }
    //....IProductN....
    public class ConcreteProductA_1 : IProductA { }
    public class ConcreteProductB_1 : IProductB { }
    public class ConcreteProductC_1 : IProductC { }
    public class ConcreteProductA_2 : IProductA { }
    public class ConcreteProductB_2 : IProductB { }
    public class ConcreteProductC_2 : IProductC { }
    //Factories
    public interface IProductABCAbstractFactory {
        IProductA CreateProductA();
        IProductB CreateProductB();
        IProductC CreateProductC();
    }
    public class ProductABC_1_Factory : IProductABCAbstractFactory {
        public IProductA CreateProductA() => new ConcreteProductA_1();
        public IProductB CreateProductB() => new ConcreteProductB_1();
        public IProductC CreateProductC() => new ConcreteProductC_1();
    }
    public class ProductABC_2_Factory : IProductABCAbstractFactory {
        public IProductA CreateProductA() => new ConcreteProductA_2();
        public IProductB CreateProductB() => new ConcreteProductB_2();
        public IProductC CreateProductC() => new ConcreteProductC_2();
    }
    #endregion

    /**
     * 抽象工厂:提供创建一系列相关/相互依赖的产品对象,而无须指定具体的类.
     * 
     * 在需要创建一系列产品族时使用.
     * 
     * FCL:DbProviderFactory(SqlClientFactory)->DbCommand,DbCommandBuilder,DbConnection,DbConnectionStringBuilder,DbDataSourceEnumerator....
     **/
    public class Clinet {
        private readonly IProductABCAbstractFactory _factory;
        public Clinet(IProductABCAbstractFactory factory) => _factory = factory;
        public Clinet() : this(new ProductABC_1_Factory()) { }
        public void Demo1() {
            IProductA pa = _factory.CreateProductA();
            IProductB pb = _factory.CreateProductB();
            IProductC pc = _factory.CreateProductC();
            Contract.Assert(pa.GetType() == typeof(ConcreteProductA_1));
            Contract.Assert(pb.GetType() == typeof(ConcreteProductB_1));
            Contract.Assert(pc.GetType() == typeof(ConcreteProductC_1));
        }
    }

    #region Example
    ///查看结构.
    #endregion
}