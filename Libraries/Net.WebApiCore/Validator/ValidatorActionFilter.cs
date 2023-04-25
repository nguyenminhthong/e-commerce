using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Net.WebApiCore.JsonResult;

namespace Net.WebApiCore.Validator
{
    public class ValidatorActionFilter : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.ModelState.IsValid)
            {
                await next();
            } else
            {
                var errors = context.ModelState.Where(x => x.Value.Errors.Any())
                                    .Select(x => ErrorMapping(x))
                                    .ToList();
                context.Result = await RawJsonResult.BabRequest<IEnumerable<ErrorModel>>(errors);
            }

        }

        private ErrorModel ErrorMapping(KeyValuePair<String, ModelStateEntry> error)
        {
            return new ErrorModel(error.Key, error.Value.Errors.Select(x => x.ErrorMessage).FirstOrDefault()?? "");
        }
    }
}
