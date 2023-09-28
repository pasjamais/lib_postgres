namespace lib_postgres.DEPLOY
{
    public class File_Level_Operations
    {

        /// <summary>
        ///return full directory name after creation
        /// </summary>
        public static string Create_Directory(string directory_name)
        {
            return Directory.CreateDirectory(directory_name).ToString();
        }

        public static string Ensure_Directory_Exists_by_Creation(string directory_name)
        {
            string path = "";
            if (!is_Directory_Exist(directory_name))
                path = Create_Directory(directory_name);
            // else path = output_directory_path; //?
            return path;
        }
        public static bool is_Directory_Exist(string directory_name)
        {
            if (Directory.Exists(directory_name))
                return true;
            else
                return false;
        }
    }
}
