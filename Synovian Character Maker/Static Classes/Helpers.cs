using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Synovian_Character_Maker.Static_Classes
{
    static public class Helpers
    {
        /// <summary>
        /// Tries to find a form of the provided name in the running program.
        /// </summary>
        /// <param name="name">The name of the form.</param>
        /// <param name="form">The out result of what was found or not found.</param>
        /// <returns>Returns true if a form of said name was found.</returns>
        public static bool TryGetForm(string name, out Form form)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form _form in fc)
            {
                if (_form.Name == name)
                {
                    form = _form;
                    return true;
                }
            }

            form = null;
            return false;
        }

        public static bool TryGetForm(Type type, out Form form)
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form _form in fc)
            {
                if(_form.GetType() == type)
                {
                    form = _form;
                    return true;
                }
            }

            form = null;
            return false;
        }

        public static T GetForm<T>() where T : Form
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form form in fc)
            {
                T casted_form = form as T;
                if (casted_form != null)
                    return casted_form;
            }
            return null;
        }

        public static void ExceptionHandle(string message)
        {
#if DEBUG
            Debug.Write(message);
            throw new Exception(message);
#else
            MessageBox.Show(message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
        }

        public static void ExceptionHandle(Exception e)
        {
#if DEBUG
            Debug.Write(e.Message);
            Debug.Write(e.InnerException.Message);
            throw e;
#else
            MessageBox.Show(e.Message,"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
        }
    }
}
