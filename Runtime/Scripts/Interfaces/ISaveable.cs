namespace Juanda.SaveSystem
{
    public interface Isaveable
    {
        public string GetModuleID();
        public object GetModuleData();
        public void SetModuleValues(string values);
    }
}