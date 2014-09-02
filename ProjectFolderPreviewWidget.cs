//
// ProjectFolderPreviewWidget.cs
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

namespace NewProjectDialogTest
{
	[System.ComponentModel.ToolboxItem (true)]
	public partial class ProjectFolderPreviewWidget : Gtk.Bin
	{
		TreeStore folderTreeStore;

		public ProjectFolderPreviewWidget ()
		{
			this.Build ();
			folderTreeView.ModifyBase (Gtk.StateType.Normal, new Gdk.Color (229, 233, 239));

			LoadFolderTreeView ();
		}

		void LoadFolderTreeView ()
		{
			folderTreeStore = new TreeStore (typeof(Pixbuf), typeof(string));
			folderTreeView.Model = folderTreeStore;
			folderTreeView.ShowExpanders = false;
			folderTreeView.LevelIndentation = 10;
			folderTreeView.CanFocus = false;

			var column = new TreeViewColumn ();
			var iconRenderer = new CellRendererPixbuf ();
			column.PackStart (iconRenderer, false);
			column.AddAttribute (iconRenderer, "pixbuf", column: 0);

			var textRenderer = new CellRendererText ();
			column.PackStart (textRenderer, true);
			column.AddAttribute (textRenderer, "markup", column: 1);

			folderTreeView.AppendColumn (column);

			var folderImage = new Gdk.Pixbuf (typeof(ProjectFolderPreviewWidget).Assembly, "md-generic-folder");
			var fileImage = new Gdk.Pixbuf (typeof(ProjectFolderPreviewWidget).Assembly, "md-generic-file");

			TreeIter iter = folderTreeStore.AppendValues (folderImage, "~/Projects");
			iter = folderTreeStore.AppendValues (iter, folderImage, "Solution");
			folderTreeStore.AppendValues (iter, fileImage, "Solution.sln");
			iter = folderTreeStore.AppendValues (iter, folderImage, "Project");
			folderTreeStore.AppendValues (iter, fileImage, "Project.csproj");

			folderTreeView.ExpandAll ();
		}
	}
}

