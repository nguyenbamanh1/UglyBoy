using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UglyBoy.Canvas
{
    public class myCanvas : ICanvas
    {
        MyVector currItem = new MyVector();
        public bool isShow;
        public int x, y ;
        public int[] margin = new int[4] { 0, 0, 0, 0 };
        public int cmy, cmx;
        public myCanvas()
        {
            this.x = GameCanvas.w / 2 - (GameCanvas.w - 10) / 2;
            this.y = GameCanvas.h / 2 - (GameCanvas.h - 10) / 2;
        }

        public void addItem(object _item)
        {
            currItem.addElement(_item);
        }

        public void setMargin(int top, int down, int left, int right)
        {
            margin[0] = top;
            margin[1] = down;
            margin[2] = left;
            margin[3] = right;
        }

        public void paint(mGraphics g)
        {
            if (isShow)
            {
                g.setColor(13418622);
                g.fillRect(x, y, getW(), GameCanvas.h - 10);
                g.setClip(x, y, getW(), getH());
                g.translate(cmx, -cmy);
                int v = 0;
                int countEditText = 0;
                for(int i = 0; i < currItem.size(); i++)
                {
                    ICanvas canvas = (ICanvas)currItem.elementAt(i);
                    if(canvas == null)
                    {
                        continue;
                    }
                    if(canvas is myButton == false || ((myButton)canvas).isHole == false)
                    {
                        canvas.setX(margin[2]);
                        if(canvas is EditText)
                        {
                            canvas.setY(margin[0] + v * (mScreen.ITEM_HEIGHT + 10) + countEditText * 10);
                            countEditText++;

                        }
                        else if(canvas is Checked)
                        {
                            canvas.setY(margin[0] + v * 18 + v * 10);
                        }else if(canvas is myButton)
                        {
                            canvas.setY(margin[0] + v * GameScr.imgLbtn.getHeight() + v * 10);
                        }
                        if (i % 2 != 0 && GameCanvas.w > 400)
                        {
                            canvas.setX(margin[2] + getW() / 2);
                            v++;
                        }
                        if(GameCanvas.w <= 400)
                        {
                            v++;
                        }
                        
                    }

                    canvas.paint(g);

                }
            }
            
        }

        public void update()
        {
            if (isShow)
            {
                for (int i = 0; i < currItem.size(); i++)
                {
                    ICanvas canvas = (ICanvas)currItem.elementAt(i);
                    if(canvas != null)
                    {
                        canvas.update();

                    }
                }
            }
        }

        public void updateKey()
        {
            
        }

        public int getW()
        {
            return GameCanvas.w - 10;
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
            return GameCanvas.h - 10;
        }
    }
}
