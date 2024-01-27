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
                        Attack(gun1, gun2);
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
        public static void Attack(Gun Gun1, Gun Gun2) {
            Console.Clear();
            float firstTimeTakeDmg2 = Gun1.delayShoot + range / Gun1.bulletSpeed;
            double[] timeTakeDmgP2 = GenerateTimeArray(Gun1, (int)range, firstTimeTakeDmg2);

            float totalDmgP2 = 0;
            float totalTimeP2 = 0;
            // In kết quả
            Console.WriteLine("Moc thoi gian nhan dmg:");
            for (int i = 0; i < timeTakeDmgP2.Length; i++) {
                double time = timeTakeDmgP2[i];
                totalDmgP2 += Gun1.damage;
                totalTimeP2 += (float)timeTakeDmgP2[i];
                Console.WriteLine($"Sau {time:F2} giay, nguoi choi 2 nhan {Gun1.damage} damage");
                
                if (totalDmgP2 >= 10) {
                    Console.WriteLine($"-------------------------");
                    Console.WriteLine($"Tong thoi gian de nguoi choi 1 ha nguoi choi 2: {totalTimeP2:F2} giay");
                    break;
                }
            }


            float firstTimeTakeDmgP1 = Gun2.delayShoot + range / Gun2.bulletSpeed;
            double[] timeTakeDmgP1 = GenerateTimeArray(Gun2, (int)range, firstTimeTakeDmgP1);

            float totalDmgP1 = 0;
            float totalTimeP1 = 0;

            Console.WriteLine($"------------------------------------------------------");
            Console.WriteLine("Moc thoi gian nhan dmg:");
            for (int i = 0; i < timeTakeDmgP1.Length; i++) {
                double time = timeTakeDmgP1[i];
                totalDmgP1 += Gun2.damage;
                totalTimeP1 += (float)timeTakeDmgP1[i];
                Console.WriteLine($"Sau {time:F2} giay, nguoi choi 1 nhan {Gun2.damage} damage");
                
                if (totalDmgP1 >= 10) {
                    Console.WriteLine($"-------------------------");
                    Console.WriteLine($"Tong thoi gian de nguoi choi 2 ha nguoi choi 1: {totalTimeP1:F2} giay");
                    break;
                }
            }
            Console.WriteLine($"-------------------------");
            string result = (totalTimeP1 > totalTimeP2) ? "Nguoi choi 1 thang!" :
                        (totalTimeP1 < totalTimeP2) ? "Nguoi choi 2 thang!" :
                        "Hai nguoi choi hoa";
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static double[] GenerateTimeArray(Gun gun, int range, double firstTimeTakeDmg) {
            List<double> timeTakeDmg = new List<double>();

            for (int i = 0; i < (int)gun.bulletPerShoot; i++) {
                double time = firstTimeTakeDmg + i * (range / gun.bulletSpeed + gun.shootDelayTime);
                timeTakeDmg.Add(time);
            }

            return timeTakeDmg.ToArray();
        }
        
    }
}
