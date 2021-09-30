using System;
using System.Collections.Generic;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.ViewModel;

namespace TPExamAuthumn.Interfaces
{
    public interface IProduct
    {
        List<ProductViewModel> GetFullList();
        List<ProductViewModel> GetFilteredList(ProductBindingModel model);
        ProductViewModel GetElement(ProductBindingModel model);
        void Insert(ProductBindingModel model);
        void Update(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
