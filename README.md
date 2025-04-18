# 🕹️ 텍스트 RPG (C# 콘솔 게임)

내일배움캠프에서 진행한 과제인 간단한 **C# 콘솔 기반 RPG 게임**입니다.  

Program.cs가 메인 실행 스크립트입니다.

---
## 🛠️ 개발 환경

- 언어: **C#**

## 🎯 주요 기능

### 📌 기본 시스템
- ✅ **선택지 기반 진행**: 콘솔에 표시되는 선택지를 골라 플레이어를 조작합니다.
- 🧭 **던전 탐사**: 체력을 소모하면서 던전을 탐험하면 **골드를 획득**할 수 있습니다.
- ❤️ **체력 관리 & 휴식**: 골드를 지불하고 **체력을 100으로 회복**할 수 있습니다.

### 💼 아이템 및 장비 시스템
- 🎒 **아이템 획득 및 사용**: 탐험이나 상점에서 아이템을 획득하고 사용할 수 있습니다.
- 🗡️ **장착/해제 기능**:
  - **무기와 방어구는 각각 한 개씩만 장착 가능**
  - 이미 장착 중인 장비가 있을 경우, 새 장비를 선택하면 **기존 장비는 자동으로 해제**되고 새로운 장비로 교체됩니다.
  - 장착 해제도 수동으로 가능합니다 (선택지 제공 시).

### 🛍️ 상점 시스템
- 💰 **아이템 구매 및 판매 가능**
- 인벤토리와 골드를 전략적으로 관리하며 진행

---

## 📌 게임 예시 화면
**게임시작 화면**
스파르타 마을에 오신 여러분 환영합니다.
이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점
4. 던전입장
5. 휴식하기

원하시는 행동을 입력해주세요.
>>

**상태보기**

캐릭터의 정보를 표시합니다.
7개의 속성을 가지고 있습니다.
레벨 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
처음 기본값은 이름을 제외하고는 아래와 동일하게 만들어주세요
이후 장착한 아이템에 따라 수치가 변경 될 수 있습니다.
상태 보기
캐릭터의 정보가 표시됩니다.

Lv. 01      
Chad ( 전사 )
공격력 : 10
방어력 : 5
체 력 : 100
Gold : 1500 G

0. 나가기

원하시는 행동을 입력해주세요.
>>

**장착 관리**

장착관리가 시작되면 아이템 목록 앞에 숫자가 표시됩니다.

1) 일치하는 아이템을 선택했다면
1-1) 장착중이지 않다면 → 장착 → E 표시 추가
1-2) 이미 장착중이라면 → 장착 해제 → E 표시 없애기
2) 일치하는 아이템을 선택했지 않았다면
2-1) 잘못된 입력입니다 출력

아이템의 중복 장착을 허용합니다.
창과 검을 동시에 장착가능 
갑옷도 동시에 착용가능        // 밑에 장착 개선에서 동시 장착과 장착 갯수 제한을 두었습니다. (무기는 1개씩 방어구도 1개씩)
장착 갯수 제한 X 
인벤토리 - 장착 관리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]
- 1 [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.
- 2 [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.
- 3 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.

0. 나가기

원하시는 행동을 입력해주세요.
>>

**장착 개선**

각 타입별로 하나의 아이템만 장착가능 - ( 방어구 / 무기 )
방어구를 장착하면 기존 방어구가 있다면 해제하고 장착
무기를 장착하면 기존 무기가 있다면 해제하고 장착
인벤토리 - 장착 관리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]
- 1 [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.
- 2 [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.
- 3 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.

0. 나가기

원하시는 행동을 입력해주세요.
>>
​
**인벤토리에서 아이템을 장착한 경우**
상태 보기
캐릭터의 정보가 표시됩니다.

Lv. 01      
Chad ( 전사 )
공격력 : 17 = 기본 공격력에 무기의 공격력을 추가 한 값
방어력 : 10 = 기본 방어력에 방어구의 방어력을 추가 한 값
체 력 : 100
Gold : 1500 G

0. 나가기

원하시는 행동을 입력해주세요.
>>

**상점**
필요한 아이템을 얻을 수 있는 상점입니다.

[보유 골드]
800 G

[아이템 목록]
- 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.             |  1000 G
- 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  구매완료
- 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G
- 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  600 G
- 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  1500 G
- 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  구매완료

1. 아이템 구매
2. 아이템 판매
0. 나가기

원하시는 행동을 입력해주세요.
>>

**아이템 구매**

아이템 구매를 선택하면 아이템 목록 앞에 숫자가 표시됩니다.
일치하는 아이템을 선택했다면
 - 이미 구매한 아이템이라면
   → 이미 구매한 아이템입니다 출력
구매가 가능하다면
- 보유 금액이 충분하다면
→ 구매를 완료했습니다. 출력
재화 감소 / 인벤토리에 아이템 추가 / 상점에 구매완료 표시
보유 금액이 부족하다면
→ Gold 가 부족합니다. 출력
일치하는 아이템을 선택했지 않았다면 
잘못된 입력입니다 출력
상점 - 아이템 구매
필요한 아이템을 얻을 수 있는 상점입니다.

[보유 골드]
800 G

[아이템 목록]
- 1 수련자 갑옷    | 방어력 +5  | 수련에 도움을 주는 갑옷입니다.             |  1000 G
- 2 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  구매완료
- 3 스파르타의 갑옷 | 방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  3500 G
- 4 낡은 검      | 공격력 +2  | 쉽게 볼 수 있는 낡은 검 입니다.            |  600 G
- 5 청동 도끼     | 공격력 +5  |  어디선가 사용됐던거 같은 도끼입니다.        |  1500 G
- 6 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  구매완료

0. 나가기

원하시는 행동을 입력해주세요.
>>

**상점 - 아이템 판매**
필요한 아이템을 얻을 수 있는 상점입니다.

[보유 골드]
800 G

[아이템 목록]
- 1 무쇠갑옷      | 방어력 +9  | 무쇠로 만들어져 튼튼한 갑옷입니다.           |  1800 G
- 2 스파르타의 창  | 공격력 +7  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  2700 G

0. 나가기

원하시는 행동을 입력해주세요.
>>

**던전입장 기능 추가 **

- 던전은 3가지 난이도가 있습니다.
- 방어력으로 던전을 수행할 수 있을지 판단합니다.
    - 권장 방어력보다 낮다면
        - 40% 확률로 던전 실패
            - 보상 없고 체력 감소 절반
    - 권장 방어력 보다 높다면
        - 던전 클리어
            - 권장 방어력 +- 에 따라 종료시 체력 소모 반영
                - 기본 체력 감소량
                    - 20 ~ 35 랜덤
                    - (내 방어력 - 권장 방어력) 만큼 랜덤 값에 설정
                    - ex) 권장 방어력 5, 내 방어력 7
                    20(-2) ~ 35(-2) 랜덤
                    - ex) 권장 방어력 11, 내 방어력 5
                    20(+6) ~ 35(+6) 랜덤
- 공격력으로 던전 클리어시 보상을 어느정도 얻을지 계산됩니다.
    - 각 던전별 기본 클리어 보상
        - 쉬운 던전 - 1000 G
        - 일반 던전 - 1700 G
        - 어려운 던전 - 2500 G
    - 공격력  ~ 공격력 * 2 의 % 만큼 추가 보상 획득 가능
        - ex) 공격력 10, 쉬움 던전
        기본 보상 1000 G
        공격력으로 인한 추가 보상 10 ~ 20%
        - ex) 공격력 15, 어려운 던전
        기본 보상 2500 G
        공격력으로 인한 추가 보상 15 ~ 30%

스파르타 마을에 오신 여러분 환영합니다.
이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점
4. 던전입장

원하시는 행동을 입력해주세요.
>>

**던전입장**
이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.

1. 쉬운 던전     | 방어력 5 이상 권장
2. 일반 던전     | 방어력 11 이상 권장
3. 어려운 던전    | 방어력 17 이상 권장
0. 나가기

원하시는 행동을 입력해주세요.
>>

**던전 클리어**
축하합니다!!
쉬운 던전을 클리어 하였습니다.

[탐험 결과]
체력 100 -> 70
Gold 1000 G -> 2200 G 

0. 나가기

원하시는 행동을 입력해주세요.
>>


**휴식하기**
800 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : 800 G)

1. 휴식하기
0. 나가기

원하시는 행동을 입력해주세요.
>>

**휴식하기를 할 경우**
휴식을 완료했습니다. 체력이 모두 회복되었습니다!
[남은 골드] 9860 G
[현재 체력] 100 / 100

계속하려면 아무 키나 누르세요...
>>

---

## 🔧 고쳐야 할 내용
### 체력이 0이하로 떨어질때 게임오버 출력하기
### 나만의 아이템 추가하기
### 레벨업과 경험치 시스템 구현하기
### 던전 클리어 보상으로 경험치와 아이템을 얻을 수 있는 기능 추가하기
### 저장 기능 추가하기





