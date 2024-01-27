using System;
using System.Runtime.InteropServices;

namespace FPSconsoleGame {
    internal class Program {
        public static Gun gun1 = new Gun();
        public static Gun gun2 = new Gun();
        public static Gun[] guns = new Gun[] { gun1, gun2 };

        public static Player player1 = new Player();
        public static Player player2 = new Player();

        public static Player[] players = new Player[] { player1, player2 };

        static float range = 100f;
        static void Main(string[] args) {
            while (true) {
                int key = PrintGameUI();
                if (key == 5)
                    break;

                switch (key) {
                    case 1:
                        for (int i = 0; i < guns.Length; i++) {
                           CreateGun(guns[i]);
                        }
                        break;
                    case 2:
                        ShowGun();
                        break;
                    case 3:
                        //for (int i = 0; i < guns.Length; i++) {
                        //    for (int j = players.Length - 1; j >= 0; j--) {
                        //        Attack(guns[i],players[j]); 
                        //    }
                        //}
                        Attack(gun1, player2);
                        break;
                    case 4:
                        // Xử lý khi chọn 4
                        break;
                }
            }

            Console.ReadKey();
        }

        public static void CreateGun(Gun gun) {
            gun.SetInformation(gun);
            Console.WriteLine("Tao sung thanh cong, nhan phim bat ky tiep tuc...");
            Console.ReadLine(); // Chờ người dùng nhấn phím
        }

        public static void ShowGun(){
            Console.Clear();
            Console.WriteLine("==================== Thong tin sung =============================");
            Console.WriteLine("1. Thong tin sung 1");
            Console.WriteLine("2. Thong tin sung 2");
            Console.WriteLine("3. Quay lai main menu");
            int choice;
            do {
                Console.Write("Nhap lua chon: ");
            } while (!int.TryParse(Console.ReadLine(), out choice) );

            if (choice == 1) {
                guns[0].ShowInformation(guns[0]);
            } else if (choice == 2) {
                guns[1].ShowInformation(guns[1]);
            } else if (choice == 3) {
                PrintGameUI();
            }

            Console.ReadLine();
        }

        public static int PrintGameUI() {
            int key;
            do {
                Console.Clear();
                Console.WriteLine("==================== Gia lap game FPS =============================");
                Console.WriteLine("1. Tao sung");
                Console.WriteLine("2. Hien thi sung ");
                Console.WriteLine("3. Bat dau game");
                Console.WriteLine("4. Thoat chuong trinh");
                Console.Write("--- Nhap lua chon: ");
            } while (!int.TryParse(Console.ReadLine(), out key) );

            return key;
        }
        public static void Attack(Gun gun, Player player) {
            Console.Clear();
            float firstTimeTakeDmg = gun.delayShoot + range / gun.bulletSpeed;
            double[] timeTakeDmg = GenerateTimeArray(gun, (int)range, firstTimeTakeDmg);

            // In kết quả
            Console.WriteLine($"firstTimeTakeDmg:{firstTimeTakeDmg}");
            Console.WriteLine("Time Take Damage Array:");
            for (int i = 0; i < timeTakeDmg.Length; i++) {
                double time = timeTakeDmg[i];
                Console.WriteLine($"Sau {time:F2} giay, nguoi choi 2 nhan {gun.damage} damage");
            }
            Console.ReadLine();
        }
        static double[] GenerateTimeArray(Gun gun, int range, double firstTimeTakeDmg) {
            List<double> timeTakeDmg = new List<double>();

            for (int i = 0; i < (int)gun.bulletPerShoot; i++) {
                double time = firstTimeTakeDmg + i * (1.0 / gun.bulletSpeed + gun.shootDelayTime);
                timeTakeDmg.Add(time);
            }

            return timeTakeDmg.ToArray();
        }
        
    }
}
