namespace Morgobot.Brain
{
    public class BrainResponse
    {
        public BrainResponse()
        {

        }

        public BrainResponse(string text)
        {
            Text = text;
            ClenUpCurrentContext = false;
        }

        public string Text { get; set; }
        public bool ClenUpCurrentContext { get; set; }
    }
}
