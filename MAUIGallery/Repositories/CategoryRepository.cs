using MAUIGallery.Models;
using MAUIGallery.Views.Components.Mains;
using MAUIGallery.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGallery.Repositories
{
    public class CategoryRepository
    {
        public CategoryRepository()
        {
            
        }

        public List<Category> GetCategories()
        {
            List<Category> list = new List<Category>();
            list.Add(new Category
            {
                Name = "Layout",
                Components = new List<Component> {
                    new Component {
                        Title = "StackLayout",
                        Description = "Organização sequencial dos elementos.",
                        Page = typeof(StackLayoutPage)
                    },
                    new Component
                    {
                        Title = "Grid",
                        Description = "Organiza os elementos dentro de uma tabela.",
                        Page = typeof(GridLayoutPage)
                    },
                    new Component
                    {
                        Title = "AbsoluteLayout",
                        Description = "Liberdade total para posicionar e dimensionar os elementos na tela.",
                        Page = typeof(AbsoluteLayoutPage)
                    },
                    new Component
                    {
                        Title = "FlexLayout",
                        Description = "Organiza os elementos de forma sequencial com muitas opções de personalização.",
                        Page = typeof(FlexLayoutPage)
                    }
                }
            });

            list.Add(new Category
            {
                Name = "Componentes (Views)",
                Components = new List<Component>
                {
                    new Component
                    {
                        Title = "BoxView",
                        Description = "Um componente que cria uma caixa para ser apresentada",
                        Page = typeof(BoxViewPage)
                    },

                    new Component
                    {
                        Title = "Label",
                        Description = "Um componente que apresenta textos",
                        Page = typeof(LabelPage)
                    },
                    new Component
                    {
                        Title = "Button",
                        Description = "Um componente de click",
                        Page = typeof(ButtonPage)
                    },
                    new Component
                    {
                        Title = "Image",
                        Description = "Um componente para visualizar imagens",
                        Page = typeof(ImagePage)
                    }
                }
            });

            return list;
        }
    }
}
