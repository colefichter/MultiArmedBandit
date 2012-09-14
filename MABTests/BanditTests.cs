using System;

using MAB;

using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MABTests
{
    [TestFixture]
    public class BanditTests
    {
        IBanditRepo<object> _nullRepository = null;
        IBanditRepo<FakeListrun> _fakeListrunRepository = new FakeListrunRepository(9999);
        IBanditRepo<object> _emptyRepository = new EmptyRepository();

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentException))]
        public void Constructor_NullRepository()
        {
            Bandit<object> b = new Bandit<object>(this._nullRepository);
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentException))]
        public void Play_NoAlternativesInRepository()
        {
            Bandit<object> b = new Bandit<object>(this._emptyRepository);
            IAlternative alternative = b.Play();
        }

        [Test]
        public void DefaultConstructor_NoDiagnostics()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository);
            Assert.IsNull(b.Diagnostics);
        }

        [Test]
        public void InitConstructor_False_NoDiagnostics()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository, false);
            Assert.IsNull(b.Diagnostics);
        }

        [Test]
        public void InitConstructor_True_Diagnostics()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository, true);
            Assert.IsNotNull(b.Diagnostics);
        }

        [Test]
        public void CollectDiagnostics_DefaultConstructor_False()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository);
            Assert.IsFalse(b.CollectDiagnostics);
        }

        [Test]
        public void CollectDiagnostics_InitConstructor_False()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository, false);
            Assert.IsFalse(b.CollectDiagnostics);
        }

        [Test]
        public void CollectDiagnostics_InitConstructor_True()
        {
            Bandit<object> b = new Bandit<object>(_emptyRepository, true);
            Assert.IsTrue(b.CollectDiagnostics);
        }
    }
}
