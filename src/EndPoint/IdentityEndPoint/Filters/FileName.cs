using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace IdentityEndPoint.Filters
{
    public class TestAfterAttribute : ActionFilterAttribute
    {
        private long UserID;
        private long _SYSUserID;
        public TestAfterAttribute()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var sysusr = context.HttpContext.User.Identities.Where(x => x.AuthenticationType == "UserID").Select(x => x.NameClaimType).ToList()[0];
            var ssusrType = context.HttpContext.User.Identities.Where(x => x.AuthenticationType == "UserTypeID").Select(x => x.NameClaimType).ToList()[0];
            _SYSUserID = Convert.ToInt64(sysusr);
            long sysUserType = Convert.ToInt64(ssusrType);
            var uID = BindingFlags.GetField;
            var action = (string)context.RouteData.Values["action"];
            var _parameterName = context.ActionArguments.First().Value.GetType().GetGenericArguments();//.GetType().GetMethod(action).GetParameters().GetValue(0).GetType().GetProperties();//.AttemptedValue;

            if (context.HttpContext.Request.Method.ToUpper() == "Get".ToUpper())
            {
                UserID = Convert.ToInt64(context.HttpContext.Request.Query["UserID"]);
            }
            else if (context.HttpContext.Request.Method.ToUpper() == "Post".ToUpper())
            {
                //  var u = context.ActionDescriptor.Properties;
                var t = context.ActionArguments.Values;
                dynamic tt;
                foreach (var i in context.ActionArguments.Values)
                {
                    tt = i.GetType().GetProperties();
                    foreach (var ii in tt)
                    {
                        var a = ii;
                    }

                }


            }

            if ((UserID == 1) || (sysUserType == 1))
            { return; }
            if (UserID == _SYSUserID)
            { return; }

            if (UserID != _SYSUserID)
            {
                context.Result = new Microsoft.AspNetCore.Mvc.BadRequestObjectResult("خطای ورودی"); ;
            }

        }


    }
}
