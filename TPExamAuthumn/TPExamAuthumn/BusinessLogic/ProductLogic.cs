using System;
using System.Collections.Generic;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.Interfaces;
using TPExamAuthumn.ViewModel;

namespace TPExamAuthumn.BusinessLogic
{
    public class ProductLogic
    {

        private readonly IProduct _ProductStorage;
        public ProductLogic(IProduct componentStorage)
        {
            _ProductStorage = componentStorage;
        }
        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return _ProductStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { _ProductStorage.GetElement(model)
};
            }
            return _ProductStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ProductBindingModel model)
        {
            var element = _ProductStorage.GetElement(new ProductBindingModel
            {
                name = model.name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _ProductStorage.Update(model);
            }
            else
            {
                _ProductStorage.Insert(model);
            }
        }
        public void Delete(ProductBindingModel model)
        {
            var element = _ProductStorage.GetElement(new ProductBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _ProductStorage.Delete(model);
        }
    }
}