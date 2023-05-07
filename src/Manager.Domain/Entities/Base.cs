using FluentValidation;
using FluentValidation.Results;
using System.Text;

namespace Manager.Domain.Entities { 

    public abstract class Base {

        public long Id { get; set; }
        
        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;

        public bool isValid => _errors.Count == 0;

        protected bool Validate<V, O>(V validator, O obj) where V : AbstractValidator<O>
        {
            var validation = validator.Validate(obj);

            if (validation.Errors.Count > 0)
            {
                AddErrorList(validation.Errors);
            }

            return isValid;
        }

        private void AddErrorList(List<ValidationFailure> errors)
        {
            foreach (var error in errors)
                _errors.Add(error.ErrorMessage);
        }

        public string ErrorsToString()
        {
            var builder = new StringBuilder();

            foreach (var error in _errors)
                builder.Append(" " + error);

            return builder.ToString();
        }
    }
    
}