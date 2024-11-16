namespace ApiJogo.Modal
{
    public class TotalTimeRegistro
    {
        public int id { get; set; }
         public string? nome { get; set; }
         public double total_time { get; set; }
         public DateTime data_cadastro { get; set; } = DateTime.Now;
    }
}
