using System;
using System.Reactive.Disposables;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter1Tests
    {
        public class Using
        {
            [Fact]
            public void Should_ReturnCorrectValueBeforeDisposing()
            {
                static IDisposable DisposableFactory() => new BooleanDisposable();

                var result = Chapter1.Using(DisposableFactory, GetDisposed);

                result.Should().BeFalse();
            }

            [Fact]
            public void Should_DisposeDisposable()
            {
                var disposable = new BooleanDisposable();

                var result = Chapter1.Using(disposable, GetDisposed);

                result.Should().BeFalse();

                disposable.IsDisposed.Should().BeTrue();
            }

            private static bool GetDisposed(IDisposable disposable) =>
                disposable switch
                {
                    ICancelable cancelable => cancelable.IsDisposed,
                    _ => false
                };
        }
    }
}
