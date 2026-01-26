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
        private const int OFFSET = 50;
        public CardModel Model { get; set; }
        public CardView(CardModel model)
        {
            Model = model;
            Source = model.ImageCard;
            Margin = model.MarginCard;
        }
        public CardView()
        {
            Source = Model.ImageCard;
            Margin = Model.MarginCard;
        }
        public void ToggleSelected()
        {
            Model.IsSelected = !Model.IsSelected;
            Thickness t = Margin;
            t.Bottom = Model.IsSelected ? OFFSET : 0;
            Margin = t;

        }
    }
}
