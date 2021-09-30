using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TPExamAuthumn.BindingModel;
using TPExamAuthumn.Interfaces;
using TPExamAuthumn.ViewModel;

namespace Database.Implements
{
    public class ProductStorage : IProduct
    {
        public void Delete(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                var extrsClass = context.Products
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (extrsClass == null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Products.Remove(extrsClass);
                context.SaveChanges();
            }
        }

        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null) return null;
            using (var context = new Database())
            {
                var component = context.Products
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (component == null) return null;
                return CreateModel(component);
            }
        }

        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null) return null;
            using (var context = new Database())
            {
                return context.Products
                     .Where(rec => rec.name == model.name || rec.DishId == model.DishId)
                     .Select(CreateModel).ToList();
            }
        }

        public List<ProductViewModel> GetFullList()
        {
            {
                using (var context = new Database())
                {
                    return context.Products
                        .Select(CreateModel)
                        .ToList();
                }
            }
        }

        public void Insert(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Product(), context);
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

        public void Update(ProductBindingModel model)
        {
            using (var context = new Database())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dish = context.Products
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
        private Product CreateModel(ProductBindingModel model, Product Product, Database context)
        {
            Product.count = model.count;
            Product.name = model.name;
            Product.dateSupplier = model.dateSupplier;
            Product.placeMade = model.placeMade;
            Product.DishId = model.DishId;
            if (Product.Id == 0) { context.Add(Product); }
            return Product;
        }

        private ProductViewModel CreateModel(Product Product)
        {
            return new ProductViewModel
            {
                Id = (int)Product.Id,
                name = Product.name,
                count = Product.count,
                dateSupplier = Product.dateSupplier,
                placeMade= Product.placeMade
            };
        }
    }
}
