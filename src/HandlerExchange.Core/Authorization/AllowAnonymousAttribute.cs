using System;

namespace HandlerExchange.Core.Authorization
{
        [AttributeUsage(AttributeTargets.Method)]
        public class AllowAnonymousAttribute : Attribute
        {}
}