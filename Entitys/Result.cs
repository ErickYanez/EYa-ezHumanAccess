namespace Entitys
{
    public class Result
    {
        public bool Correct { get; set; }
        public string Message { get; set; }
        public Exception Ex{ get; set; }
        public List<Object> Objects { get; set; }
        public Object Object { get; set; }
        public string Cantidad { get; set; }
    }
}