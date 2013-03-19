using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LevelUp.ProcessPro
{
	public class WinFXCursorFromBitmap : SafeHandle
	{

		public static System.Windows.Input.Cursor CreateCursor(System.Drawing.Bitmap cursorBitmap)
		{
			WinFXCursorFromBitmap csh = new WinFXCursorFromBitmap(cursorBitmap);
			return csh.CreateCursor();
		}

		protected WinFXCursorFromBitmap(System.Drawing.Bitmap cursorBitmap)
			: base((IntPtr)(-1), true)
		{
			handle = cursorBitmap.GetHicon();
		}

		public override bool IsInvalid
		{
			get
			{
				return handle == (IntPtr)(-1);
			}
		}

		protected override bool ReleaseHandle()
		{
			bool result = DestroyIcon(handle);
			handle = (IntPtr)(-1);
			return result;
		}

		protected System.Windows.Input.Cursor CreateCursor()
		{
			return System.Windows.Interop.CursorInteropHelper.Create(this);
		}

		/// <summary>
		/// Imported from user32.dll. Destroys an icon GDI object.
		/// </summary>
		/// <param name="hIcon"></param>
		/// <returns></returns>
		[System.Runtime.InteropServices.DllImport("user32")]
		private static extern bool DestroyIcon(IntPtr hIcon);

	}
}
