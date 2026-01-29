using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;

namespace SleepingQueensTogether.Models
{
    public abstract class CardModel
    {

        public string Type { get; set; } = Strings.number;
        public int Value { get; set; } = 0;
        public bool IsUsed { get; set; } = false;
        public bool IsAwaken { get; set; } = false;
        [Ignored]
        public bool IsSelected { get; private set; } = false;
        [Ignored]
        public bool IsEmpty => Type == Strings.empty;
    }
}
