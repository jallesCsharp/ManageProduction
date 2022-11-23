using Manage.Core.Interfaces.IBase;

namespace Manage.Core.Models.Base
{
    public class BaseModel : IBaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }

        public BaseModel(DateTime createdAt, bool active) : this()
        {
            CreatedAt = createdAt;
            Active = active;
        }

        public BaseModel(Guid id, DateTime createdAt, bool active)
        {
            Id = id;
            CreatedAt = createdAt;
            Active = active;
        }

        public Guid Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Active { get; set; }
    }
}
