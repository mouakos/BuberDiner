using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandler(IMenuRepository menuRepository)
        : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
    {
        #region Public methods declaration

        /// <inheritdoc />
        public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand command,
            CancellationToken cancellationToken)
        {
            // Create the menu
            Menu menu = Menu.Create(
                hostId: HostId.CreateUnique(),
                name: command.Name,
                description: command.Description,
                sections: command.Sections.ConvertAll(section => MenuSection.Create(
                    section.Name,
                    section.Description,
                    section.Items.ConvertAll(item => MenuItem.Create(
                        item.Name,
                        item.Description)))));

            // Save the menu
            await menuRepository.AddSync(menu);

            // Return the menu
            return menu;
        }

        #endregion
    }
}