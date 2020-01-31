using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
	class BuyBasictower : Button
	{
        TowerController towerController;
		public BuyBasictower(String text, Vector2 pos, int size, TowerController towerController) : base (text,pos,size)
		{
            this.towerController = towerController;
		}

		public override void OnClick()
		{
            towerController.BoughtTower(1);
		}
	}
}
