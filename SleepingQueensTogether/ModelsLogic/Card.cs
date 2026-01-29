using SleepingQueensTogether.Models;
using Xamarin.Google.Crypto.Tink.Prf;

namespace SleepingQueensTogether.ModelsLogic
{
    public class Card : CardModel
    {
      
        public Card()
        {
            Type = Strings.empty;
        }
        public Card(string type, int value)
        {
            Type = type;
            Value = value;            
        }

        //protected override string SetImageCard()
        //{
        //    ImageCard = Type == Strings.queen ? cardsImage[0][Value]:
        //        Type == Strings.number ? cardsImage[1][Value - 1] :
        //    if (type == )
        //    {
        //        ImageCard = 
        //    }
        //    else if (type == Strings.number)
        //    {
        //        ImageCard = ;
        //    }
        //    else if (type == Strings.king)
        //    {
        //        ImageCard = cardsImage[2][value - 1];
        //    }
        //    else if (type == Strings.knight)
        //    {
        //        ImageCard = cardsImage[2][value + 6];
        //    }
        //    else if (type == Strings.dragon)
        //    {
        //        ImageCard = cardsImage[2][value + 10];
        //    }
        //    else if (type == Strings.joker)
        //    {
        //        ImageCard = cardsImage[2][value + 11];
        //    }
        //    else if (type == Strings.sleepingpotion)
        //    {
        //        ImageCard = cardsImage[2][value + 12];
        //    }
        //    else if (type == Strings.wand)
        //    {
        //        ImageCard = cardsImage[2][value + 13];
        //    }
        //}

        //public static Card Copy(Card card)
        //{
        //    Card newCard = new();
        //    if (!card.IsEmpty)
        //    {
        //        newCard = new Card(card.Type, card.Value)
        //        {
        //            Index = card.Index
        //        };
        //    }
        //    return newCard;
        //}
    }
}
