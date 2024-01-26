using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSconsoleGame {
    public interface IGun {
        string name { get; set; }
        float damage { get; set; }
        float bulletPerShoot { get; set; }
        float shootDelayTime { get; set; }
        float bulletSpeed { get; set; }
        float bulletPerGun { get; set; }
        float bulletLoad {get; set; }

        void ShowInformation() { }
        void Equip() { }

    }
}
