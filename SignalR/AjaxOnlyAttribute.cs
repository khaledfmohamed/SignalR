using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SignalR
{
    [AttributeUsage(AttributeTargets.Method , AllowMultiple =false)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public AjaxOnlyAttribute()
        {
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
           if( controllerContext.HttpContext.Request.IsAjaxRequest())
            {
                return true;
            }
            return false;

        }
    }
}