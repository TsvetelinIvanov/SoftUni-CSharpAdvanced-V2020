namespace _08CollectionHierarchy.Interfaces
{
    public interface IRemovable : IAddable
    {
        void Remove();

        string ReportRemovedItems();
    }
}