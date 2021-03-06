using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Classes.Loadable;
using ModLibsCore.Libraries.Debug;
using ModLibsCore.Libraries.DotNET.Extensions;


namespace ModLibsMaps.Services.Maps {
	/// <summary>
	/// Provides functions for adding markers to the map.
	/// </summary>
	partial class MapMarkersManager : ILoadable {
		/// <summary>Adds or updates a given map marker by id.</summary>
		/// <param name="id">Must be unique.</param>
		/// <param name="tileX"></param>
		/// <param name="tileY"></param>
		/// <param name="icon"></param>
		/// <param name="scale"></param>
		public static void SetFullScreenMapMarker( string id, int tileX, int tileY, Texture2D icon, float scale ) {
			var markers = ModContent.GetInstance<MapMarkersManager>();
			var marker = new MapMarker( id, icon, scale );
			
			if( markers.MarkersPerLabel.ContainsKey(id) ) {
				MapMarkersManager.RemoveFullScreenMapMarker( id );
			}

			if( !markers.Markers.ContainsKey(tileX) ) {
				markers.Markers[ tileX ] = new Dictionary<int, IDictionary<string, MapMarker>>();
			}
			if( !markers.Markers[tileX].ContainsKey(tileY) ) {
				markers.Markers[ tileX ][ tileY ] = new Dictionary<string, MapMarker>();
			}

			markers.Markers[ tileX ][ tileY ][ id ] = marker;
			markers.MarkersPerLabel[ id ] = ( tileX, tileY, marker );
		}


		/// <summary></summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static bool RemoveFullScreenMapMarker( string id ) {
			var markers = ModContent.GetInstance<MapMarkersManager>();

			(int x, int y, MapMarker marker) marker;
			if( !markers.MarkersPerLabel.TryGetValue( id, out marker ) ) {
				return false;
			}

			IDictionary<string, MapMarker> markersByIds = markers.Markers.Get2DOrDefault( marker.x, marker.y );
			
			bool hadMarkerPerLabel = markers.MarkersPerLabel.Remove( id );
			bool hadMarkerById = markersByIds?.Remove(id) ?? false;
			return hadMarkerPerLabel && hadMarkerById;
		}


		////////////////

		/// <summary></summary>
		/// <returns></returns>
		public static IList<string> GetFullScreenMapMarkerLabels() {
			var markers = ModContent.GetInstance<MapMarkersManager>();
			return markers.MarkersPerLabel.Keys.ToList();
		}


		/// <summary></summary>
		/// <param name="id"></param>
		/// <param name="markerAt"></param>
		/// <returns></returns>
		public static bool TryGetFullScreenMapMarker( string id, out (int tileX, int tileY, MapMarker marker) markerAt ) {
			var markers = ModContent.GetInstance<MapMarkersManager>();

			return markers.MarkersPerLabel.TryGetValue( id, out markerAt );
		}


		/// <summary></summary>
		/// <param name="tileX"></param>
		/// <param name="tileY"></param>
		/// <returns></returns>
		public static IDictionary<string, MapMarker> GetFullScreenMapMakersAt( int tileX, int tileY ) {
			var markers = ModContent.GetInstance<MapMarkersManager>();
			var markersAt = markers.Markers.Get2DOrDefault( tileX, tileY );
			if( markersAt == null ) {
				return null;
			}

			return new Dictionary<string, MapMarker>( markersAt );
		}
	}
}
