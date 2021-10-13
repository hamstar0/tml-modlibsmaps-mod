using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using ModLibsCore.Libraries.Debug;


namespace ModLibsMaps {
	public class ModLibsConfig : ModConfig {
		public static ModLibsConfig Instance => ModContent.GetInstance<ModLibsConfig>();



		////////////////

		public override ConfigScope Mode => ConfigScope.ServerSide;



		////////////////

		public bool DebugModeInfo { get; set; } = false;

		////

		public int DebugModeInfoQuantity { get; set; } = 10;
	}
}
