using WEBASE.AspNet.Security;
using WEBASE.i18n;
using WEBASE.Minio;
using Webase.TelegramBot.Configs;

namespace SendResumeBot;

public class AppSettings
{
    public static AppSettings Instance { get; private set; }
    public string TestByUserName { get; set; }
    public CultureConfig Culture { get; set; } = new();
    public CookieConfig Cookie { get; set; }
    public ClientErrorsConfig ClientErrors { get; set; } = new();
    public JwtConfig Jwt { get; set; }
    public DatabaseConfig Database { get; set; } = new();
    public ControllerConfig ControllerConfig { get; set; } = new();
   // public IntegrationConfig Integration { get; set; } = new();
    public CorsConfig Cors { get; set; } = new();
    public SwaggerConfig Swagger { get; set; } = new();
    public TelegramBotConfig TelegramBot { get; set; } = new();
    public MinioConfig Minio { get; set; } = new();

    public static void Init(AppSettings instance)
    {
        Instance = instance;
    }
}

public class ClientErrorsConfig
{
    public bool Enabled { get; set; }
    public bool SentErrorDetails { get; set; }
}

public class DatabaseConfig
{
    public PgSqlConfig PgSql { get; set; } = new();
}

public class PgSqlConfig
{
    public string ConnectionString { get; set; } = "";
}

public class SwaggerConfig
{
    public bool Enabled { get; set; }
    public string Prefix { get; set; }
}

public class ControllerConfig
{
    public bool EnableSecurityInfo { get; set; }
}

public class CorsConfig
{
    public bool UseCors { get; set; }
    public string AllowedOrgins { get; set; }
}


