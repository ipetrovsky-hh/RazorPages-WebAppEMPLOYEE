namespace WebAppEMPLOYEE.Models
{
    public class ResultActionModelcs
    {
        public string Result { get; set; }

        public string Message { get; set; }

        public ResultActionModelcs(string result, string message)
        {
            this.Result = result;
            this.Message = message; 
        }
    }
}