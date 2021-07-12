using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace WRLibrary.Services
{
    /// <summary>
    /// Сервис чтения и записи карточек.
    /// </summary>
    class CardIOService
    {
        // Файл, в котором сохраняются все карточки.
        private readonly string path;

        public CardIOService(string path)
        {
            if (path == null)
            {
                throw new NullReferenceException("Parameter 'path' was null.");
            }
            this.path = path;
        }

        public List<Card> Read()
        {
            try
            {
                using (var reader = File.OpenText(path))
                {
                    var fileText = reader.ReadToEnd();

                    List<CardIOModel> dataFromMemory = JsonConvert.DeserializeObject<List<CardIOModel>>(fileText);
                    List<Card> cards = new List<Card>();

                    foreach (CardIOModel item in dataFromMemory)
                    {
                        cards.Add(new Card(item));
                    }

                    return cards;
                }
            }
            catch (Exception ex)
            {
                throw new CardIOServiceException(ex);
            }
        }
        public void Write(List<Card> cards)
        {
            try
            {
                List<CardIOModel> dataToWrite = new List<CardIOModel>();
                foreach (Card item in cards)
                {
                    dataToWrite.Add(item.ToIOModel());
                }

                using (StreamWriter writer = File.CreateText(path))
                {
                    string output = JsonConvert.SerializeObject(dataToWrite);
                    writer.Write(output);
                }
            }
            catch (Exception ex)
            {
                throw new CardIOServiceException(ex);
            }
        }
    }
}
