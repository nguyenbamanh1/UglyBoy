using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace UglyBoy.Canvas
{
    public class SetupView
    {
        private static SetupView instance;
        public static EditText text;
        private myButton exit;
        public myCanvas myCanvas;
        private bool startHide;
        private int indexMouse = 0;


        Checked sanboss;
        Checked csb;
        Checked Autohs1;
        Checked Automocskb;
        Checked xhq;
        Checked Autobuffhp_mp;
        Checked petgohome;
        Checked autoks;
        Checked chimkhi;
        Checked adthpmp;
        Checked fboss;
        Checked xoaBG;
        private Checked thayBG;
        EditText editText;
        EditText autochat;
        EditText hpttnl;
        EditText mpttnl;
        EditText hpks;
        myButton selectF;
        public static SetupView gI()
        {
            if(instance == null)
            {
                instance = new SetupView();
            }
            return instance;
        }

        public SetupView()
        {
            //khởi tạo canvas
            myCanvas = new myCanvas();
            //căn lề cho canvas
            myCanvas.setMargin(20, 20, 20, 20);

            sanboss = new Checked("Săn Boss");
            sanboss.setChecked(getChecked("sanboss"));
            csb = new Checked("Dùng CSB khi xmap");
            csb.setChecked(getChecked("csb"));
            Autohs1 = new Checked("Auto hồi sinh (1 ngọc)");
            Autohs1.setChecked(getChecked("ahs1"));
            Automocskb = new Checked("Auto mở cskb khi auto up cskb");
            Automocskb.setChecked(getChecked("opencskb"));
            xhq = new Checked("Xóa Hào Quang");
            xhq.setChecked(getChecked("xoahaoquang"));
            Autobuffhp_mp = new Checked("Auto buff đậu theo HP/MP");
            Autobuffhp_mp.setChecked(getChecked("Autobuffhp_mp"));
            autoks = new Checked("Auto ks boss");
            autoks.setChecked(getChecked("autoks"));
            chimkhi = new Checked("Auto dùng chim/khỉ khi dùng 'ts3'");
            chimkhi.setChecked(getChecked("chimkhi"));
            adthpmp = new Checked("Auto buff đậu đệ theo % HP/MP (bật petw)");
            adthpmp.setChecked(getChecked("autobuff"));
            fboss = new Checked("Auto chỉ vào boss");
            fboss.setChecked(getChecked("fboss"));
            petgohome = new Checked("Đệ về nhà khi tách hợp thể");
            petgohome.setChecked(getChecked("petbackhome"));
            xoaBG = new Checked("Xóa BackGround");
            xoaBG.setChecked(getChecked("xoabg"));
            thayBG = new Checked("Thay BackGround");
            editText = new EditText("Boss cần săn");
            autochat = new EditText("Nhập nội dung chat");
            hpttnl = new EditText("Nhập HP (%)");
            mpttnl = new EditText("Nhập MP (%)");
            hpks = new EditText("Nhập lượng hp ks boss");

            editText.setText(getText("dsboss"));
            autochat.setText(getText("autochat"));
            hpttnl.setText(getText("hpttnl"));
            mpttnl.setText(getText("mpttnl"));
            hpks.setText(getText("hpks"));

            selectF = new myButton("Chọn ảnh");
            selectF.setAction(() =>
            {
                GameScr.info1.addInfo("hii", 0);
            });
            exit = new myButton("Save");

            //đặt vị trí x, y cho button
            exit.setX(myCanvas.getW() - exit.getW());
            exit.setY(myCanvas.getH() - GameScr.imgLbtn.getHeight());
            //setAction sẽ là sự kiện khi người chơi nhấn vào button
            exit.setAction(() =>
            {
                try
                {
                    SanBoss.gI().sb = sanboss.getChecked();
                    Xmap.isCSB = csb.getChecked();
                    Ugly.gI().autohs1 = Autohs1.getChecked();
                    AutoItem.gI().isOpencskbX99 = Automocskb.getChecked();
                    SanBoss.gI().isTeleBoss = autoks.getChecked();
                    SanBoss.gI().fboss = fboss.getChecked();
                    Ugly.gI().chimkhi = chimkhi.getChecked();
                    if (Ugly.gI().chimkhi)
                    {
                        if(Char.myCharz().cgender == 1)
                        {
                            Ugly.gI().skillChimkhi = Ugly.gI().findSkill(12);
                        }else if(Char.myCharz().cgender == 2)
                        {
                            Ugly.gI().skillChimkhi = Ugly.gI().findSkill(13);
                        }
                    }
                    Ugly.gI().noidung = autochat.getText();
                    Ugly.petbackhome = petgohome.getChecked();
                    Ugly.gI().xoabg = xoaBG.getChecked();
                    Ugly.gI().thayBG = thayBG.getChecked();
                    if (Ugly.gI().thayBG)
                    {
                        if (Rms.loadRMS("bg") != null)
                        {

                            byte[] array = Rms.convertSbyteToByte(Rms.loadRMS("bg"));

                            Ugly.bg = Image.createImage(array);


                            if(Ugly.bg != null)
                            {
                                float w = Ugly.bg.w > ScaleGUI.WIDTH ? ScaleGUI.WIDTH / ((float)Ugly.bg.w) : ((float)Ugly.bg.w) / ScaleGUI.WIDTH;
                                float h = Ugly.bg.h > ScaleGUI.HEIGHT ? ScaleGUI.HEIGHT / ((float)Ugly.bg.h) : ((float)Ugly.bg.h) / ScaleGUI.HEIGHT;
                                float min = (w > h ? h : w);

                                Ugly.bg.texture = Ugly.gI().Resize(Ugly.bg.texture, (int)(min * Ugly.bg.w), (int)(min * Ugly.bg.h));

                                Ugly.bg.w = Ugly.bg.texture.width;
                                Ugly.bg.h = Ugly.bg.texture.height;
                            }
                            else
                            {
                                Ugly.gI().thayBG = false;
                                thayBG.setChecked(false);
                            }
                        }
                    }
                    SanBoss.gI().LoadData(editText.getText().Split(';'));
                }catch(Exception e)
                {

                }
                SetupView.gI().save();
                SetupView.gI().hide();
                GameScr.info1.addInfo("Lưu dữ liệu thành công", 0);
            });
            //isHole của button mục đích sẽ cho button đứng im 1 chỗ 
            exit.isHole = true;
            //đoạn addItem này là sẽ thêm các Item menu vào menu
            myCanvas.addItem(sanboss);
            myCanvas.addItem(csb);
            myCanvas.addItem(Autohs1);
            myCanvas.addItem(Automocskb);
            myCanvas.addItem(xhq);
            myCanvas.addItem(Autobuffhp_mp);
            myCanvas.addItem(autoks);
            myCanvas.addItem(chimkhi);
            myCanvas.addItem(adthpmp);
            myCanvas.addItem(fboss);
            myCanvas.addItem(petgohome);
            myCanvas.addItem(xoaBG);
            myCanvas.addItem(thayBG);
            myCanvas.addItem(editText);
            myCanvas.addItem(autochat);
            myCanvas.addItem(hpttnl);
            myCanvas.addItem(mpttnl);
            myCanvas.addItem(hpks);
            myCanvas.addItem(selectF);
            myCanvas.addItem(exit);
        }

        //lấy dữ liệu kiểu boolean ra từ file
        private bool getChecked(string name)
        {
            return Rms.loadRMSString(name) != null ? Rms.loadRMSString(name).Equals("1") : false;
        }
        //lấy dữ liệu cho edittext
        private string getText(string name)
        {
            return Rms.loadRMSString(name) != null ? Rms.loadRMSString(name) : "";
        }

        //lưu dữ liệu ra file
        public void save()
        {
            Rms.saveRMSString("sanboss", SanBoss.gI().sb ? "1" : "0");
            Rms.saveRMSString("csb", Xmap.isCSB ? "1" : "0");
            Rms.saveRMSString("ahs1", Ugly.gI().autohs1 ? "1" : "0");
            Rms.saveRMSString("opencskb", AutoItem.gI().isOpencskbX99 ? "1" : "0");
            Rms.saveRMSString("xoahaoquang", Ugly.xoahaoquang ? "1" : "0");
            Rms.saveRMSString("autoks", SanBoss.gI().isTeleBoss ? "1" : "0");
            Rms.saveRMSString("fboss", SanBoss.gI().fboss ? "1" : "0");
            Rms.saveRMSString("chimkhi", Ugly.gI().chimkhi ? "1" : "0");
            Rms.saveRMSString("autobuff", Ugly.gI().abuffpethpmp ? "1" : "0");
            Rms.saveRMSString("autochat", Ugly.gI().noidung);
            Rms.saveRMSString("dsboss", editText.getText());
            Rms.saveRMSString("xoabg", Ugly.gI().xoabg ? "1" : "0");
            Rms.saveRMSString("petbackhome", Ugly.petbackhome ? "1" : "0");

        }

        //cho vào cuối của hàm paint trong GameScr
        public void paint(mGraphics g)
        {
            myCanvas.paint(g);

        }

        //cho vào update
        public void update()
        {
            myCanvas.update();
            if(startHide && GameCanvas.gameTick % 20 == 0)
            {
                startHide = false;
                this.myCanvas.isShow = false;
            }
        }

        //gọi hàm này khi muốn mở menu
        public void show()
        {
            this.myCanvas.isShow = true;
            GameScr.gI().isLockKey = true;
            //this.myCanvas.cmy = this.myCanvas.y;
        }

        //hàm này gọi trong button exit
        public void hide()
        {
            startHide = true;
            GameScr.gI().isLockKey = false;
        }

        public bool isShow()
        {
            return this.myCanvas.isShow;
        }
        //hàm này cho vào checkInput của Main cho vào sau GameMidlet.gameCanvas.keyPressedz(num);
        public void keyPressed(int c)
        {
            if (text != null && myCanvas.isShow)
            {
                text.keyPressed(c);
            }
        }
        //hàm này cho vào checkInput của Main cho vào sau GameMidlet.gameCanvas.scrollMouse((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
        //viết như sau: UglyBoy.Canvas.SetupView.gI().updateScroolView((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
        public void updateScroolView(int a)
        {
            if(a > 0 )
            {
                indexMouse--;
            }
            if(a < 0)
            {
                indexMouse++;
            }
            if (indexMouse < 0)
            {
                indexMouse = 0;
            }


            this.myCanvas.cmy = indexMouse * 12;
        }
    }
}
