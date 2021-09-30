using BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.BindingModels;
using TPExamAuthumn.Interfaces;

namespace TPExamAuthumn.BussinessLogics
{
    public class ReportLogic
    {
        private readonly IDish _DishStorage;
        public ReportLogic(IDish dish)
        {
            _DishStorage = dish;
        }

        /// <summary>
        /// Получение списка авторов определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportDishesViewModel> GetAuthors(DishBindingModel model)
        {
            var Dish = _DishStorage.GetFilteredList(model);
            var list = new List<ReportDishesViewModel>();
            foreach (var rec in Dish)
            {
                if (!(model.DateFrom < rec.datePrepare && rec.datePrepare < model.DateTo))
                    continue;
                var record = new ReportDishesViewModel
                {
                    name = rec.name,
                    datePrepare = rec.datePrepare

                };
                foreach (var auth in rec.Products)
                {
                    record.dateSupplier = auth.Value.Item3;
                    record.name = auth.Value.Item1;
                    record.placeMade = auth.Value.Item2;
                    list.Add(record);
                }
            }
            return list;
        }

        //сериализация
        public async void SaveJSONDataContractPDF(DishBindingModel model)
        {
            await Task.Run(() =>
            {
                //cоздаем объект, затем открываем поток для заиси сериал. объекта
                DataContractJsonSerializer formatter =
                new DataContractJsonSerializer(typeof(List<ReportDishesBindingModel>));
                using (FileStream fs = new FileStream(@"C:\Destctop\Report.json", FileMode.OpenOrCreate))
                {
                    formatter.WriteObject(fs, GetAuthors(model));
                }
            });
        }
    }
}
