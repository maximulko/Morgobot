namespace Morgobot.Brain
{
    public class BrainResponse
    {
        public BrainResponse()
        {

        }

        public BrainResponse(string text, bool clenUpCurrentContext = false)
        {
            Text = text;
            ClenUpCurrentContext = clenUpCurrentContext;
        }

        public string Text { get; set; }
        public bool ClenUpCurrentContext { get; set; }
    }
}
