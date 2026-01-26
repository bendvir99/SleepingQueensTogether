using Plugin.CloudFirestore.Attributes;
using SleepingQueensTogether.ModelsLogic;

namespace SleepingQueensTogether.Models
{
    public abstract class CardModel
    {
        protected static readonly string[][] cardsImage = {
        ["cakequeen.png","catqueen.png","dogqueen.png","heartqueen.png","ladybugqueen.png","moonqueen.png","pancakequeen.png","peacockqueen.png","rainbowqueen.png","rosequeen.png","starfishqueen.png","sunflowerqueen.png"],
        ["one.png","two.png","three.png","four.png","five.png","six.png","seven.png","eight.png","nine.png","ten.png"],
        ["kingone.png", "kingtwo.png", "kingthree.png", "kingfour.png", "kingfive.png", "kingsix.png", "kingseven.png", "knightone.png", "knighttwo.png", "knightthree.png", "knightfour.png", "dragon.png", "jester.png", "sleepingpotion.png", "wand.png"] };

        public string Type { get; set; } = Strings.number;
        public int Value { get; set; } = 0;
        public bool IsUsed { get; set; } = false;
        public bool IsAwaken { get; set; } = false;
        public int Index { get; set; }
        public bool IsSelected { get; set; }
        [Ignored]
        public string ImageCard { get; set; } = Strings.orangecard;
        [Ignored]
        public string BackImage { get; set; } = Strings.greencard;
        [Ignored]
        public bool IsEmpty => Type == Strings.empty;
        [Ignored]
        public Thickness MarginCard { get; set; } = new(0);
        protected abstract string SetImageCard();
    }
}
