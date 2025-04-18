﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TextRpg;

namespace TextRpg
{
    class Shop
    {
        private Player _player;
        public Item selectedItem;


        int itemNum = 0;
        private List<Item> items;

        public Shop(Player player)
        {
            _player = player;

            items = new List<Item>()
            {
            new Armor("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, false),
            new Armor("무쇠갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1500, false),
            new Armor("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false),
            new Weapon("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600, false),
            new Weapon("청동 도끼", 5, "어디선가 사용됐던거 같은 도끼입니다.", 1500, false),
            new Weapon("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 4000, false)
            };

        }
        public void DisplayItems(Inventory _inventory)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드]\n{_player.gold}\n");
                Console.WriteLine("[아이템 목록]\n");
                foreach (Item item in items)
                {
                    item.PrintInfo();
                }

                Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                string shopExit = Console.ReadLine();
                int shopTmp;
                if (!int.TryParse(shopExit, out shopTmp))
                {
                    Console.Clear();
                    Console.WriteLine("목록에 나온 숫자만 입력하세요.");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    switch (shopTmp)
                    {
                        case 0:
                            break;
                        case 1:
                            DisplayBuyItems(_inventory);
                            break;
                        case 2:
                            SellItem(_inventory); // 아이템 판매
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("목록에 나온 숫자만 입력하세요.");
                            Console.ReadKey();
                            continue;

                    }
                    break;
                }
                break;
            }
        }
        public void DisplayBuyItems(Inventory _inventory)
        {
            while (true) // 상점 메뉴를 계속 유지하려면 무한 루프
            {
                Console.Clear();
                Console.WriteLine("상점\n번호를 눌러 아이템을 구매하세요.\n");
                Console.WriteLine($"[보유 골드]\n{_player.gold}\n");
                Console.WriteLine("[아이템 목록]\n");

                for (int i = 0; i < items.Count; i++)
                {
                    Console.Write($"- {i + 1}  ");
                    items[i].PrintInfo(); // item리스트의 i번쨰 요소아이템정보를 보여줌
                }

                Console.WriteLine("\n0. 나가기\n");
                Console.WriteLine("구매하려는 아이템의 번호를 입력해주세요.");
                string selectBuy = Console.ReadLine();

                if (!int.TryParse(selectBuy, out int buyTmp)) // 숫자인지 판단하기
                {
                    Console.Clear();
                    Console.WriteLine("목록에 나온 숫자만 입력하세요.");
                    Console.ReadKey();
                    continue; // 잘못된 입력은 다시 루프를 돌도록 함
                }

                if (buyTmp == 0)
                {
                    return; // 0번을 눌렀을 때 상점 메뉴 종료 후, 메인 화면으로 돌아가는 경우
                }

                if (buyTmp < 1 || buyTmp > items.Count) // 0이나 리스트 인덱스 값을 넘어가면 재입력받게 하기
                {
                    Console.Clear();
                    Console.WriteLine("올바른 번호를 입력해주세요.");
                    Console.ReadKey();
                    continue; // 잘못된 입력은 다시 루프를 돌도록 함
                }

                selectedItem = items[buyTmp - 1]; // items리스트의 타입이 Item이므로 Item형의 변수를 생성하고 입력받은 값을 items 리스트의 인덱스에 접근시킨다.

                if (selectedItem.isPurchased) // 선택한 아이템(선택한 리스트의 인덱스)가 이미 구매했는지에 대한 여부를 확인하는 조건문
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (_player.gold >= selectedItem.price) // 또는 플레이어가 가지고있는 골드가 아이템 가격보다 많이가지고 있을경우(같을경우)
                {
                    _player.gold -= selectedItem.price; // 플레이어 골드에 아이템 가격을 빼준다.
                    selectedItem.isPurchased = true; // 구매를 했으니 구매했는지에 대한 여부를 나타내는 bool타입 변수를 true로 바꿔줘 중복구매를 방지한다.
                    _inventory.inventory.Add(selectedItem); // 인벤토리에 추가
                    Console.WriteLine($"{selectedItem.itemName} 을(를) 구매했습니다!");
                }
                else // 그외는 골드가 모자를 경우
                {
                    Console.WriteLine("골드가 부족합니다!");
                }

                Console.WriteLine("계속하려면 아무 키나 누르세요...");
                Console.ReadKey();
            }
        }
        public void SellItem(Inventory inventory)
        {
            var ownedItems = inventory.GetOwnedItems();

            if (ownedItems.Count == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매\n");
            Console.WriteLine("번호를 입력해 아이템을 판매하세요.\n");
            Console.WriteLine($"\n[보유 골드]\n{_player.gold} G");

            // 판매 가능한 아이템 목록을 출력
            for (int i = 0; i < ownedItems.Count; i++)
            {
                var item = ownedItems[i];
                int sellPrice = (int)(item.price * 0.85); // 85%로 판매 가격 계산

                Console.WriteLine($"{i + 1}. {item.itemName} | 가격: {sellPrice} G");
            }

            Console.WriteLine("\n0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요. ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int selectedItemIndex) && selectedItemIndex >= 1 && selectedItemIndex <= ownedItems.Count)
            {
                var selectedItem = ownedItems[selectedItemIndex - 1];

                // 아이템이 장착 중이라면 해제
                if (selectedItem == _player.EquippedWeapon)
                {
                    _player.EquippedWeapon = null;
                    Console.WriteLine($"{selectedItem.itemName}을(를) 해제했습니다. (무기)");
                }
                else if (selectedItem == _player.EquippedArmor)
                {
                    _player.EquippedArmor = null;
                    Console.WriteLine($"{selectedItem.itemName}을(를) 해제했습니다. (방어구)");
                }

                // 아이템 판매 처리
                inventory.RemoveItem(selectedItem); // 아이템을 인벤토리에서 제거
                int sellPrice = (int)(selectedItem.price * 0.85); // 85% 가격
                _player.gold += sellPrice; // 골드 증가

                Console.WriteLine($"{selectedItem.itemName}을(를) {sellPrice} G에 판매했습니다!");
                Console.WriteLine($"현재 보유 골드: {_player.gold} G");
            }
            else if (selectedItemIndex != 0)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            Console.ReadKey();
        }

        public Item TossItem()
        {
            // 선택된 아이템을 반환하고 선택을 초기화
            Item tmp = selectedItem;
            selectedItem = null;  // 선택된 아이템 초기화
            return tmp;  // 아이템 반환
        }
    }

}
