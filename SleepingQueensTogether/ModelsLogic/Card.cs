using SleepingQueensTogether.Models;
using Xamarin.Google.Crypto.Tink.Prf;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Card : CardModel
    {
        private const int OFFSET = 50;
        private static readonly string[][] cardsImage = {
        ["cakequeen.png","catqueen.png","dogqueen.png","heartqueen.png","ladybugqueen.png","moonqueen.png","pancakequeen.png","peacockqueen.png","rainbowqueen.png","rosequeen.png","starfishqueen.png","sunflowerqueen.png"],
        ["one.png","two.png","three.png","four.png","five.png","six.png","seven.png","eight.png","nine.png","ten.png"],
        ["kingone.png", "kingtwo.png", "kingthree.png", "kingfour.png", "kingfive.png", "kingsix.png", "kingseven.png", "knightone.png", "knighttwo.png", "knightthree.png", "knightfour.png", "dragon.png", "jester.png", "sleepingpotion.png", "wand.png"] };

        public Card()
        {
            Type = Strings.empty;
            ImageCard = Strings.orangecard;
        }
        public Card(string type, int value)
        {
            Type = type;
            if (type == Strings.queen)
            {
                ImageCard = cardsImage[0][value];
                QueenValue = value;
            }
            else if (type == Strings.number)
            {
                ImageCard = cardsImage[1][value - 1];
                Value = value;
            }
            else if (type == Strings.king)
            {
                ImageCard = cardsImage[2][value - 1];
            }
            else if (type == Strings.knight)
            {
                ImageCard = cardsImage[2][value + 6];
            }
            else if (type == Strings.dragon)
            {
                ImageCard = cardsImage[2][value + 10];
            }
            else if (type == Strings.joker)
            {
                ImageCard = cardsImage[2][value + 11];
            }
            else if (type == Strings.sleepingpotion)
            {
                ImageCard = cardsImage[2][value + 12];
            }
            else if (type == Strings.wand)
            {
                ImageCard = cardsImage[2][value + 13];
            }
        }
        public override void ToggleSelected()
        {
            IsSelected = !IsSelected;
            Thickness t = Margin;
            t.Bottom = IsSelected ? OFFSET : 0;
            Margin = t;
        }
        public static Card Copy(Card card)
        {
            Card newCard = new();
            if (!card.IsEmpty)
            {
                newCard = new Card(card.Type, card.Value)
                {
                    Index = card.Index
                };
            }
            return newCard;
        }
    }
}
