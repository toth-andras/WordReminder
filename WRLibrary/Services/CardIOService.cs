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

                    return JsonConvert.DeserializeObject<List<Card>>(fileText);
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
                using (StreamWriter writer = File.CreateText(path))
                {
                    string output = JsonConvert.SerializeObject(cards);
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
