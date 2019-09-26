using GigHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigHub.Core.Repositories
{
    public interface ICompositionRepository
    {
        /// <summary>
        /// Method to add the new Compostion
        /// </summary>
        /// <param name="compostion">Compostion Object</param>
        void Add(Composition compostion);
        /// <summary>
        /// Method to get All the compostion
        /// </summary>
        /// <param name="userId">id of autheticated user</param>
        /// <returns>List of compostions</returns>
        List<Composition> GetAllComposition(string userId);
    }
}
