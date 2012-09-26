using System;

using MAB;

using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace MABTests
{
    [TestFixture]
    public class BanditTests
    {
        IBanditRepo<EmptyAlternative> _nullRepository = null;
        IBanditRepo<FakeListrun> _fakeListrunRepository = new FakeListrunRepository(9999);
        IBanditRepo<EmptyAlternative> _emptyRepository = new EmptyRepository();

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentException))]
        public void Constructor_NullRepository()
        {
            var b = new Bandit<EmptyAlternative>(this._nullRepository);
        }

        [Test]
        [ExpectedException(ExceptionType = typeof(ArgumentException))]
        public void Play_NoAlternativesInRepository()
        {
            Bandit<EmptyAlternative> b = new Bandit<EmptyAlternative>(this._emptyRepository);
            EmptyAlternative alternative = b.Play();
        }

        [Test]
        public void DefaultConstructor_NoDiagnostics()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository);
            Assert.IsNull(b.Diagnostics);
        }

        [Test]
        public void InitConstructor_False_NoDiagnostics()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository, false);
            Assert.IsNull(b.Diagnostics);
        }

        [Test]
        public void InitConstructor_True_Diagnostics()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository, true);
            Assert.IsNotNull(b.Diagnostics);
        }

        [Test]
        public void CollectDiagnostics_DefaultConstructor_False()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository);
            Assert.IsFalse(b.CollectDiagnostics);
        }

        [Test]
        public void CollectDiagnostics_InitConstructor_False()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository, false);
            Assert.IsFalse(b.CollectDiagnostics);
        }

        [Test]
        public void CollectDiagnostics_InitConstructor_True()
        {
            Bandit<FakeListrun> b = new Bandit<FakeListrun>(_fakeListrunRepository, true);
            Assert.IsTrue(b.CollectDiagnostics);
        }
    }
}
