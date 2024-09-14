namespace Rabis.Api.Settings
{
    public static class Endpoints
    {
        public const string Base = "api/v1";
        public static class User
        {
            public const string Get = $"{Base}/user/get";
            public const string Create = $"{Base}/user/create";
            public const string Update = $"{Base}/user/update";
            public const string Delete = $"{Base}/user/delete";
        }
    }
}
