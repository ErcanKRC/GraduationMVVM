namespace GraduationMVVM.Abstract
{
    public static class Constant
    {

        private const string DBFileName = "GraduationMVVM1.db3";
        public static string DBpath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
