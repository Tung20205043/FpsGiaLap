using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPSconsoleGame {
    public static class GameHelper {
        public static int GetRandomNumber(int min, int max) {
            Random r = new Random();
            return r.Next(min, max);
        }
    }
}
