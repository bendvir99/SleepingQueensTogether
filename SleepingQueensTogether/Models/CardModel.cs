using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;

namespace SleepingQueensTogether.Models
{
    public abstract class CardModel : ImageButton
    {
        public string Type { get; set; } = Strings.number;
        public int Value { get; set; } = 0;
        public int QueenValue { get; set; } = 0;
        public bool IsUsed { get; set; } = false;
        public bool IsAwaken { get; set; } = false;
        public int Index { get; set; }
        public bool IsSelected { get; set; }
        public string ImageCard { get; set; } = Strings.orangecard;
        public string BackImage { get; set; } = Strings.greencard;
        [Ignored]
        public bool IsEmpty => Type == Strings.empty;
        public abstract void ToggleSelected();
    }
}
