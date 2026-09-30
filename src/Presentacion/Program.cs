using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
                MessageBox.Show(e.Exception is ArgumentException ? e.Exception.Message
                    : "No se pudo completar la operación. Revise la conexión, los campos y la disponibilidad del registro.",
                    "Operación pendiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Run(new FrmLogin());
        }
    }
}
