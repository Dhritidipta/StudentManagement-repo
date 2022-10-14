using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using StudentManagement.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.API.Helpers
{
    public class NotEmptyListOfResponseModels : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            //Get command model payload (JSON) from the body  
            String valueFromBody;
            using (var streamReader = new StreamReader(bindingContext.HttpContext.Request.Body))
            {
                valueFromBody = await streamReader.ReadToEndAsync();
            }
            var modelInstance = JsonConvert.DeserializeObject<StudentForCreationDto>(valueFromBody);

            if (modelInstance == null)
            {
                bindingContext.ModelState.AddModelError("JsonData", "The json body is empty !");
            }

            bindingContext.Result = ModelBindingResult.Success(modelInstance);
        }
    }
}
