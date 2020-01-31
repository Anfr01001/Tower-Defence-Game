﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenceGame
{
	class BasicTower : TowerBase
	{
		
		public BasicTower(Map map) : base(map)
		{
            rectangle = new Rectangle(pos.ToPoint(), new Point(50,50));
		}

	}
}
