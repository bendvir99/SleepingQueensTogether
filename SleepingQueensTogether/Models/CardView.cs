using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Prf;

namespace SleepingQueensTogether.Models
{
    public class CardView : ImageButton
    {
        //private const int Offset = 50;
        public int Index { get; set; }
        protected static readonly string[][] cardsImage = {
        ["cakequeen.png","catqueen.png","dogqueen.png","heartqueen.png","ladybugqueen.png","moonqueen.png","pancakequeen.png","peacockqueen.png","rainbowqueen.png","rosequeen.png","starfishqueen.png","sunflowerqueen.png"],
        ["one.png","two.png","three.png","four.png","five.png","six.png","seven.png","eight.png","nine.png","ten.png"],
        ["kingone.png", "kingtwo.png", "kingthree.png", "kingfour.png", "kingfive.png", "kingsix.png", "kingseven.png", "knightone.png", "knighttwo.png", "knightthree.png", "knightfour.png", "dragon.png", "jester.png", "sleepingpotion.png", "wand.png"] };

        public CardView()
        {
            Source = Strings.orangecard;
        }
        //public void ToggleSelected()
        //{
        //    IsSelected = !IsSelected;
        //    Thickness t = Margin;
        //    t.Bottom = IsSelected ? Offset : 0;
        //    Margin = t;
        //}
        public void SetCardSource(string type, int value)
        {
            Source = type == Strings.queen ? cardsImage[0][value] :
                type == Strings.number ? cardsImage[1][value - 1] :
                type == Strings.king ? cardsImage[2][value - 1] :
                type == Strings.knight ? cardsImage[2][value + 6] :
                type == Strings.dragon ? cardsImage[2][value + 10] :
                type == Strings.joker ? cardsImage[2][value + 11] :
                type == Strings.sleepingpotion ? cardsImage[2][value + 12] :
                type == Strings.wand ? cardsImage[2][value + 13] : Strings.orangecard;
        }
    }
}
