using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglyBoy.Canvas
{
    public class Checked : ICanvas
    {
        private bool ischecked, focus;
        public int x, y;
        private string caption;
        public static Image imgCheck = GameCanvas.loadImage("/mainImage/myTexture2dcheck.png");
        public Checked(string caption)
        {
            this.caption = caption;
        }

        public void paint(mGraphics g)
        {
            paintCheckPass(g, x, y);
        }

        public void paintCheckPass(mGraphics g, int x, int y)
        {
            g.drawRegion(imgCheck, 0, (ischecked ? 2 : 0) * 18, 20, 18, 0, x, y, 0);
            mFont.tahoma_7_white.drawString(g, caption, x + imgCheck.getWidth() + 5, y + 4, 0);
        }

        public void update()
        {
            if (GameCanvas.isPointerHoldIn(x, y - SetupView.gI().myCanvas.cmy, 20, 18))
            {

                GameCanvas.isPointerJustDown = false;

                if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
                {
                    ischecked = !ischecked;
                    SoundMn.gI().buttonClick();
                    Char.myCharz().currentMovePoint = null;
                    GameCanvas.clearAllPointerEvent();
                }
            }
        }

        public void updateKey()
        {
            
        }

        public int getW()
        {
            return imgCheck.getWidth() + mFont.tahoma_7_grey.getWidth(caption);
        }

        public void setChecked(bool check)
        {
            ischecked = check;
        }
        public bool getChecked()
        {
            return ischecked;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }

        public int getY()
        {
            return this.y;
        }

        public int getH()
        {
            return imgCheck.getHeight();
        }
    }
}
