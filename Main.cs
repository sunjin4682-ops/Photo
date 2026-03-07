using System.Security.Cryptography.X509Certificates;
using static Photo.Main;

namespace Photo
{

    public partial class Main : Form
    {
        CommandManager commandManager = new CommandManager();          //명령 관리
        List<StickerObject> stickersList = new List<StickerObject>();  //스티커 리스트

        public interface ICommand
        {
            void Execute(); // 명령 실행 (이미지에 효과 적용)
            void UnExecute(); // 명령 취소 (이전 상태로 복구)
        };


        //명령 관리자. 명령들을 쌓아둘 스택 포함
        public class CommandManager
        {
            private Stack<ICommand> _undoStack = new Stack<ICommand>();
            private Stack<ICommand> _redoStack = new Stack<ICommand>();

            // 새로운 작업을 실행하고 스택에 저장
            public void ExecuteCommand(ICommand command)
            {
                command.Execute();        // 1. 실제로 실행
                _undoStack.Push(command); // 2. "방금 이거 했음"이라고 기록
                _redoStack.Clear();       // 3. 새 작업을 했으니 Redo 기록은 삭제
            }

            public void Undo()
            {
                if (_undoStack.Count > 0)
                {
                    ICommand command = _undoStack.Pop(); // 1. 가장 최근 기록을 꺼냄
                    command.UnExecute();                 // 2. "취소해!" 명령 (스티커가 리스트에서 빠짐)
                    _redoStack.Push(command);            // 3. 나중에 다시 할 수도 있으니 Redo에 보관
                }
            }
        }


        ////1. 핵심 이미지 관리 클래스
        //public class ImageEditorContext
        //{
        //    public Bitmap CurrentImage { get; private set; }
        //    private Stack<ICommand> UndoStack;
        //    private Stack<ICommand> RedoStack;

        //    //public void ExecuteCommand(ICommand command) { ... }
        //    //public void Undo() { ... }

        //    //메인 배경 이미지
        //    public Bitmap BackgroundImage { get; set; }
        //    //추가된 스티커들을 관리하는 리스트
        //    public List<StickerObject> Stickers { get; set; } = new List<StickerObject>();
        //}


        public class StickerObject
        {
            public Bitmap StickerImage { get; set; }  //스티커 원본 이미지
            public RectangleF Bounds { get; set; }    //스티커 위치와 크기
            public bool IsSelected { get; set; }      //현재 선택되었는지 여부

            public StickerObject(Bitmap image, float x, float y, float width, float height)
            {
                StickerImage = image;
                Bounds = new RectangleF(x, y, width, height);
                IsSelected = false;
            }

            //주어진 마우스 좌표가 스티커 영역 안에 있는지 확인하는 메서드
            public bool Contains(PointF point)
            {
                return Bounds.Contains(point);
            }
        };
        public class AddStickerCommand : ICommand
        {
            private List<StickerObject> _stickerList; // 전체 스티커 관리 리스트
            private StickerObject _mySticker;         // 내가 추가할 스티커 객체
            private Action _refreshAction;            // 화면을 새로고침할 메서드를 담을 변수

            // 생성자: 필요한 정보를 미리 받아둡니다.
            public AddStickerCommand(List<StickerObject> list, StickerObject sticker, Action refreshAction)
            {
                _stickerList = list;
                _mySticker = sticker;
                _refreshAction = refreshAction;
            }

            public void Execute()
            {
                _stickerList.Add(_mySticker); // 리스트에 추가 (화면에 나타남)
                _refreshAction?.Invoke(); // 리스트에 추가 후 화면 새로고침 실행!
            }

            public void UnExecute()
            {
                _stickerList.Remove(_mySticker); // 리스트에서 제거 (화면에서 사라짐)
                _refreshAction?.Invoke(); // 리스트에서 제거 후 화면 새로고침 실행!
            }
        }
        //public class MoveStickerCommand : ICommand
        //{
        //    private StickerObject _sticker;
        //    private RectangleF _oldBounds; // 이동 전 좌표와 크기
        //    private RectangleF _newBounds; // 이동 후 좌표와 크기
        //    private StickerObject _targetSticker; // 현재 드래그 중인 스티커
        //    private RectangleF _originalBounds;   // 드래그 시작 시점의 위치
        //    private PointF _lastMousePos;         // 마우스 이동 거리 계산용

        //    public MoveStickerCommand(StickerObject sticker, RectangleF oldBounds, RectangleF newBounds)
        //    {
        //        _sticker = sticker;
        //        _oldBounds = oldBounds;
        //        _newBounds = newBounds;
        //    }

        //    public void Execute()
        //    {
        //        _sticker.Bounds = _newBounds; // 새 위치로 이동
        //    }

        //    public void UnExecute()
        //    {
        //        _sticker.Bounds = _oldBounds; // 예전 위치로 복구
        //    }

        //    private void OnMouseDown(object sender, MouseEventArgs e)
        //    {
        //        // 1. 클릭한 위치에 스티커가 있는지 확인 (뒤에서부터 검사해서 맨 위 스티커 선택)
        //        _targetSticker = Stickers.LastOrDefault(s => s.Contains(e.Location));

        //        if (_targetSticker != null)
        //        {
        //            _originalBounds = _targetSticker.Bounds; // 원래 위치 저장 (나중에 Undo용)
        //            _lastMousePos = e.Location;             // 현재 마우스 지점 저장
        //            _targetSticker.IsSelected = true;
        //        }
        //    }
        //    private void OnMouseMove(object sender, MouseEventArgs e)
        //    {
        //        if (_targetSticker != null && e.Button == MouseButtons.Left)
        //        {
        //            // 마우스가 움직인 거리만큼 스티커 좌표 이동
        //            float dx = e.X - _lastMousePos.X;
        //            float dy = e.Y - _lastMousePos.Y;

        //            _targetSticker.Bounds = new RectangleF(
        //                _targetSticker.Bounds.X + dx,
        //                _targetSticker.Bounds.Y + dy,
        //                _targetSticker.Bounds.Width,
        //                _targetSticker.Bounds.Height
        //            );

        //            _lastMousePos = e.Location; // 마우스 위치 갱신
        //            pictureBox.Invalidate();    // 화면 다시 그리기 (Paint 이벤트 발생)
        //        }
        //    }
        //    private void OnMouseUp(object sender, MouseEventArgs e)
        //    {
        //        if (_targetSticker != null)
        //        {
        //            // 1. 최종 이동 명령 객체 생성
        //            var moveCmd = new MoveStickerCommand(_targetSticker, _originalBounds, _targetSticker.Bounds);

        //            // 2. 매니저를 통해 실행 (이미 위치는 변해있지만 스택에 쌓기 위해 호출)
        //            // 실제로는 Execute 내부 로직을 중복 실행하지 않도록 처리하거나, 스택에만 Push합니다.
        //            commandManager.AddHistory(moveCmd);

        //            _targetSticker = null; // 타겟 해제
        //        }
        //    }
        //}


        public Main()
        {



            InitializeComponent();
            //드롭을 허용하도록 설정
            this.AllowDrop = true;
            //픽쳐박스에 드롭 허용
            MainPic.AllowDrop = true;
            this.DragEnter += Main_DragEnter;
            this.DragDrop += Main_DragDrop;



            ////pictureBox2의 배경을 투명하게 하는 코드
            //pictureBox2.Parent = pictureBox1;        //2의 부모를 1로 설정  
            //pictureBox2.Location = new Point(0, 0);  //부모 기준의 상대 좌표로 위치 조정
        }



        private void Sticker_Click(object sender, EventArgs e)
        {

        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {


        }



        private void MainPic_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    string ext = System.IO.Path.GetExtension(files[0]).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".bmp")
                    {
                        e.Effect = DragDropEffects.Copy; // 허용 } } }
                    }
                }
            }
        }

        private void MainPic_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                try
                {
                    // 1. 파일 경로로부터 이미지 불러오기
                    // (실제 프로젝트에서는 지원하는 확장자인지 체크하는 로직을 추가하는 게 좋습니다)
                    Bitmap loadedImage = new Bitmap(filePath);

                    // 2. 드롭된 좌표 계산 (화면 좌표를 폼 내부 좌표로 변환)
                    Point clientPoint = this.PointToClient(new Point(e.X, e.Y));

                    // 3. 스티커 객체 생성 (기본 크기는 이미지 크기나 특정 값으로 설정)
                    float defaultWidth = 100;
                    float defaultHeight = (float)loadedImage.Height * (defaultWidth / loadedImage.Width); // 비율 유지

                    StickerObject newSticker = new StickerObject(
                        loadedImage,
                        clientPoint.X - (defaultWidth / 2),  // 마우스 위치가 중심이 되도록
                        clientPoint.Y - (defaultHeight / 2),
                        defaultWidth,
                        defaultHeight
                    );

                    // 4. 이전에 만든 AddStickerCommand를 생성하고 실행
                    // stickersList는 메인 클래스에 선언된 List<StickerObject>입니다.
                    ICommand addCommand = new AddStickerCommand(
                        this.stickersList, 
                        newSticker,
                        () => MainPic.Invalidate());  // 이 람다식이 _refreshAction으로 전달됩니다.

                    // 5. 커맨드 매니저를 통해 실행 (자동으로 Undo 스택에 저장됨)
                    this.commandManager.ExecuteCommand(addCommand);

                    // 6. 화면 갱신
                    this.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("이미지 파일을 불러오지 못했습니다: " + ex.Message);
                }
            }
        }

        private void MainPic_Paint(object sender, PaintEventArgs e)
        {
            // 배경 이미지 그리기 (생략 가능)
            // e.Graphics.DrawImage(backgroundImage, 0, 0);

            // 리스트에 있는 모든 스티커 그리기
            foreach (var sticker in stickersList)
            {
                e.Graphics.DrawImage(sticker.StickerImage, sticker.Bounds);
            }
        }
    }
}
