using Nancy;

namespace WebServer
{
    public class WebServerLogic : NancyModule
    {
        // Poor mans DI
        public WebServerLogic() : this (null)
        {
        }

        public WebServerLogic(IPickRockPaperOrScissors pickRockPaperOrScissors)
        {
            Get["/"] = parameters =>
            {
                var choice = pickRockPaperOrScissors.MakeDecision();

                return choice;
            }; 
        }
    }
}