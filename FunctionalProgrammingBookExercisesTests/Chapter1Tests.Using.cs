using System;
using System.Reactive.Disposables;

using FluentAssertions;

using FunctionalProgrammingBookExercises;

using Xunit;

namespace FunctionalProgrammingBookExercisesTests
{
    public partial class Chapter1Tests
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Naming",
            "CA1716:Identifiers should not match keywords",
            Justification = "The method is an alternative for the keyword")]
        public class Using : Chapter1Tests
        {
            [Fact]
            public void Should_ReturnCorrectValueBeforeDisposing()
            {
                static IDisposable DisposableFactory() => new BooleanDisposable();

                var result = Chapter1.Using(DisposableFactory, GetDisposed);

                result.Should().BeFalse();
            }

            [Fact]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "Reliability",
                "CA2000:Dispose objects before losing scope",
                Justification = "The code is disposing")]
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
