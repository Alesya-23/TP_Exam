using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.Interfaces;
using TPExamAuthumn.ViewModel;

namespace Database.Implements
{
    public class DishStorage : IDish
    {
        public void Delete(DishBindingModel model)
        {
            using (var context = new Database())
            {
                var extrsClass = context.Dishes
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (extrsClass == null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Dishes.Remove(extrsClass);
                context.SaveChanges();
            }
        }

        public DishViewModel GetElement(DishBindingModel model)
        {
            if (model == null) return null;
            using (var context = new Database())
            {
                var component = context.Dishes
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (component == null) return null;
                return CreateModel(component);
            }
        }

        public List<DishViewModel> GetFilteredList(DishBindingModel model)
        {
            if (model == null) return null;
            using (var context = new Database())
            {
                return context.Dishes.Include(rec => rec.Products)
                    .Where(rec => model.DateFrom.HasValue
                    && model.DateTo.HasValue
                    && rec.datePrepare >= model.DateFrom
                    && rec.datePrepare <= model.DateTo)
                    .Select(CreateModel).ToList();
            }
        }

        public List<DishViewModel> GetFullList()
        {
            {
                using (var context = new Database())
                {
                    return context.Dishes
                        .Select(CreateModel)
                        .ToList();
                }
            }
        }

        public void Insert(DishBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Dish(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(DishBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dish = context.Dishes
                            .FirstOrDefault(rec => rec.Id == model.Id);
                        if (dish == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, dish, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private Dish CreateModel(DishBindingModel model, Dish Dish, Database context)
        {
            Dish.datePrepare = model.datePrepare;
            Dish.name = model.name;
            Dish.type = model.type;
            Dish.datePrepare = model.datePrepare;
            if (Dish.Id == 0) { context.Add(Dish); }
            return Dish;
        }

        private DishViewModel CreateModel(Dish Dish)
        { 
            Dictionary<int, (string,string, DateTime)> dict = new Dictionary<int, (string, string, DateTime)>();
            Dish.Products
                .ForEach(rec => dict.Add((int)rec.Id, (rec.name.ToString(), rec.placeMade, rec.dateSupplier)));
            return new DishViewModel
            {
                Id = (int)Dish.Id,
                name = Dish.name,
                type = Dish.type,
                Products = dict,
                datePrepare = Dish.datePrepare
            };
        }
    }
}
