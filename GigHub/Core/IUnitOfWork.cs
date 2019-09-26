using GigHub.Core.Repositories;

namespace GigHub.Core
{
    public interface IUnitOfWork
    {
        IAttendenceRepository Attendence { get; }
        IFollowingRepository Following { get; }
        IGenreRepository Genre { get; }
        IGigRepository Gigs { get; }
        INotificationRepository Notification { get; }
        IArtistRepository Artist { get; }
        ICompositionRepository Composition { get; }
        /// <summary>
        /// Method to commit 
        /// </summary>
        void Complete();
    }
}