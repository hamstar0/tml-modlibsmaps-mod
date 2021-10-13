using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using ModLibsMaps.Services.Maps;


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


		////////////////

		public override void MidUpdateTimeWorld() {
			var config = ModLibsConfig.Instance;

			if( config.DebugModeInfo ) {
				IEnumerable<string> labels = MapMarkersManager.GetFullScreenMapMarkerLabels()
					.OrderBy( l=>l );

				int count = 0;
				foreach( string label in labels ) {
					if( !MapMarkersManager.TryGetFullScreenMapMarker(label, out (int x, int y, MapMarker m) marker) ) {
						continue;
					}

					DebugLibraries.Print( "MapMarker_"+label, "x: "+marker.x+", y: "+marker.y );

					count++;
					if( count++ > config.DebugModeInfoQuantity ) {
						break;
					}
				}
			}
		}
	}
}
