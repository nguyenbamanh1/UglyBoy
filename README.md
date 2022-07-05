# UglyBoy: web của tôi https://www.manhhdc.online/ vẫn nhận tiền donate nhé :))
Thông tin
- SetupView.cs là view chính chứa các view nhỏ hơn.
- myCanvas.cs là nơi xử lý các item menu
- Checked là item kiểu check
- myButton là item kiểu buttom
- Edittext là item nhập dữ liệu.
Cách sử dụng
- trong SetupView khởi tạo myCanvas, cài margin (căn lề) cho canvas nếu bạn muốn
- khởi tạo các item của bạn
  + Checked có setCheck và getCheck là đặt trạng thái và lấy trạng thái của checked đó
  + EditText có setText và getText là đặt dữ liệu và lấy dữ liệu của edittext đó
  + myButton có setAction để đặt action cho button mỗi khi button đó được nhấn VD: khi ta đặt setAction(()=>{ GameScr.info.addInfo("hi", 0); }) thì khi ta nhấn thì sẽ chạy code trong đoạn '{...}'
  + trong myButton có isHole là đặt trạng thái tĩnh cho button, khi isHole đc đặt là true thì button sẽ không bị ảnh hưởng bưởi cuộn chuột.
- Hàm save() trong SetupView là hàm bạn sẽ lưu các dữ liệu ra file. 
- Hàm paint() của SetupView sẽ đc đặt vào cuối hàm Paint của GameScr
- Hàm update() của setupview sẽ đc đặt vào hàm update() * cái này tùy bạn đặt đâu cũng đc, miễn sao hợp lý
- Hàm keyPressed() của SetupView cho vào checkInput của Main cho vào sau GameMidlet.gameCanvas.keyPressedz(num);
- Hàm updateScroolView của SetupView cho vào checkInput của Main cho vào sau GameMidlet.gameCanvas.scrollMouse((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
  * sẽ có dạng như sau: UglyBoy.Canvas.SetupView.gI().updateScroolView((int)(Input.GetAxis("Mouse ScrollWheel") * 10f));
- Hàm addItem trong myCanvas là hàm chúng ta sẽ thêm các item của menu vào thì mới xuất hiện khi chúng ta mở menu lên nhé
-Trong file setup view vẫn có các tag hướng dẫn nhé.
