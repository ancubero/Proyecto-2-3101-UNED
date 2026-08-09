using System.Text.Json;
using Proyecto_2_3101.Constants;
using Proyecto_2_3101.Models;

namespace Proyecto_2_3101.Extensions;

public static class SessionExtensions
{
    extension(ISession session)
    {
        private void SetObject(string key, object value)
        {
            var jsonString = JsonSerializer.Serialize(value);
            session.SetString(key, jsonString);
        }

        private T? GetObject<T>(string key)
        {
            var jsonString = session.GetString(key);
            return jsonString == null ? default : JsonSerializer.Deserialize<T>(jsonString);
        }
        
        public void SetUser(UserModel userModel)
        {
            session.SetObject(GlobalConstants.UserSessionKey, userModel);
        }

        public UserModel? GetUser()
        {
            return session.GetObject<UserModel>(GlobalConstants.UserSessionKey);
        }

        public void SetClient(ClientModel clientModel)
        {
            session.Remove(GlobalConstants.ClientSessionKey);
            session.SetObject(GlobalConstants.ClientSessionKey, clientModel);
        }

        public ClientModel? GetClient()
        {
            return session.GetObject<ClientModel>(GlobalConstants.ClientSessionKey);
        }
    }
}