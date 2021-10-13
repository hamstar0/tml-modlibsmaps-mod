using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;
using ModLibsGeneral.Libraries.HUD;
using ModLibsMaps.Services.Maps;


namespace ModLibsMaps {
	/// @private
	partial class ModLibsMapsMod : Mod {


		////////////////

		public override void PostDrawFullscreenMap( ref string mouseText ) {
			(int x, int y, MapMarker marker) info;

			foreach( string label in MapMarkersAPI.GetFullScreenMapMarkerLabels() ) {
				if( MapMarkersAPI.TryGetFullScreenMapMarker( label, out info ) ) {
					this.DrawFullScreenMapMarker( info.x, info.y, info.marker );
				}
			}
		}


		////

		private void DrawFullScreenMapMarker( int tileX, int tileY, MapMarker marker ) {
			Texture2D tex = marker.Icon;
			Vector2 origin = new Vector2( tex.Width / 2, tex.Height / 2 );

			var wldPos = new Vector2( tileX * 16, tileY * 16 );
			wldPos.X += 8f;
			wldPos.Y += 8f;
			var mapPos = HUDMapLibraries.GetFullMapPositionAsScreenPosition( wldPos );
			if( !mapPos.IsOnScreen ) {
				return;
			}

			Main.spriteBatch.Draw(
				texture: tex,
				position: mapPos.ScreenPosition,
				sourceRectangle: null,
				color: Color.White,
				rotation: 0f,
				origin: origin,
				scale: marker.Scale,
				effects: SpriteEffects.None,
				layerDepth: 1f
			);
		}
	}
}
