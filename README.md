# Sparta Dungeon

## 목차
1. [프로젝트](#프로젝트)
2. [스캐너 기능](#스캐너)
3. [점프대](#점프대)
4. [아이템](#아이템)
5. [트러블슈팅](#트러블슈팅)

## 프로젝트
![intro](https://github.com/xoxohoon01/Sparta-Dungeon/blob/main/Intro.gif)

스파르타 던전 탐험 - 스파르타사우루스

## 스캐너
![scanner](https://github.com/xoxohoon01/Sparta-Dungeon/blob/main/Scanner.gif)

마우스를 움직여 오브젝트를 바라보면 해당 오브젝트의 정보가 좌측 상단의 패널에 표시됩니다.

Raycast를 사용하여 카메라에서 forward 방향으로 레이를 생성해 레이에 접촉한 오브젝트의 정보를 받아오도록 구현했습니다.

## 점프대
![jumpPlatform](https://github.com/xoxohoon01/Sparta-Dungeon/blob/main/JumpPlatform.gif)

캐릭터가 점프대를 밟으면 높이 튀어오릅니다.

점프대 오브젝트 콜라이더를 trigger로 설정하고, 캐릭터 오브젝트에 EnterObject라는 스크립트를 만들었습니다.

EnterObject는 OnEnterTrigger 메소드에서 현재 충돌한 트리거가 점프대일 때 Rigidbody.AddForce 메소드를 통해 구현했습니다.

## 아이템
![speedUp](https://github.com/xoxohoon01/Sparta-Dungeon/blob/main/SpeedUp.gif)

캐릭터가 아이템을 획득하면 일정 시간동안 빨라집니다.

점프대와 마찬가지로 아이템 오브젝트 콜라이더를 trigger로 설정하였으며

캐릭터 오브젝트의 EnterObject 스크립트에서 충돌한 트리거가 아이템일 경우 코루틴을 실행하게 됩니다.

코루틴에서 yield return new WaitForSeconds를 통해 지속시간을 구현했습니다.


## 트러블슈팅

1. 지속시간이 끝나기 전에 같은 아이템을 획득할 경우 지속시간이 초기화 되지 않는 문제가 있었는데,
이는 IEnumerator 멤버를 선언하고, 해당 IEnumerator 멤버를 초기화하고 시작하는 방식을 사용했습니다.

2. 아이템의 기능, 즉 "획득했을 때 이동속도가 빨라짐" 이런 기능 자체를 ScriptableObject에 추가하여 적용시키고 싶었지만, ScriptableObject 에셋은 스크립트처럼 수정이 불가능하여 구현할 수 없었습니다.
ItemScript를 따로 구현하여, 아이템의 정보를 토대로 기능이 실행되도록 구현했습니다.
