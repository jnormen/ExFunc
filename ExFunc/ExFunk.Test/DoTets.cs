using System;
using NUnit.Framework;

namespace ExFunk.Test.DoClass
{
    [TestFixture]
    public class When_call_Try_With_Function_That_Return_a_value : BaseTest
    {
        Func<dynamic> _functionThatReturnValue;
        string _result;
        public override void Arrange()
        {
            _functionThatReturnValue = () => "Hello World!";
        }

        public override void Act()
        {
            _result = Do.Try(() => _functionThatReturnValue()).Run();
        }

        [TestCase]
        public void _result_should_be_returned_as_expected()
        {
            Assert.AreEqual("Hello World!", _result);
        }
    }

    [TestFixture]
    public class When_call_Try_With_a_Void_Action : BaseTest
    {
        Action _voidfunction;
        string _result;
        public override void Arrange()
        {
            _voidfunction = () => { var x = "Hello World!"; };
        }

        public override void Act()
        {
            _result = Do.Try(() => _voidfunction()).Run();
        }

        [TestCase]
        public void _result_should_be_null_though_nothing_to_returnd()
        {
            Assert.AreEqual(null, _result);
        }
    }

    [TestFixture]
    public class When_call_Try_With_a_null_Action : BaseTest
    {
        Action _voidfunction;
        string _result;
        public override void Arrange()
        {
            _voidfunction = null;
        }

        public override void Act(){}

        [TestCase]
        [ExpectedException(typeof(NullReferenceException))]
        public void _result_should_be_null_though_nothing_to_returnd()
        {
            _result = Do.Try(() => _voidfunction()).Run();
        }
    }

    [TestFixture]
    public class When_call_Try_With_a_null_Function : BaseTest
    {
        Func<dynamic> _function;
        string _result;
        public override void Arrange()
        {
            _function = null;
        }

        public override void Act() { }

        [TestCase]
        [ExpectedException(typeof(NullReferenceException))]
        public void _result_should_be_null_though_nothing_to_returnd()
        {
            _result = Do.Try(() => _function()).Run();
        }
    }
}
