using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMU.src.utils.MyForm
{
    public class MyButton: Button
    {
        public MyButton(string text, int positionX, int positionY, EventHandler clickEvent)
        {
            AutoSize = true ;
            Text = text;
            Location = new System.Drawing.Point(positionX, positionY);
            Click += clickEvent;
        }
    }
}