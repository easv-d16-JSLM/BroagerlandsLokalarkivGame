namespace BLAG.Common.Models.Question
{
    public class QuestionAudio : QuestionBase
    {
        // String will hold the ID of where the audio file is saved in LiteDB
        public string Audio { get; set; }
    }
}