using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame {
    static class Controllers {
        public static TowerController towerController;

        public static void Setup(TowerController tower) {
            towerController = tower;
        }

    }
}
