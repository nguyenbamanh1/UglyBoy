using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglyBoy.Canvas
{
    interface ICanvas
    {
        void paint(mGraphics g);
        void update();
        void updateKey();

        void setX(int x);
        void setY(int y);

        int getX();
        int getY();
        
        int getW();
        int getH();
    }
}
