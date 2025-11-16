// MIT License - Copyright (c) 2025 Marcus Ackre Medina
// See LICENSE file in the project root for full license information.

namespace MarcusMedina.Fluent.Text.Core.Tests.Builders;
#pragma warning disable IDE0058 // Expression value is never used

using FluentAssertions;
using MarcusMedina.Fluent.Text.Core.Builders;
using Xunit;

public class FluentTextBuilderTests
{
    #region Public Methods

    [Fact]
    public void Build_ReturnsValue()
    {
        // Arrange
        var builder = FluentTextBuilder.From("test");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().Be("test");
    }

    [Fact]
    public void From_NullValue_ThrowsArgumentNullException()
    {
        // Act
        var act = () => FluentTextBuilder.From(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void From_ValidValue_CreatesBuilder()
    {
        // Act
        var builder = FluentTextBuilder.From("test");

        // Assert
        builder.Should().NotBeNull();
    }

    #endregion Public Methods
}