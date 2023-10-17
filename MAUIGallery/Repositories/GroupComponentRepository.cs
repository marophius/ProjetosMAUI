using MAUIGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGallery.Repositories
{
    public partial class GroupComponentRepository : IGroupComponentRepository
    {
        private List<Component> _components;
        private List<GroupComponent> _groupComponents;

        public GroupComponentRepository()
        {
            LoadData();
        }

        public List<Component> GetComponents()
        {
            return _components;
        }

        public List<Component> GetComponents(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return _components;
            }
            return _components.Where(x => x.Title.ToLower().Contains(word)).ToList();
        }

        public List<GroupComponent> GetGroupComponents()
        {
            return _groupComponents;
        }
    }
}
