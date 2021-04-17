using System.Collections.Generic;

namespace _07MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral
    {
        List<IPrivate> Privates { get; }
    }
}