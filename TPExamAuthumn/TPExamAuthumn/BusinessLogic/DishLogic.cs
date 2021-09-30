using System;
using System.Collections.Generic;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.Interfaces;
using TPExamAuthumn.ViewModel;

namespace TPExamAuthumn.BusinessLogic
{
    public class DishLogic
    {
        private readonly IDish _DishStorage;
        public DishLogic(IDish componentStorage)
        {
            _DishStorage = componentStorage;
        }
        public List<DishViewModel> Read(DishBindingModel model)
        {
            if (model == null)
            {
                return _DishStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DishViewModel> { _DishStorage.GetElement(model)
};
            }
            return _DishStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            var element = _DishStorage.GetElement(new DishBindingModel
            {
                name = model.name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _DishStorage.Update(model);
            }
            else
            {
                _DishStorage.Insert(model);
            }
        }
        public void Delete(DishBindingModel model)
        {
            var element = _DishStorage.GetElement(new DishBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _DishStorage.Delete(model);
        }
    }
}
   