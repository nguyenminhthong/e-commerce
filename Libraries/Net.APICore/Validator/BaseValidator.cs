using FluentValidation;
using Net.APICore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.APICore.Validator
{
    public class BaseValidator<TModel> : AbstractValidator<TModel> where TModel : BaseModel
    {
    }
}