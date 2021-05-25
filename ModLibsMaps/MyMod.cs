using System;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace ModLibsMaps {
	/// @private
	partial class ModLibsMapsMod : Mod {
		public static ModLibsMapsMod Instance { get; private set; }



		////////////////

		public override void Load() {
			ModLibsMapsMod.Instance = this;
		}

		////

		public override void Unload() {
			try {
				LogLibraries.Alert( "Unloading mod..." );
			} catch { }

			ModLibsMapsMod.Instance = null;
		}
	}
}
