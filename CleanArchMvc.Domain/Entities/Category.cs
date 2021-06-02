using System;
using CleanArchMvc.Domain.Validation;
using System.Collections.Generic;

namespace CleanArchMvc.Domain.Entities
{
    //sealed garante que nao possa ser herdado
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            
            DomainExceptionValidation.When(id < 0, "Invalid ID, ID must to be greater then zero.");
            Id = id;
            ValidateDomain(name);
        }

        private void ValidateDomain(string name){
            //Valida por excecao, se nao tiver erro atribue ao name
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name must have 3 caracters");
            Name = name;
        }

        public void update(string name){
            ValidateDomain(name);
            Name = name;
        }
    }
}