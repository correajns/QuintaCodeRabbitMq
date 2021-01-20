using System;
using System.Text.Json;

namespace Dominio
{
    public class Mensagem
    {
        public int ID { get; set; }
        public int JobNum { get; set; }
        public int MaxJobs { get; set; }
        public string MensagemInOut { get; set; }
    }

    public static class MensagemExtension
    {
        public static string ToJson(this Mensagem mensagem)
        {
            return JsonSerializer.Serialize(mensagem);
        }

        public static Mensagem FromJson(this string mensagem)
        {
            return JsonSerializer.Deserialize<Mensagem>(mensagem);
        }
    }
}
