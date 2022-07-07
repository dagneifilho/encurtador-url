using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Application.Models.Request
{
    public class PostUrl : IValidatableObject
    {
        public string Url {get;set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrEmpty(Url) || !Uri.TryCreate(Url, UriKind.Absolute, out Uri uriResult))
            {
                yield return new ValidationResult("É necessário passar uma url válida. ");
            } 
        }
    }
}