using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Builder {
    #region Structure
    //Product ,生成器可以生成相同类型的对象,也可以生成不同类型的对象.
    public interface IProdcut {
        List<string> Parts { get; set; }
    }
    public class ProductA : IProdcut {
        public List<string>Parts { get; set; }
        public ProductA() => Parts = new List<string>();
    }
    public class ProductB : IProdcut {
        public List<string> Parts { get; set; }
        public ProductB() => Parts = new List<string>();
    }
    //Builder
    public interface IBuilder {
        void BuildPartA();
        void BuildPartB();
        IProdcut GetResult();
    }
    public class BuilderA : IBuilder {
        IProdcut product = new ProductA();
        public void BuildPartA() => product.Parts.Add("ProductA_PartA");
        public void BuildPartB() => product.Parts.Add("ProductA_PartB");
        public IProdcut GetResult() => product;
    }
    public class BuilderB : IBuilder {
        IProdcut product = new ProductB();
        public void BuildPartA() => product.Parts.Add("ProductB_PartA");
        public void BuildPartB() => product.Parts.Add("ProductB_PartB");
        public IProdcut GetResult() => product;
    }
    //Director
    public class Director {
        private readonly IBuilder _builder;
        public Director(IBuilder builder) => _builder = builder;
        public void Construce() {
            _builder.BuildPartA();
            _builder.BuildPartB();
        }
    }
    #endregion

    /**
     * 将复杂对象的创建过程(导航器),与表示分离,使得同样的创建过程,可以创建不同的表示.
     * 
     * 构建过程相同,但是不同的生成器生成的表示不同的时候使用.
     * 
     * FCL:StringBuilder,即是导航器也是生成器.
     * 
     * **/
    public class Client {
        public void Demo1() {
            IBuilder builder = new BuilderB();
            Director director = new Director(builder);
            director.Construce();
            IProdcut prodcut = builder.GetResult();

            Contract.Assert(prodcut.GetType() == typeof(ProductB));
            Contract.Assert(prodcut.Parts.Count == 2);
            Contract.Assert(prodcut.Parts[0] == "ProductB_PartA");
            Contract.Assert(prodcut.Parts[1] == "ProductB_PartB");
        }
    }

    #region Example

    #endregion
}
