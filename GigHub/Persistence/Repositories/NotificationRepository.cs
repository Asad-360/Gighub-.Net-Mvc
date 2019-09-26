using GigHub.Core.Models;
using GigHub.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace GigHub.Persistence.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;
        public NotificationRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Notification> GetNewNotification(string userId)
        {
            return _context.UserNotifications
                               .Where(un => un.UserId == userId && !un.IsRead)
                               .Select(un => un.Notification)
                               .Include(n => n.Gig.Artist)
                               .ToList();
        }

        public IEnumerable<UserNotification> MarkAsRead(string userId)
        {
            return _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();
        }
    }
}