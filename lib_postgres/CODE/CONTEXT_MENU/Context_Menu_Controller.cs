namespace lib_postgres
{
    public class Context_Menu_Controller
    {
        private static Type? current_Working_Type;
        private static Type? previous_Working_Type;
        public static ToolStripItem[] Change_Working_Type<T>()
        {
            previous_Working_Type = current_Working_Type;
            Type type = typeof(T);
            current_Working_Type = type;
            string methodName = "ContexctMenu_Prepare";
            if (type.GetMethod(methodName) != null)
                return (ToolStripItem[]) type.GetMethod(methodName).Invoke(null, null);
            else
            {
                return new ToolStripItem[0];
            }
        }
    }
}
