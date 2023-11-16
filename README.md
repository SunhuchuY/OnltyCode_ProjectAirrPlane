EventBus.cs

Update()를 되도록 지양하고, 이전 프로젝트에서 Player 와 관련 된 HUD, 정보 탐색 관련 기능들이 많이 엉켜있었던 경험을 토대로 디자인패턴 중 Observer Pattern 으로 고쳐 보려고 했습니다

https://velog.io/@qwert5678/Observer-Pattern 

[https://velog.io/@qwert5678/객체지향OOP](https://velog.io/@qwert5678/%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP)

**저는** Observer Pattern 을 사용하면 나중에 충돌이 일어날 수 있기 때문에 특정 이벤트만 부를 수 있도록 재구성 하여 만들었습니다.
