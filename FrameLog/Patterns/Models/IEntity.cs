using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameLog.Patterns.Models
{
    public interface IChangeSetFactory<TChangeSet, TPrincipal>
    where TChangeSet : IChangeSet<TPrincipal>
    {
        TChangeSet ChangeSet();
        IObjectChange<TPrincipal> ObjectChange();
        IPropertyChange<TPrincipal> PropertyChange();
    }

    public interface IChangeSet<TPrincipal>
    {
        IEnumerable<IObjectChange<TPrincipal>> ObjectChanges { get; }
        void Add(IObjectChange<TPrincipal> objectChange);

        DateTime Timestamp { get; set; }
        TPrincipal Author { get; set; }
    }

    public interface IObjectChange<TPrincipal>
    {
        IChangeSet<TPrincipal> ChangeSet { get; set; }
        IEnumerable<IPropertyChange<TPrincipal>> PropertyChanges { get; }
        void Add(IPropertyChange<TPrincipal> propertyChange);

        string TypeName { get; set; }
        string ObjectReference { get; set; }
    }

    public interface IPropertyChange<TPrincipal>
    {
        IObjectChange<TPrincipal> ObjectChange { get; set; }
        string PropertyName { get; set; }
        string Value { get; set; }
        int? ValueAsInt { get; set; }
    }
}
