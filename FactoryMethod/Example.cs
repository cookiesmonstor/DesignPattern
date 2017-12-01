using System;
using System.Collections;
using System.Diagnostics.Contracts;

namespace FactoryMethod {
    #region Structure
    //Products
    public interface IProduct { }
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }
    public class ConcreteProductC : IProduct { }
    //Factories:ConcreteProductAFactory->ConcreteProductA,ConcreteProductBFactory->ConcreteProductB,...
    public interface IProductFactory {
        IProduct CreateProduct();
    }
    public class ConcreteProductAFactory : IProductFactory {
        public IProduct CreateProduct() => new ConcreteProductA();
    }
    public class ConcreteProductBFactory : IProductFactory {
        public IProduct CreateProduct() => new ConcreteProductB();
    }
    public class ConcreateProductCFactory : IProductFactory {
        public IProduct CreateProduct() => new ConcreteProductC();
    }
    #endregion

    /**
     * 工厂方法:定义一个提供对象的工厂方法的工厂接口/抽象类,由工厂子类决定具体实例化哪个类(将对象的实例化延迟到子类).
     * 
     * 在某个类必须创建某类型(接口/抽象类)对象,但又不知道/或只有具体的子类才知道创建指定类型(接口/抽象类)的某个具体子类对象的情况下使用.
     * 非常适合聚合关系:鸟(包含工厂方法LayEggs)->鸟蛋(鸟必须创建的对象),鸡->鸡蛋,鹅->鹅蛋
     * 
     * FCL:集合(实现IEnumerable接口,包含工厂方法:GetEnumerator)->迭代器(IEnumerator).
     * * */
    public class Client {
        public void Demo1() {
            IProductFactory factory = new ConcreteProductAFactory();
            IProduct product = factory.CreateProduct();
            Contract.Assert(product.GetType() == typeof(ConcreteProductA));
        }
        public void Demo2() {
            IEnumerable arrayList = new ArrayList();
            IEnumerator enumerator = arrayList.GetEnumerator();
            Contract.Assert(enumerator.GetType().Name == "ArrayListEnumeratorSimple");//ArrayListEnumeratorSimple为ArrayList下声明的私有类型.

            IEnumerator strEnumerator = "".GetEnumerator();
            Contract.Assert(strEnumerator.GetType() == typeof(CharEnumerator));
        }
        public void Demo3() {
            IOperaterFactory factory = new SubOperaterFactory();
            Operater operater = factory.GetOperater();
            operater.NumberA = 7;
            operater.NumberB = 3;

            Contract.Assert(operater.GetResult() == 4);
        }
    }

    #region Example
    public abstract class Operater {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public abstract double GetResult();
    }
    public class AddOperater : Operater {
        public override double GetResult() => NumberA + NumberB;
    }
    public class SubOperater : Operater {
        public override double GetResult() => NumberA - NumberB;
    }
    public interface IOperaterFactory {
        Operater GetOperater();
    }
    public class AddOperaterFactory : IOperaterFactory {
        public Operater GetOperater() => new AddOperater();
    }
    public class SubOperaterFactory : IOperaterFactory {
        public Operater GetOperater() => new SubOperater();
    }
    #endregion
}