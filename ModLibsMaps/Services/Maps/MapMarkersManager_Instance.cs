using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Terraria;
using ModLibsCore.Classes.Loadable;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Services.Hooks.LoadHooks;


namespace ModLibsMaps.Services.Maps {
	/// <summary>
	/// Provides functions for adding markers to the map.
	/// </summary>
	partial class MapMarkersManager : ILoadable {
		private IDictionary<int, IDictionary<int, IDictionary<string, MapMarker>>> Markers
			= new ConcurrentDictionary<int, IDictionary<int, IDictionary<string, MapMarker>>>();

		private IDictionary<string, (int, int, MapMarker)> MarkersPerLabel
			= new ConcurrentDictionary<string, (int, int, MapMarker)>();



		////////////////

		void ILoadable.OnModsLoad() { }

		void ILoadable.OnModsUnload() { }

		void ILoadable.OnPostModsLoad() {
			LoadHooks.AddWorldUnloadEachHook( () => {
				this.Markers.Clear();
				this.MarkersPerLabel.Clear();
			} );
		}
	}
}
