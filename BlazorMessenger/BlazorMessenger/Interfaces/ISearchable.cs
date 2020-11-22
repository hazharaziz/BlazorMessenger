using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface ISearchable<T> 
    {
        List<T> Search(string query);
    }
}
