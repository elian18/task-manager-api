namespace TaskManager.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para modelos de Entity Framework.
    /// Al create un objeto con esta interfaz, la propiedad Id
    /// se definirá como la Pk(comportamiento por defecto en EF)
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Primary key de esta entidad
        /// </summary>
        public Guid Id { get; set; }
    }
}
