using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace SonMogendorff
{
    public class ErrorExtractor
    {
        public static List<PropErrors> ExtractErrors(ModelStateDictionary modelState)
        {
            List<PropErrors> errorList = new List<PropErrors>();

            foreach (var item in modelState)
            {
                PropErrors propErrors = new PropErrors();

                propErrors.property = item.Key;

                foreach (var err in item.Value.Errors)
                {
                    propErrors.errors.Add(err.ErrorMessage);
                }
                errorList.Add(propErrors);
            }
            return errorList;
        }
    }
}