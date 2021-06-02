using System;
namespace CleanArchMvc.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        //recebe erro na string e retorana para classe vase
        public DomainExceptionValidation(string error) : base(error)
        {
            
        }

        public static void When(bool hasError, string error){
            if(hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}