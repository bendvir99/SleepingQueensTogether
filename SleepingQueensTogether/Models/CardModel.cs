using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;

namespace SleepingQueensTogether.Models
{
    public abstract class CardModel : ImageButton
    {
        public string Type { get; set; } = "Number";
        public int Value { get; set; } = 0;
        public int QueenValue { get; set; } = 0;
        public bool IsUsed { get; set; } = false;
        public bool IsAwaken { get; set; } = false;
        public int Index { get; set; }
        public bool IsSelected { get; set; }
        public string Image { get; set; } = "orangecard.png";
        public string BackImage { get; set; } = "greencard.png";
        [Ignored]
        public bool IsEmpty => Type == "Empty";
        public abstract void ToggleSelected();
    }
}
