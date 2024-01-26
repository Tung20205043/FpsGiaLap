using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSconsoleGame {
    public class Gun {
        public string name { get; protected set; } = "";
        public string[] gunType = {"AK47","AKM","K98","SungLuc","SungTruong"};
        public float damage { get; protected set; }
        public float bulletPerShoot { get; protected set; } // mỗi lần bắn 10 viên
        public float shootDelayTime { get; protected set; } // mỗi viên đạn cách nhau 0.1s
        public float bulletSpeed { get; protected set; } // v = 50m/s
        public float bulletPerGun { get; protected set; } // 1 băng đạn 10 viên
        public float bulletLoad { get; protected set; } 
        public void SetInformation(Gun gun) {
            name = gunType[GameHelper.GetRandomNumber(0, 5)];
            damage = GameHelper.GetRandomNumber(1, 5);
            bulletPerShoot = GameHelper.GetRandomNumber(2, 5);
            shootDelayTime = GameHelper.GetRandomNumber(1, 3);
            bulletSpeed = GameHelper.GetRandomNumber(50, 70);
            bulletPerGun = GameHelper.GetRandomNumber(1, 10);
            bulletLoad = GameHelper.GetRandomNumber(2, 5);
        }
        public void ShowInformation(Gun gun) {
            Console.Clear();
            Console.WriteLine("=============== Thong tin khau sung =================");
            Console.WriteLine($"Ten: {gun.name} ");
            Console.WriteLine($"Damage: {gun.damage} ");
            Console.WriteLine($"So luong dan 1 lan ban ra: {gun.bulletPerShoot} vien/1 lan ban ");
            Console.WriteLine($"Delaytime: {shootDelayTime} s");
            Console.WriteLine($"Toc do dan: {bulletSpeed} m/s");
            Console.WriteLine($"Bang dan: {bulletPerGun} vien dan");
            Console.WriteLine($"Toc do nap dan: {bulletLoad} s");
            Console.WriteLine("=====================================================");
            Console.WriteLine("1. Gan trang bi");
            Console.WriteLine("2. Quay lai");
        }
        void Equip() { }

    }
}
