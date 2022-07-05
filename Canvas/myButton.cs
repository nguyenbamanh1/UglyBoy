using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglyBoy.Canvas
{
    public class myButton : ICanvas
    {

        public int x, y;
        private string caption;
        private bool isClick;
        private ActionButton actionButton;
        public bool isHole;
        public myButton(string caption)
        {
            this.caption = caption;
        }
        public int getW()
        {
            return GameScr.imgLbtn.getWidth();
        }

        public void paint(mGraphics g)
        {
            if (isHole)
            {
                g.reset();
            }
            
            if (!isClick)
            {
                g.drawImage(GameScr.imgLbtn, x, y, 0);

            }
            else
            {
                g.drawImage(GameScr.imgLbtnFocus, x, y, 0);
            }
            mFont.tahoma_7b_dark.drawString(g, caption, x + 35, y + 5, mFont.CENTER);
            if (isHole)
            {
                g.setClip(SetupView.gI().myCanvas.x, SetupView.gI().myCanvas.y, SetupView.gI().myCanvas.getW(), SetupView.gI().myCanvas.getH());
                g.translate(SetupView.gI().myCanvas.cmx, -SetupView.gI().myCanvas.cmy);
            }
        }

        public void update()
        {
            int yy = isHole == false ? y - SetupView.gI().myCanvas.cmy : y;
            if (GameCanvas.isPointerHoldIn(x, yy, getW(), GameScr.imgLbtn.h))
            {

                GameCanvas.isPointerJustDown = false;

                if (GameCanvas.isPointerClick && GameCanvas.isPointerJustRelease)
                {
                    if(actionButton != null)
                    {
                        actionButton();
                    }
                    isClick = true;
                    SoundMn.gI().buttonClick();
                    Char.myCharz().currentMovePoint = null;
                    GameCanvas.clearAllPointerEvent();
                }
            }
            if(GameCanvas.gameTick % 10 == 0 && isClick == true)
            {
                isClick = false;
            }
        }

        public void updateKey()
        {
            
        }
       
        public void setAction(ActionButton action)
        {
            this.actionButton = action;
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
            return GameScr.imgLbtn.getHeight();
        }
    }

    public delegate void ActionButton();
}
