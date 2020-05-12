# RemoteFileAccessProgram
소켓 통신을 이용하여 원격으로 파일을 확인하고 다운로드하는 프로그램

C#, Winform

1. 실행 화면

Server, Client

Server 실행화면

2. 설명

서버와 클라이언트간의 데이터 통신을 구현하기 위해 패킷 통신을 사용하였습니다.

서버

![image](https://user-images.githubusercontent.com/53392870/81662440-89f8ed00-9478-11ea-8492-ba07d722a588.png)

서버는 확장서버, 선택서버, 상세정보서버, 다운로드서버 라는 이름의 패킷 타입이 있습니다.


클라이언트

![image](https://user-images.githubusercontent.com/53392870/81662437-87969300-9478-11ea-87dc-47db29993bfb.png)

클라이언트는 초기화, 확장손님, 선택소님, 상세정보 손님, 다운로드손님, 다운로드파일 라는 이름의 패킷 타입이 있습니다.



19.04 ~ 19.05
