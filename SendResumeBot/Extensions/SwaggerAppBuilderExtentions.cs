using IHMA_INSON_bot;
using SendResumeBot;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerAppBuilderExtentions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            if (AppSettings.Instance.Swagger.Enabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}
