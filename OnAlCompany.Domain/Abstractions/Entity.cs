namespace OnalCompany.Domain.Abstractions
{
    public abstract class Entity<TId> where TId : struct
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        protected Entity()
        {
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
        }
    }

    public abstract class Entity : Entity<Guid>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}