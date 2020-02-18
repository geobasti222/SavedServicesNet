using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Data;
using System.Web.Security;

namespace Application.Enterprise.CommonObjects
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utilidades
	{
		#region Constants

		internal const int			DRIVE_UNKNOWN		= 0;
		internal const int			DRIVE_NO_ROOT_DIR	= 1;
		internal const int			DRIVE_REMOVABLE		= 2;
		internal const int			DRIVE_FIXED			= 3;
		internal const int			DRIVE_REMOTE		= 4;
		internal const int			DRIVE_CDROM			= 5;
		internal const int			DRIVE_RAMDISK		= 6;

		#endregion Constants

		#region Public Static Methods
	
		#region DarkenColor

		/// <summary>
		/// Darkens the specified color by the specified amount.
		/// </summary>
		/// <param name="color">The color to darken.</param>
		/// <param name="amount">The amount by which to darken the color.</param>
		/// <returns></returns>
		internal static Color DarkenColor(Color color, int amount)
		{
			return Color.FromArgb(color.A,
				Math.Max(color.R - amount, 0),
				Math.Max(color.G - amount, 0),
				Math.Max(color.B - amount, 0));
		}

		#endregion DarkenColor
	
		#region FileSizeFromFileInfo

		/// <summary>
		/// Returns a string representation of the size of the file represented by the specified file info.
		/// </summary>
		internal static string FileSizeFromFileInfo(FileInfo fileInfo)
		{
			decimal fileSize = 0;
			if (fileInfo.Length > 0)
			{
				fileSize = Convert.ToDecimal(fileInfo.Length / 1000.0);
				fileSize = Math.Round(fileSize);
				fileSize = Math.Max(1, fileSize);
			}

			int fileSizeInt = Convert.ToInt32(fileSize);

			return fileSizeInt.ToString("###,###,##0") + " KB";	
		}

		#endregion FileSizeFromFileInfo

		#region RemovePath

		/// <summary>
		/// Removes the path from a fully qualified name and returns the last element of the path.
		/// </summary>
		/// <param name="fullyQualifedName"></param>
		/// <returns></returns>
		public static string RemovePath(string fullyQualifedName)
		{
			// Return everything after the last slash.
			int	lastSlashIndex	= fullyQualifedName.LastIndexOf("\\");

			if (lastSlashIndex == -1)
				return fullyQualifedName;
			else
				return fullyQualifedName.Substring(lastSlashIndex + 1);
		}

		/// <summary>
		/// Removes the path from a fully qualified name and returns the last element of the path.
		/// </summary>
		/// <param name="fullyQualifedName"></param>
		/// <returns></returns>
		public static string RemovePath(string fullyQualifedName,string separator)
		{
			// Return everything after the last slash.
			int	lastSlashIndex	= fullyQualifedName.LastIndexOf(separator);

			if (lastSlashIndex == -1)
				return fullyQualifedName;
			else
				return fullyQualifedName.Substring(lastSlashIndex + 1);
		}

		#endregion RemovePath

		#region RemovePathEx

		/// <summary>
		/// Removes the path from a fully qualified name and returns the last element of the path.
		/// If the path represents the root folder of a drive, returns the formatted string 'Local Disk (X:)'
		/// where 'X' is the drive letter.
		/// </summary>
		/// <param name="fullyQualifedName"></param>
		/// <returns></returns>
		public static string RemovePathEx(string fullyQualifedName)
		{
			if (fullyQualifedName.Length			== 3	&&
				fullyQualifedName.Substring(1, 1)	== ":"	&&
				fullyQualifedName.Substring(2, 1)	== "\\")
				return "Local Disk (" + fullyQualifedName.Substring(0, 2) + ")";

			return Utilidades.RemovePath(fullyQualifedName);
		}

		#endregion RemovePathEx

        #region GetTablePosition
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colummnName"></param>
        /// <param name="Columnvalue"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static int GetTablePosition(string colummnName, string Columnvalue, DataTable table)
        {
            int pos = -1;
            try
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i][colummnName].ToString() == Columnvalue)
                        pos = i;
                }
            }
            catch { }
            return pos;
        }
        #endregion

        /// <summary>
        /// Método para Validar la Clave Inicial
        /// </summary>
        /// <param name="dbPasswordHash">Hash del Password actual</param>
        /// <param name="clave">Clave Inicial</param>
        /// <param name="salt">Salt</param>
        /// <returns>Verdadero si la clave del Usuario es la inicial, Falso de lo contrario</returns>
        public static bool VerificarClave(string dbPasswordHash, string clave, string salt)
        {
            bool estado = true;

            try
            {
                //Obtener el Hash de la clave para la autenticación
                string passwordAndSalt = String.Concat(clave, salt);
                string hashedPasswordAndSalt = FormsAuthentication.HashPasswordForStoringInConfigFile(passwordAndSalt, "SHA1");
                estado = hashedPasswordAndSalt.Equals(dbPasswordHash);
            }
            catch { }

            return estado;
        }

    
        #endregion Public Static Methods

        #region Windows APIs

        #region GetDriveType

        internal static int GetDriveTypeApi(string path)
		{
			IntPtr lpString = Marshal.StringToCoTaskMemAnsi(path);

			int driveType = GetDriveType(lpString);

			Marshal.FreeCoTaskMem(lpString);

			return driveType;
		}

		[DllImport("kernel32")]
		private static extern int GetDriveType(IntPtr lpString);

		#endregion GetDriveType

		#endregion Windows APIs
	}
}
