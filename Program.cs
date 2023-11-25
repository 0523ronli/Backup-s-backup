using UItestv2;

namespace Bachup_s_backup
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        public static class HotKeys
        {
            public static Hotkey Switch_Visable = new()
            {
                ID = 1,
                Key = (int)Keys.V
            };
            public static Hotkey Switch_DragMode = new ()
            {
                ID = 2,
                Key = (int)Keys.E
            };
        }
        public struct Hotkey
        {
            public int ID;
            public int Key;
        }
        private static void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Something not expected went wrong: \n " + e.Exception.Message, "O_o", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static Color DI_default = SystemColors.ActiveBorder;
        public static Color DI_selected = Color.LightBlue;
    }
}