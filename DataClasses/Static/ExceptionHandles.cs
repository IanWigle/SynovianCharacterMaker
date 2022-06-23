using System;
using System.Windows.Forms;

namespace Synovian_Character_Maker.DataClasses.Static
{
    public static partial class ExceptionHandles
    {
        public static void ExceptionHandle(string message)
        {
#if DEBUG
            //Debug.Write(message);
            throw new Exception(message);
#else
            MessageBox.Show(message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
        }

        public static void ExceptionHandle(Exception e)
        {
#if DEBUG
            //Debug.Write(e.Message);
            //if (e.InnerException != null) Debug.Write(e.InnerException.Message);
            throw e;
#else
            MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
#endif
        }
    }
}
