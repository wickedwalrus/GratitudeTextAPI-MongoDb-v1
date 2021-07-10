using GratitudeTextAPI_v1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GratitudeTextAPI_v1.Services
{
    public class TextService
    {
        private readonly IMongoCollection<Text> _texts;
        public TextService(IGratitudeTextDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _texts = database.GetCollection<Text>(settings.GratitudesCollectionName);
        }

        public List<Text> Get() =>
            _texts.Find(text => true).ToList();

        public Text Get(string id) =>
            _texts.Find<Text>(text => text.Id == id).FirstOrDefault();

        public Text Create(Text text)
        {
            _texts.InsertOne(text);
            return text;
        }

        public void Update(string id, Text textIn) =>
            _texts.ReplaceOne(text => text.Id == id, textIn);

        public void Remove(Text textIn) =>
            _texts.DeleteOne(text => text.Id == textIn.Id);

        public void Remove(string id) =>
            _texts.DeleteOne(text => text.Id == id);
    }
}
