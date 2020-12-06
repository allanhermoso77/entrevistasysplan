using SysplanSolution.API.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SysplanSolution.API.ViewModels
{
    public class ClienteViewModel : IValidatableObject
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ClienteViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
