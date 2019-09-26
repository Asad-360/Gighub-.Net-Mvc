using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Core.Repositories
{
    public interface INotificationRepository
    {
        /// <summary>
        /// Method to get new notification
        /// </summary>
        /// <param name="userId">id of authenticated user</param>
        /// <returns>list of notification</returns>
        IEnumerable<Notification> GetNewNotification(string userId);
        /// <summary>
        /// Method to get new notification
        /// </summary>
        /// <param name="userId">id of authenticated user</param>
        /// <returns>list of notification</returns>
        IEnumerable<UserNotification> MarkAsRead(string userId);
    }
}
