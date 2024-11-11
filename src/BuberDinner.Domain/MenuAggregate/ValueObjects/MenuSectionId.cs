using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public class MenuSectionId(Guid value) : EntityId<Guid>(value)
    {
        #region Public methods declaration

        public static MenuSectionId Create(Guid guid)
        {
            return new MenuSectionId(guid);
        }

        public static MenuSectionId CreateUnique()
        {
            return new MenuSectionId(Guid.NewGuid());
        }

        #endregion
    }
}