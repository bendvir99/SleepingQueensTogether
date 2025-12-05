using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Card : CardModel
    {
        public Card()
        {
        }
        public Card(string type, string image)
        {
            Type = type;
            Image = image;
        }
        public Card(string type, string image, int value)
        {
            Type = type;
            Image = image;
            if (type == "Queen")
            {
                QueenValue = value;
            }
            else if (type == "Number")
                Value = value;
        }
    }
}
