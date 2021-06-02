using System;
using Xunit;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductunitTest1
    {
        [Fact]
        public void CreateProduct_WithParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,"product image");
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name","Product Description",9.99m,99,"product image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid ID, ID must to be greater then zero.");
        }

        [Fact]
        public void CreateProduct_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr","Product Description",9.99m,99,"product image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name must have 3 caracters.");
        }

        [Fact]
        public void CreateProduct_LongImage_DomainExceptionLongNameImage()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,"product image tooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooOOOOOooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo longgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Image name is invalid. Too long, image name execeed 200 caracters");
        }

        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name","Product Description",-9.99m,99,"product image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Price is invalid. Price cannot be zero.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,null);
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,null);
            action.Should()
            .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,99,"");
            action.Should()
            .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]
        [InlineData(-5)]
        public void Createproduct_InvalidStockValue_ExceptionDomainNegativeValue(int value){
            Action action = () => new Product(1, "Product Name","Product Description",9.99m,value,"product image");
            action.Should()
            .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Stock is invalid. Stock cannot be zero.");
        }

    }
}