using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Users.WebAPI.UnitOfWork
{
    public class UnitOfWorkFilter : IAsyncActionFilter
    {
        private static UnitOfWorkAttribute? GetUoWAttr(ActionDescriptor actionDesc)
        {
            var desc = actionDesc as ControllerActionDescriptor;
            if (desc == null)
            {
                return null;
            }
            var uowAttr = desc.ControllerTypeInfo.GetCustomAttribute<UnitOfWorkAttribute>();
            if (uowAttr != null)
            {
                return uowAttr;
            }
            else
            {
                return desc.MethodInfo.GetCustomAttribute<UnitOfWorkAttribute>();
            }
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var uowAttr = GetUoWAttr(context.ActionDescriptor);
            if (uowAttr == null)
            {
                await next();
                return;
            }
            List<DbContext> dbContexts = new List<DbContext>();
            foreach (var dbContextType in uowAttr.DbContextTypes)
            {
                var sp = context.HttpContext.RequestServices;
                DbContext dbContext = (DbContext)sp.GetRequiredService(dbContextType);
                dbContexts.Add(dbContext);
            }
            var result = await next();
            if (result.Exception == null)
            {
                foreach (var dbContext in dbContexts)
                {
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
