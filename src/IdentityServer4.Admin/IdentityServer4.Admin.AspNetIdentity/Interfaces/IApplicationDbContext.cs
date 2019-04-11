using System;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.AspNetIdentity.Interfaces
{
    /// <summary>
    /// Abstraction for the configuration context.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IApplicationDbContext : IDisposable
    {
        

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();
    }
}
