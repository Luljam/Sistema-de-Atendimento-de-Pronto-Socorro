using System.Runtime.Serialization;

namespace AtendimentoProntoSocorro.Repositories
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}