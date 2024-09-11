namespace Rabis.Api.Settings
{
    public static class Endpoints
    {
        public const string Base = "api/v1";
        public static class User
        {
            public const string GetAll = $"{Base}/user/getall";
            public const string Create = $"{Base}/user/create";
            public const string Update = $"{Base}/user/update";
        }
    }
}
