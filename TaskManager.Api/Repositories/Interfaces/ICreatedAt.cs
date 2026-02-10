namespace TaskManager.Api.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para modelos de Entity Framework.
    /// Al create un objeto con esta interfaz, la propiedad CreatedAt
    /// se definirá automaticamente al llamar Add() dentro de un repositorio
    /// Centraliza las llamadas a .CreatedAt= y nos protegue contra la necesidad
    /// de Shotgun Surgery en algun momento
    /// </summary>
    public interface ICreatedAt
    {
        /// <summary>
        /// Esta propiedad se autoconfigura al pasara este objecto a Add()
        /// Esta propiedad será sobrescrita si se intenta configurar
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
