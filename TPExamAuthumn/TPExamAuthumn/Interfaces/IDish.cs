using System;
using System.Collections.Generic;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.ViewModel;

namespace TPExamAuthumn.Interfaces
{
    public interface IDish
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFilteredList(DishBindingModel model);
        DishViewModel GetElement(DishBindingModel model);
        void Insert(DishBindingModel model);
        void Update(DishBindingModel model);
        void Delete(DishBindingModel model);
    }
}
