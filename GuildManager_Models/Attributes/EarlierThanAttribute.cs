using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models.Attributes
{
    public class EarlierThanAttribute : ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public EarlierThanAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_otherPropertyName);
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if ((DateTime)value >= (DateTime)otherValue)
            {
                return new ValidationResult("Start date must be earlier than end date.");
            }
            return ValidationResult.Success;
        }
    }
}
