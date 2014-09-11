﻿//
// TemplateCellRendererText.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using Gdk;
using Gtk;
using System;
using MonoDevelop.Components;

namespace NewProjectDialogTest
{
	public class TemplateCellRendererText : CellRendererText
	{
		public static Color LanguageButtonBackgroundColor = new Color (247, 247, 247);

		Color triangleColor = new Color (0, 0, 0);
		const int languageTextPadding = 10;
		Rectangle languageRect;

		public SolutionTemplate Template { get; set; }

		public bool IsLanguageButtonPressed (EventButton button)
		{
			return languageRect.Contains ((int)button.X, (int)button.Y);
		}

		public Rectangle GetLanguageRect ()
		{
			return languageRect;
		}

		protected override void Render (Drawable window, Widget widget, Rectangle background_area, Rectangle cell_area, Rectangle expose_area, CellRendererState flags)
		{
			base.Render (window, widget, background_area, cell_area, expose_area, flags);

			if (Template == null) {
				return;
			}

			StateType stateType = GetState (widget, flags);

			if (stateType == StateType.Selected) {

				using (var ctx = CairoHelper.Create (window)) {
					using (var layout = new Pango.Layout (widget.PangoContext)) {
						layout.SetMarkup ("C#");

						int textHeight = 0;
						int textWidth = 0;
						layout.GetPixelSize (out textHeight, out textWidth);

						languageRect = GetLanguageButtonRectangle (window, widget, cell_area, textHeight, textWidth);

						//RoundBorder (ctx, alloc.X + 0.5, alloc.Y + 0.5, alloc.Width - 1, alloc.Height - 1);
						SetSourceColor (ctx, LanguageButtonBackgroundColor.ToCairoColor ());
						ctx.Rectangle (languageRect.X, languageRect.Y, languageRect.Width, languageRect.Height);
						ctx.Fill ();

						int triangleX = languageRect.X + textWidth;
						int triangleY = languageRect.Y + 10;
						DrawTriangle (ctx, triangleX, triangleY);

						layout.FontDescription = widget.PangoContext.FontDescription.Copy ();
						int languageY = languageRect.Y + (languageRect.Height - textHeight) / 2;
						window.DrawLayout (widget.Style.TextGC (StateType.Normal), languageRect.X, languageY, layout);
					}
				}
			}
		}

		static StateType GetState (Widget widget, CellRendererState flags)
		{
			StateType stateType = StateType.Normal;
			if ((flags & CellRendererState.Prelit) != 0)
				stateType = StateType.Prelight;
			if ((flags & CellRendererState.Focused) != 0)
				stateType = StateType.Normal;
			if ((flags & CellRendererState.Insensitive) != 0)
				stateType = StateType.Insensitive;
			if ((flags & CellRendererState.Selected) != 0)
				stateType = widget.HasFocus ? StateType.Selected : StateType.Active;
			return stateType;
		}

		static Rectangle GetLanguageButtonRectangle (Drawable window, Widget widget, Rectangle cell_area, int textHeight, int textWidth)
		{
			int rightHandEdgePadding = 1;
			int languageRectangleHeight = cell_area.Height - 4;
			int languageRectangleWidth = textWidth + 2 * languageTextPadding;

			var dy = (cell_area.Height - languageRectangleHeight) / 2 - 1;
			var y = cell_area.Y + dy;
			var x = widget.Allocation.Width - languageRectangleWidth - rightHandEdgePadding;

			return new Rectangle (x, y, languageRectangleWidth, languageRectangleHeight);
		}

		void DrawTriangle (Cairo.Context ctx, int x, int y)
		{
			int width = 8;
			int height = 6;
			SetSourceColor (ctx, triangleColor.ToCairoColor ());
			ctx.MoveTo (x, y);
			ctx.LineTo (x + width, y);
			ctx.LineTo (x + (width / 2), y + height);
			ctx.LineTo (x, y);
			ctx.Fill ();
		}

		// Taken from MonoDevelop.Components.SearchEntry.
		static void RoundBorder (Cairo.Context ctx, double x, double y, double w, double h)
		{
			double r = h / 2;
			ctx.Arc (x + r, y + r, r, Math.PI / 2, Math.PI + Math.PI / 2);
			ctx.LineTo (x + w - r, y);

			ctx.Arc (x + w - r, y + r, r, Math.PI + Math.PI / 2, Math.PI + Math.PI + Math.PI / 2);

			ctx.LineTo (x + r, y + h);

			ctx.ClosePath ();
		}

		// Taken from Mono.TextEditor.HelperMethods.
		public static void SetSourceColor (Cairo.Context cr, Cairo.Color color)
		{
			cr.SetSourceRGBA (color.R, color.G, color.B, color.A);
		}
	}
}

