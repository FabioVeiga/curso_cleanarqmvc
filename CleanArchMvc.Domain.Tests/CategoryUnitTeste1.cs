using System;
using Xunit;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTeste1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid ID, ID must to be greater then zero.");
        }

        [Fact]
        public void CreateCategory_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have 3 caracters");
        }

        [Fact]
        public void CreateCategory_MissingName_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullnameValue_DomainExceptionrInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
