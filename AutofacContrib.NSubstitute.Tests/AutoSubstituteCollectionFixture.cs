using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using NSubstitute;
using NUnit.Framework;

namespace AutofacContrib.NSubstitute.Tests
{
    [TestFixture]
    public sealed class AutoSubstituteCollectionFixture
    {
        #region stubs

        public interface IServiceItem
        {
        }

        public class ItemA : IServiceItem
        {
        }

        public class ItemB : IServiceItem
        {
        }

        public sealed class TestIEnumerableComponent
        {
            public readonly IEnumerable<IServiceItem> Items;

            public TestIEnumerableComponent(IEnumerable<IServiceItem> serviceItems)
            {
                Items = serviceItems;
            }
        }

        public sealed class TestIListComponent
        {
            public readonly IList<IServiceItem> Items;

            public TestIListComponent(IList<IServiceItem> serviceItems)
            {
                Items = serviceItems;
            }
        }

        public sealed class TestIReadOnlyCollectionComponent
        {
            public readonly IReadOnlyCollection<IServiceItem> Items;

            public TestIReadOnlyCollectionComponent(IReadOnlyCollection<IServiceItem> serviceItems)
            {
                Items = serviceItems;
            }
        }

        public sealed class TestICollectionComponent
        {
            public readonly ICollection<IServiceItem> Items;

            public TestICollectionComponent(ICollection<IServiceItem> serviceItems)
            {
                Items = serviceItems;
            }
        }

        public sealed class TestIReadOnlyListComponent
        {
            public readonly IReadOnlyList<IServiceItem> Items;

            public TestIReadOnlyListComponent(IReadOnlyList<IServiceItem> serviceItems)
            {
                Items = serviceItems;
            }
        }

        #endregion

        [Test]
        public void TestIEnumerableCorrectlyResolves()
        {
            using(var autosub = new AutoSubstitute())
            {
                var mockA = autosub.Provide<IServiceItem, ItemA>();
                var mockB = autosub.Provide<IServiceItem, ItemB>();
                var component = autosub.Resolve<TestIEnumerableComponent>();

                Assert.That(component.Items, Is.Not.Empty);
                Assert.That(component.Items.Contains(mockA), Is.True);
                Assert.That(component.Items.Contains(mockB), Is.True);
            }
        }

        [Test]
        public void TestIListCorrectlyResolves()
        {
            using(var autosub = new AutoSubstitute())
            {
                var mockA = autosub.Provide<IServiceItem, ItemA>();
                var mockB = autosub.Provide<IServiceItem, ItemB>();
                var component = autosub.Resolve<TestIListComponent>();

                Assert.That(component.Items, Is.Not.Empty);
                Assert.That(component.Items.Contains(mockA), Is.True);
                Assert.That(component.Items.Contains(mockB), Is.True);
            }
        }

        [Test]
        public void TestIReadOnlyCollectionCorrectlyResolves()
        {
            using(var autosub = new AutoSubstitute())
            {
                var mockA = autosub.Provide<IServiceItem, ItemA>();
                var mockB = autosub.Provide<IServiceItem, ItemB>();
                var component = autosub.Resolve<TestIReadOnlyCollectionComponent>();

                Assert.That(component.Items, Is.Not.Empty);
                Assert.That(component.Items.Contains(mockA), Is.True);
                Assert.That(component.Items.Contains(mockB), Is.True);
            }
        }

        [Test]
        public void TestICollectionCorrectlyResolves()
        {
            using(var autosub = new AutoSubstitute())
            {
                var mockA = autosub.Provide<IServiceItem, ItemA>();
                var mockB = autosub.Provide<IServiceItem, ItemB>();
                var component = autosub.Resolve<TestICollectionComponent>();

                Assert.That(component.Items, Is.Not.Empty);
                Assert.That(component.Items.Contains(mockA), Is.True);
                Assert.That(component.Items.Contains(mockB), Is.True);
            }
        }

        [Test]
        public void TestIReadOnlyListCorrectlyResolves()
        {
            using(var autosub = new AutoSubstitute())
            {
                var mockA = autosub.Provide<IServiceItem, ItemA>();
                var mockB = autosub.Provide<IServiceItem, ItemB>();
                var component = autosub.Resolve<TestIReadOnlyListComponent>();

                Assert.That(component.Items, Is.Not.Empty);
                Assert.That(component.Items.Contains(mockA), Is.True);
                Assert.That(component.Items.Contains(mockB), Is.True);
            }
        }
    }
}