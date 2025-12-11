namespace SleepingQueensTogether.Models
{
    public class CardModel
    {
        public string Type { get; set; } = "Number";
        public int Value { get; set; } = 0;
        public int QueenValue { get; set; } = 0;
        public bool IsUsed { get; set; } = false;
        public bool IsAwaken { get; set; } = false;
        public string Image { get; set; } = "orangecard.png";
        public string BackImage { get; set; } = "greencard.png";
    }
}
