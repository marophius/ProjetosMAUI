﻿using MAUIGallery.Models;
using MAUIGallery.Views.Cells;
using MAUIGallery.Views.Components.Forms;
using MAUIGallery.Views.Components.Mains;
using MAUIGallery.Views.Layouts;
using MAUIGallery.Views.Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGallery.Repositories
{
    public partial class GroupComponentRepository : IGroupComponentRepository
    {
        private void LoadData()
        {
            _components = new List<Component>();
            _groupComponents = new List<GroupComponent>();

            LoadLayout();
            LoadControls();
            LoadVisuals();
            LoadForms();
            LoadCells();
            LoadLists();
        }

        private void LoadLayout()
        {

            var components = new List<Component> {
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
                };

            var group = new GroupComponent()
            {
                Name = "Layout"
            };

            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadControls()
        {
            var components = new List<Component>
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
            };

            var groupComponent = new GroupComponent() { Name = "Controles (Views)" };
            groupComponent.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(groupComponent);
        }

        private void LoadVisuals()
        {
            var components = new List<Component>
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
            };

            var group = new GroupComponent() { Name = "Visuais" };
            group.AddRange(components);
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadForms()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "Entry",
                    Description = "Um campo de entrada de texto",
                    Page = typeof(EntryPage)
                },
                new Component
                {
                    Title = "Checkbox",
                    Description = "Cria uma caixa de marcação",
                    Page = typeof(CheckBoxPage)
                },
                new Component
                {
                    Title = "RadioButton",
                    Description = "Cria uma marcação de escolha única",
                    Page = typeof(RadioButtonPage)
                },
                new Component
                {
                    Title = "Switch",
                    Description = "Componente de alternância de valores",
                    Page = typeof(SwitchPage)
                },
                new Component
                {
                    Title = "Stepper",
                    Description = "Cria opções de incrementar ou decrementar números",
                    Page = typeof(StepperPage)
                },
                new Component
                {
                    Title = "Slider",
                    Description = "Cria barra para incrementar ou decrementar um número.",
                    Page = typeof(SliderPage)
                },
                new Component
                {
                    Title = "Timepicker",
                    Description = "Um componente que pega o horario",
                    Page = typeof(TimePickerPage)
                },
                new Component
                {
                    Title = "DatePicker",
                    Description = "Um componente que pega a data",
                    Page = typeof(DatePickerPage)
                },
                new Component
                {
                    Title = "SearchBar",
                    Description = "Um componente para realizar pesquisa",
                    Page = typeof(SearchBarPage)
                },
                new Component
                {
                    Title = "Picker",
                    Description = "Um componente para selecionar item da lista",
                    Page = typeof(PickerPage)
                }
            };

            var group = new GroupComponent() { Name = "Formulários" };

            group.AddRange(components);

            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadCells()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "TextCell",
                    Description = "Apresenta até duas labels onde uma é destinada ao título e outra a descrição",
                    Page = typeof(TextCellPage)
                },
                new Component
                {
                    Title = "ImageCell",
                    Description = "Apresenta até duas labels onde uma é destinada ao título e outra a descrição e também imagem.",
                    Page = typeof(ImageCellPage)
                },
                new Component
                {
                    Title = "SwitchCell",
                    Description = "Apresenta uma Label em conjunto com um Switch",
                    Page = typeof(SwitchCellPage)
                },
                new Component
                {
                    Title = "EntryCell",
                    Description = "",
                    Page = typeof(EntryCellPage)
                },
                new Component
                {
                    Title = "ViewCell",
                    Description = "Permite criar célular com layout personalizado",
                    Page = typeof(ViewCellPage)
                }
            };

            var group = new GroupComponent() { Name = "Células" };

            group.AddRange(components);
            _components.AddRange(components);
            _groupComponents.Add(group);
        }

        private void LoadLists()
        {
            var components = new List<Component>
            {
                new Component
                {
                    Title = "TableView",
                    Description = "Apresenta células em linhas separadas e permite agrupar",
                    Page = typeof(TableViewPage)
                },
                new Component
                {
                    Title = "Picker",
                    Description = "Apresenta uma lista de seleção única",
                    Page = typeof(PickerListPage)
                },
                new Component
                {
                    Title = "ListView",
                    Description = "Apresenta uma lista de itens.",
                    Page = typeof(ListViewPage)
                },
                new Component
                {
                    Title = "CollectionView",
                    Description = "Apresenta uma lista de itens.",
                    Page = typeof(CollectionViewPage)
                },
                new Component
                {
                    Title = "CarouselView",
                    Description = "Apresenta uma lista de itens horizontais com navegação lateral.",
                    Page = typeof(CarouselViewPage)
                },
                new Component
                {
                    Title = "BindableLayout (Atributo)",
                    Description = "Permite ao layout apresentar listas e coleções.",
                    Page = typeof(BindableLayoutPage)
                },
                new Component
                {
                    Title = "DataTemplateSelector (Classe)",
                    Description = "Permite que os itens possam ser apresentados com layouts diferentes",
                    Page = typeof(DataTemplateSelectorPage)
                },
            };

            var group = new GroupComponent() { Name = "Listas" };

            group.AddRange(components);
            _components.AddRange(components);
            _groupComponents.Add(group);
        }
    }
}
