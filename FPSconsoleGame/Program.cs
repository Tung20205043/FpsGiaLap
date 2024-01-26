using System;

namespace FPSconsoleGame {
    internal class Program {
        public static Gun gun1 = new Gun();
        public static Gun gun2 = new Gun();

        static void Main(string[] args) {
            while (true) {
                int key = PrintGameUI();
                if (key == 5)
                    break;

                switch (key) {
                    case 1:
                        CreateGun();
                        break;
                    case 2:
                        ShowGun();
                        break;
                    case 3:
                        // Xử lý khi chọn 3
                        break;
                    case 4:
                        // Xử lý khi chọn 4
                        break;
                }
            }

            Console.ReadKey();
        }

        public static void CreateGun() {
            gun1.SetInformation(gun1);
            gun2.SetInformation(gun2);
            Console.WriteLine("Tao sung thanh cong, nhan phim bat ky de quay lai...");
            Console.ReadLine(); // Chờ người dùng nhấn phím
        }

        public static void ShowGun(){
            gun1.ShowInformation(gun1);
            gun2.ShowInformation(gun2);
            Console.ReadLine(); // Chờ người dùng nhấn phím
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
            } while (!int.TryParse(Console.ReadLine(), out key) || key < 1 || key > 5);

            return key;
        }
    }
}
