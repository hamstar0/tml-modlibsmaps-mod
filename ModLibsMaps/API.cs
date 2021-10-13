using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using ModLibsCore.Libraries.Debug;


namespace ModLibsMaps.Services.Maps {
	/// <summary>
	/// Provides functions for adding markers to the map.
	/// </summary>
	public partial class MapMarkersAPI {
		/// <summary>Adds or updates a given map marker by id.</summary>
		/// <param name="id">Must be unique.</param>
		/// <param name="tileX"></param>
		/// <param name="tileY"></param>
		/// <param name="icon"></param>
		/// <param name="scale"></param>
		public static void SetFullScreenMapMarker( string id, int tileX, int tileY, Texture2D icon, float scale ) {
			MapMarkersManager.SetFullScreenMapMarker( id, tileX, tileY, icon, scale );
		}


		/// <summary></summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static bool RemoveFullScreenMapMarker( string id ) {
			return MapMarkersManager.RemoveFullScreenMapMarker( id );
		}


		////////////////

		/// <summary></summary>
		/// <returns></returns>
		public static IList<string> GetFullScreenMapMarkerLabels() {
			return MapMarkersManager.GetFullScreenMapMarkerLabels();
		}


		/// <summary></summary>
		/// <param name="id"></param>
		/// <param name="markerAt"></param>
		/// <returns></returns>
		public static bool TryGetFullScreenMapMarker( string id, out (int tileX, int tileY, MapMarker marker) markerAt ) {
			return MapMarkersManager.TryGetFullScreenMapMarker( id, out markerAt );
		}


		/// <summary></summary>
		/// <param name="tileX"></param>
		/// <param name="tileY"></param>
		/// <returns></returns>
		public static IDictionary<string, MapMarker> GetFullScreenMapMakersAt( int tileX, int tileY ) {
			return MapMarkersManager.GetFullScreenMapMakersAt( tileX, tileY );
		}
	}
}
