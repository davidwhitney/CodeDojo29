using System;

namespace CodoDojo29
{
    public interface IPlayer
    {
        string GetHand();
    }

    public class Player : IPlayer
    {
        private readonly IDoAHttpGet _httpChannel;

        public Player(IDoAHttpGet httpChannel)
        {
            _httpChannel = httpChannel;
            if (httpChannel == null) throw new ArgumentNullException("httpChannel");
        }

        public string GetHand()
        {
            var response = _httpChannel.GetUrl("http://localhost:8888/");

            return response;
        }
    }
}