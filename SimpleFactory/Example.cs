using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace SimpleFactory {
    #region Structure
    //Products
    public interface IProduct { }
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }
    public class ConcreteProductC : IProduct { }
    //Factory
    public static class SimpleFactory {
        public static IProduct CreateProduct(string className) {
            switch (className) {
                case nameof(ConcreteProductA): return new ConcreteProductA();
                case nameof(ConcreteProductB): return new ConcreteProductB();
                case nameof(ConcreteProductC): return new ConcreteProductC();
                default: return null;
            }
        }
    }
    #endregion

    /**
     * 简单工厂:工厂类(通常为静态类)的工厂方法,根据参数,生成指定接口/抽象类的具体子类.
     * 
     * 在指定接口/抽象类的具体子类数量有限的情况下,用于分离客户端和具体子类之间的耦合.
     * 
     * FCL:Encoding即是工厂类,又是抽象基类.
     * */
    public class Client {
        public void Demo1() {
            IProduct product = SimpleFactory.CreateProduct(nameof(ConcreteProductC));
            Contract.Assert(product.GetType() == typeof(ConcreteProductC));
        }
        public void Demo2() {
            Operater operater = OperaterFactory.GetOprater("+");
            operater.NumberA = 3;
            operater.NumberB = 4;
            Contract.Assert(operater.GetResult() == 7);
        }
        public void Demo3() {
            Encoding encoding = Encoding.GetEncoding(0);
            Contract.Assert(encoding == Encoding.Default);
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
    public static class OperaterFactory {
        public static Operater GetOprater(string OpType) {
            switch (OpType) {
                case "+": return new AddOperater();
                case "-": return new SubOperater();
                default: throw new Exception($"不支持的操作类型:{OpType}");
            }
        }
    }
    #endregion
}