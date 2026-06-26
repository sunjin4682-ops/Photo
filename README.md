# Photo

C# WinForms로 만든 간단한 사진 편집 프로그램입니다. 사진 위에 이미지 파일을 스티커처럼 올리고, 추가한 스티커를 명령 객체로 관리해 Undo 구조를 연습한 프로젝트입니다.

아직 포토샵처럼 완성된 편집기는 아니지만, 이미지 편집 툴의 기본 구조인 화면 캔버스, 드래그 앤 드롭 입력, 편집 명령 관리, 스티커 객체 모델을 직접 구현해 본 데 의미를 둔 프로젝트입니다.

## 주요 기능

- Windows Forms 기반 사진 편집 UI
- 이미지 파일 드래그 앤 드롭
- 드롭한 이미지를 스티커 객체로 생성
- 스티커 위치와 크기 정보를 `RectangleF`로 관리
- `PictureBox.Paint`에서 스티커 목록을 다시 그리는 방식의 캔버스 구성
- Command 패턴 기반 스티커 추가/취소 구조
- 자르기, 모자이크, 필터, 밝기/대비, 콜라주, 배경 변경 메뉴 UI 구성

## 화면 구성

메인 화면은 사진 편집 영역과 오른쪽 도구 버튼으로 나뉩니다.

| 영역 | 설명 |
|------|------|
| `MainPic` | 사진과 스티커가 표시되는 편집 캔버스 |
| 상단 메뉴 | 영역 편집, 세부 편집, 필터, 꾸미기, 배경 변경 메뉴 |
| 우측 버튼 | 저장, 사진 넣기, 스티커, 초기화, 제거 |
| `Sticker_property` | 스티커 크기 조절을 위한 보조 폼 |

## 구현 구조

```text
Photo/
├── Program.cs                    앱 진입점
├── Main.cs                       메인 폼 로직
├── Main.Designer.cs              메인 폼 UI 배치
├── Sticker_property.cs           스티커 속성 폼 로직
├── Sticker_property.Designer.cs  스티커 속성 UI 배치
├── Photo.csproj                  .NET WinForms 프로젝트 파일
└── Properties/                   리소스 파일
```

## 핵심 코드

### 스티커 객체

스티커는 이미지, 위치/크기, 선택 상태를 가진 객체로 관리합니다.

```csharp
public class StickerObject
{
    public Bitmap StickerImage { get; set; }
    public RectangleF Bounds { get; set; }
    public bool IsSelected { get; set; }
}
```

### Command 패턴

스티커 추가 작업은 `ICommand`로 감싸서 실행과 취소를 같은 인터페이스로 처리합니다.

```csharp
public interface ICommand
{
    void Execute();
    void UnExecute();
}
```

`CommandManager`는 실행한 명령을 Undo 스택에 저장합니다. 이후 이동, 삭제, 크기 변경 같은 편집 기능도 같은 방식으로 확장할 수 있게 설계했습니다.

### 드래그 앤 드롭

사용자가 `.jpg`, `.png`, `.bmp` 파일을 편집 영역에 드롭하면 이미지가 로드되고, 마우스 위치를 기준으로 스티커 객체가 생성됩니다. 스티커는 원본 비율을 유지한 기본 크기로 배치됩니다.

## 실행 환경

- Windows
- .NET 6 SDK 이상
- Windows Forms 지원 환경

## 실행 방법

```powershell
git clone https://github.com/sunjin4682-ops/Photo.git
cd Photo
dotnet build
dotnet run
```

Visual Studio에서 실행할 경우 `Photo.csproj` 또는 솔루션 파일을 열고 실행하면 됩니다.

## 현재 구현 상태

완료된 부분:

- WinForms 기본 UI
- 이미지 드래그 앤 드롭
- 스티커 객체 생성 및 캔버스 렌더링
- 스티커 추가 명령과 Undo 기반 구조
- 스티커 속성 폼의 크기 값 표시

추가 개선할 부분:

- 스티커 이동/삭제/크기 조절 기능 연결
- Undo/Redo 전체 구현
- 저장 기능 구현
- 필터, 밝기, 대비, 모자이크 등 메뉴 기능 구현
- 선택된 스티커 테두리 표시

## 배운 점

- WinForms의 이벤트 기반 UI 흐름
- `PictureBox.Paint`를 이용한 직접 렌더링
- 드래그 앤 드롭 파일 입력 처리
- 편집 작업을 Command 패턴으로 분리하는 방식
- 기능을 붙이기 전에 객체 모델과 실행 취소 구조를 먼저 잡는 설계 방식

## 시연 영상

[![Photo 시연 영상](https://img.youtube.com/vi/-YuLMFe86JE/hqdefault.jpg)](https://youtu.be/-YuLMFe86JE)

영상 링크: https://youtu.be/-YuLMFe86JE
